using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuLogic
{
    public class Order
    {
        // Fields

        /// <summary>
        /// List of Dishes for the order
        /// </summary>
        private List<Dish> _orderedDishes;

        /// <summary>
        /// Status of order: 0 - in progress, 1 - complete
        /// </summary>
        private int _status;

        /// <summary>
        /// Reference to the Inventory
        /// </summary>
        private Supplies inventory;

        /// <summary>
        /// Event Handler for Placing an Order to Notify Cook
        /// </summary>
        /// <param name="sender">Order</param>
        /// <param name="e">Message</param>
        public delegate void OrderPlacedEventHandler(object sender, EventArgs e);
        public event OrderPlacedEventHandler OnOrderPlaced; 

        // Properties

        public List<Dish> OrderedDishes
        {
            get { return this._orderedDishes; }
            set { this._orderedDishes = value; }
        }

        public int Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        // Methods

        // Constructor
        public Order(List<Dish> dishes)
        {
            this._orderedDishes = dishes;
            this._status = 0;
        }

        /// <summary>
        /// Adds Dish to the list of Ordered Dishes
        /// </summary>
        /// <param name="orderedDish">Dish to add to order</param>
        public void AddDish(Dish orderedDish)
        {
            this._orderedDishes.Add(orderedDish);
            this.AddOrderSum(orderedDish.Price);
        }

        /// <summary>
        /// Sums the Price of the Order
        /// </summary>
        /// <param name="orderSum">Newest dish price to add</param>
        /// <returns>Order Cost</returns>
        private double AddOrderSum(double orderSum)
        {
            double orderCost = 0.0;

            foreach (Dish dish in this.OrderedDishes)
            {
                orderCost += dish.Price;
            }

            return orderCost;
        }

        /// <summary>
        /// Notifies Cook that an Order was placed
        /// </summary>
        /// <param name="userOrder">Order to place</param>
        /// <returns></returns>
        private bool NotifyCook(Order userOrder)
        {
            this.OnOrderPlaced(this, new EventArgs());
            return true;
        }

        /// <summary>
        /// Update the Supply Inventory after creating a dish
        /// </summary>
        /// <param name="order">Order to place</param>
        public void UpdateSupply(Order order)
        {
            foreach (Dish dish in order.OrderedDishes)
            {
                foreach (Ingredient ingredient in dish.Ingredients)
                {
                    inventory.Update(ingredient);
                }
            }
        }

        /// <summary>
        /// Allows user to place an order
        /// </summary>
        /// <param name="order">Order to place</param>
        public void PlaceOrder(Order order)
        {
            this.NotifyCook(order);
            this.UpdateSupply(order);
        }
    }
}
