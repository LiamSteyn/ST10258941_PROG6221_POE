using System;
using System.Collections.Generic;
using System.Windows;
using ST10258941_PROG6221_3;

namespace WpfApp2
{
    public partial class AddRecipeWindow : Window
    {
        private List<Ingredient> ingredients;
        private List<string> steps;
        private List<Recipe> recipes;

        public AddRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            steps = new List<string>();
            this.recipes = recipes ?? new List<Recipe>(); // Ensure recipes is not null
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Validate ingredient inputs
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(QuantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(UnitTextBox.Text) ||
                string.IsNullOrWhiteSpace(CaloriesTextBox.Text) ||
                string.IsNullOrWhiteSpace(FoodGroupTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields for the ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Parse quantity and calories
            if (!double.TryParse(QuantityTextBox.Text, out double quantity) ||
                !double.TryParse(CaloriesTextBox.Text, out double calories))
            {
                MessageBox.Show("Please enter valid numeric values for Quantity and Calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create new Ingredient object
            Ingredient newIngredient = new Ingredient(
                IngredientNameTextBox.Text,
                quantity,
                UnitTextBox.Text,
                calories,
                FoodGroupTextBox.Text
            );

            // Add ingredient to list
            ingredients.Add(newIngredient);

            // Clear ingredient input fields
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitTextBox.Clear();
            CaloriesTextBox.Clear();
            FoodGroupTextBox.Clear();

            // Update status message
            StatusTextBlock.Text = $"Ingredient '{newIngredient.Name}' added successfully!";

            
            
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            // Add step to list
            if (!string.IsNullOrWhiteSpace(StepTextBox.Text))
            {
                steps.Add(StepTextBox.Text);
                StepTextBox.Clear();
                RefreshStepsTextBox();
            }
            else
            {
                MessageBox.Show("Please enter a step description.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe newRecipe = new Recipe(RecipeNameTextBox.Text);

            foreach (var ingredient in ingredients)
            {
                newRecipe.AddIngredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup);
            }

            foreach (var step in steps)
            {
                newRecipe.AddStep(step);
            }

            recipes.Add(newRecipe); // Add the new recipe to the recipes list
            MessageBox.Show("Recipe added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving changes
            this.Close();
        }

        private void RefreshStepsTextBox()
        {
            StepsTextBox.Text = string.Join(Environment.NewLine, steps);
        }
    }
}
