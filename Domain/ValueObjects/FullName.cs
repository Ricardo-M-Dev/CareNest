using ValueOf;

namespace Domain.ValueObjects
{
    public class FullName : ValueOf<string, FullName>
    {
        public static implicit operator string(FullName fullName) => fullName.Value;
        public static implicit operator FullName(string fullName) => From(fullName);
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Nome é obrigatório.", nameof(Value));
            if (Value.Length < 3)
                throw new ArgumentException("Nome deve ter pelo menos 3 caracteres.", nameof(Value));
        }
    }
}
