using api.core.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
public class DatabaseContext : DbContext
{
    public DbSet<MaterialModel>? Material { get; set; }
    public DbSet<QuizzModel>? Quiz { get; set; }
    public DbSet<StudentModel>? Student { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31)); // Especifique a versão correta do servidor MySQL aqui

        optionsBuilder.UseMySql("Server=database;Port=3306;Database=tarefas;User=root;Password=tarefas;",
            serverVersion,
            options => options.EnableRetryOnFailure()
        );

    }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<MaterialModel>().HasData(
    //         new
    //         {

    //             MaterialType = 1,
    //             Link = 'assets/1000-frases-mais-usadas-no-ingles.pdf',
    //             Title = '1000 Frases Mais Usadas No Ingles',
    //             Image = 'https://www.baixelivros.com.br/media/2022/02/frases-ingles.jpg'
    //         }
    //         ,
    //         new
    //         {
    //             MaterialType = 1,
    //             Link = 'assets/ingles-aplicado-a-eventos.pdf',
    //             Title = 'Ingles Aplicado A Eventos',
    //             Image = 'https://www.baixelivros.com.br/media/2022/02/ingles-aplicado-eventos.jpg'
    //         }
    //     );
    //     modelBuilder.Entity<QuizzModel>().HasData(
    //         new QuizzModel
    //         {
    //             QuizzTitle = 'To Be',
    //             Correct = 1,
    //             Questions = 'Qual é a forma correta do verbo "to be" na terceira pessoa do singular no presente simples?',
    //             FirstOption = 'is',
    //             SecondOption = 'are',
    //             ThirdOption = 'am',
    //         },
    //         new QuizzModel
    //         {
    //             QuizzTitle = 'Pronome',
    //             Correct = 3,
    //             Questions = 'Qual das seguintes palavras é um pronome pessoal no caso objetivo?',
    //             FirstOption = 'she',
    //             SecondOption = 'we',
    //             ThirdOption = 'me',
    //         },
    //         new QuizzModel
    //         {
    //             QuizzTitle = 'Comparativo',
    //             Correct = 2,
    //             Questions = 'Qual é a forma correta do comparativo de superioridade do adjetivo "good" (bom)?',
    //             FirstOption = 'goodest',
    //             SecondOption = 'better',
    //             ThirdOption = 'best',
    //         });
    // }
}
