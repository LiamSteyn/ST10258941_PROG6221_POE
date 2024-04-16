using System;

namespace ST10258941_PROG6221
{
    class Program
    {
        static Recipe recipe = new Recipe();

        static void Main(string[] args)
        {
            bool exit = false;
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
                // Main loop to keep the program running until the user chooses to exit
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                // Perform action based on user's choice
                switch (choice)
                {
                    case 1:
                        EnterRecipeDetails();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
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

        // Method to enter recipe details
        static void EnterRecipeDetails()
        {
            Console.Write("\nEnter the number of ingredients: ");
            int numIngredients;
            if (!int.TryParse(Console.ReadLine(), out numIngredients))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the number of ingredients.");
                return;
            }

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

            int numSteps;
            bool validNumSteps = false;
            do
            {
                Console.Write("Enter the number of steps: ");
                if (!int.TryParse(Console.ReadLine(), out numSteps))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for the number of steps.");
                }
                else
                {
                    validNumSteps = true;
                }
            } while (!validNumSteps);

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

            double scaleFactor;
            Console.Write("\nEnter scale factor (0.5, 2, 3): ");
            if (!double.TryParse(Console.ReadLine(), out scaleFactor))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the scale factor.");
                return;
            }

            recipe.ScaleRecipe(scaleFactor);
            Console.WriteLine($"Recipe has been scaled by a factor of {scaleFactor}.");
        }

        // Method to clear the recipe
        static void ResetRecipe()
        {
            Console.Write("Are you sure you want to reset the recipe? (y/n): ");
            string confirmation = Console.ReadLine();
            if (confirmation.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                recipe.ResetQuantities();
                Console.WriteLine("Recipe quantities have been reset.");
            }
            else
            {
                Console.WriteLine("Reset cancelled.");
            }
        }

        // Method to reset the recipe
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