using ValueOf;

namespace Domain.ValueObjects
{
    public class City : ValueOf<string, City>
    {
        public static implicit operator string(City city) => city.Value;
        public static implicit operator City(string city) => From(city);
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Campo Cidade não pode ser vazio.", nameof(Value));
            if (Value.Length < 3)
                throw new ArgumentException("Cidade inválida.", nameof(Value));
        }
    }
}
