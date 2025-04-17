using Application.Common.Mediator;

namespace Application.Commands.Patients
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        public async Task<int> Handle(CreatePatientCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
