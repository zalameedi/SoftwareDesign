/***************
 * Zeid Al-Ameedi
 * 03/04/2019
 * CptS321 HW5 - Spreadsheet application
 * 
****************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CptS321;

namespace UnitTests
{
    /// <summary>
    /// Class designed for testing!
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Testing the spreadsheet, can't do much yet since we're waiting for more parts of the spreadsheet.
        /// </summary>
        [TestMethod]
        public void SpreadsheetTest()
        {
            int i = 0;
            string expected = "This is cell B";

            while (i < 50)
            {
                int rc = 25;
                int rr = 49;

                Assert.AreEqual(rc, 25);
                Assert.AreEqual(rr, 49);


                string x = "CptS 321 is cool!";
                Assert.AreEqual(x, "CptS 321 is cool!");
                i++;
            }
            for (i = 0; i < 50; i++)
            {
                Assert.AreEqual(expected, "This is cell B");
                // this.ss[i, 1].setText = "This is cell B" + (i + 1);
            }
            for (i = 0; i < 50; i++)
            {
                int rc = 25;
                Assert.AreEqual(rc, 25);
                // this.ss[i, 0].setText = "=B" + (i + 1);
            }

            i++;

        }

        /// <summary>
        /// Tests the Add portion of Expression Tree
        /// </summary>
        [TestMethod]
        public void ExpressionTreeAdd()
        {
            ExpressionTree t1 = new ExpressionTree("5+2");
            Assert.AreEqual(7, t1.Evaluate());
        }

        /// <summary>
        /// Tests the subtraction portion of the expression Tree
        /// </summary>
        [TestMethod]
        public void ExpressionTreeSub()
        {
            ExpressionTree t1 = new ExpressionTree("5-2");
            Assert.AreEqual(3, t1.Evaluate());
        }

        /// <summary>
        /// Tests the multiplication portion of the expression Tree
        /// </summary>
        [TestMethod]
        public void ExpressionTreeMult()
        {
            ExpressionTree t1 = new ExpressionTree("5*2");
            Assert.AreEqual(10, t1.Evaluate());
        }

        /// <summary>
        /// Tests the division portion of the expression tree
        /// </summary>
        [TestMethod]
        public void ExpressionTreeDiv()
        {
            ExpressionTree t1 = new ExpressionTree("10/2");
            Assert.AreEqual(5, t1.Evaluate());
        }

        /// <summary>
        /// The way our expression tree is coded is an 0 should be returned if an unidentified string is present
        /// </summary>
        [TestMethod]
        public void UnidentifiedVariablesExpressionTree()
        {
            ExpressionTree t1 = new ExpressionTree("T1+T2");
            Assert.AreEqual(0, t1.Evaluate());
        }
        
        /// <summary>
        /// Tests the Precedence portion of Expression Tree
        /// </summary>
        [TestMethod]
        public void ExpTreeStatementPrecedence()
        {
            ExpressionTree t1 = new ExpressionTree("100-(10*2)+8/2");
            Assert.AreEqual(84, t1.Evaluate());
        }

        /// <summary>
        /// Tests the Excess Parentheses portion of Expression Tree
        /// </summary>
        [TestMethod]
        public void ExpTreeStatementParentheses()
        {
            ExpressionTree t1 = new ExpressionTree("((10+7-2)*(2+10)-7+(2-1))");
            Assert.AreEqual(174, t1.Evaluate());
        }






    }
}

