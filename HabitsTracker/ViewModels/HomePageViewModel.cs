using System;
using System.Collections.ObjectModel;
using System.Globalization;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitsTracker.Domain;
using HabitsTracker.Infrastructure;
using HabitsTracker.Views;

namespace HabitsTracker.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<HabitModel> habits = new();

        [ObservableProperty]
        HabitModel selectedHabit;

        [ObservableProperty]
        string habitName;

        partial void OnSelectedHabitChanged(HabitModel value)
        {
            if (value is null)
                return;

            GoToPageCommand.Execute(nameof(MainPage));

        }

        private IHabitsRepository _habitRepository;
        private IMapper _mapper;

        public HomePageViewModel(IHabitsRepository habitsRepository, IMapper mapper)
        {
            _habitRepository = habitsRepository;
            _mapper = mapper;
            GetInitialDataCommand.Execute(null);
        }

        [RelayCommand]
        private async Task GetInitialData()
        {
            var habitsValues = await _habitRepository.GeAllHabitsAsync();
            Habits = new ObservableCollection<HabitModel>(_mapper.Map<List<Habit>, List<HabitModel>>(habitsValues));
        }

        [RelayCommand]
        private async Task GoToPage(string path)
        {
            await Shell.Current.GoToAsync(path, new Dictionary<string, object>
            {
                { "HabitId", SelectedHabit.Id },
            });

            SelectedHabit = null;

        }

        [RelayCommand]
        private async void AddHabit()
        {
            if (string.IsNullOrWhiteSpace(HabitName))
                return;

            await _habitRepository.CreateHabitAsync(new Habit { Name = HabitName, HabitType = EnHabitType.Good });
            HabitName = string.Empty;

            GetInitialDataCommand.Execute(null);
        }
    }
}

