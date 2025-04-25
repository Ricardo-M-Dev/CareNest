using Application.Common.Exceptions;
using Application.Common.Factory;
using Application.Common.Interfaces;
using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Enum;
using Domain.ValueObjects;

namespace Application.Commands.Patients
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        private readonly IPsychologistRepository _psychologistRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IPersonFactory _personFactory;
        private readonly IPasswordHasher _passwordHasher;

        public CreatePatientCommandHandler(IPsychologistRepository psychologistRepository, IPatientRepository patientRepository, IPersonFactory personFactory, IPasswordHasher passwordHasher)
        {
            _psychologistRepository = psychologistRepository;
            _patientRepository = patientRepository;
            _personFactory = personFactory;
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
            Roles role = command.Role;
            int? psychologistId = null;

            if (command.PsychologistId.HasValue && command.Role == Roles.Patient)
            {
                var psychologist = await _psychologistRepository.GetByIdAsync(command.PsychologistId.Value);

                if (psychologist == null)
                    throw new NotFoundException("Psicologo", command.PsychologistId.Value);

                psychologistId = psychologist.Id;
            }

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
                role,
                command.IsActive,
                psychologistId,
                emergencyContact,
                insurance,
                command.IsUnderTreatment
            );

            var person = _personFactory.CreateFrom(command, hashedPassword);

            return await _patientRepository.AddAsync(patient);
        }
    }
}
