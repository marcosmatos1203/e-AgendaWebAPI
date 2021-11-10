using eAgenda.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Infra.Data.ORM.Configuration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TBTarefa");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titulo)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder.Property(t => t.Prioridade)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(t => t.DataCriacao)
               .HasColumnType("date")
               .IsRequired();

            builder.Property(t => t.Percentual);

            builder.Property(t => t.DataConclusao)
               .HasColumnType("date");            
        }
    }
}