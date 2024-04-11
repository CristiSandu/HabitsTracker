using CommunityToolkit.Mvvm.ComponentModel;

namespace HabitsTracker.Models
{
    public partial class DayModel : ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty]
        private bool isSelected;

        public int Day { get; set; }

        public string Month { get; set; }

        public override string ToString()
        {
            return $"{Day}-{Month}-{IsSelected}";
        }
    }
}
