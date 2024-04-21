using HabitsTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace HabitsTracker.Infrastructure;

public class DaysRepository : IDaysRepository
{
    private readonly HabitsTrackerDbContext _habitsContext;

    public DaysRepository(HabitsTrackerDbContext habitsContext)
    {
        _habitsContext = habitsContext;
    }

    public async Task CreateDayAsync(MonthDay input)
    {
        try
        {
            await _habitsContext.MonthDays.AddAsync(input);
            await _habitsContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {

        }
    }

    public async Task<MonthDay?> GetDayAsync(int id)
    {
        var day = await _habitsContext.MonthDays
                                .Where(t => t.Id == id)
                                .FirstOrDefaultAsync();
        if (day == null)
            return null;

        return day;
    }

    public async Task<List<MonthDay>?> GeAllDaysForHabitAsync(int habitId)
    {
        var habits = await _habitsContext.Habits
                                .Include(h => h.Days)
                                .Where(h => h.Id == habitId)
                                .FirstOrDefaultAsync();

        return habits.Days.ToList();
    }

    public async Task DeleteDayAsync(int id)
    {
        var day = await _habitsContext.MonthDays
                                            .Where(t => t.Id == id)
                                            .FirstOrDefaultAsync();
        if (day != null)
        {
            _habitsContext.MonthDays.Remove(day);
            await _habitsContext.SaveChangesAsync();
        }
    }

    public async Task UpdateDayAsync(int id, MonthDay input)
    {
        var day = await _habitsContext.MonthDays
                                            .Where(t => t.Id == id)
                                            .FirstOrDefaultAsync();
        if (day != null)
        {
            day.Id = input.Id;
            day.Value = input.Value;
            day.HabitId = input.HabitId;
            day.IsSelected = input.IsSelected;

            _habitsContext.MonthDays.Update(day);
            await _habitsContext.SaveChangesAsync();
        }
    }
}
