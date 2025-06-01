namespace ProductLookupService.Domain.Entities.Products.Interfaces;

public interface IProductRepository
{
    Task SaveAsync(Product product, CancellationToken cancellationToken);

    Task<Product?> GetByBarcodeAsync(string barcode, CancellationToken cancellationToken);

    IEnumerable<Product> GetAll();

    Task UpdateAsync(Product product, CancellationToken cancellationToken);
}
