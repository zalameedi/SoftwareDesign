using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenue
{
    public class Amount
    {
        public String dateRange;
        
        //profit = totalReceived - taxes - costToMakeMeal
        public double profit;

        public double tips;

        public double taxes;

        //calculated when entering in each order
        public double costToMakeMeal;

        public double totalReceived;

        //private bool type; //if true, then its daily. if false, then its weekly, monthly, or yearly

        public Amount(double TotalReceived, double Tips, double Taxes, double CostToMakeMeal)
        {
            dateRange = getDate();
            totalReceived = TotalReceived;
            tips = Tips;
            taxes = Taxes;
            costToMakeMeal = CostToMakeMeal;
            profit = totalReceived - taxes - costToMakeMeal;
        }

        private String getDate()
        {
            return DateTime.Now.ToString("MM/dd/yyyy");
        }

        public void addToAmount(Amount add, bool type)//if type is true, then it is daily so the dates are not a range
        {
            totalReceived += add.totalReceived;
            tips += add.tips;
            taxes += add.taxes;
            costToMakeMeal += add.costToMakeMeal;
            profit += add.totalReceived - add.taxes - add.costToMakeMeal;

            if (!type)
            {
                dateRange.Remove(10, dateRange.Length - 1);
                dateRange = dateRange + " to " + add.dateRange;
            }
        }
    }
}
