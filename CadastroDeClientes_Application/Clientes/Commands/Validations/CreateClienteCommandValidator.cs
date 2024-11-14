using FluentValidation;
namespace CadastroDeClientes_Application.Clientes.Commands.Validations
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(c => c.NomeEmpresa)
              .NotEmpty().WithMessage("Insira o Nome da Empresa")
              .Length(4, 100).WithMessage("O Nome da Empresa deve ter entre 4 e 150 caracteres");
        }
    }
}
