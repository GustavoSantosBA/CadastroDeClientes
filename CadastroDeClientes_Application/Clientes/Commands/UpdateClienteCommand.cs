using CadastroDeClientes_Domain.Abstractions;
using CadastroDeClientes_Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_Application.Clientes.Commands
{
    public class UpdateClienteCommand : ClienteCommandBase
    {
        public int Id { get; set; }
        public class UpdateClienteCommandHandler :
                     IRequestHandler<UpdateClienteCommand, Cliente>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateClienteCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Cliente> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
            {
                var existingCliente = await _unitOfWork.ClienteRepository.GetClienteById(request.Id);

                if (existingCliente is null)
                {
                    throw new InvalidOperationException("Cliente não encontrado");
                }

                existingCliente.Update(request.NomeEmpresa, request.PorteDaEmpresa);
                _unitOfWork.ClienteRepository.UpdateCliente(existingCliente);
                await _unitOfWork.CommitAsync();

                return existingCliente;
            }
        }
    }
}
