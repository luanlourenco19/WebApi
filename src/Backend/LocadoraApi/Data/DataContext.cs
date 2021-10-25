using LocadoraApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraApi.Data
{
    public class DataContext : DbContext
    {
        //public DataContext(DbContextOptions<DataContext> options)
        //    : base(options)
        //{
        //}
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>()
                        .ToTable("Filme");

            modelBuilder.Entity<Cliente>()
                        .ToTable("Cliente");

            modelBuilder.Entity<Locacao>()
                        .ToTable("Locacao");
        }
    }
}
