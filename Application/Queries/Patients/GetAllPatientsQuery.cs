using Application.Common.Mediator;
using Domain.Entities;

namespace Application.Queries.Patients
{
    public record GetAllPatientsQuery() : IRequest<IEnumerable<Patient?>> { }
}
