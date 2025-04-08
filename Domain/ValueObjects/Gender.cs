using ValueOf;

namespace Domain.ValueObjects
{
    public class Gender : ValueOf<string, Gender>
    {
        public static implicit operator string(Gender gender) => gender.Value;
        public static implicit operator Gender(string gender) => From(gender);

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Campo Gênero não pode ser vazio.", nameof(Value));
            if (Value.Length < 1)
                throw new ArgumentException("Gênero inválido.", nameof(Value));
        }
    }
}
