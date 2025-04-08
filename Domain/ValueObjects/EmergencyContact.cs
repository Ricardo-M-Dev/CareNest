using ValueOf;

namespace Domain.ValueObjects
{
    public class EmergencyContact : ValueOf<(string Name, string Phone), EmergencyContact>
    {
        protected override void Validate()
        {
            var (name, phone) = Value;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome do contato de emergência é obrigatório.");

            var digitsOnly = new string([.. phone.Where(char.IsDigit)]).Trim();

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Telefone do contato de emergência é obrigatório.");

            if (phone.Length < 10)
                throw new ArgumentException("Telefone do contato de emergência inválido.");
        }
    }
}
