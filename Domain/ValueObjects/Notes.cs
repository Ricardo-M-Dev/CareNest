using ValueOf;

namespace Domain.ValueObjects
{
    public class Notes : ValueOf<string, Notes>
    {
        public static implicit operator string(Notes notes) => notes.Value;
        public static implicit operator Notes(string notes) => From(notes);
        protected override void Validate()
        {
            var trimmedValue = Value;

            if (string.IsNullOrWhiteSpace(trimmedValue))
                throw new ArgumentException("Campo Observações não pode ser vazio.", nameof(trimmedValue));
            if (trimmedValue.Length < 3)
                throw new ArgumentException("Observações não pode ter menos de 3 caracteres.", nameof(trimmedValue));
        }
    }
}
