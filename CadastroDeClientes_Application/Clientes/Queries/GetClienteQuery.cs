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
    public class GetClienteQuery : IRequest<IEnumerable<Cliente>>
    {
        public class GetClientesQueryHandler : IRequestHandler<GetClienteQuery, IEnumerable<Cliente>>
        {
            private readonly IClienteDapperRepository _clienteDapperRepository;

            public GetClientesQueryHandler(IClienteDapperRepository clienteDapperRepository)
            {
                _clienteDapperRepository = clienteDapperRepository;
            }
            public async Task<IEnumerable<Cliente>> Handle(GetClienteQuery request, CancellationToken cancellationToken)
            {
                var clientes = await _clienteDapperRepository.GetClientes();
                return clientes;
            }
        }
    }
}
