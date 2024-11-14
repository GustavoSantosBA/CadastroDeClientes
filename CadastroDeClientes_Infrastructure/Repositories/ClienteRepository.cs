using CadastroDeClientes_Domain.Abstractions;
using CadastroDeClientes_Domain.Entities;
using CadastroDeClientes_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly AppDbContext db;

        public ClienteRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            if (cliente is null)
                throw new ArgumentNullException(nameof(cliente));

            await db.Clientes.AddAsync(cliente);
            return cliente;
        }

        public async Task<Cliente> DeleteCliente(int clienteId)
        {
            var cliente = await GetClienteById(clienteId);

            if (cliente is null)
                throw new InvalidOperationException("Cliente não encontrado");

            db.Clientes.Remove(cliente);
            return cliente;
        }

        public async Task<Cliente> GetClienteById(int clienteId)
        {
            var cliente = await db.Clientes.FindAsync(clienteId);

            if (cliente is null)
                throw new InvalidOperationException("Cliente não encontrado");

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var clientelist = await db.Clientes.ToListAsync();
            return clientelist ?? Enumerable.Empty<Cliente>();
        }

        public void UpdateCliente(Cliente cliente)
        {
            if (cliente is null)
                throw new ArgumentNullException(nameof(cliente));

            db.Clientes.Update(cliente);
        }
    }
}
