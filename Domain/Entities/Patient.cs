using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Patient : Person
    {
        public int PersonId { get; private set; }
        public int? PsychologistId { get; private set; }
        public EmergencyContact? EmergencyContact { get; private set; }
        public Insurance? Insurance { get; private set; }
        public bool IsUnderTreatment { get; private set; }

        public Patient() { }

        public Patient(
            int personId,
            int? psychologistId,
            EmergencyContact? emergencyContact,
            Insurance? insurance,
            bool isUnderTreatment)
            : base()
        {
            PersonId = personId;
            EmergencyContact = emergencyContact;
            Insurance = insurance;
            IsUnderTreatment = isUnderTreatment;
        }
    }
}
