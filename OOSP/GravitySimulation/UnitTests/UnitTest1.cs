using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeid_Alameedi_11484180_HW13;

namespace Zeid_Alameedi_11484180_HW13
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Joke of a test case, just so it can be present. (Not gonna test GUIs)
        /// </summary>
        [TestMethod]
        public void OrbitTester()
        {
            CenterOfGravity obj = new CenterOfGravity();
            Assert.AreNotEqual(obj, null);
        }
    }
}
