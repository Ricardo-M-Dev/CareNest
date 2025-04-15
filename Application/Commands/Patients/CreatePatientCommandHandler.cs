using Application.Common.Mediator;

namespace Application.Commands.Patients
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        public int Handle(CreatePatientCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
