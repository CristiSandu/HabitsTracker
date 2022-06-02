using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsTracker.Helpers
{
    public static class DataBaseQuerys
    {
        public static string GetDayInAMonth(string month)
        {
            return $"SELECT * FROM DayModel WHERE Month = '{month}'";
        }
    }
}
