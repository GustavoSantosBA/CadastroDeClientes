using CadastroDeClientes_Domain.Abstractions;
using CadastroDeClientes_Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_Application.Clientes.Queries
{
    public class GetClienteByIdQuery : IRequest<Cliente>
    {
        public int Id { get; set; }

        public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
        {
            private readonly IClienteDapperRepository _clienteDapperRepository;

            public GetClienteByIdQueryHandler(IClienteDapperRepository clienteDapperRepository)
            {
                _clienteDapperRepository = clienteDapperRepository;
            }
            public async Task<Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
            {
                var cliente = await _clienteDapperRepository.GetClienteById(request.Id);
                return cliente;
            }
        }
    }
}
