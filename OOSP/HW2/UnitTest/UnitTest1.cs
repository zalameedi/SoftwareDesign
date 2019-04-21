using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    /// <summary>
    /// Unit tests that will test the 3 algorithms to make sure that they really get the unique count of a list full of duplicates.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testing algorithm 1. Involving a hash set or dictionary with unique keys, avoids duplicates
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            List<int> myLst = new List<int>
            { 10, 20, 30, 30, 30, 40, 40, 50, 60, 70, 70, 80, 90, 100, 10 }; //List with 10 unique values

            int expected = 10;

            int index = 1;
            Dictionary<int, int> hashDict = new Dictionary<int, int>();

            foreach (int s in myLst)
            {
                if (!hashDict.ContainsKey(s))
                {
                    hashDict.Add(s, index); //Keys will be unique, index is just a placeholder for value
                }
            }

            Assert.AreEqual(expected, hashDict.Count());
        }

        /// <summary>
        /// Testing algorithm 2, which involves two for loops checking a value vs entire list one at a time.
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            List<int> myLst = new List<int>
            {
                10, 20, 30, 30, 30, 40, 40, 50, 60, 70, 70, 80, 90, 100, 10
            }; //List with 10 unique values

            int expected = 0; //should be 10 when done
            int answer = 10;

            for (int i = 0; i < myLst.Count(); i++)
            {
                bool duplicate = false;
                for (int m = i + 1; m < myLst.Count(); m++) //i+1 is important as it allows you to stay ahead of the loop
                {
                    if (myLst[i] == myLst[m])
                    {
                        duplicate = true;
                    }
                }

                if (!duplicate) //If no duplicate is found just increment and move forward
                {
                    expected++;
                }
            }

            Assert.AreEqual(expected, answer);
        }

        /// <summary>
        /// Algorithm 3 involving the built-in sorting algorithm is built and tested here.
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            List<int> myLst = new List<int>
            {
                10, 20, 30, 30, 30, 40, 40, 50, 60, 70, 70, 80, 90, 100, 10
            }; //List with 10 unique values            
            int expected = 10;
            int answer = 0;
            int j = 1;
            int result = 0;
            try
            {
                for (int i = 0; i < myLst.Count(); i++)
                {
                    if (myLst[i] != myLst[j])
                    {
                        answer++;
                    }

                    j++;
                }
            }
            catch (Exception)
            {
                result = answer;
            }

            Assert.AreEqual(expected, result);
        }
    }
}
