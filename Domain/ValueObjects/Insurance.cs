using ValueOf;

namespace Domain.ValueObjects
{
    public class Insurance : ValueOf<(string InsuranceProvider, string InsuranceNumber), Insurance>
    {
        public static implicit operator (string InsuranceProvider, string InsuranceNumber)(Insurance contact) => contact.Value;

        public static implicit operator Insurance((string InsuranceProvider, string InsuranceNumber) value) => From(value);

        protected override void Validate()
        {
            var (insuranceProvider, insuranceNumber) = Value;

            if (string.IsNullOrWhiteSpace(insuranceProvider))
                throw new ArgumentException("Nome do Convênio é obrigatório.", nameof(insuranceProvider));

            if (insuranceProvider.Length < 3)
                throw new ArgumentException("Nome do Convênio inválido.", nameof(insuranceProvider));

            if (string.IsNullOrWhiteSpace(insuranceNumber))
                throw new ArgumentException("Número do Convênio é obrigatório.", nameof(insuranceNumber));

            if (insuranceNumber.Length < 3)
                throw new ArgumentException("Número do Convênio inválido.", nameof(insuranceNumber));
        }
    }
}
