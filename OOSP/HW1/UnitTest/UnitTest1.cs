using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW1
{   
    [TestClass]
    public class BSTTest
    {
        /// <summary>
        ///  Testing to assert if the BST constructor() method works correctly. No parameters.
        /// </summary>
        [TestMethod]
        public void MakeTree()
        {
            BST bst = new BST();
            Assert.AreEqual(null, bst.Root);
        }

        /// <summary>
        ///  Testing to assert if the Insert() method works correctly. No parameters.
        /// </summary>
        [TestMethod]
        public void InsertTest()
        {
            BST bst = new BST();
            List<int> myLst = new List<int>();
            myLst.Add(20);
            myLst.Add(30);
            myLst.Add(10);
            foreach(int x in myLst)
            {
                bst.Root = bst.Insert(bst.Root, x);
            }

            Assert.AreEqual(20, bst.Root.Data);
            Assert.AreEqual(30, bst.Root.PRight.Data);
            Assert.AreEqual(10, bst.Root.PLeft.Data);
        }

        /// <summary>
        ///  Testing to assert if the InOrderTraversal() method works correctly. No parameters.
        /// </summary>
        [TestMethod]
        public void InOrderTest()
        {
            BST bst = new BST();
            try
            {
                bst.InOrderTraversal(bst.Root); //Empty inorder traversal
                Assert.Fail(); // raises AssertionException
            }
            catch (Exception)
            {}
            bst.Insert(bst.Root, 30);
            bst.InOrderTraversal(bst.Root); //non empty tree
            Assert.IsNotNull(bst);
        }
        /// <summary>
        ///  Testing to assert if the MinLevels() method works correctly. No parameters.
        /// </summary>
        [TestMethod]
        public void MinLevelTest()
        {
            BST bst = new BST();
            List<int> myLst = new List<int>
            {
                20,
                30,
                15,
                1,
                5,
                55,
                600,
                43
            };
            foreach (int x in myLst)
            {
                bst.Root = bst.Insert(bst.Root, x);
            }
            double result = 0.0;

            result = bst.MinLevel(bst.Root);

            Assert.AreEqual(bst.MinLevel(bst.Root), result);
        }
        /// <summary>
        /// Testing to assert if the Levels() method works correctly. No parameters.
        /// </summary>
        [TestMethod]
        public void LevelsTest()
        {
            BST bst = new BST();
            List<int> myLst = new List<int>
            {
                20,
                30,
                15,
                1,
                5,
                55,
                600,
                43
            };
            foreach (int x in myLst)
            {
                bst.Root = bst.Insert(bst.Root, x);
            }

            Assert.AreEqual(4, bst.Levels(bst.Root));
        }
    }
}
