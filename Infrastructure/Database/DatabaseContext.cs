using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        optionsBuilder.UseNpgsql("Host=localhost;Database=dotnet_boilerplate;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().Property(x => x.Id).ValueGeneratedNever();
    }
}