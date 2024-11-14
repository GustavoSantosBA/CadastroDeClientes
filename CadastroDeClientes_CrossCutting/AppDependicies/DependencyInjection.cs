using CadastroDeClientes_Application.Clientes.Commands.Validations;
using CadastroDeClientes_Domain.Abstractions;
using CadastroDeClientes_Infrastructure.Context;
using CadastroDeClientes_Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_CrossCutting.AppDependicies
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(
                      this IServiceCollection services,
                      IConfiguration configuration)
        {
            var mySqlConnection = configuration
                                  .GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                             options.UseMySql(mySqlConnection,
                             ServerVersion.AutoDetect(mySqlConnection)));

            // Registrar IDbConnection como uma instância única
            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new MySqlConnection(mySqlConnection);
                connection.Open();
                return connection;
            });

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteDapperRepository, ClienteDapperRepository>();

            var myhandlers = AppDomain.CurrentDomain.Load("CadastroDeClientes_Application");
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(myhandlers);
                cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.Load("CadastroDeClientes_Application"));

            return services;
        }
    }
}
