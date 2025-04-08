using ValueOf;

namespace Domain.ValueObjects
{
    public class CRP : ValueOf<string, CRP>
    {
        public static implicit operator string(CRP crp) => crp.Value;
        public static implicit operator CRP(string crp) => From(crp);
        protected override void Validate()
        {
            var digitsOnly = new string([.. Value.Where(char.IsDigit)]).Trim();

            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Campo CRP não pode ser vazio.", nameof(Value));
            if (Value.Length < 7)
                throw new ArgumentException("CRP inválido.", nameof(Value));
        }
    }
}
