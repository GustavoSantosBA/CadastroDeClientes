using CadastroDeClientes_Domain.Abstractions;
using CadastroDeClientes_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IClienteRepository? _clienteRepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepository = _clienteRepository ??
                    new ClienteRepository(_context);
            }
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
