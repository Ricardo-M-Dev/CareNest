using Application.Common.Exceptions;
using Application.Common.Factory;
using Application.Common.Interfaces;
using Application.Common.Mediator;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Commands.Psychologists
{
    public class CreatePsychologistCommandHandler : IRequestHandler<CreatePsychologistCommand, int>
    {
        private readonly IPsychologistService _psychologistService;
        private readonly IPersonService _personService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IPersonFactory _personFactory;


        public CreatePsychologistCommandHandler(IPsychologistService psychologistService, IPersonService personService, IPasswordHasher passwordHasher, IPersonFactory personFactory)
        {
            _psychologistService = psychologistService;
            _personService = personService;
            _passwordHasher = passwordHasher;
            _personFactory = personFactory;
        }

        public async Task<int> Handle(CreatePsychologistCommand command)
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

            CRP crp = command.CRP;
            string specialization = command.Specialization;
            string bio = command.Bio;
            bool isAvailable = command.IsAvailable;

            var psychologist = new Psychologist(
                personId,
                crp,
                specialization,
                bio,
                isAvailable
            );

            return await _psychologistService.SavePsychologistAsync(psychologist);
        }
    }
}
