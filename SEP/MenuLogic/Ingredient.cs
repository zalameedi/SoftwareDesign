using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuLogic
{
    public class Ingredient
    {
        // Fields

        /// <summary>
        /// Name of the Ingredient
        /// </summary>
        private string _name;

        /// <summary>
        /// Cost of a single Ingredient
        /// </summary>
        private double _cost;

        /// <summary>
        /// No of Ingredients that come as a unit
        /// </summary>
        private double _unitAmmount;

        // Properties

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public double Cost
        {
            get { return this._cost; }
            set { this._cost = value; }
        }

        public double UnitAmmount
        {
            get { return this._unitAmmount; }
            set { this._unitAmmount = value; }
        }

        // Methods

        // Constructor
        Ingredient(string name, double cost, double unitAmmount)
        {
            this._name = name;
            this._cost = cost;
            this._unitAmmount = unitAmmount;
        }

        /// <summary>
        /// Calculates Unit Price for an Ingredient
        /// </summary>
        /// <param name="ingredient">Ingredient to calculate</param>
        /// <returns>Unit cost for ingredient</returns>
        double CalculateUnitCost(Ingredient ingredient)
        {
            // Multiplies cost * unit ammount to get unit cost
            // i.e. $.70 per pepper * 1 doz peppers = $8.4
            return ingredient._cost * ingredient._unitAmmount;
        }
    }
}
