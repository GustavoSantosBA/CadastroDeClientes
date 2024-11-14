using CadastroDeClientes_Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes_Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string NomeEmpresa { get; set; }
        public PorteDaEmpresa PorteDaEmpresa { get; set; }

        public Cliente() { }
        public Cliente(string nomeEmpresa, PorteDaEmpresa porteDaEmpresa)
        {
            ValidateDomain(nomeEmpresa, porteDaEmpresa);
        }
        public void Update(string nomeEmpresa, PorteDaEmpresa porteDaEmpresa)
        {
            ValidateDomain(nomeEmpresa, porteDaEmpresa);
        }
        private void ValidateDomain(string nomeEmpresa, PorteDaEmpresa porteDaEmpresa)
        {
            DomainValidation.When(string.IsNullOrEmpty(nomeEmpresa),
                "Nome Inválido. Nome da Empresa é obrigatório");

            DomainValidation.When(nomeEmpresa.Length < 3,
                "Nome Inválido, nome com menos de 2 caracteres");

            NomeEmpresa = nomeEmpresa;
            PorteDaEmpresa = porteDaEmpresa;
        }
    }

    public enum PorteDaEmpresa
    {
        Pequena,
        Media,
        Grande
    }




}
