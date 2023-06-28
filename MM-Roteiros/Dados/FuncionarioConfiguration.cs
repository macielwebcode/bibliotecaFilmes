using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MM_Roteiros.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Roteiros.Dados
{
   
    public class FuncionarioConfiguration : PessoaConfiguration<Funcionario>
    {
       
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {

            base.Configure(builder);

            builder.ToTable("staff");

            builder
                .Property(f => f.Id)
                .HasColumnName("staff_id");

            builder
                .Property(f => f.Login)
                .HasColumnName("username")
                .HasColumnType("varchar(16)")
                .IsRequired();

            builder
                .Property(f => f.Senha)
                .HasColumnName("password")
                .HasColumnType("varchar(40)");
        }
    }
}
