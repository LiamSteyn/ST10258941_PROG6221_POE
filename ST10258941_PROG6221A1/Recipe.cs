using System;
using System.Collections.Generic;

namespace ST10258941_PROG6221
{
    public class Recipe
    {
        /// <summary>
        /// Represents a recipe, including its name, ingredients, steps, and methods for managing and displaying the recipe.
        /// </summary>
        public string Name { get; set; }
        private List<Ingredient> ingredients;
        private List<string> steps;
        private List<double> originalQuantities;

        /// <summary>
        /// Event that notifies when the total calories of the recipe exceed a certain limit.
        /// </summary>
        public delegate void CalorieNotificationHandler(string message);
        public event CalorieNotificationHandler CalorieNotification;

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
            originalQuantities = new List<double>();

        }

        /// <summary>
        /// Adds an ingredient to the recipe with the specified name, quantity, unit, calories, and food group.
        /// </summary>
        /// <param name="name">The name of the ingredient.</param>
        /// <param name="quantity">The quantity of the ingredient.</param>
        /// <param name="unit">The unit of measurement for the quantity.</param>
        /// <param name="calories">The calorie count of the ingredient.</param>
        /// <param name="foodGroup">The food group to which the ingredient belongs.</param>
        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            originalQuantities.Add(quantity);
        }

        /// <summary>
        /// Adds a step to the recipe.
        /// </summary>
        /// <param name="step">The step description.</param>
        public void AddStep(string step)
        {
            steps.Add(step);
        }

        /// <summary>
        /// Scales the recipe by the specified factor, adjusting the quantities and calories of ingredients accordingly.
        /// </summary>
        /// <param name="factor">The scaling factor.</param>
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
                ingredient.Calories *= factor;
            }
        }

        /// <summary>
        /// Resets the quantities of ingredients to their original values.
        /// </summary>
        public void ResetQuantities()
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalQuantities[i];
            }
        }

        /// <summary>
        /// Clears the recipe, removing all ingredients and steps.
        /// </summary>
        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
            originalQuantities.Clear();
        }

        /// <summary>
        /// Displays the recipe details, including name, ingredients, steps, and total calories.
        /// Notifies if total calories exceed 300.
        /// </summary>
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

        /// <summary>
        /// Calculates the total calories of the recipe by summing the calories of all ingredients.
        /// </summary>
        /// <returns>The total calories of the recipe.</returns>
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
