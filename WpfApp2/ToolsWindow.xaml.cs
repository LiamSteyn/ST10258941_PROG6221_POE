using System.Windows;
using System.Windows.Controls;
using ST10258941_PROG6221_3; // Assuming this is where your Recipe class is defined

namespace WpfApp2
{
    public partial class ToolsWindow : Window
    {
        private Recipe[] recipes; // Array to hold the recipes
        private string[] recipeNames;

        // Constructor that initializes the window with an array of Recipe objects
        public ToolsWindow(Recipe[] recipes)
        {
            InitializeComponent();

            // Initialize the recipes array
            this.recipes = recipes;

            // Populate the ComboBox with recipe names
            PopulateRecipeComboBox();
        }

        // Method to populate the ComboBox with recipe names
        private void PopulateRecipeComboBox()
        {
            // Set the ComboBox items source to the recipes array
            RecipeSelector.ItemsSource = recipes;

            // Set the display member path to "Name" to display recipe names
            RecipeSelector.DisplayMemberPath = "Name";

            // Select the first recipe by default if there are recipes
            if (recipes.Length > 0)
                RecipeSelector.SelectedIndex = 0;
        }

        // Event handler for scaling the selected recipe by a factor
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is selected
            if (RecipeSelector.SelectedItem == null)
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Get the selected recipe from the ComboBox
            Recipe selectedRecipe = RecipeSelector.SelectedItem as Recipe;

            // Placeholder logic for scaling the recipe
            double scaleFactor = 1.5; // Example scale factor
            selectedRecipe.ScaleRecipe(scaleFactor);
            MessageBox.Show($"Recipe '{selectedRecipe.Name}' scaled by factor of {scaleFactor}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for resetting ingredient quantities to original for the selected recipe
        private void ResetIngredients_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is selected
            if (RecipeSelector.SelectedItem == null)
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Get the selected recipe from the ComboBox
            Recipe selectedRecipe = RecipeSelector.SelectedItem as Recipe;

            // Placeholder logic for resetting ingredient quantities
            selectedRecipe.ResetQuantities();
            MessageBox.Show($"Ingredients of recipe '{selectedRecipe.Name}' reset to original quantities.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for clearing the entire selected recipe
        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is selected
            if (RecipeSelector.SelectedItem == null)
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Get the selected recipe from the ComboBox
            Recipe selectedRecipe = RecipeSelector.SelectedItem as Recipe;

            // Placeholder logic for clearing the recipe
            selectedRecipe.ClearRecipe();
            MessageBox.Show($"Recipe '{selectedRecipe.Name}' cleared.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
