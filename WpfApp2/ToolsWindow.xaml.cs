using System.Windows;
using System.Windows.Controls;
using ST10258941_PROG6221_3; // Assuming your Recipe and Ingredient classes are in this namespace

namespace WpfApp2
{
    public partial class ToolsWindow : Window
    {
        private Recipe currentRecipe; // Assuming you'll pass the current recipe to this window

        public ToolsWindow(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecipe == null)
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(ScaleFactorTextBox.Text, out double scaleFactor) || scaleFactor <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for the scale factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            currentRecipe.ScaleRecipe(scaleFactor);
            MessageBox.Show($"Recipe scaled by factor of {scaleFactor}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ResetIngredients_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecipe == null)
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            currentRecipe.ResetQuantities();
            MessageBox.Show("Ingredients reset to original quantities.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecipe == null)
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            currentRecipe.ClearRecipe();
            MessageBox.Show("Recipe cleared.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
