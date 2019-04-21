using System.Text;
using System.IO;
using System.Numerics;

//// Zeid Al-Ameedi
//// 11484180

namespace HW3
{
    class FibonacciTextReader : TextReader
    {
        private int maxLines;

        /// <summary>
        /// Property for the maxLines variable to get/set
        /// </summary>
        public int MaxLines
        {
            get { return maxLines; }
            set { maxLines = value; }
        }

        /// <summary>
        /// Default constructor, zero arguments
        /// </summary>
        public FibonacciTextReader()
        {
            MaxLines = 0;
        }

        /// <summary>
        /// Constructor that sets maxLines to num that we pass in. 
        /// </summary>
        /// <param name="num"></param>
        public FibonacciTextReader(int num)
        {
            MaxLines = num;
        }

        /// <summary>
        /// ReadLines from the calculation consecutively until our num is reached
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private string ReadLine(int n)
        {
            BigInteger BigNum = calculate(n);
            return BigNum.ToString();
        }

        /// <summary>
        /// Overrides the previous Textwriter readtoend, this way the object has a unique way of writing our data
        /// </summary>
        /// <returns></returns>
        override public string ReadToEnd()
        {
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < maxLines; i++)
            {
                temp.AppendLine((i + 1) + ": " + ReadLine(i));
            }
            return temp.ToString();
        }

        /// <summary>
        /// Calculation, done in fibonnacci sequence. Algorithm assistance from geeksforgeeks/fibonacci/C++
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private BigInteger calculate(int max)
        {
            BigInteger firstnumber = 0, secondnumber = 1, result = 0;

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
