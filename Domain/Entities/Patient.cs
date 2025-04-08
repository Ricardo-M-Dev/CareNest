using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Patient(FullName fullName, Email email, Password password, Identity identity, DateOfBirth dateOfBirth, Gender gender, Phone phone, Address address, City city, State state, ZipCode zipCode, Country country, EmergencyContact? emergencyContact, Insurance? insurance, bool isUnderTreatment) : Person
    {
        public EmergencyContact? EmergencyContact { get; private set; } = emergencyContact;
        public Insurance? Insurance { get; private set; } = insurance;
        public bool IsUnderTreatment { get; private set; } = isUnderTreatment;
    }
}
