using ValueOf;

namespace Domain.ValueObjects
{
    public class Summary : ValueOf<string, Summary>
    {
        public static implicit operator string(Summary summary) => summary.Value;
        public static implicit operator Summary(string summary) => From(summary);

        protected override void Validate()
        {
            var trimmedValue = Value.Trim();

            if (string.IsNullOrWhiteSpace(trimmedValue))
                throw new ArgumentException("Resumo é obrigatório.", nameof(trimmedValue));
            if (trimmedValue.Length < 10)
                throw new ArgumentException("Resumo não pode ter menos de 10 caracteres.", nameof(trimmedValue));
        }
    }
}
