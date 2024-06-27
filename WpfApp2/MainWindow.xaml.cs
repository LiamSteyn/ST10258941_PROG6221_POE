using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ST10258941_PROG6221_3;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes; // List to store recipes

        // Constructor for MainWindow
        public MainWindow()
        {
            InitializeComponent();


            recipes = new List<Recipe>(); // Initialize the recipes list

            // Display the DisplayRecipeWindow with the list of recipes
            DisplayRecipeWindow displayRecipeWindow = new DisplayRecipeWindow(recipes);
            
        }

        // Event handler for Exit button click
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Shutdown the application
        }

        // Event handler for Add Recipe button click
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Open AddRecipeWindow to add a new recipe
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipes);
            addRecipeWindow.ShowDialog();
        }

        // Event handler for Tools button click
        private void Tools_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count > 0)
            {
                // Convert recipes List to an array of Recipe objects
                Recipe[] recipesArray = recipes.ToArray();

                // Open ToolsWindow with the array of recipes
                ToolsWindow toolsWindow = new ToolsWindow(recipesArray);
                toolsWindow.ShowDialog();
            }
            else
            {
                // Display error message if no recipes are available
                MessageBox.Show("No recipes available. Add a recipe first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for Display Recipes button click
        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (recipes == null || recipes.Count == 0)
            {
                // Display information message if there are no recipes to display
                MessageBox.Show("No recipes to display.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            
            // Convert recipes List to Recipe[]
            Recipe[] recipesArray = recipes.ToArray();

            // Open DisplayRecipeWindow to show all recipes
            var displayRecipeWindow = new DisplayRecipeWindow(recipes);
            displayRecipeWindow.ShowDialog();
        }
    }
}
