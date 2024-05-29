using System;
using System.Collections.Generic;

namespace ST10258941_PROG6221
{
    public class Recipe
    {
        public string Name { get; set; }
        private List<Ingredient> ingredients;
        private List<string> steps;

        public delegate void CalorieNotificationHandler(string message);
        public event CalorieNotificationHandler CalorieNotification;

        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
        }

        public void AddStep(string step)
        {
            steps.Add(step);
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            
        }

        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }

            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                CalorieNotification?.Invoke($"Warning: Total calories exceed 300 for recipe '{Name}'!");
            }
        }

        public double CalculateTotalCalories()
        {
            double total = 0;
            foreach (var ingredient in ingredients)
            {
                total += ingredient.Calories;
            }
            return total;
        }
    }
}
