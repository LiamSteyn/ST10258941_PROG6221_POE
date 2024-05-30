using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10258941_PROG6221;
using System;

namespace ST10258941_PROG6221.RecipeTests
{
    [TestClass]
    public class RecipeTests
    {
        // Test method for calculating total calories
        [TestMethod]
        public void TestTotalCalories()
        {
            // Arrange: Set up the recipe with known ingredients
            Recipe recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Sugar", 100, "grams", 387, "Carbohydrate");
            recipe.AddIngredient("Butter", 200, "grams", 1433, "Fat");

            // Act: Calculate the total calories
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert: Verify the total calories are calculated correctly
            Assert.AreEqual(1820, totalCalories, "The total calories calculation is incorrect.");
        }

        // Test method for checking calorie notification
        [TestMethod]
        public void TestCaloriesExceedNotification()
        {
            // Arrange: Set up a high-calorie recipe and notification flag
            Recipe recipe = new Recipe("High Calorie Recipe");
            recipe.AddIngredient("Chocolate", 100, "grams", 546, "Sweet");
            bool notificationReceived = false;

            // Act: Subscribe to the calorie notification event and display the recipe
            recipe.CalorieNotification += (message) => { notificationReceived = true; };
            recipe.DisplayRecipe();

            // Assert: Verify the notification was received
            Assert.IsTrue(notificationReceived, "Notification for calories exceeding 300 was not received.");
        }

        // Test method for no notification when total calories do not exceed 300
        [TestMethod]
        public void TestNoCaloriesExceedNotification()
        {
            // Arrange: Set up a recipe with low-calorie ingredients
            Recipe recipe = new Recipe("Low Calorie Recipe");
            recipe.AddIngredient("Lettuce", 100, "grams", 15, "Vegetable");
            bool notificationReceived = false;

            // Act: Subscribe to the calorie notification event and display the recipe
            recipe.CalorieNotification += (message) => { notificationReceived = true; };
            recipe.DisplayRecipe();

            // Assert: Verify that no notification was received
            Assert.IsFalse(notificationReceived, "Notification for calories exceeding 300 should not be received.");
        }
    }


}
