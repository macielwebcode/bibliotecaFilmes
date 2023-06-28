//select * from actor

using MM_Roteiros.Dados;
using MM_Roteiros.Negocio;
using Microsoft.EntityFrameworkCore;
using MM_Roteiros.Extensions;
using System.Data.SqlClient;

using (var contexto = new MMRoteirosContexto())
{

    var categ = "Action"; //36

    var paramCateg = new SqlParameter("category_name", categ);

    var paramTotal = new SqlParameter
    {
        ParameterName = "@total_actors",
        Size = 4,
        Direction = System.Data.ParameterDirection.Output
    };

    contexto.Database
        .ExecuteSqlRaw("total_actors_from_given_category @categoria, @total OUT", paramCateg, paramTotal);

    System.Console.WriteLine($"O total de atores na categoria {categ} é de {paramTotal.Value}.");


    //contexto.LogSQLToConsole();

    //Console.WriteLine("Clientes:");
    //foreach (var cliente in contexto.Clientes)
    //{
    //    Console.WriteLine(cliente);
    //}

    //Console.WriteLine("\nFuncionários");
    //foreach (var func in contexto.Funcionarios)
    //{
    //    Console.WriteLine(func);
    //}


    //var filme = new Filme();
    //filme.Titulo = "Senhor dos Anéis";
    //filme.Duracao = 120;
    //filme.AnoLancamento = "2000";
    //filme.Classificacao = ClassificacaoIndicativa.Livre;
    //filme.IdiomaFalado = contexto.Idiomas.First();
    //contexto.Entry(filme).Property("last_update").CurrentValue = DateTime.Now;

    //contexto.Filmes.Add(filme);
    //contexto.SaveChanges();




    //var m10 = ClassificacaoIndicativa.MaioresQue10;
    //string textoLivre = "G";

    //Console.WriteLine(m10.ParaString());



    //var idiomas = contexto.Idiomas
    //        .Include(i => i.FilmesFalados);

    //foreach (var idioma in idiomas)
    //{
    //    Console.WriteLine(idioma);

    //    foreach (var filme in idioma.FilmesFalados)
    //    {
    //        Console.WriteLine(filme);
    //    }
    //    Console.WriteLine("\n");
    //}


    //contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;

    //listar os 10 atores modificados recentemente
    //var atores = contexto.Atores
    //     .OrderByDescending(a => EF.Property<DateTime>(a, "last_update"))
    //     .Take(10);

    //foreach (var item_ator in atores)
    //{
    //    Console.WriteLine(item_ator + " - " + contexto.Entry(item_ator).Property("last_update").CurrentValue);
    //}

    //var filme = contexto.Filmes
    //    .Include(f => f.Atores)
    //    .ThenInclude(fa => fa.Ator)
    //    .First();

    //foreach (var item_ator in filme.Atores)
    //{
    //    Console.WriteLine(item_ator.Ator);
    //}

    //foreach (var item in contexto.Elenco)
    //{
    //    var entidade = contexto.Entry(item);
    //    var filmId = entidade.Property("film_id").CurrentValue;
    //    var actorId = entidade.Property("actor_id").CurrentValue;
    //    var lastUpdate = entidade.Property("last_update").CurrentValue;

    //    Console.WriteLine($"Filme {filmId}, Ator {actorId}, LastUpdate{lastUpdate}");    
    //}

    //contexto.SaveChanges();

}