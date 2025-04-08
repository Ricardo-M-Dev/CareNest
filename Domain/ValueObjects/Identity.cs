using ValueOf;

namespace Domain.ValueObjects
{
    public class Identity : ValueOf<string, Identity>
    {
        protected override void Validate()
        {
            var digitsOnly = new string([.. Value.Where(char.IsDigit)]).Trim();

            if (digitsOnly.Length == 11)
            {
                if (!IsValidCpf(digitsOnly))
                    throw new ArgumentException("CPF inválido");
            }
            else if (digitsOnly.Length == 14)
            {
                if (!IsValidCnpj(digitsOnly))
                    throw new ArgumentException("CNPJ inválido.");
            }
            else
                throw new ArgumentException("Campo Identidade precisa ter 11 (CPF) ou 14 (CNPJ) caracteres.");
        }

        private static bool IsValidCpf(string cpf)
        {
            if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
                return false;

            int[] mult1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] mult2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

            var tempCpf = cpf[..9];
            var sum = tempCpf.Select((t, i) => int.Parse(t.ToString()) * mult1[i]).Sum();
            var remainder = sum % 11;
            var firstDigit = remainder < 2 ? 0 : 11 - remainder;

            tempCpf += firstDigit;
            sum = tempCpf.Select((t, i) => int.Parse(t.ToString()) * mult2[i]).Sum();
            remainder = sum % 11;
            var secondDigit = remainder < 2 ? 0 : 11 - remainder;

            return cpf.EndsWith($"{firstDigit}{secondDigit}");
        }

        private static bool IsValidCnpj(string cnpj)
        {
            if (cnpj.Length != 14 || cnpj.All(c => c == cnpj[0]))
                return false;

            int[] mult1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] mult2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

            var tempCnpj = cnpj[..12];
            var sum = tempCnpj.Select((t, i) => int.Parse(t.ToString()) * mult1[i]).Sum();
            var remainder = sum % 11;
            var firstDigit = remainder < 2 ? 0 : 11 - remainder;

            tempCnpj += firstDigit;
            sum = tempCnpj.Select((t, i) => int.Parse(t.ToString()) * mult2[i]).Sum();
            remainder = sum % 11;
            var secondDigit = remainder < 2 ? 0 : 11 - remainder;

            return cnpj.EndsWith($"{firstDigit}{secondDigit}");
        }

        public bool IsCpf => new string([.. Value.Where(char.IsDigit)]).Length == 11;
        public bool IsCnpj => new string([.. Value.Where(char.IsDigit)]).Length == 14;
    }
}
