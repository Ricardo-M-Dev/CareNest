using ValueOf;

namespace Domain.ValueObjects
{
    public class Country : ValueOf<string, Country>
    {
        public static implicit operator string(Country country) => country.Value;
        public static implicit operator Country(string country) => From(country);
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("País é obrigatório.", nameof(Value));
            if (Value.Length < 3)
                throw new ArgumentException("País inválido.", nameof(Value));
        }
    }
}
