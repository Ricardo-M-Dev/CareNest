using Domain.ValueObjects;

namespace Domain.Entities
{
    class Psychologist : Person
    {
        public CRP? CRP { get; set; }
        public string? Specialization { get; set; }
        public List<Patient>? Patients { get; set; } = [];
        public string? Bio { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
