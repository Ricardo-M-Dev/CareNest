using Application.Common.Interfaces;
using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Enum;
using Domain.ValueObjects;

namespace Application.Commands.Psychologists
{
    public class CreatePsychologistCommandHandler : IRequestHandler<CreatePsychologistCommand, int>
    {
        private readonly IPsychologistRepository _psychologistRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreatePsychologistCommandHandler(IPsychologistRepository psychologistRepository, IPasswordHasher passwordHasher)
        {
            _psychologistRepository = psychologistRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(CreatePsychologistCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var hashedPassword = _passwordHasher.Hash(command.Password);

            FullName fullName = command.FullName;
            Email email = command.Email;
            Password password = hashedPassword;
            Identity identity = command.Identity;
            DateOfBirth dateOfBirth = command.DateOfBirth;
            Gender gender = command.Gender;
            Phone phone = command.Phone;
            Address address = command.Address;
            City city = command.City;
            State state = command.State;
            ZipCode zipCode = command.ZipCode;
            Country country = command.Country;
            CRP crp = command.CRP;
            string specialization = command.Specialization;
            Roles role = command.Role;
            string bio = command.Bio;
            bool isAvailable = command.IsAvailable;
            bool isActive = command.IsActive;

            var psychologist = new Psychologist(
                fullName,
                email,
                password,
                identity,
                dateOfBirth,
                gender,
                phone,
                address,
                city,
                state,
                zipCode,
                country,
                isActive,
                crp,
                specialization,
                role,
                bio,
                isAvailable
            );

            return await _psychologistRepository.AddAsync(psychologist);
        }
    }
}
