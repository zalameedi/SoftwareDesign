using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            // Create multiple methods for functions
            Assert.Pass("Your first passing test");
        }

        [Test]
        public void MakeNode()
        {
            Node n1 = new Node();

            Assert.AreNotEqual(null, n1);
        }
    }
}
