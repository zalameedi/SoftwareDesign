using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actors
{
    internal abstract class User
    {
        // Fields
        private string name = "";
        private double wage = 0.0;
        private WorkDay[] current_schedule = new WorkDay[7];    // 7 workdays in a week. This might need changed.

        public void setName(string newname)
        {
            this.name = newname;
        }

        public void setWage(double newWage)
        {
            this.wage = newWage;
        }

        public string getName()
        {
            return this.name;
        }

        public double getWage()
        {
            return this.wage;
        }

    }
}
