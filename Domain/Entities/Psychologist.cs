using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Psychologist : Person
    {
        public CRP? CRP { get; private set; }
        public string? Specialization { get; private set; }
        public List<Patient>? Patients { get; private set; }
        public string? Bio { get; private set; }
        public bool IsAvailable { get; private set; }

        public Psychologist() { }

        public Psychologist(
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
            CRP crp,
            string specialization,
            List<Patient>? patients,
            string bio,
            bool isAvailable)
            : base(fullName, email, password, identity, dateOfBirth, gender, phone, address, city, state, zipCode, country, isActive)
        {
            CRP = crp;
            Specialization = specialization;
            Patients = patients;
            Bio = bio;
            IsAvailable = isAvailable;
        }
    }
}
