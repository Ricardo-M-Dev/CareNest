using Application.Commands.Patients;
using Domain.Entities;

namespace Application.Common.Factory
{
    public interface IPersonFactory
    {
        Person CreateFrom(CreatePatientCommand command, string hashedPassword);
    }
}
