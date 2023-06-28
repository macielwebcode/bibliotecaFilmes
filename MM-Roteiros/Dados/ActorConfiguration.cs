using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MM_Roteiros.Negocio;

namespace MM_Roteiros.Dados
{
    public class ActorConfiguration : IEntityTypeConfiguration<Ator>
    {
       
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder
                .ToTable("actor");

            builder
                .Property(a => a.Id)
                .HasColumnName("actor_id");

            builder
                .Property(a => a.PrimeiroNome)
                .HasColumnName("first_name")
                .HasColumnType("varchar(45)")
                .IsRequired();


            builder
               .Property(a => a.UltimoNome)
               .HasColumnName("last_name")
               .HasColumnType("varchar(45)")
               .IsRequired();

            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder
                .HasIndex(a => a.UltimoNome);

                
            builder
                .HasAlternateKey(a => new { a.PrimeiroNome, a.UltimoNome });
        }
    }
}
