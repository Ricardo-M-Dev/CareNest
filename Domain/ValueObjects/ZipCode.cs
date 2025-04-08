using ValueOf;

namespace Domain.ValueObjects
{
    public class ZipCode : ValueOf<string, ZipCode>
    {
        public static implicit operator string(ZipCode zipCode) => zipCode.Value;
        public static implicit operator ZipCode(string zipCode) => From(zipCode);
        protected override void Validate()
        {
            var digitsOnly = new string([.. Value.Where(char.IsDigit)]).Trim();

            if (string.IsNullOrWhiteSpace(digitsOnly))
                throw new ArgumentException("Campo CEP não pode ser vazio.", nameof(digitsOnly));
            if (digitsOnly.Length < 8)
                throw new ArgumentException("CEP inválido.", nameof(digitsOnly));
        }
    }
}
