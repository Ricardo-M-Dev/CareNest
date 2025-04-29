using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Psychologist : Person
    {
        public int PersonId { get; private set; }
        public CRP? CRP { get; private set; }
        public string? Specialization { get; private set; }
        public List<Patient>? Patients { get; private set; }
        public string? Bio { get; private set; }
        public bool IsAvailable { get; private set; }

        public Psychologist() { }

        public Psychologist(
            int personId,
            CRP crp,
            string specialization,
            string bio,
            bool isAvailable)
            : base()
        {
            PersonId = personId;
            CRP = crp;
            Specialization = specialization;
            Bio = bio;
            IsAvailable = isAvailable;
        }
    }
}
