using ValueOf;

namespace Domain.ValueObjects
{
    public class Phone : ValueOf<string, Phone>
    {
        public static implicit operator string(Phone phone) => phone.Value;
        public static implicit operator Phone(string phone) => From(phone);
        protected override void Validate()
        {
            var digitsOnly = new string([.. Value.Where(char.IsDigit)]).Trim();

            if (string.IsNullOrWhiteSpace(digitsOnly))
                throw new ArgumentException("Campo Telefone não pode ser vazio.", nameof(digitsOnly));
            if (digitsOnly.Length < 10)
                throw new ArgumentException("Telefone inválido.", nameof(digitsOnly));
        }
    }
}
