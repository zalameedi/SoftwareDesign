using System.Collections.Generic;

namespace Menu
{
    /// <summary>
    /// Menu class that inhereits from Dish, able to adapt based on new entries coming from 
    /// derived class is constant updates.
    /// </summary>
    public class Menu : MenuLogic.Dish
    {
        /// <summary>
        /// Dictionary that will hold the style of food and the accomodating List that it can carry.
        /// </summary>
        private Dictionary<string, List<string>> Dishname = new Dictionary<string, List<string>>();

        /// <summary>
        /// Property setter for our dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetDish(string key, List<string> value)
        {
            if (Dishname.ContainsKey(key))
            {
                Dishname[key] = value;
            }
            else
            {
                Dishname.Add(key, value);
            }
        }

        /// <summary>
        /// Property getter for our dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<string> GetDish(string key)
        {
            List<string> result = null;

            if (Dishname.ContainsKey(key))
            {
                result = Dishname[key];
            }

            return result;
        }

        /// <summary>
        /// Add dish based on style (Appetizer, entree etc) into it's possible combinations (list)
        /// return bool on success or failure
        /// </summary>
        /// <param name="table"></param>
        /// <param name="newDish"></param>
        /// <returns></returns>
        bool AddDish(string table, string newDish)
        {
            if (Dishname.ContainsKey(table))
            {
                Dishname[table].Add(newDish);
                return true;
            }
            return false;
        }

        /// <summary>
        /// C# trick to return a pair of key,value if ever required.
        /// </summary>
        public KeyValuePair<string, List<string>> Users
        {
            set
            {
                SetDish(value.Key, value.Value);
            }
        }

    }
}
