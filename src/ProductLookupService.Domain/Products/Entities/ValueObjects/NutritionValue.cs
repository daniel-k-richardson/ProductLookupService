namespace ProductLookupService.Domain.Products.Entities.ValueObjects;

public record NutritionValue(double Value)
{
    public static implicit operator double(NutritionValue nutritionValue) => nutritionValue.Value;

    public static implicit operator NutritionValue(double nutritionValue)
    {
        if (nutritionValue < 0)
        {
            throw new ArgumentException("Nutrition value cannot be negative.", nameof(nutritionValue));
        }

        return new(nutritionValue);
    }

    public override string ToString() => $"{Value:F2}";
}
