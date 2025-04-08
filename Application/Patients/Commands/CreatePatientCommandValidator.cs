using FluentValidation;
using Domain.ValueObjects;

namespace Application.Patients.Commands
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatório.")
                .MinimumLength(6).WithMessage("Senha deve ter pelo menos 6 caracteres.");

            RuleFor(x => x.Identity)
                .NotEmpty().WithMessage("CPF/CNPJ é obrigatório.")
                .Must(BeValidCpfOrCnpj).WithMessage("CPF/CNPJ deve ter pelo menos 11 caracteres.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Data de nascimento é obrigatório.")
                .GreaterThan(DateTime.Now).WithMessage("Data de nascimento deve ser menor que a data atual.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Genero é obrigatório.")
                .MinimumLength(1).WithMessage("Genero inválido.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .MinimumLength(10).WithMessage("Telefone deve ter pelo menos 11 caracteres.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Endereço é obrigatório.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Cidade é obrigatório.");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("Estado é obrigatório.");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("CEP é obrigatório.")
                .MinimumLength(8).WithMessage("CEP deve ter pelo menos 8 caracteres.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Pais é obrigatório.");

            When(x => !string.IsNullOrEmpty(x.EmergencyContactPhone), () =>
            {
                RuleFor(x => x.EmergencyContactName).NotEmpty();
            });

            When(x => !string.IsNullOrEmpty(x.InsuranceProvider), () =>
            {
                RuleFor(x => x.InsuranceNumber).NotEmpty();
            });
        }

        private bool BeValidCpfOrCnpj(string value)
        {
            try
            {
                var identity = Identity.From(value);
                return identity.IsCpf || identity.IsCnpj;
            }
            catch
            {
                return false;
            }
        }
    }
}
