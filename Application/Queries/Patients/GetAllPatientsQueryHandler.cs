using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Queries.Patients
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, IEnumerable<Patient?>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllPatientsQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient?>> Handle(GetAllPatientsQuery request)
        {
            return await _patientRepository.GetAllAsync();
        }
    }
}
