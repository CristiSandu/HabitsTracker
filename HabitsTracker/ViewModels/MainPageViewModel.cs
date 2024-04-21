using System.Globalization;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitsTracker.Domain;
using HabitsTracker.Infrastructure;
using HabitsTracker.Models;
using HabitsTracker.Services;
using MonthModel = HabitsTracker.Models.MonthModel;

namespace HabitsTracker.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        List<MonthModel> months = new();

        [ObservableProperty]
        bool isLoading = false;

        [ObservableProperty]
        int habitId;

        private IDaysRepository _daysRepository;
        private IMapper _mapper;

        public MainPageViewModel(IDaysRepository daysRepository, IMapper mapper)
        {
            _daysRepository = daysRepository;
            _mapper = mapper;
        }

        [RelayCommand]
        private async void SelectADay(DayModel day)
        {
            var monthIndex = Months.FindIndex(x => x.MonthIndex == day.Value.Month);
            var dayIndex = Months[monthIndex].Days.FindIndex(x => x.Value == day.Value);

            Months[monthIndex].Days[dayIndex].IsSelected = !day.IsSelected;

            var selectedDay = _mapper.Map<DayModel, MonthDay>(Months[monthIndex].Days[dayIndex]);

            await _daysRepository.UpdateDayAsync(selectedDay.Id, selectedDay);
        }

        [RelayCommand]
        public async void GetDays()
        {
            IsLoading = true;

            List<MonthDay> month = await _daysRepository.GeAllDaysForHabitAsync(HabitId);

            var months = Enumerable
                 .Range(1, 12)
                 .Select(i =>
                 new MonthModel
                 {
                     Name = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                     Order = i - 1,
                     MonthIndex = i,
                     Days = _mapper.Map<List<MonthDay>, List<DayModel>>(month.Where(d => d.Value.Month == i).OrderBy(d => d.Value).ToList())
                 }).ToList();

            Months = months;

            IsLoading = false;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            HabitId = (int)query["HabitId"];
            GetDaysCommand.Execute(null);
        }
    }
}
