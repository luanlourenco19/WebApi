using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraApi.Domain
{
    public sealed class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
