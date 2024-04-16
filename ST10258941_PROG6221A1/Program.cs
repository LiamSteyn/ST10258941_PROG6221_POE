using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10258941_PROG6221
{
    using System;

    class Program
    {
        static Recipe recipe = new Recipe();

        static void Main(string[] args)
        {
            bool exit = false;
            // Main loop to keep the program running until the user chooses to exit
            while (!exit)
            {
                // Display menu options
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset recipe");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                // Read user input and parse it as an integer
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                // Perform action based on user's choice
                switch (choice)
                {
                    case 1:
                        EnterRecipeDetails();   // Call method to enter recipe details
                        break;
                    case 2:
                        recipe.DisplayRecipe(); // Call method to display recipe
                        break;
                    case 3:
                        ScaleRecipe();  // Call method to scale the recipe
                        break;
                    case 4:
                        recipe.ResetQuantities();   // Call method to reset ingredient quantities
                        Console.WriteLine("Recipe quantities have been reset.");
                        break;
                    case 5:
                        ClearRecipe();   // Call method to clear the recipe
                        break;
                    case 0:
                        exit = true;    // Set exit flag to true to exit the loop
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        // Method to enter recipe details
        static void EnterRecipeDetails()
        {
            Console.Write("\nEnter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter ingredient name: ");
                string name = Console.ReadLine();
                Console.Write("Enter quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Enter unit of measurement: ");
                string unit = Console.ReadLine();
                recipe.AddIngredient(name, quantity, unit);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1} description: ");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }
        }

        // Method to scale the recipe
        static void ScaleRecipe()
        {
            if (recipe.ingredientCount == 0)
            {
                Console.WriteLine("No recipe available. Please enter a recipe first.");
                return;
            }

            Console.Write("\nEnter scale factor (0.5, 2, 3): ");
            double scaleFactor = double.Parse(Console.ReadLine());
            recipe.ScaleRecipe(scaleFactor);
            Console.WriteLine($"Recipe has been scaled by a factor of {scaleFactor}.");
        }

        // Method to clear the recipe
        static void ClearRecipe()
        {
            Console.Write("Type 'Clear' to confirm and clear the recipe: ");
            string confirmation = Console.ReadLine();
            if (confirmation.Equals("Clear", StringComparison.OrdinalIgnoreCase))
            {
                recipe.ClearRecipe();
                Console.WriteLine("Recipe cleared.");
            }
            else
            {
                Console.WriteLine("Clear cancelled.");
            }
        }
    }
}
