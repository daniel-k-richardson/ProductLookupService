using ProductLookupService.Domain.Entities.Products;
using ProductLookupService.Domain.Entities.Products.ValueObjects;
using ProductLookupService.Integration.Common;
using ProductLookupService.Persistence.Repositories;

namespace ProductLookupService.Integration.Products.Repositories
{
    public class ProductRepositoryTests : SqliteIntegrationTestBase
    {
        private readonly ProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepository(Context);
        }

        [Fact]
        public async Task SaveAsync_ShouldAddProduct()
        {
            Product product = CreateProduct("123456789012");
            await _productRepository.SaveAsync(product);
            Product? found = await _productRepository.GetByBarcodeAsync(product.Barcode);
            Assert.NotNull(found);
            Assert.Equal(product.Barcode, found.Barcode);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateProduct()
        {
            Product product = CreateProduct("123456789012");
            await _productRepository.SaveAsync(product);
            Product? found = await _productRepository.GetByBarcodeAsync(product.Barcode);

            found?.AddNutritionFacts([]);
            await _productRepository.UpdateAsync(found!);

            Product? updated = await _productRepository.GetByBarcodeAsync(product.Barcode);
            Assert.NotNull(updated);
            Assert.Empty(updated.NutritionFacts);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllProducts()
        {
            Product product1 = CreateProduct("036000291452"); // valid UPC-A
            Product product2 = CreateProduct("012345678905"); // valid UPC-A
            await _productRepository.SaveAsync(product1);
            await _productRepository.SaveAsync(product2);
            List<Product> all = _productRepository.GetAll().ToList();
            Assert.Contains(all, p => p.Barcode == product1.Barcode);
            Assert.Contains(all, p => p.Barcode == product2.Barcode);
        }

        private static Product CreateProduct(string barcode)
        {
            return new Product(
                "Test Product",
                "Test Description",
                new Size(1, SizeUnit.Gram),
                "Test Brand",barcode
            );
        }
    }
}
