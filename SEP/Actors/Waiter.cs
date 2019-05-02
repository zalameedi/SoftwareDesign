using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actors
{
    public class Waiter : User
    {

        // Tables the waiter is responsible for.
        private List<Table> tables;

        // Constructor //

        /// <summary>
        /// Constructor for a 'waiter' user object.
        /// </summary>
        /// <param name="_name">Name of the waiter.</param>
        public Waiter(String _name)
        {
            this.setName(_name);
        }

        // Waiter Methods //

        public void addTable(Table _table)
        {
            tables.Add(_table);
        }

        /// <summary>
        /// 
        /// </summary>
        public void updateTableSatus() // Implementation of this method requires further discussion.
        {

        }

    }
}
