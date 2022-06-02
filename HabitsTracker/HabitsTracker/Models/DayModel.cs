using CommunityToolkit.Mvvm.ComponentModel;
using HabitsTracker.ViewModels;

namespace HabitsTracker.Models
{
    public partial class DayModel : ObservableObject
    {
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
