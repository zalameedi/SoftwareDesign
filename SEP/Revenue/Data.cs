using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenue
{
    public static class Data
    {
        public static List<Amount> dailyRevenue;

        public static List<Amount> weeklyRevenue;

        public static List<Amount> monthlyRevenue;

        public static List<Amount> yearlyRevenue;

        public static void makeNewTimePeriod(String dataRange, int type)
        {
            //every day call this function. this will create a new day, week, month, year
            dailyRevenue.Add(new Amount(0, 0, 0, 0));
            //new week
            if(DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                weeklyRevenue.Add(new Amount(0, 0, 0, 0));
            }
            //new month
            if (DateTime.Now.Day == 1)
            {
                monthlyRevenue.Add(new Amount(0, 0, 0, 0));
            }
            //new year
            if((DateTime.Now.Month == 1) && (DateTime.Now.Day == 1))
            {
                yearlyRevenue.Add(new Amount(0, 0, 0, 0));
            }
        }

        //finish this one
        public static void addOneMealRevenue(Amount paymentReceived)
        {
            if((dailyRevenue == null) || (paymentReceived.dateRange != dailyRevenue[dailyRevenue.Count - 1].dateRange))
            {
                dailyRevenue.Add(paymentReceived);
            }
            else
            {
                dailyRevenue[dailyRevenue.Count - 1].addToAmount(paymentReceived, true);
                weeklyRevenue[weeklyRevenue.Count - 1].addToAmount(paymentReceived, false);
                monthlyRevenue[monthlyRevenue.Count - 1].addToAmount(paymentReceived, false);
                yearlyRevenue[yearlyRevenue.Count - 1].addToAmount(paymentReceived, false);
            }
        }
    }
}
