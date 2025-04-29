using Application.Common.Exceptions;
using Application.Common.Factory;
using Application.Common.Interfaces;
using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Enum;
using Domain.ValueObjects;

namespace Application.Commands.Patients
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        private readonly IPsychologistRepository _psychologistRepository;
        private readonly IPersonService _personService;
        private readonly IPatientRepository _patientRepository;
        private readonly IPersonFactory _personFactory;
        private readonly IPasswordHasher _passwordHasher;

        public CreatePatientCommandHandler(IPsychologistRepository psychologistRepository, IPersonService personService, IPatientRepository patientRepository, IPersonFactory personFactory, IPasswordHasher passwordHasher)
        {
            _psychologistRepository = psychologistRepository;
            _personService = personService;
            _patientRepository = patientRepository;
            _personFactory = personFactory;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(CreatePatientCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var hashedPassword = _passwordHasher.Hash(command.Password);

            var person = _personFactory.CreateFrom(command, hashedPassword);

            if (person == null)
                throw new BadRequestException("Não foi possível mapear a entidade Pessoa.");

            int personId = await _personService.SavePersonAsync(person);

            if (personId == 0)
                throw new BadRequestException("Não foi possível salvar a entidade Pessoa.");

            int? psychologistId = null;
            bool isUnderTreatment = command.IsUnderTreatment;

            if (command.PsychologistId.HasValue && command.Role == Roles.Patient)
            {
                var psychologist = await _psychologistRepository.GetByIdAsync(command.PsychologistId.Value);

                if (psychologist == null)
                    throw new NotFoundException("Psicologo", command.PsychologistId.Value);

                psychologistId = psychologist.Id;
                isUnderTreatment = true;
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
                personId,
                psychologistId,
                emergencyContact,
                insurance,
                isUnderTreatment
            );

            return await _patientRepository.AddAsync(patient);
        }
    }
}
