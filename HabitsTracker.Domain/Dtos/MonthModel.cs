namespace HabitsTracker.Domain;

public class MonthModel
{
    public int Order { get; set; }

    public string Name { get; set; }

    public string Abbreviation => Name[..3];

    public List<MonthDay> Days { get; set; } = [];
}