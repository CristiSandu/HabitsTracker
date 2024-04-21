using HabitsTracker.Domain;

namespace HabitsTracker.Infrastructure
{
    public interface IHabitsRepository
    {
        Task CreateHabitAsync(Habit input);
        Task DeleteHabitAsync(int id);
        Task<List<Habit>> GeAllHabitsAsync();
        Task<Habit?> GetHabitAsync(int id);
        Task UpdateHabitAsync(int id, Habit input);
    }
}