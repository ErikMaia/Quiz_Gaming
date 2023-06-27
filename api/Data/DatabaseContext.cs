using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using api.Models;
public class DatabaseContext : DbContext
{
    public DbSet<ProductModel>? Products { get; set; }
    public DbSet<TableModel>? Tables { get; set; }
    public DbSet<WaiterModel>? Waiters { get; set; }
    public DbSet<CategoryModel>? Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31)); // Especifique a versão correta do servidor MySQL aqui

        optionsBuilder.UseMySql("Server=database;Port=3306;Database=tarefas;User=root;Password=tarefas;",
            serverVersion,
            options => options.EnableRetryOnFailure()
        );
    }
}
