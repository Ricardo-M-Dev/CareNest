using ValueOf;

namespace Domain.ValueObjects
{
    public class Email : ValueOf<string, Email>
    {
        public static implicit operator string(Email email) => email.Value;
        public static implicit operator Email(string email) => From(email);
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Campo Email não pode ser vazio.", nameof(Value));
            if (!Value.Contains('@') || !Value.Contains('.'))
                throw new ArgumentException("Email não possui o formato correto.", nameof(Value));
        }
    }
}
