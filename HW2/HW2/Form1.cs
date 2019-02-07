using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form1_Load is a function that utilizes three different algorithms. The algorithms revolve around a list that is
        /// holding 10k random integers. The first being a hashset that checks to see if that value is present as a key, it will not add a duplicate into its dictionary.
        /// The second being a bad time complexity algorithm that sticks to O(1) time and uses O(1) storage. It does so by two for loops that compare. The third algorithm uses the built
        /// in sort algorithm, then compares itself to the value next to it (obviously duplicates would be present) then loops through it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            int method1 = 0, method2 = 0, method3 = 0;

            List<int> randomList = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 10000; i++)
            {
                randomList.Add(rnd.Next(0, 20000));
            }

            //Method 1: Hashset 
            int index = 1;
            Dictionary<int, int> hashDict = new Dictionary<int, int>();
            
            foreach (int s in randomList)
            {
                if (!hashDict.ContainsKey(s))
                    hashDict.Add(s, index); //Keys will be unique, index is just a placeholder for value
            }

            method1 = hashDict.Count();
            string s1 = "1. HashSet method: " + method1 + Environment.NewLine + "Let's breakdown the time complexity. Looping through the list in order to check whether or not" +
                " a key is present in the dictionary is O(n)." + Environment.NewLine + "However the operation of calling Hash.Contains is O(1) and adding is O(1). If rehashing is required it becomes O(n) [adding]. Assuming so it's O(n^2) however final answer it's O(n)." + Environment.NewLine + "SOURCE: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1.contains?view=netframework-4.7.2" + Environment.NewLine
                + Environment.NewLine;
            textBox1.Text += s1;

            //Method 2: O(1) storage complexity, terrible iteration and slow however
            //method2 = randomList.Distinct().Count(); CANNOT USE DISTINCT      

            for (int i = 0; i < randomList.Count(); i++)
            {
                bool duplicate = false;
                for (int m = i + 1; m < randomList.Count(); m++) //i+1 is important as it allows you to stay ahead of the loop
                {
                    if (randomList[i] == randomList[m])
                    {
                        duplicate = true;
                    }
                }

                if (!duplicate) //If no duplicate is found just increment and move forward
                    method2++;
            }

            string s2 = "2. O(1) storage method: " + method2 + Environment.NewLine;
            textBox1.Text += s2;

            //Method 3
            randomList.Sort(); //O(n)
            int j = 1;
            int result = 0;
            try
            {
                for (int i = 0; i < randomList.Count(); i++)
                {
                    if (randomList[i] != randomList[j])
                        method3++;
                    j++;
                }
            }
            catch (Exception)
            {
                result = method3 + 1; //Last increment after j goes out of bounds.
            }

            string s3 = "3. Sorted list method: " + result + Environment.NewLine;
            textBox1.Text += s3;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }
    }
}
