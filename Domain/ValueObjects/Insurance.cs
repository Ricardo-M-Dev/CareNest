using ValueOf;

namespace Domain.ValueObjects
{
    public class Insurance : ValueOf<(string InsuranceProvider, string InsuranceNumber), Insurance>
    {
        protected override void Validate()
        {
            var (insuranceProvider, insuranceNumber) = Value;

            if (string.IsNullOrWhiteSpace(insuranceProvider))
                throw new ArgumentException("Campo Nome do Convênio não pode ser vazio.", nameof(insuranceProvider));

            if (insuranceProvider.Length < 3)
                throw new ArgumentException("Nome do Convênio inválido.", nameof(insuranceProvider));

            if (string.IsNullOrWhiteSpace(insuranceNumber))
                throw new ArgumentException("Campo Número do Convênio não pode ser vazio.", nameof(insuranceNumber));

            if (insuranceNumber.Length < 3)
                throw new ArgumentException("Número do Convênio inválido.", nameof(insuranceNumber));
        }
    }
}
