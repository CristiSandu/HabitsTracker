using CommunityToolkit.Mvvm.ComponentModel;
using HabitsTracker.ViewModels;
using SQLite;

namespace HabitsTracker.Models
{
    public partial class DayModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty]
        private bool isSelected;

        public int Day { get; set; }

        public string Month { get; set; }

        public override string ToString()
        {
            return $"{Day}-{Month}-{isSelected}";
        }
    }
}
