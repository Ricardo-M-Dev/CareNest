using ValueOf;

namespace Domain.ValueObjects
{
    public class Insurance : ValueOf<(string InsuranceProvider, string InsuranceNumber), Insurance>
    {
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
