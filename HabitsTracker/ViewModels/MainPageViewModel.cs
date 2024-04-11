using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitsTracker.Models;
using HabitsTracker.Services;
using System.Globalization;

namespace HabitsTracker.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<MonthModel> months = new();

        [ObservableProperty]
        bool isLoading = false;

        LocalDatabaseService _localDataBase;

        public MainPageViewModel(LocalDatabaseService localDatabaseService)
        {
            _localDataBase = localDatabaseService;
            GetDaysCommand.Execute(null);
        }

        [RelayCommand]
        private void SelectADay(DayModel day)
        {
            //string currentMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).Substring(0, 3);
            //int currentDay = DateTime.Now.Day;


            var monthIndex = Months.FindIndex(x => x.Abbreviation == day.Month);
            var dayIndex = Months[monthIndex].Days.FindIndex(x => x.Day == day.Day);

            Months[monthIndex].Days[dayIndex].IsSelected = !day.IsSelected;

            //await _localDataBase.UpdateDay(day);
        }

        [RelayCommand]
        public void GetDays()
        {
            IsLoading = true;
            List<MonthModel> month = Helpers.Constants.GetMonths();
            List<DayModel> savedDays = new();
            //List<DayModel> savedDays = await _localDataBase.GetAllDaysSaved();

            //var result = savedDays.GroupBy(x => x.Month)
            //      .Select(y => new MonthModel
            //      {
            //          Name = y.Key,
            //          Days = y.ToList()
            //      }).ToList();

            //month.ForEach(m =>
            //{
            //    var index = result.FindIndex(x => x.Name == m.Abbreviation);
            //    m.Days = result[index].Days;
            //});


            Months = new List<MonthModel>(month);
            IsLoading = false;
        }

    }
}
