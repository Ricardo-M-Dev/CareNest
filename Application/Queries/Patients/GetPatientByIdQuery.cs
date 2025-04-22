using Application.Common.Mediator;
using Domain.Entities;

namespace Application.Queries.Patients
{
    public record GetPatientByIdQuery(int Id) : IRequest<Patient?> { }
}
