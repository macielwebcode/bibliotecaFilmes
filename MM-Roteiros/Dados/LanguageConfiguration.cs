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
    public class LanguageConfiguration : IEntityTypeConfiguration<Idioma>
    {
        public void Configure(EntityTypeBuilder<Idioma> builder)
        {
            builder
                .ToTable("language");

            builder
                .Property(i => i.Id)
                .HasColumnName("language_id");

            builder
               .Property(i => i.Nome)
               .HasColumnName("name")
               .HasColumnType("char(20)")
               .IsRequired();

            builder
               .Property<DateTime>("last_update")
               .HasColumnType("datetime")
               .HasDefaultValueSql("getdate()")
               .IsRequired();
        }
    }
}
