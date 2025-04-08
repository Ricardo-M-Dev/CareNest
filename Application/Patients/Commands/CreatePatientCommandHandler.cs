using Application.Common.Mediator;

namespace Application.Patients.Commands
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        public int Handle(CreatePatientCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
