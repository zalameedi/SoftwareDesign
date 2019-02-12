using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//// Zeid Al-Ameedi
//// 11484180
/// HW3

namespace UnitTests
{
    /// <summary>
    /// Test for our fib sequence
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests our Fibonacci algorithm on 11, since those fib numbers are usually known by heart
        /// </summary>
        [TestMethod]
        public void FibTest()
        {
            List<int> tempFib = new List<int>
            {
                0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55
            };

            List<int> myLst = new List<int>();

            for (int i = 0; i < 11; i++)
            {
                myLst.Add(PrivateHelper(i));
                Assert.AreEqual(myLst[i], tempFib[i]);
            }
        }

        /// <summary>
        /// Method to call our logic for the fib generator
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        int PrivateHelper(int max)
        {
            int firstnumber = 0, secondnumber = 1, result = 0;

            if (max == 0)
            {
                return 0;

            }
            if (max == 1)
            {
                return 1;
            }
            for (int i = 2; i <= max; i++)
            {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }

            return result;
        }
    }
}
