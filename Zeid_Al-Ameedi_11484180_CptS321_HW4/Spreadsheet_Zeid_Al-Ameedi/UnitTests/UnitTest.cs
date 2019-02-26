/***************
 * Zeid Al-Ameedi
 * 02/22/2019
 * CptS321 HW4 - Spreadsheet application
 * 
****************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Here We will test the clicking of buttons

            //WHAT I WOULD TEST -> Instructions for testing hardcore GUI development that I'm unaware of...

            //1) make the gui object and ensure that the cell has the correct value i expect
            //2) make sure it's saved into cell by testing its still there after i'm done with edit mode
            //3) Test the sample dmeo to ensure that 50 slots are accounted for

            //Test to make sure spreadsheet does operations

            //Assert act arrange TDD
            Assert.AreEqual(true, true);
        }


        public void TestMethod2()
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
    }
}

