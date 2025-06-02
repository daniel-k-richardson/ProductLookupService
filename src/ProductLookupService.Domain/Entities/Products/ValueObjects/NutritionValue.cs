namespace ProductLookupService.Domain.Entities.Products.ValueObjects
{
    public record NutritionValue(double Value)
    {
        public static implicit operator double(NutritionValue nutritionValue)
        {
            return nutritionValue.Value;
        }

        public static implicit operator NutritionValue(double nutritionValue)
        {
            if (nutritionValue < 0)
            {
                throw new ArgumentException("Nutrition value cannot be negative.", nameof(nutritionValue));
            }

            return new NutritionValue(nutritionValue);
        }

        public override string ToString()
        {
            return $"{Value:F2}";
        }
    }
}
