using LocadoraApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraApi.Repository
{
    public interface IRelatoriosRepository
    {
        public IEnumerable<Filme> GetTopFilmesAlugados();

        public IEnumerable<Filme> GetTopFilmesMenosAlugados();
        
        public IEnumerable<Cliente> GetSegundoClienteMaisAlugou(); 

    }
}
