using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10258941_PROG6221
{
    /// Represents a single ingredient used in a recipe, including its quantity and measurement unit.
    public class Ingredient
    {
        // Public properties to get and set the name of the ingredient.
        public string Name { get; set; }

        // Public property to get and set the quantity of the ingredient. The quantity can be adjusted, for example, when scaling a recipe.
        public double Quantity { get; set; }

        // Public property to get and set the unit of measurement for the ingredient's quantity (e.g., cup, teaspoon, gram).
        public string Unit { get; set; }

        /// Initializes a new instance of the Ingredient class with specified details.
        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
