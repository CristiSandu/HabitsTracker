using HabitsTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabitsTracker.Services
{
    public interface ILocalDatabaseService
    {
        Task AddDay(DayModel day);
        Task DeleteAllDays();
        Task<List<DayModel>> GetAllDayFormAMonth(string month);
        Task<List<DayModel>> GetAllDaysSaved();
        Task UpdateDay(DayModel day);
    }
}