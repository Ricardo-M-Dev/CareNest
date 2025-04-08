using ValueOf;

namespace Domain.ValueObjects
{
    public class Address : ValueOf<string, Address>
    {
        public static implicit operator string(Address address) => address.Value;
        public static implicit operator Address(string address) => From(address);
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Campo Logradouro não pode ser vazio.", nameof(Value));
            if (Value.Length < 3)
                throw new ArgumentException("Logradouro inválido.", nameof(Value));
        }
    }
}
