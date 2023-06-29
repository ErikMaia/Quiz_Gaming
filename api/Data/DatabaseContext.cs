using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
// using api.Models;
public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31)); // Especifique a versão correta do servidor MySQL aqui

        optionsBuilder.UseMySql("Server=database;Port=3306;Database=tarefas;User=root;Password=tarefas;",
            serverVersion,
            options => options.EnableRetryOnFailure()
        );
    }
}
