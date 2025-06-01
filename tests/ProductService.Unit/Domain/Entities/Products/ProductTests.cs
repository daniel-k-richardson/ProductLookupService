using ProductLookupService.Domain.Entities.Products;
using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductService.Unit.Domain.Entities.Products;

public class ProductTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        var name = new Name("Test Product");
        var description = new Description("A test product");
        var size = new Size(1.0, SizeUnit.Gram);
        var brand = new Brand("Test Brand");
        var barcode = new Barcode("012345678905"); // Valid UPC-A

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
        var description = new Description("A test product");
        var size = new Size(1.0, SizeUnit.Gram);
        var brand = new Brand("Test Brand");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Product(name, description, size, brand, null));
    }

    [Fact]
    public void Constructor_ThrowsArgumentException_WhenDescriptionIsNull()
    {
        // Arrange
        var name = new Name("Test Product");
        Description description = null;
        var size = new Size(1.0, SizeUnit.Gram);
        var brand = new Brand("Test Brand");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Product(name, description, size, brand, null));
    }

    [Fact]
    public void Constructor_ThrowsArgumentNullException_WhenBarcodeIsNull()
    {
        // Arrange
        var name = new Name("Test Product");
        var description = new Description("A test product");
        var size = new Size(1.0, SizeUnit.Gram);
        var brand = new Brand("Test Brand");
        Barcode barcode = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Product(name, description, size, brand, barcode));
    }

    [Fact]
    public void AddNutritionFacts_ReplacesExistingFacts()
    {
        // Arrange
        var product = new Product(
            new Name("Test Product"),
            new Description("A test product"),
            new Size(1.0, SizeUnit.Gram),
            new Brand("Test Brand"),
            new Barcode("012345678905")
        );
        var initialFacts = new Dictionary<NutritionName, NutritionValue>
        {
            { new NutritionName("Calories"), new NutritionValue(100) },
            { new NutritionName("Fat"), new NutritionValue(10) }
        };
        product.AddNutritionFacts(initialFacts);

        var newFacts = new Dictionary<NutritionName, NutritionValue>
        {
            { new NutritionName("Protein"), new NutritionValue(20) }
        };

        // Act
        product.AddNutritionFacts(newFacts);

        // Assert
        Assert.Single(product.NutritionFacts);
        Assert.True(product.NutritionFacts.ContainsKey(new NutritionName("Protein")));
        Assert.False(product.NutritionFacts.ContainsKey(new NutritionName("Calories")));
        Assert.False(product.NutritionFacts.ContainsKey(new NutritionName("Fat")));
    }
}
