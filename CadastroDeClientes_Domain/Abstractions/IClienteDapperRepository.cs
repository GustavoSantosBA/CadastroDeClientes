using CadastroDeClientes_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_Domain.Abstractions
{
    public interface IClienteDapperRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetClienteById(int id);
    }
}
