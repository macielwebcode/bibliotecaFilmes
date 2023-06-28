using Microsoft.EntityFrameworkCore;
using MM_Roteiros.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Roteiros.Dados
{
    public class MMRoteirosContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<FilmeAtor> Elenco { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios
        {
            get; set;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=WatchMoviesMMB;Trusted_connection=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorConfiguration());

            modelBuilder.ApplyConfiguration(new MovieConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeAtorConfguration());

            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());

        }

        internal void LogSQLToConsole()
        {
            throw new NotImplementedException();
        }
    }


}
