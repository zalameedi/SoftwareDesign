using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Node()
        {
            Node n1 = new Node(42);
            Assert.AreEqual(42, n1.data);
        }
    }
}
