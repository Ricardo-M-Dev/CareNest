using Application.Common.Mediator;
using Domain.Entities;

namespace Application.Queries.Psychologists
{
    public class GetAllPsychologistsQuery() : IRequest<IEnumerable<Psychologist?>> { }
}
