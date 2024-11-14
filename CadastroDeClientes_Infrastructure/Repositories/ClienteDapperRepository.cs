using CadastroDeClientes_Domain.Abstractions;
using CadastroDeClientes_Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_Infrastructure.Repositories
{
    public class ClienteDapperRepository : IClienteDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClienteDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            string query = "SELECT * FROM Clientes WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(query, new { Id = id });

        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            string query = "SELECT * FROM Clientes";
            return await _dbConnection.QueryAsync<Cliente>(query);
        }
    }
}
