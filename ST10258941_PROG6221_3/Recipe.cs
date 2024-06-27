using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10258941_PROG6221_3
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<string> Steps { get; private set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
        }



        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        public string StepsText => string.Join(Environment.NewLine, Steps);

        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }

        // Example implementation within Recipe class
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe Name: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit} ({ingredient.Calories} calories)");
            }
            Console.WriteLine("\nSteps:");
            foreach (var step in Steps)
            {
                Console.WriteLine(step);
            }
        }

        public void ResetQuantities()
        {
            // Reset quantities of ingredients to their original values
        }

        public void ScaleRecipe(double scaleFactor)
        {
            // Scale quantities of ingredients by scaleFactor
        }
        public void ClearRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
        }


    }
}
