using System;
using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitsTracker.Models;
using HabitsTracker.Views;

namespace HabitsTracker.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<HabbitModel> habbits = new();

        [ObservableProperty]
        HabbitModel selectedHabbit;

        partial void OnSelectedHabbitChanged(HabbitModel value)
        {
            if (value is null)
                return;

            GoToPageCommand.Execute(nameof(MainPage));

            SelectedHabbit = null;
        }

        public HomePageViewModel()
        {
            Habbits = new ObservableCollection<HabbitModel>(Enumerable
                        .Range(1, 12)
                        .Select(i =>
                            new HabbitModel
                            {
                                Id = i,
                                Name = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                                HabbitType = i % 2 == 0 ? Helpers.EnHabbitType.Good : Helpers.EnHabbitType.Bad
                            })
                        .ToList());
        }


        [RelayCommand]
        private async Task GoToPage(string path)
        {
            await Shell.Current.GoToAsync(path);
        }

        [RelayCommand]
        private void AddHabbit(string name)
        {
            Habbits.Add(new HabbitModel
            {
                Id = 1,
                Name = name,
                HabbitType = Helpers.EnHabbitType.Good
            });
        }
    }
}

