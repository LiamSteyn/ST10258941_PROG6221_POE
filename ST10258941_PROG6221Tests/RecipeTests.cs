using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10258941_PROG6221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10258941_PROG6221.RecipeTests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestTotalCalories()
        {
            // Arrange
            Recipe recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Sugar", 100, "grams", 387, "Carbohydrate");
            recipe.AddIngredient("Butter", 200, "grams", 1433, "Fat");

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(1820, totalCalories, "The total calories calculation is incorrect.");
        }

        [TestMethod]
        public void TestCaloriesExceedNotification()
        {
            // Arrange
            Recipe recipe = new Recipe("High Calorie Recipe");
            recipe.AddIngredient("Chocolate", 100, "grams", 546, "Sweet");
            bool notificationReceived = false;

            // Act
            recipe.CalorieNotification += (message) => { notificationReceived = true; };
            recipe.DisplayRecipe();

            // Assert
            Assert.IsTrue(notificationReceived, "Notification for calories exceeding 300 was not received.");
        }
    }
}