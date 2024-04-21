using HabitsTracker.Domain;

namespace HabitsTracker.Infrastructure
{
    public interface IDaysRepository
    {
        Task CreateDayAsync(MonthDay input);
        Task DeleteDayAsync(int id);
        Task<List<MonthDay>?> GeAllDaysForHabitAsync(int habitId);
        Task<MonthDay?> GetDayAsync(int id);
        Task UpdateDayAsync(int id, MonthDay input);
    }
}