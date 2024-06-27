using System;
using System.Collections.Generic;
using System.Windows;
using ST10258941_PROG6221_3;
namespace WpfApp2
{
    public partial class AddRecipeWindow : Window
    {
        private List<Ingredient> ingredients; // List to store ingredients for the recipe
        private List<string> steps; // List to store steps of the recipe
        private List<Recipe> recipes; // List of all recipes, passed from outside

        // Constructor for the AddRecipeWindow class
        public AddRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent(); // Initialize the window components defined in XAML
            ingredients = new List<Ingredient>(); // Initialize the ingredients list
            steps = new List<string>(); // Initialize the steps list
            this.recipes = recipes ?? new List<Recipe>(); // Initialize recipes list, ensuring it's not null
        }

        // Event handler for adding ingredients to the recipe
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

        // Event handler for adding a step to the recipe
        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            // Add step to list if the step text box is not empty
            if (!string.IsNullOrWhiteSpace(StepTextBox.Text))
            {
                steps.Add(StepTextBox.Text);
                StepTextBox.Clear();
                RefreshStepsTextBox(); // Refresh displayed steps
            }
            else
            {
                MessageBox.Show("Please enter a step description.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for adding a recipe
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new Recipe object
            Recipe newRecipe = new Recipe(RecipeNameTextBox.Text);

            // Add ingredients to the new recipe
            foreach (var ingredient in ingredients)
            {
                newRecipe.AddIngredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup);
            }

            // Add steps to the new recipe
            foreach (var step in steps)
            {
                newRecipe.AddStep(step);
            }

            recipes.Add(newRecipe); // Add the new recipe to the recipes list
            MessageBox.Show("Recipe added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close(); // Close the window after adding the recipe
        }

        // Event handler for canceling recipe addition
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving changes
            this.Close();
        }

        // Refresh the displayed steps in the StepsTextBox
        private void RefreshStepsTextBox()
        {
            StepsTextBox.Text = string.Join(Environment.NewLine, steps);
        }
    }
}
