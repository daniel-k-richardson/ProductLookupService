using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductService.Unit.Domain.Entities.Products.ValueObjects;

public class NutritionNameTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ImplicitOperator_ThrowsArgumentException_WhenNullOrEmpty(string? input)
    {
        var ex = Assert.Throws<ArgumentException>(() => { NutritionName n = input; });
        Assert.Equal("Nutrition name cannot be null or empty. (Parameter 'nutritionName')", ex.Message);
    }

    [Fact]
    public void ImplicitOperator_CreatesNutritionName_WhenValid()
    {
        string input = "Calories";
        NutritionName n = input;
        Assert.Equal(input, n.Value);
    }
}

