using Application.Common.Mediator;

namespace Application.Commands.Psychologists
{
    public class CreatePsychologistCommandHandler : IRequestHandler<CreatePsychologistCommand, int>
    {
        public async Task<int> Handle(CreatePsychologistCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
