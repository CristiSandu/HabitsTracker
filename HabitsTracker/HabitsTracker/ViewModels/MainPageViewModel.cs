using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitsTracker.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HabitsTracker.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        List<MonthModel> months = new();

        Services.ILocalDatabaseService _localDataBase;

        public MainPageViewModel()
        {
            _localDataBase = DependencyService.Get<Services.ILocalDatabaseService>();
            GetDays();
        }

        [ICommand]
        async Task SelectADay(DayModel day)
        {
            string currentMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).Substring(0, 3);
            int currentDay = DateTime.Now.Day;
 

            var monthIndex = months.FindIndex(x => x.Abreviation == day.Month);
            var dayIndex = months[monthIndex].Days.FindIndex(x => x.Day == day.Day);

            months[monthIndex].Days[dayIndex].IsSelected = !day.IsSelected;

            await _localDataBase.UpdateDay(day);
        }

        public async Task GetDays()
        {
            List<MonthModel> month = Helpers.Constants.Months;
            List<DayModel> savedDays = await _localDataBase.GetAllDaysSaved();

            var result = savedDays.GroupBy(x => x.Month)
                  .Select(y => new MonthModel
                  {
                      Name = y.Key,
                      Days = y.ToList()
                  }).ToList();

            month.ForEach(m =>
            {
                var index = result.FindIndex(x => x.Name == m.Abreviation);
                m.Days = result[index].Days;
            });


            Months = new List<MonthModel>(month);
        }
    }
}
