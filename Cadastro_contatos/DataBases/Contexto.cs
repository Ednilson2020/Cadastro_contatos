using Cadastro_contatos.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cadastro_contatos.DataBases
{
    public class Contexto: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contatos>()
                .HasIndex(p => new { p.Contato, p.Email})
                .IsUnique(true);
        }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Contatos> Contatos { get; set; }
    }
}
