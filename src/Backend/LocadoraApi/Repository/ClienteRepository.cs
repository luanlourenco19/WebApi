using Dapper;
using LocadoraApi.Data;
using LocadoraApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraApi.Repository
{
    public sealed class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataServer");
        }

        public IEnumerable<Cliente> UpdateCliente(Cliente cliente)
        {
            using var connection = new SqlConnection(_connectionString);
            
            var data = connection.Query<Cliente>("Update Cliente set CPF = " + cliente.CPF
                    + "Where Id = " + cliente.Id);
                


            return data;

        }
        }
    }
}
