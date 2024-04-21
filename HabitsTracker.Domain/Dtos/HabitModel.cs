namespace HabitsTracker.Domain;

public class HabitModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public EnHabitType HabitType { get; set; }
}
