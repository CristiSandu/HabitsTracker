using System.Collections.Generic;

namespace HabitsTracker.Models
{
    public class MonthModel
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public string Abreviation => Name.Substring(0, 3);
        public List<DayModel> Days { get; set; } = new List<DayModel>();
    }
}
