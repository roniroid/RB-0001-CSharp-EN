using Roniroid.Basics.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Roniroid.Basics.EF.Data;
public class BasicsDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Person> Person { get; set; }
    public string ConnectionString { get; }
    
    public BasicsDbContext( )
    {
            // Build the configuration from the appsettings.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // Set the base path to the current directory
                .AddJsonFile("appsettings.json")  // Add the appsettings.json file
                .Build();

            // Get the connection string from the appsettings.json
            this.ConnectionString = configuration.GetConnectionString("Default");
    }

    public BasicsDbContext(DbContextOptions<BasicsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Person>()
            .HasKey(p => p.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseNpgsql(this.ConnectionString)
                .UseModel(Roniroid.Basics.EF.CompiledModels.BasicsDbContextModel.Instance);
        }
    }
}