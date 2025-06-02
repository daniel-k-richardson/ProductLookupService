namespace ProductLookupService.Domain.Entities.Products.ValueObjects
{
    public record NutritionName(string Value)
    {
        public static implicit operator string(NutritionName nutritionName)
        {
            return nutritionName.Value;
        }

        public static implicit operator NutritionName(string nutritionName)
        {
            if (string.IsNullOrEmpty(nutritionName))
            {
                throw new ArgumentException("Nutrition name cannot be null or empty.", nameof(nutritionName));
            }

            return new NutritionName(nutritionName);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
