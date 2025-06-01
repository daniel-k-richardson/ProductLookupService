using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductLookupService.Domain.Entities.Products.Interfaces;
using ProductLookupService.Persistence.Data;
using ProductLookupService.Persistence.Repositories;

namespace ProductLookupService.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDataContext>(options =>
        {
            // Place the SQLite database in the root of the persistence directory
            var dbPath = Path.Combine(AppContext.BaseDirectory, "ProductDb.db");
            options.UseSqlite($"Data Source={dbPath}");
        });

        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
