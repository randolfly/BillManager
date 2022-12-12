using BillManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BillManager.DataContext;

public class AppDataContext : DbContext
{
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Asset> Assets { get; set; }

    public static readonly ILoggerFactory ConsoleLoggerFactory =
        LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddConsole();
        });

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}