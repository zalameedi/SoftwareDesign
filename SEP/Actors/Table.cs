using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actors
{
    /// <summary>
    /// Table class needed for Waiter.cs
    /// This class may have to be relocated/reimplemented in the future.
    /// </summary>
    class Table
    {

        // Fields //

        private String status = "READY";
        private Waiter currenwaiter = null;
        private int waitingtime = 0;
        // I might need someone to explain this to me in the near future --jarred
        private Table table = null;

        // Constructor //

        /// <summary>
        /// 
        /// </summary>
        public Table ()
        {

        }


        // Getters //

        /// <summary>
        /// Getter for table status.
        /// </summary>
        /// <returns>Status of the table, as a string.</returns>
        public String getStatus()
        {
            return this.status;
        }

        /// <summary>
        /// Getter for the table's current waiter.
        /// </summary>
        /// <returns>Current waiter tending to this table.</returns>
        public Waiter getWaiter()
        {
            return this.currenwaiter;
        }

        /// <summary>
        /// Getter for the table's current waiting time.
        /// </summary>
        /// <returns>The table's waiting time, as an integer.</returns>
        public int getWaitTime()
        {
            return this.waitingtime;
        }

        // Setters //

        /// <summary>
        /// Setter for the table's status.
        /// </summary>
        /// <param name="_status">The status you would like the table to be, as a string.</param>
        public void setStatus(String _status)
        {
            this.status = _status;
        }

        /// <summary>
        /// Setter for the table's waiter.
        /// </summary>
        /// <param name="_waiter">The waiter you would like to be responsible for this table.</param>
        public void assignWaiter(Waiter _waiter)
        {
            this.currenwaiter = _waiter;
        }

        /// <summary>
        /// Setter for the table's waiting time.
        /// </summary>
        /// <param name="_waitingtime">Desired waiting time, as an integer.</param>
        public void setWaitTime(int _waitingtime)
        {
            this.waitingtime = _waitingtime;
        }

    }
}
