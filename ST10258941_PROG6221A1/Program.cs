using System;
using System.Collections.Generic;

namespace ST10258941_PROG6221
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display a recipe");
                Console.WriteLine("3. Scale a recipe");
                Console.WriteLine("4. Reset a recipe");
                Console.WriteLine("5. Clear a recipe");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        EnterRecipeDetails();
                        break;
                    case 2:
                        DisplayRecipes();
                        break;
                    case 3:
                        ScaleRecipe();
                        break;
                    case 4:
                        ResetRecipe();
                        break;
                    case 5:
                        ClearRecipe();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static void EnterRecipeDetails()
        {
            Console.Write("\nEnter the name of the recipe: ");
            string recipeName = Console.ReadLine();
            Recipe recipe = new Recipe(recipeName);

            Console.Write("Enter the number of ingredients: ");
            int numIngredients;
            if (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the number of ingredients.");
                return;
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter ingredient name: ");
                string name = Console.ReadLine();
                Console.Write("Enter quantity: ");
                double quantity;
                if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for the quantity.");
                    return;
                }
                Console.Write("Enter unit of measurement: ");
                string unit = Console.ReadLine();
                Console.Write("Enter number of calories: ");
                double calories;
                if (!double.TryParse(Console.ReadLine(), out calories) || calories < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for the calories.");
                    return;
                }
                string foodGroup = SelectFoodGroup();
                recipe.AddIngredient(name, quantity, unit, calories, foodGroup);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps;
            if (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the number of steps.");
                return;
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1} description: ");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            recipes.Add(recipe);
        }

        static string SelectFoodGroup()
        {
            Console.WriteLine("\nSelect a food group:");
            Console.WriteLine("1. Vegetables");
            Console.WriteLine("2. Fruits");
            Console.WriteLine("3. Grains, Beans, and Nuts");
            Console.WriteLine("4. Dairy");
            Console.WriteLine("5. Meat, Poultry, and Fish");
            Console.WriteLine("6. Fats and Oils");
            Console.WriteLine("7. Sweets");
            Console.Write("Enter the number corresponding to the food group: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 7)
            {
                Console.WriteLine("Invalid input. Please select a valid food group.");
                return SelectFoodGroup();
            }

            switch (choice)
            {
                case 1:
                    return "Vegetables";
                case 2:
                    return "Fruits";
                case 3:
                    return "Grains, Beans, and Nuts";
                case 4:
                    return "Dairy";
                case 5:
                    return "Meat, Poultry, and Fish";
                case 6:
                    return "Fats and Oils";
                case 7:
                    return "Sweets";
                default:
                    return "";
            }
        }

        static void DisplayRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));
            Console.WriteLine("\nRecipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }

            Console.Write("Select a recipe to display: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > recipes.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            recipes[choice - 1].DisplayRecipe();
        }

        static void ScaleRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.Write("Select a recipe to scale: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > recipes.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Recipe recipe = recipes[choice - 1];
            Console.Write("Enter scale factor (e.g., 0.5, 2, 3): ");
            double scaleFactor;
            if (!double.TryParse(Console.ReadLine(), out scaleFactor))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the scale factor.");
                return;
            }

            recipe.ScaleRecipe(scaleFactor);
            Console.WriteLine($"Recipe '{recipe.Name}' has been scaled by a factor of {scaleFactor}.");
        }

        static void ResetRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.Write("Select a recipe to reset: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > recipes.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Recipe recipe = recipes[choice - 1];
            Console.Write("Are you sure you want to reset the recipe? (y/n): ");
            string confirmation = Console.ReadLine();
            if (confirmation.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                recipe.ResetQuantities();
                Console.WriteLine($"Recipe '{recipe.Name}' quantities have been reset.");
            }
            else
            {
                Console.WriteLine("Reset cancelled.");
            }
        }

        static void ClearRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.Write("Select a recipe to clear: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > recipes.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Recipe recipe = recipes[choice - 1];
            Console.Write("Type 'Clear' to confirm and clear the recipe: ");
            string confirmation = Console.ReadLine();
            if (confirmation.Equals("Clear", StringComparison.OrdinalIgnoreCase))
            {
                recipe.ClearRecipe();
                Console.WriteLine($"Recipe '{recipe.Name}' cleared.");
            }
            else
            {
                Console.WriteLine("Clear cancelled.");
            }
        }
    }
}