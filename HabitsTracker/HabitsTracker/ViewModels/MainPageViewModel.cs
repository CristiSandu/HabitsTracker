using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitsTracker.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HabitsTracker.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        List<MonthModel> months = new();

        public MainPageViewModel()
        {
            GetDays();
        }

        public void GetDays()
        {
            List<MonthModel> month = Helpers.Constants.Months;
            months = new List<MonthModel>(month);
        }

        [ICommand]
        async Task SelectADay(DayModel day)
        {
            string currentMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).Substring(0, 3);
            int currentDay = DateTime.Now.Day;

            if (day.Day != currentDay || currentMonth != day.Month)
            {
                await Application.Current.MainPage.DisplayAlert("Wrong Date", $"You can check only curent date {currentDay} {currentMonth}", "Ok");
                return;
            }

            var monthIndex = months.FindIndex(x => x.Abreviation == day.Month);
            var dayIndex = months[monthIndex].Days.FindIndex(x => x.Day == day.Day);

            months[monthIndex].Days[dayIndex].IsSelected = !day.IsSelected;
        }
    }
}
