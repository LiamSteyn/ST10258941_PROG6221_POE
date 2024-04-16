using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10258941_PROG6221
{
        public class Recipe
        {
            private Ingredient[] ingredients;
            private string[] steps;
            private Ingredient[] originalIngredients;

            public int ingredientCount;
            private int stepCount;

            public Ingredient[] Ingredients => ingredients;

            public Recipe()
            {
                ingredients = new Ingredient[10]; // Initial capacity
                steps = new string[10]; // Initial capacity
                originalIngredients = new Ingredient[10]; // Initial capacity

                ingredientCount = 0;
                stepCount = 0;
            }

            public void AddIngredient(string name, double quantity, string unit)
            {
                if (ingredientCount == ingredients.Length)
                {
                    Array.Resize(ref ingredients, ingredients.Length * 2); // Double the array size if full
                    Array.Resize(ref originalIngredients, originalIngredients.Length * 2); // Double the array size if full
                }

                ingredients[ingredientCount++] = new Ingredient(name, quantity, unit);
                originalIngredients[ingredientCount - 1] = new Ingredient(name, quantity, unit);
            }

            public void AddStep(string step)
            {
                if (stepCount == steps.Length)
                {
                    Array.Resize(ref steps, steps.Length * 2); // Double the array size if full
                }

                steps[stepCount++] = step;
            }

            public void ScaleRecipe(double factor)
            {
                for (int i = 0; i < ingredientCount; i++)
                {
                    ingredients[i].Quantity *= factor;
                }
            }

            public void ResetQuantities()
            {
                for (int i = 0; i < ingredientCount; i++)
                {
                    ingredients[i] = originalIngredients[i];
                }
            }

            public void ClearRecipe()
            {
                ingredients = new Ingredient[10];
                steps = new string[10];
                originalIngredients = new Ingredient[10];

                ingredientCount = 0;
                stepCount = 0;
            }

            public void DisplayRecipe()
            {
                if (ingredientCount == 0)
                {
                    Console.WriteLine("No recipe available. Please enter a recipe first.");
                    return;
                }

                Console.WriteLine("\nIngredients:");
                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.WriteLine($"{ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name}");
                }

                Console.WriteLine("\nSteps:");
                for (int i = 0; i < stepCount; i++)
                {
                    Console.WriteLine($"{i + 1}. {steps[i]}");
                }
            }
        }
}