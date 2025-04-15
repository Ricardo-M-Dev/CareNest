using Application.Common.Mediator;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Commands.Psychologists
{
    public class CreatePsychologistCommand : IRequest<int>
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Identity { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
        public string Country { get; set; } = default!;
        public bool IsActive { get; set; } = default!;
        public string? CRP { get; set; }
        public string? Specialization { get; set; }
        public string? Bio { get; set; }
        public bool IsAvailable { get; set; }
    }
}
