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
          
            // Constructor to initialize arrays and counts
            public Recipe()
            {
                ingredients = new Ingredient[10]; // Initial capacity
                steps = new string[10]; // Initial capacity
                originalIngredients = new Ingredient[10]; // Initial capacity

                ingredientCount = 0; // Initialize ingredient count
                stepCount = 0; // Initialize step count
        }
            
            // Adds an ingredient to the recipe
            public void AddIngredient(string name, double quantity, string unit)
            {
                // Double the array size if full
                if (ingredientCount == ingredients.Length)
                {
                    Array.Resize(ref ingredients, ingredients.Length * 2); // Double the array size if full
                    Array.Resize(ref originalIngredients, originalIngredients.Length * 2); // Double the array size if full
                }

                // Add new ingredient
                ingredients[ingredientCount++] = new Ingredient(name, quantity, unit);
                originalIngredients[ingredientCount - 1] = new Ingredient(name, quantity, unit);
            }

            // Adds a step to the recipe
            public void AddStep(string step)
            {
                // Double the array size if full
                if (stepCount == steps.Length)
                {
                    Array.Resize(ref steps, steps.Length * 2); // Double the array size if full
                }

                // Add new step
                steps[stepCount++] = step;
            }

            // Scales the quantities of ingredients in the recipe
            public void ScaleRecipe(double factor)
            {
                // Multiply each ingredient's quantity by the scaling factor
                for (int i = 0; i < ingredientCount; i++)
                {
                    ingredients[i].Quantity *= factor;
                }
            }

            // Resets ingredient quantities to their original values
            public void ResetQuantities()
            {
                for (int i = 0; i < ingredientCount; i++)
                {
                    ingredients[i] = originalIngredients[i];
                }
            }

            // Clears the recipe by resetting arrays and counts
            public void ClearRecipe()
            {
                ingredients = new Ingredient[10];
                steps = new string[10];
                originalIngredients = new Ingredient[10];

                ingredientCount = 0;    // Reset ingredient count
                stepCount = 0;  // Reset step count
        }
            
            // Displays the recipe's ingredients and steps
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