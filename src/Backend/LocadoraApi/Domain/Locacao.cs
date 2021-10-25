using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraApi.Domain
{
    public class Locacao
    {
        public int Id { get; set; }

        public int Id_Cliente { get; set; }

        public int Id_Filme { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime? DataDevolucao { get; set; }
    }
}
