using ProductLookupService.Domain.Entities.Products;
using ProductLookupService.Domain.Entities.Products.ValueObjects;
using ProductLookupService.Integration.Common;
using ProductLookupService.Persistence.Repositories;

namespace ProductLookupService.Integration.Products.Repositories
{
    public class ProductRepositoryTests : SqliteIntegrationTestBase
    {
        private readonly ProductRepository _repository;

        public ProductRepositoryTests()
        {
            _repository = new ProductRepository(Context);
        }

        [Fact]
        public async Task SaveAsync_ShouldAddProduct()
        {
            var product = CreateProduct("123456789012");
            await _repository.SaveAsync(product);
            var found = await _repository.GetByBarcodeAsync(product.Barcode);
            Assert.NotNull(found);
            Assert.Equal(product.Barcode, found.Barcode);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateProduct()
        {
            var product = CreateProduct("123456789012");
            await _repository.SaveAsync(product);
            var found = await _repository.GetByBarcodeAsync(product.Barcode);

            found?.AddNutritionFacts(new List<NutritionFact>());
            await _repository.UpdateAsync(found);

            var updated = await _repository.GetByBarcodeAsync(product.Barcode);
            Assert.NotNull(updated);
            Assert.Empty(updated.NutritionFacts);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllProducts()
        {
            var product1 = CreateProduct("036000291452"); // valid UPC-A
            var product2 = CreateProduct("012345678905"); // valid UPC-A
            await _repository.SaveAsync(product1);
            await _repository.SaveAsync(product2);
            var all = _repository.GetAll();
            Assert.Contains(all, p => p.Barcode == product1.Barcode);
            Assert.Contains(all, p => p.Barcode == product2.Barcode);
        }

        private static Product CreateProduct(string barcode)
        {
            return new Product(
                new Name("Test Product"),
                new Description("Test Description"),
                new Size(1, SizeUnit.Gram),
                new Brand("Test Brand"),
                new Barcode(barcode)
            );
        }
    }
}
