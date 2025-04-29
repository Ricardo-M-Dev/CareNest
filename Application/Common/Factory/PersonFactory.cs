using Application.Commands.Patients;
using Application.Commands.Psychologists;
using Domain.Entities;

namespace Application.Common.Factory
{
    public class PersonFactory : IPersonFactory
    {
        public Person CreateFrom(CreatePatientCommand command, string hashedPassword)
        {
            return new Person(
                command.FullName,
                command.Email,
                hashedPassword,
                command.Identity,
                command.DateOfBirth,
                command.Gender,
                command.Phone,
                command.Address,
                command.City,
                command.State,
                command.ZipCode,
                command.Country,
                command.Role,
                command.IsActive
            );
        }

        public Person CreateFrom(CreatePsychologistCommand command, string hashedPassword)
        {
            return new Person(
                command.FullName,
                command.Email,
                hashedPassword,
                command.Identity,
                command.DateOfBirth,
                command.Gender,
                command.Phone,
                command.Address,
                command.City,
                command.State,
                command.ZipCode,
                command.Country,
                command.Role,
                command.IsActive
            );
        }
    }
}
