using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PsychologistId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public SessionStatus Status { get; set; } = SessionStatus.Scheduled;
        public Notes? Notes { get; set; }
        public Summary? Summary { get; set; }
        public string? Location { get; set; }
        public bool IsFirstSession { get; set; }
        public LocationType? LocationType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; set; }
    }
}
