using HabitsTracker.Domain;
using AutoMapper;
namespace HabitsTracker.Infrastructure;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Habit, HabitModel>();
        CreateMap<MonthDay, DayModel>().ReverseMap();
    }
}
