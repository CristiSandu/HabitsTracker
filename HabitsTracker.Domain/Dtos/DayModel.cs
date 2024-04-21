using CommunityToolkit.Mvvm.ComponentModel;

namespace HabitsTracker.Domain;

public partial class DayModel : ObservableObject
{
    public int Id { get; set; }

    public DateTime Value { get; set; }

    public int HabitId { get; set; }


    [ObservableProperty]
    private bool isSelected;
}
