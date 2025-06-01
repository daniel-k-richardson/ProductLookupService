using Microsoft.EntityFrameworkCore;
using ProductLookupService.Domain.Entities.Products;

namespace ProductLookupService.Persistence.Data;

public class AppDataContext(DbContextOptions<AppDataContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDataContext).Assembly);
    }

    public static void CreateDatabaseIfNotExists(AppDataContext context)
    {
        if (context.Database.EnsureCreated())
        {
            // Database was created, you can seed initial data here if needed
        }
    }
}
