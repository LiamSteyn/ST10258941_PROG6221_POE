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
            while (!exit)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset recipe");
                Console.WriteLine("5. Clear recipe");
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
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        ScaleRecipe();
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        Console.WriteLine("Recipe quantities have been reset.");
                        break;
                    case 5:
                        recipe.ClearRecipe();
                        Console.WriteLine("Recipe cleared.");
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
    }
}
