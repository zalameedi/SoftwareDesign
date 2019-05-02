using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actors
{
    public class Manager : User
    {

        /// <summary>
        /// Constructor for a 'manager' user object.
        /// </summary>
        /// <param name="_name">Name of the manager.</param>
        public Manager (String _name)
        {
            this.setName(_name);
        }

    }
}
