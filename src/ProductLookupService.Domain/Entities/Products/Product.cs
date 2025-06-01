using ProductLookupService.Domain.Entities.Products.ValueObjects;

namespace ProductLookupService.Domain.Entities.Products;

public sealed class Product : EntityId
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Size Size { get; private set; }
    public Brand Brand { get; private set; }
    public Barcode Barcode { get; private set; }
    public List<NutritionFact> NutritionFacts { get; private set; }

    private Product() { }

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

    public void AddNutritionFacts(List<NutritionFact> nutritionFacts)
    {
        ArgumentNullException.ThrowIfNull(nutritionFacts);
        NutritionFacts.Clear();
        NutritionFacts.AddRange(nutritionFacts);
    }
}
