using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductLookupService.Domain.Entities.Products;

public sealed class Product : EntityId
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Size Size { get; private set; }
    public Brand Brand { get; private set; }
    public Barcode Barcode { get; private set; }
    public Dictionary<NutritionName, NutritionValue> NutritionFacts { get; private set; }

    public Product(
        Name name,
        Description description,
        Size size,
        Brand brand,
        Barcode barcode)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(description);
        ArgumentNullException.ThrowIfNull(size);
        ArgumentNullException.ThrowIfNull(brand);
        ArgumentNullException.ThrowIfNull(barcode);

        Name = name;
        Description = description;
        Size = size;
        Brand = brand;
        Barcode = barcode;
        NutritionFacts = new();
    }

    public void AddNutritionFacts(Dictionary<NutritionName, NutritionValue> nutritionFacts)
    {
        ArgumentNullException.ThrowIfNull(nutritionFacts);
        NutritionFacts = new(nutritionFacts);
    }
}
