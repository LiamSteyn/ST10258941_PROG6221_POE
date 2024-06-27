using System.Windows;
using System.Windows.Controls;
using ST10258941_PROG6221_3;

namespace WpfApp2
{
    public partial class ToolsWindow : Window
    {
        private Recipe currentRecipe; // Holds the current recipe for this window

        // Constructor that initializes the window with a recipe
        public ToolsWindow(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe; // Set the current recipe
        }

        // Event handler for scaling the recipe by a factor
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is selected
            if (currentRecipe == null)
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Parse the scale factor input
            if (!double.TryParse(ScaleFactorTextBox.Text, out double scaleFactor) || scaleFactor <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for the scale factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Scale the current recipe
            currentRecipe.ScaleRecipe(scaleFactor);
            MessageBox.Show($"Recipe scaled by factor of {scaleFactor}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for resetting ingredient quantities to original
        private void ResetIngredients_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is selected
            if (currentRecipe == null)
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Reset ingredient quantities
            currentRecipe.ResetQuantities();
            MessageBox.Show("Ingredients reset to original quantities.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for clearing the entire recipe
        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is selected
            if (currentRecipe == null)
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Clear the entire recipe
            currentRecipe.ClearRecipe();
            MessageBox.Show("Recipe cleared.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
