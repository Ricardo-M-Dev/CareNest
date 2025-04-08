using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int PsychologistId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsRecurring { get; set; } = true;
        public DateTime NonRecurringDate { get; set; } = DateTime.UtcNow;
        public Notes? Notes { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int MaxSessionsPerDay { get; set; } = 5;
        public List<LocationType>? LocationType { get; set; }
    }
}
