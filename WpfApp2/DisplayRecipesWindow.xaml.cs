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
        private Recipe _selectedRecipe;
        private ObservableCollection<Recipe> _recipes;

        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
                OnPropertyChanged(nameof(IsRecipeSelected));
                OnPropertyChanged(nameof(IsNoRecipeSelected));
            }
        }

        public ObservableCollection<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public DisplayRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            // Sort recipes alphabetically by name
            recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name, StringComparison.Ordinal));
            Recipes = new ObservableCollection<Recipe>(recipes ?? new List<Recipe>());
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RecipesListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecipesListView.SelectedItem != null)
            {
                Recipe selectedRecipe = RecipesListView.SelectedItem as Recipe;
                if (selectedRecipe != null)
                {
                    
                }
            }
        }

        public bool IsRecipeSelected => SelectedRecipe != null;
        public bool IsNoRecipeSelected => SelectedRecipe == null;
    }
}
