using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Queries.Psychologists
{
    public class GetAllPsychologistsQueryHandler : IRequestHandler<GetAllPsychologistsQuery, IEnumerable<Psychologist?>>
    {
        private readonly IPsychologistRepository _psychologistRepository;

        public GetAllPsychologistsQueryHandler(IPsychologistRepository psychologistRepository)
        {
            _psychologistRepository = psychologistRepository;
        }

        public async Task<IEnumerable<Psychologist?>> Handle(GetAllPsychologistsQuery request)
        {
            return await _psychologistRepository.GetAllAsync();
        }
    }
}
