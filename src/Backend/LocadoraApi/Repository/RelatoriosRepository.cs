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
    public sealed class RelatoriosRepository : IRelatoriosRepository
    {
        private readonly string _connectionString;

        public RelatoriosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataServer");
        }



        public IEnumerable<Filme> GetTopFilmesAlugados()
        {
            using var connection = new SqlConnection(_connectionString);

            var data = connection.Query<Filme>("select * from filme where id in(select top 5 Id_Filme from Locacao where DataLocacao BETWEEN DATEADD(Year,-1,GETDATE()) AND GetDATE() group by Id_Filme having COUNT(Id_Filme) > 0)");

            return data;
        }

        public IEnumerable<Filme> GetTopFilmesMenosAlugados()
        {
            using var connection = new SqlConnection(_connectionString);

            var data = connection.Query<Filme>("select * from filme where id in(select top 3 Id_Filme from Locacao where DataLocacao BETWEEN DATEADD(Year,-1,GETDATE()) AND GetDATE() group by Id_Filme having COUNT(Id_Filme) > 0 order by Id_Filme desc)");

            return data;
        }


        public IEnumerable<Cliente> GetSegundoClienteMaisAlugou()
        {
            using var connection = new SqlConnection(_connectionString);

            var data = connection.Query<Cliente>("select * from Cliente where id in( select top 2  Id_Cliente from Locacao where DataLocacao BETWEEN DATEADD(Year,-1,GETDATE()) AND GetDATE() group by Id_Cliente having COUNT(Id_Cliente) > 0 )");

            return data;
        }
    }
}

