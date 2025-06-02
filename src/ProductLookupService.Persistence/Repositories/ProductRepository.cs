using Microsoft.EntityFrameworkCore;
using ProductLookupService.Domain.Entities.Products;
using ProductLookupService.Domain.Entities.Products.Interfaces;
using ProductLookupService.Persistence.Data;

namespace ProductLookupService.Persistence.Repositories
{
    public sealed class ProductRepository(AppDataContext context) : IProductRepository
    {
        public async Task SaveAsync(Product product, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(product);
            await context.Products.AddAsync(product, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product?> GetByBarcodeAsync(string barcode, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(barcode);

            return await context.Products.FirstOrDefaultAsync(p => p.Barcode == barcode, cancellationToken);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(product);
            context.Products.Update(product);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
