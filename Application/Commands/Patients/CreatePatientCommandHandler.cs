using Application.Common.Interfaces;
using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Commands.Patients
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreatePatientCommandHandler(IPatientRepository patientRepository, IPasswordHasher passwordHasher)
        {
            _patientRepository = patientRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(CreatePatientCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var hashedPassword = _passwordHasher.Hash(command.Password);

            FullName fullName = command.FullName;
            Email email = command.Email;
            Password password = hashedPassword;
            Identity identity = command.Identity;
            DateOfBirth dob = command.DateOfBirth;
            Gender gender = command.Gender;
            Phone phone = command.Phone;
            Address address = command.Address;
            City city = command.City;
            State state = command.State;
            ZipCode zipCode = command.ZipCode;
            Country country = command.Country;

            EmergencyContact? emergencyContact = null;
            if (!string.IsNullOrWhiteSpace(command.EmergencyContactName) &&
                !string.IsNullOrWhiteSpace(command.EmergencyContactPhone))
                emergencyContact = (command.EmergencyContactName, command.EmergencyContactPhone);

            Insurance? insurance = null;
            if (!string.IsNullOrWhiteSpace(command.InsuranceProvider) &&
                !string.IsNullOrWhiteSpace(command.InsuranceNumber))
                insurance = (command.InsuranceProvider, command.InsuranceNumber);

            var patient = new Patient(
                fullName,
                email,
                password,
                identity,
                dob,
                gender,
                phone,
                address,
                city,
                state,
                zipCode,
                country,
                command.IsActive,
                emergencyContact,
                insurance,
                command.IsUnderTreatment
            );

            return await _patientRepository.AddAsync(patient);
        }
    }
}
