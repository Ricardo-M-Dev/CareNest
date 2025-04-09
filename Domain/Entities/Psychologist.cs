using Domain.ValueObjects;

namespace Domain.Entities
{
    class Psychologist(FullName fullName, Email email, Password password, Identity identity, DateOfBirth dateOfBirth, Gender gender, Phone phone, Address address, City city, State state, ZipCode zipCode, Country country, bool isActive, CRP cRP, string specialization, List<Patient> patients, string bio, bool isAvailable) : Person(fullName, email, password, identity, dateOfBirth, gender, phone, address, city, state, zipCode, country, isActive)
    {
        public CRP? CRP { get; private set; } = cRP;
        public string? Specialization { get; private set; } = specialization;
        public List<Patient>? Patients { get; private set; } = patients;
        public string? Bio { get; private set; } = bio;
        public bool IsAvailable { get; private set; } = isAvailable;
    }
}
