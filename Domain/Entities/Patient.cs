using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Patient : Person
    {
        public EmergencyContact? EmergencyContact { get; set; }
        public string? InsuranceProvider { get; set; }
        public string? InsuranceNumber { get; set; }
        public bool IsUnderTreatment { get; set; }
    }
}
