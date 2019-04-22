using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zeid_Al_Ameedi_11484180_CptS321_HW11
{
    [TestClass]
    public class NodeTest
    {
        /// <summary>
        /// Testing to assert if the Node constructor() method works correctly. No parameters.
        /// </summary>
        [TestMethod]
        public void MakeNode()
        {
            Node n1 = new Node(42);
            Node n2 = new Node();

            Assert.AreEqual(42, n1.Data);
            Assert.AreEqual(null, n1.PLeft);
            Assert.AreEqual(null, n1.PRight);
            Assert.AreEqual(0, n2.Data);
        }
    }
}
