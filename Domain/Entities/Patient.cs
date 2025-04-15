using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Patient : Person
    {
        public EmergencyContact? EmergencyContact { get; private set; }
        public Insurance? Insurance { get; private set; }
        public bool IsUnderTreatment { get; private set; }

        public Patient(
            FullName fullName,
            Email email,
            Password password,
            Identity identity,
            DateOfBirth dateOfBirth,
            Gender gender,
            Phone phone,
            Address address,
            City city,
            State state,
            ZipCode zipCode,
            Country country,
            bool isActive,
            EmergencyContact? emergencyContact,
            Insurance? insurance,
            bool isUnderTreatment)
            : base(fullName, email, password, identity, dateOfBirth, gender, phone, address, city, state, zipCode, country, isActive)
        {
            EmergencyContact = emergencyContact;
            Insurance = insurance;
            IsUnderTreatment = isUnderTreatment;
        }
    }

}
