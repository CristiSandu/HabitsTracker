using HabitsTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace HabitsTracker.Infrastructure;

public class HabitsTrackerDbContext : DbContext
{
    public DbSet<Habit>? Habits { get; set; }
    public DbSet<MonthDay>? MonthDays { get; set; }

    public HabitsTrackerDbContext(DbContextOptions<HabitsTrackerDbContext> options) : base(options)
    {
        SQLitePCL.Batteries_V2.Init();
        Database.Migrate();

        //Use to remove database
        //this.Database.EnsureDeletedAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "habitsTrackerDb.db");
        optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Data Source={sqlitePath}");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<EnHabitType>().HaveConversion<int>();
    }
}
