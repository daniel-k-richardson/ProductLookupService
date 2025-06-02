using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductService.Unit.Domain.Entities.Products.ValueObjects
{
    public class NameTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ImplicitOperator_ThrowsArgumentException_WhenNullOrEmpty(string input)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Name name = input;
            });
            Assert.Equal("Name cannot be null or empty. (Parameter 'name')", ex.Message);
        }

        [Fact]
        public void ImplicitOperator_CreatesName_WhenValid()
        {
            var input = "Valid Name";
            Name name = input;
            Assert.Equal(input, name.Value);
        }
    }
}
