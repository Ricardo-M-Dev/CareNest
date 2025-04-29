using Application.Commands.Patients;
using Application.Commands.Psychologists;
using Domain.Entities;

namespace Application.Common.Factory
{
    public interface IPersonFactory
    {
        Person CreateFrom(CreatePatientCommand command, string hashedPassword);
        Person CreateFrom(CreatePsychologistCommand command, string hashedPassword);
    }
}
