using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HabitsTracker.Domain;

namespace HabitsTracker.Models
{
    public class MonthModel
    {
        public int Order { get; set; }

        public string Name { get; set; }

        public string Abbreviation => Name.Substring(0, 3);

        public int MonthIndex { get; set; }

        public List<DayModel> Days { get; set; } = new List<DayModel>();
    }
}
