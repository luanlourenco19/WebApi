using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraApi.Domain
{
    public class Filme
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public int ClassificacaoIndicativa { get; set; }

        public Byte Lancamento { get; set; }
    }
}
