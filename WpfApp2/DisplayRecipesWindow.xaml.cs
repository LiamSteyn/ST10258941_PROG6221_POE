using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using ST10258941_PROG6221_3;

namespace WpfApp2
{
    public partial class DisplayRecipeWindow : Window, INotifyPropertyChanged
    {
        private Recipe _selectedRecipe; // Currently selected recipe
        private ObservableCollection<Recipe> _recipes; // Collection of recipes to display

        // Property for the currently selected recipe
        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe)); // Notify property changed
                OnPropertyChanged(nameof(IsRecipeSelected)); // Notify property changed
                OnPropertyChanged(nameof(IsNoRecipeSelected)); // Notify property changed
            }
        }

        // Property for the collection of recipes
        public ObservableCollection<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(Recipes)); // Notify property changed
            }
        }

        // Constructor for DisplayRecipeWindow
        public DisplayRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();

            // Sort recipes alphabetically by name
            recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name, StringComparison.Ordinal));

            // Initialize ObservableCollection with sorted list of recipes, or an empty list if null
            Recipes = new ObservableCollection<Recipe>(recipes ?? new List<Recipe>());

            // Set DataContext of the window to itself, enabling data binding
            DataContext = this;
        }

        // Event raised when a recipe is selected in the ListView
        private void RecipesListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecipesListView.SelectedItem != null)
            {
                // Retrieve the selected recipe from the ListView
                Recipe selectedRecipe = RecipesListView.SelectedItem as Recipe;
                if (selectedRecipe != null)
                {
                    // Perform actions related to the selected recipe if needed
                    // (Currently empty in the provided code)
                }
            }
        }

        // Property indicating if a recipe is selected
        public bool IsRecipeSelected => SelectedRecipe != null;

        // Property indicating if no recipe is selected
        public bool IsNoRecipeSelected => SelectedRecipe == null;

        // Implementation of INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise PropertyChanged event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
