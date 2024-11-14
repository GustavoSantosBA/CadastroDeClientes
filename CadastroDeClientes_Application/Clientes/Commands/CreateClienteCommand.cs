using CadastroDeClientes_Domain.Abstractions;
using CadastroDeClientes_Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_Application.Clientes.Commands
{
    public class CreateClienteCommand : ClienteCommandBase
    {
        public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Cliente>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IValidator<CreateClienteCommand> _validator;
            private readonly IMediator _mediator;
            public CreateClienteCommandHandler(IUnitOfWork unitOfWork,
                                              IValidator<CreateClienteCommand> validator,
                                              IMediator mediator)
            {
                _unitOfWork = unitOfWork;
                _validator = validator;
                _mediator = mediator;
            }
            public async Task<Cliente> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
            {
                _validator.ValidateAndThrow(request);

                var newCliente = new Cliente(request.NomeEmpresa, request.PorteDaEmpresa);

                await _unitOfWork.ClienteRepository.AddCliente(newCliente);
                await _unitOfWork.CommitAsync();

                return newCliente;
            }
        }
    }
}
