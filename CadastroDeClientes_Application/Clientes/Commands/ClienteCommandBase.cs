using CadastroDeClientes_Domain.Entities;
using MediatR;


namespace CadastroDeClientes_Application.Clientes.Commands
{
    public abstract class ClienteCommandBase : IRequest<Cliente>
    {
        public string? NomeEmpresa { get; set; }
        public PorteDaEmpresa PorteDaEmpresa { get; set; }
    }
}
