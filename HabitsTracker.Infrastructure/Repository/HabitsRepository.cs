using System.Globalization;
using HabitsTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace HabitsTracker.Infrastructure;

public class HabitsRepository : IHabitsRepository
{
    private readonly HabitsTrackerDbContext _habitsContext;

    public HabitsRepository(HabitsTrackerDbContext proHrContext)
    {
        _habitsContext = proHrContext;
    }

    public async Task CreateHabitAsync(Habit input)
    {
        try
        {
            await _habitsContext.Habits.AddAsync(input);
            await _habitsContext.SaveChangesAsync();


            var monthsOfYear = GetMonths(input.Id);
            foreach (var months in monthsOfYear)
            {
                foreach (var day in months.Days)
                {
                    await _habitsContext.MonthDays.AddAsync(day);
                }
            }

            await _habitsContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {

        }
    }

    public async Task<Habit?> GetHabitAsync(int id)
    {
        var habit = await _habitsContext.Habits
                                .Where(t => t.Id == id)
                                .FirstOrDefaultAsync();
        if (habit == null)
            return null;

        return habit;
    }

    public async Task<List<Habit>> GeAllHabitsAsync()
    {
        var habit = await _habitsContext.Habits.ToListAsync();

        return habit;
    }

    public async Task DeleteHabitAsync(int id)
    {
        var habit = await _habitsContext.Habits
                                            .Where(t => t.Id == id)
                                            .FirstOrDefaultAsync();
        if (habit != null)
        {
            _habitsContext.Habits.Remove(habit);
            await _habitsContext.SaveChangesAsync();
        }
    }

    public async Task UpdateHabitAsync(int id, Habit input)
    {
        var habit = await _habitsContext.Habits
                                            .Where(t => t.Id == id)
                                            .FirstOrDefaultAsync();
        if (habit != null)
        {
            habit.Id = input.Id;
            habit.Name = input.Name;
            habit.HabitType = input.HabitType;

            _habitsContext.Habits.Update(habit);
            await _habitsContext.SaveChangesAsync();
        }
    }

    public static List<MonthModel> GetMonths(int habitId)
    {
        var months = Enumerable
                      .Range(1, 12)
                      .Select(i =>
                      new MonthModel
                      {
                          Name = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                          Order = i - 1,
                          Days = PopulateListOfDaysInADay(i, habitId)
                      }).ToList();

        return months;
    }

    public static List<MonthDay> PopulateListOfDaysInADay(int monthIndex, int habitId)
    {
        int days = DateTime.DaysInMonth(DateTime.Now.Year, monthIndex);
        var dayNumberList = Enumerable.Range(1, days).ToList();

        List<MonthDay> dayList = [];

        dayNumberList.ForEach(day =>
        {
            dayList.Add(new MonthDay
            {
                HabitId = habitId,
                Value = new DateTime(DateTime.Now.Year, monthIndex, day),
                IsSelected = false,
            });
        });

        return dayList;
    }
}
