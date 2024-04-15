using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10258941_PROG6221A1
{
    /// Represents a cooking recipe, including ingredients and preparation steps.
    public class Recipe
    {
        // Stores the list of ingredients used in the recipe.
        public List<Ingredient> Ingredients { get; private set; }

        // Stores the sequence of steps necessary to prepare the recipe.
        public List<string> Steps { get; private set; }

        // Keeps a copy of the original ingredients for resetting purposes.
        private List<Ingredient> originalIngredients;

        /// Initializes a new instance of the Recipe class.
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
            originalIngredients = new List<Ingredient>();
        }

        /// Adds an ingredient to the recipe.
        public void AddIngredient(string name, double quantity, string unit)
        {
            var ingredient = new Ingredient(name, quantity, unit);
            Ingredients.Add(ingredient);
            originalIngredients.Add(new Ingredient(name, quantity, unit));  // Store the original for reset
        }

        /// Adds a cooking step to the recipe.
        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        /// Scales the quantities of all ingredients in the recipe by a given factor.
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        /// Resets the ingredient quantities to their original values.
        public void ResetQuantities()
        {
            Ingredients.Clear();
            Ingredients.AddRange(new List<Ingredient>(originalIngredients));
        }

        /// Clears all ingredients and steps from the recipe, effectively resetting it.
        public void ClearRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
            originalIngredients.Clear();
        }

        /// Displays the recipe, listing all ingredients and steps neatly.
        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("\nSteps:");
            int stepCount = 1;
            foreach (var step in Steps)
            {
                Console.WriteLine($"{stepCount++}. {step}");
            }
        }
    }


}
