using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductService.Unit.Domain.Entities.Products.ValueObjects
{
    public class DescriptionTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ImplicitOperator_ThrowsArgumentException_WhenNullOrEmpty(string input)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Description desc = input;
            });
            Assert.Equal("Description cannot be null or empty. (Parameter 'description')", ex.Message);
        }

        [Fact]
        public void ImplicitOperator_CreatesDescription_WhenValid()
        {
            var input = "Valid Description";
            Description desc = input;
            Assert.Equal(input, desc.Value);
        }
    }
}
