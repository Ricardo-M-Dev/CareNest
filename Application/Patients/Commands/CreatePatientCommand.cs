using Application.Common.Mediator;

namespace Application.Patients.Commands
{
    public class CreatePatientCommand : IRequest<int>
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
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? InsuranceProvider { get; set; }
        public string? InsuranceNumber { get; set; }
        public bool IsUnderTreatment { get; set; }
    }
}
