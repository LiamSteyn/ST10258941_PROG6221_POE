using System;
using System.Collections.Generic;
using System.Windows;
using ST10258941_PROG6221_3;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;
        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>(); // Initialize the recipes list

            // Display the DisplayRecipeWindow with the list of recipes
            DisplayRecipeWindow displayRecipeWindow = new DisplayRecipeWindow(recipes);
            displayRecipeWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipes);
            addRecipeWindow.ShowDialog();


        }

        private void Tools_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count > 0)
            {
                Recipe currentRecipe = recipes[0]; // For example, select the first recipe in the list
                ToolsWindow toolsWindow = new ToolsWindow(currentRecipe);
                toolsWindow.Show();
            }
            else
            {
                MessageBox.Show("No recipes available. Add a recipe first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (recipes == null || recipes.Count == 0)
            {
                MessageBox.Show("No recipes to display.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var displayRecipeWindow = new DisplayRecipeWindow(recipes);
            displayRecipeWindow.ShowDialog();
        }


    }
}
