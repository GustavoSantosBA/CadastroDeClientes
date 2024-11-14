using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IClienteRepository ClienteRepository { get; }
        Task CommitAsync();
    }
}
