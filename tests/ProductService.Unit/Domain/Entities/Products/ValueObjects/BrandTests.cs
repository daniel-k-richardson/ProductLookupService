using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductService.Unit.Domain.Entities.Products.ValueObjects;

public class BrandTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ImplicitOperator_ThrowsArgumentException_WhenNullOrEmpty(string input)
    {
        var ex = Assert.Throws<ArgumentException>(() => { Brand brand = input; });
        Assert.Equal("Brand cannot be null or empty. (Parameter 'brand')", ex.Message);
    }

    [Fact]
    public void ImplicitOperator_CreatesBrand_WhenValid()
    {
        string input = "Valid Brand";
        Brand brand = input;
        Assert.Equal(input, brand.Value);
    }
}

