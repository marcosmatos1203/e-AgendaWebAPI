using eAgenda.Dominio;
using eAgenda.Infra.Data.ORM.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace eAgenda.Infra.Data.ORM
{
    public class eAgendaDbContext : DbContext
    {        
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=eAgendaWeb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(eAgendaDbContext).Assembly);
        }
    }
}
