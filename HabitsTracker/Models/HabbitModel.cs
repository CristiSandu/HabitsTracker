using HabitsTracker.Helpers;

namespace HabitsTracker.Models
{
    public class HabbitModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnHabbitType HabbitType { get; set; }
    }
}

