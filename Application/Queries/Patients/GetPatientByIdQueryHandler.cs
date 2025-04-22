using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Queries.Patients
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Patient?>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByIdQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient?> Handle(GetPatientByIdQuery request)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);
            return patient;
        }
    }
}
