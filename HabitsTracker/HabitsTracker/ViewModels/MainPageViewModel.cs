using HabitsTracker.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;

namespace HabitsTracker.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public List<MonthModel> Months { get; set; } = new List<MonthModel>();
        public ICommand SelectADay { get; protected set; }
        
        public MainPageViewModel()
        {
            GetDays();
            SelectADay = new Command<DayModel>(async (day) =>
            {
                string currentMonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).Substring(0, 3);
                int currentDay = DateTime.Now.Day;

                if (day.Day != currentDay || currentMonth != day.Month)
                {
                    await App.Current.MainPage.DisplayAlert("Wrong Date", $"You can check only curent date {currentDay} {currentMonth}" , "Ok");
                    return;
                }
                
                var monthIndex = Months.FindIndex(x => x.Abreviation == day.Month);
                var dayIndex = Months[monthIndex].Days.FindIndex(x => x.Day == day.Day);

                Months[monthIndex].Days[dayIndex].IsSelected = !day.IsSelected;
                OnPropertyChanged(nameof(Months));
            });
        }

        public void GetDays()
        {
            List<MonthModel> months = Helpers.Constants.Months;
            Months = new List<MonthModel>(months);
            OnPropertyChanged(nameof(Months));
        }
    }
}
