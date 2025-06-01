using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductService.Unit.Domain.Entities.Products.ValueObjects;

public class BarcodeTests
{
    [Fact]
    public void Barcode_ThrowsArgumentException_ForInvalidLength()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Barcode("12345"));
        Assert.Equal("Barcode must be 8, 12, 13, or 14 digits long. (Parameter 'value')", ex.Message);
    }

    [Fact]
    public void Barcode_ThrowsArgumentException_ForNonDigitCharacters()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Barcode("12345ABCDE12"));
        Assert.Equal("Barcode must contain only digits. (Parameter 'value')", ex.Message);
    }

    [Fact]
    public void Barcode_ThrowsArgumentException_ForInvalidEan13Checksum()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Barcode("4006381333932")); // Invalid EAN-13
        Assert.Equal("Invalid EAN-13 barcode: checksum failed. (Parameter 'value')", ex.Message);
    }

    [Fact]
    public void Barcode_CreatesSuccessfully_ForValidEan13()
    {
        var validEan13 = "4006381333931"; // Valid EAN-13
        var barcode = new Barcode(validEan13);
        Assert.Equal(validEan13, barcode.Value);
    }
}

