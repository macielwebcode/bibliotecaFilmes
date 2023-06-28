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
    public class FilmeAtorConfguration : IEntityTypeConfiguration<FilmeAtor>
    {
        public void Configure(EntityTypeBuilder<FilmeAtor> builder)
        {
            builder
                .ToTable("film_actor");

            builder.Property<int>("film_id").IsRequired();

            builder.Property<int>("actor_id").IsRequired();

            builder.Property<DateTime>("last_update")
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.HasKey("film_id", "actor_id");

            //colocando os dois lados do relacionamento

            builder
                .HasOne(fa => fa.Filme)
                .WithMany(f => f.Atores)
                .HasForeignKey("film_id");

            builder
                .HasOne(fa => fa.Ator)
                .WithMany(f => f.Filmografia)
                .HasForeignKey("actor_id");
            
            
        }
    }
}
