using ProductLookupService.Domain.Entities.Products;
using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductService.Unit.Domain.Entities.Products;

public class ProductTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        const string name = "Test Product";
        const string description = "A test product";
        var size = new Size(1.0, SizeUnit.Gram);
        const string brand = "Test Brand";
        const string barcode = "012345678905"; // Valid UPC-A

        // Act
        var product = new Product(name, description, size, brand, barcode);

        // Assert
        Assert.Equal(name, product.Name);
        Assert.Equal(description, product.Description);
        Assert.Equal(size, product.Size);
        Assert.Equal(brand, product.Brand);
        Assert.Equal(barcode, product.Barcode);
    }

    [Fact]
    public void Constructor_ThrowsArgumentException_WhenNameIsNull()
    {
        // Arrange
        Name name = null;
        const string description = "A test product";
        var size = new Size(1.0, SizeUnit.Gram);
        const string brand = "Test Brand";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Product(name, description, size, brand, null));
    }

    [Fact]
    public void Constructor_ThrowsArgumentException_WhenDescriptionIsNull()
    {
        // Arrange
        const string name = "Test Product";
        Description description = null;
        var size = new Size(1.0, SizeUnit.Gram);
        const string brand = "Test Brand";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Product(name, description, size, brand, null));
    }

    [Fact]
    public void Constructor_ThrowsArgumentNullException_WhenBarcodeIsNull()
    {
        // Arrange
        const string name = "Test Product";
        const string description = "A test product";
        var size = new Size(1.0, SizeUnit.Gram);
        const string brand = "Test Brand";
        Barcode barcode = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Product(name, description, size, brand, barcode));
    }

    [Fact]
    public void AddNutritionFacts_ReplacesExistingFacts()
    {
        // Arrange
        var product = new Product(
            "Test Product",
            "A test product",
            new Size(1.0, SizeUnit.Gram),
            "Test Brand",
            "012345678905"
        );
        var initialFacts = new List<NutritionFact>
        {
            new("Calories", 100),
            new("Fat", 10)
        };
        product.AddNutritionFacts(initialFacts);

        var newFacts = new List<NutritionFact>
        {
            new("Protein", 20)
        };

        // Act
        product.AddNutritionFacts(newFacts);

        // Assert
        Assert.Single(product.NutritionFacts);
        Assert.Contains(product.NutritionFacts, nf => nf.Name == "Protein" && nf.Value == 20);
        Assert.DoesNotContain(product.NutritionFacts, nf => nf.Name == "Calories");
        Assert.DoesNotContain(product.NutritionFacts, nf => nf.Name == "Fat");
    }
}
