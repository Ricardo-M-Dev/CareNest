using Application.Common.Mediator;
using Domain.Entities;

namespace Application.Queries.Psychologists
{
    public record GetPsychologistByIdQuery(int Id) : IRequest<Psychologist?> { }
}
