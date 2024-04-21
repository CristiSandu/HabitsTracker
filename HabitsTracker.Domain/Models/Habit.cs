using System.ComponentModel.DataAnnotations;

namespace HabitsTracker.Domain;

public class Habit
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public EnHabitType HabitType { get; set; }

    public virtual ICollection<MonthDay> Days { get; set; }
}
