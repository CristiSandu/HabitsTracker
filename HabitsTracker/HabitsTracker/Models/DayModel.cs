using HabitsTracker.ViewModels;

namespace HabitsTracker.Models
{
    public class DayModel : BaseViewModel
    {
        private bool isSelected;

        public int Day { get; set; }
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        public string Month { get; set; }

        public override string ToString()
        {
            return $"{Day}-{Month}-{IsSelected}";
        }
    }
}
