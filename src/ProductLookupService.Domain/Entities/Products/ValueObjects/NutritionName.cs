namespace ProductLookupService.Domain.Entities.Products.ValueObjects;

public record NutritionName(string Value)
{
    public static implicit operator string(NutritionName nutritionName) => nutritionName.Value;

    public static implicit operator NutritionName(string nutritionName)
    {
        if (string.IsNullOrEmpty(nutritionName))
        {
            throw new ArgumentException("Nutrition name cannot be null or empty.", nameof(nutritionName));
        }

        return new(nutritionName);
    }

    public override string ToString() => Value;
}
