using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actors
{
    /// <summary>
    /// Some refactoring might be necessary; I don't know if this should be exclusively inside the Actors package/namespace...
    /// Workdays include a start time, an endtime, and a timespan of working hours.
    /// </summary>
    class WorkDay
    {

        // Workday fields.
        private double starttime;
        private double endtime;
        private TimeSpan timespan;

        // Constructors //

        /// <summary>
        /// WorkDay constructor taking a start time and an end time. Timespan is calculated appropriately.
        /// </summary>
        /// <param name="_starttime">start time (between 00.00 and 24.60)</param> 
        /// <param name="_endtime">end time (between 00.00 and 24.60)</param> 
        public WorkDay (double _starttime, double _endtime)
        {
            // Might need to add some checks to make sure 00.00 <= start/end time <= 24.60
            this.starttime = _starttime;
            this.endtime = _endtime;
            calculateTimeSpan();
        }

        /// <summary>
        /// WorkDay constructor taking a start time and a timespan. End time is calculated appropriately.
        /// </summary>
        /// <param name="_starttime">start time (between 00.00 and 24.60)</param> 
        /// <param name="_timespan">built-in C# TimeSpan, the timespan of work hours.</param> 
        public WorkDay (double _starttime, TimeSpan _timespan)
        {
            this.starttime = _starttime;
            this.timespan = _timespan;
            calculateEndTime();
        }

        // Getters //

        /// <summary>
        /// Getter for starttime
        /// </summary>
        /// <returns>start time as a double. Form: hours.minutes</returns>
        public double getStartTime()
        {
            return this.starttime;
        }

        /// <summary>
        /// Getter for endtime
        /// </summary>
        /// <returns>end time as a djouble. Form: hours.minutes</returns>
        public double getEndTime()
        {
            return this.endtime;
        }

        /// <summary>
        /// Getter for timespan
        /// </summary>
        /// <returns>TimeSpan of workhours.</returns>
        public TimeSpan getTimeSpan()
        {
            return this.timespan;
        }

        // Setters //

        /// <summary>
        /// Set the starttime.
        /// End time remains the same, but timespan is adjusted accordingly.
        /// </summary>
        /// <param name="_starttime">The desired start time as a double. Format: hours.minutes</param>
        public void setStartTime(double _starttime)
        {
            this.starttime = _starttime;
            calculateTimeSpan();
        }

        /// <summary>
        /// Set the endtime.
        /// Start time remains the same, but timespan is adjusted accordingly.
        /// </summary>
        /// <param name="_endtime">The desired end time as a double.  Format: hours.minutes</param>
        public void setEndtime(double _endtime)
        {
            this.endtime = _endtime;
            calculateTimeSpan();
        }

        /// <summary>
        /// Set the timespan of working hours.
        /// Start time remains the same, but endtime is adjusted accordingly.
        /// </summary>
        /// <param name="_timespan">The desired timespan.</param>
        public void setTimeSpan(TimeSpan _timespan)
        {
            this.timespan = _timespan;
            calculateEndTime();
        }

        // private methods //

        /// <summary>
        /// Private method used to calculate the endtime field based off of the timespan and start time.
        /// </summary>
        private void calculateEndTime ()
        {
            // Get the timespan as a double of hours.minutes. I.e. 2 hours 15 mintues = 02.15
            double _hours = (double)timespan.Hours;
            double _minutes = (double)timespan.Minutes;
            double _timespandouble = _hours + (_minutes/100);
            // Calc endtime.
            this.endtime = (this.starttime) + _timespandouble;
        }

        /// <summary>
        /// Private method used to calculate the timespan field based off of the start and end times.
        /// </summary>
        private void calculateTimeSpan ()
        {
            // Get the hours and minutes as integers.
            double _sub = (this.endtime) - (this.starttime);
            int _hours = (int)_sub;
            int _minutes = doubleDecimal(_sub);
            // New timespan (days, HOURS, MINUTES)
            this.timespan = new TimeSpan(0, _hours, _minutes);
        }

        /// <summary>
        /// Private method which grabs the first two decimal places of a double and returns them as an int.
        /// </summary>
        /// <param name="_double">Double who's decimals you want.</param> 
        /// <returns>The first two decimal places as an integer.</returns>
        private int doubleDecimal (double _double)
        {
            // Thank you to one paticularly helpful user on stackoverflow for this implementation
            // of this function!
            // https://stackoverflow.com/questions/13038482/get-the-decimal-part-from-a-double
            var first2DecimalPlaces = (int)(((decimal)_double % 1) * 100);
            return first2DecimalPlaces;
        }

    }
}
