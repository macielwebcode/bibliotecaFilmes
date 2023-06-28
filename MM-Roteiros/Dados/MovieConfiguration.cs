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
    public class MovieConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {

            builder
                .ToTable("film");

            builder
                .Property(a => a.Id)
                .HasColumnName("film_id");

            builder
              .Property(a => a.Titulo)
              .HasColumnName("title")
              .HasColumnType("varchar(45)")
              .IsRequired();

            builder
             .Property(a => a.Description)
             .HasColumnName("description")
             .HasColumnType("text")
             .IsRequired();

            builder
             .Property(a => a.AnoLancamento)
             .HasColumnName("release_year")
             .HasColumnType("varchar(4)")
             .IsRequired();

            builder
            .Property(a => a.Duracao)
            .HasColumnName("length")
            .HasColumnType("smallint")
            .IsRequired();

            builder
             .Property<DateTime>("last_update")
             .HasColumnType("datetime")
             .HasDefaultValueSql("getdate()")
             .IsRequired();

            builder
                .Property<byte>("language_id");

            builder
                .Property<byte?>("original_language_id");

            builder
                .HasOne(f => f.IdiomaFalado)
                .WithMany(i => i.FilmesFalados)
                .HasForeignKey("language_id");

            builder
                .HasOne(f => f.IdiomaOriginal)
                .WithMany(i => i.FilmesOriginais)
                .HasForeignKey("original_language_id");

            builder
                .Property(f => f.TextoClassificacao)
                .HasColumnName("rating")
                .HasColumnType("varchar(10)");

            builder
                .Ignore(f => f.Classificacao);
        }
    }
}
