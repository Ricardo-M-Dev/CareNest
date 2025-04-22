using Application.Common.Mediator;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Queries.Psychologists
{
    public class GetPsychologistByIdQueryHandler : IRequestHandler<GetPsychologistByIdQuery, Psychologist?>
    {
        private readonly IPsychologistRepository _psychologistRepository;

        public GetPsychologistByIdQueryHandler(IPsychologistRepository psychologistRepository)
        {
            _psychologistRepository = psychologistRepository;
        }

        public async Task<Psychologist?> Handle(GetPsychologistByIdQuery request)
        {
            var psychologist = await _psychologistRepository.GetByIdAsync(request.Id);
            return psychologist;
        }
    }
}
