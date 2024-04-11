using HabitsTracker.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitsTracker.Helpers
{
    public static class Constants
    {
        public static List<MonthModel> Months = Enumerable
            .Range(1, 12)
            .Select(i =>
            new MonthModel
            {
                Name = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                Order = i - 1,
                Days = PopulateListOfDaysInADay(DateTimeFormatInfo.CurrentInfo.GetMonthName(i), i)
            }
            ).ToList();

        public static List<DayModel> PopulateListOfDaysInADay(string monthName, int monthIndex)
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, monthIndex);
            var numberList = Enumerable.Range(1, days).ToList();

            List<DayModel> dayList = new();

            numberList.ForEach(day =>
            {
                dayList.Add(new DayModel
                {
                    Month = monthName.Substring(0, 3),
                    Day = day,
                    IsSelected = false,
                });
            });

            return dayList;
        }


        public static List<DayModel> GetAllDays()
        {
            List<DayModel> daysList = new();
            Months.ForEach(month =>
            {
                daysList.AddRange(month.Days);
            });

            return daysList;
        }
    }
}
