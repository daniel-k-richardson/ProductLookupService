using ProductLookupService.Domain.Products.Entities.ValueObjects;

namespace ProductLookupService.Domain.Products.Entities;

public sealed class Product : EntityId
{
    public Name Name { get; init; }
    public Description Description { get; init; }
    public Size Size { get; init; }
    public Brand Brand { get; init; }
    public Dictionary<NutritionName, NutritionValue> NutritionFacts { get; init; }

    public Product(
        Name name,
        Description description,
        Size size,
        Brand brand,
        Dictionary<NutritionName, NutritionValue> nutritionFacts)
    {
        Name = name;
        Description = description;
        Size = size;
        Brand = brand;
        NutritionFacts = nutritionFacts;
    }
}
