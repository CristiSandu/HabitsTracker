using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HabitsTracker.Infrastructure;

public class HabitsTrackerDbContextFactory : IDesignTimeDbContextFactory<HabitsTrackerDbContext>
{
    public HabitsTrackerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HabitsTrackerDbContext>();
        var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "habitsTrackerDb.db");
        optionsBuilder.UseSqlite($"Data Source={sqlitePath}");

        return new HabitsTrackerDbContext(optionsBuilder.Options);
    }

}
