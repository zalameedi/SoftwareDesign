using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MenuLogic
{
    public class Dish
    {
        // Fields

        /// <summary>
        /// Name of the Dish
        /// </summary>        
        private string _name;

        /// <summary>
        /// Cost of the dish $$
        /// </summary>
        private double _price;

        /// <summary>
        /// Amount of time the dish takes to prepare
        /// </summary>
        private TimeSpan _prepTime;

        /// <summary>
        /// Nutritional Data for the dish
        /// </summary>
        private string[] _nutritionData;

        /// <summary>
        /// List of Ingredients in the Dish Recipe
        /// </summary>
        private List<Ingredient> _ingredientsList;

        private string orderChanges;

        // Properties

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public double Price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        public TimeSpan PrepTime
        {
            get { return this._prepTime; }
            set { this._prepTime = value; }
        }

        public string[] NutritionData
        {
            get { return this._nutritionData; }
            set { this._nutritionData = value; }
        }

        public List<Ingredient> Ingredients
        {
            get { return this._ingredientsList; }
            set { this._ingredientsList = value; }
        }

        // Methods

        // Constructor
        public Dish(string name, double price, TimeSpan prepTime, string[] nutritionals, List<Ingredient> ingredients)
        {
            this._name = name;
            this._price = price;
            this._prepTime = prepTime;
            this._nutritionData = nutritionals;
            this._ingredientsList = ingredients;
        }

        /// <summary>
        /// Prints a Summary of the Dish Attributes
        /// </summary>
        /// <param name="dish">Dish to Summarize</param>
        public void DishSummary(Dish dish)
        {
            Console.WriteLine("Dish Summary:");
            Console.WriteLine(dish.Name);
            Console.WriteLine("$ " + dish.Price);
            Console.WriteLine(dish.PrepTime);

            // Print Nutritional Data
            foreach (string item in dish.NutritionData)
            {
                Console.WriteLine(item);
            }

            // Print Ingredients List
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine(ingredient);
            }
        }
    }
}


