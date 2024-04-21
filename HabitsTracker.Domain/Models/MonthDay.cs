using System.ComponentModel.DataAnnotations;

namespace HabitsTracker.Domain;

public class MonthDay
{
    [Key]
    public int Id { get; set; }

    public int HabitId { get; set; }

    public DateTime Value { get; set; }

    public bool IsSelected { get; set; }
}
