using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductService.Unit.Domain.Entities.Products.ValueObjects
{
    public class NutritionValueTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        public void ImplicitOperator_ThrowsArgumentException_WhenNegative(double input)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                NutritionValue n = input;
            });
            Assert.Equal("Nutrition value cannot be negative. (Parameter 'nutritionValue')", ex.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(123.45)]
        public void ImplicitOperator_CreatesNutritionValue_WhenNonNegative(double input)
        {
            NutritionValue n = input;
            Assert.Equal(input, n.Value);
        }
    }
}
