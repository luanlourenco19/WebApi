using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using LocadoraApi.Domain;

namespace LocadoraApi.Repository
{
    public interface IClienteRepository
    {
        public IEnumerable<Cliente> UpdateCliente(Cliente cliente);
    }
}
