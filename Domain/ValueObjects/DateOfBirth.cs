using ValueOf;

namespace Domain.ValueObjects
{
    public class DateOfBirth : ValueOf<DateTime, DateOfBirth>
    {
        public static implicit operator DateTime(DateOfBirth dateOfBirth) => dateOfBirth.Value;
        public static implicit operator DateOfBirth(DateTime dateOfBirth) => From(dateOfBirth);

        protected override void Validate()
        {
            if (Value == default)
                throw new ArgumentException("Data de Nascimento é obrigatório.", nameof(Value));
            if (Value > DateTime.Now || Value < DateTime.Now.AddYears(-120))
                throw new ArgumentException("Data de Nascimento inválida.", nameof(Value));
        }
    }
}
