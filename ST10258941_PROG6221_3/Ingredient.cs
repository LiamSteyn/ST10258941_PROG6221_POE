namespace ST10258941_PROG6221_3
{
    /// <summary>
    /// Represents an ingredient used in a recipe.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// The name of the ingredient.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The quantity of the ingredient.
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// The unit of measurement for the quantity.
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// The number of calories in the ingredient.
        /// </summary>
        public double Calories { get; set; }
        /// <summary>
        /// The food group to which the ingredient belongs.
        /// </summary>
        public string FoodGroup { get; set; }

        public string DisplayText => $"{Quantity} {Unit} of {Name} ({Calories} calories, {FoodGroup})";
        /// <summary>
        /// The food group to which the ingredient belongs.
        /// </summary>
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }

}
