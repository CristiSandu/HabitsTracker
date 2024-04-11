
namespace HabitsTracker.Services
{
    public class LocalDatabaseService
    {
        //SQLiteAsyncConnection db;

        //async Task Init()
        //{
        //    if (db != null)
        //        return;

        //    var databasePath = Path.Combine(FileSystem.AppDataDirectory, "myDays.db");
        //    db = new SQLiteAsyncConnection(databasePath);

        //    var createTable = await db.CreateTableAsync<DayModel>();
        //    if (createTable == CreateTableResult.Created)
        //    {
        //        var days = Helpers.Constants.GetAllDays();
        //        await db.InsertAllAsync(days);
        //    }
        //}

        //public async Task AddDay(DayModel day)
        //{
        //    await Init();
        //    await db.InsertAsync(day);
        //}

        //public async Task UpdateDay(DayModel day)
        //{
        //    await Init();
        //    await db.UpdateAsync(day);
        //}

        //public async Task DeleteAllDays()
        //{
        //    await Init();
        //    await db.DeleteAllAsync<DayModel>();
        //}

        //public async Task<List<DayModel>> GetAllDaysSaved()
        //{
        //    await Init();
        //    return await db.Table<DayModel>().ToListAsync();
        //}

        //public async Task<List<DayModel>> GetAllDayFormAMonth(string month)
        //{
        //    await Init();
        //    var days = await db.QueryAsync<DayModel>(Helpers.DataBaseQuerys.GetDayInAMonth(month));
        //    return days;
        //}
    }
}
