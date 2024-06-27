using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic for adding a new recipe
        }

        private void DisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic for displaying a recipe
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic for scaling a recipe
        }

        private void ResetRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic for resetting a recipe
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic for clearing a recipe
        }
    }
}
