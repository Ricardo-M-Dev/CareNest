using ValueOf;

namespace Domain.ValueObjects
{
    public class Password : ValueOf<string, Password>
    {
        public static implicit operator string(Password password) => password.Value;
        public static implicit operator Password(string password) => From(password);
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Senha é obrigatório.", nameof(Value));
            if (Value.Length < 6)
                throw new ArgumentException("Senha deve ter pelo menos 6 caracteres.", nameof(Value));
            if (!Value.Any(char.IsDigit))
                throw new ArgumentException("Senha deve conter pelo menos um número.", nameof(Value));
            if (!Value.Any(char.IsUpper))
                throw new ArgumentException("Senha deve conter pelo menos uma letra maiúscula.", nameof(Value));
            if (!Value.Any(char.IsLower))
                throw new ArgumentException("Senha deve conter pelo menos uma letra minúscula.", nameof(Value));
            if (!Value.Any(char.IsSymbol) && !Value.Any(char.IsPunctuation))
                throw new ArgumentException("Senha deve conter pelo menos um caractere especial.", nameof(Value));
        }
    }
}
