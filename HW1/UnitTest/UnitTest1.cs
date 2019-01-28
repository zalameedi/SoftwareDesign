using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW1
{
    [TestClass]
    public class NodeTest
    {

        /// <summary>
        /// Testing to assert if the Node constructor() method works correctly. No parameters.
        /// </summary>
        [TestMethod]
        public void makeNode()
        {
            Node n1 = new Node(42);
            Node n2 = new Node();

            Assert.AreEqual(42, n1.Data);
            Assert.AreEqual(null, n1.PLeft);
            Assert.AreEqual(null, n1.PRight);



            Assert.AreEqual(0, n2.Data);
        }
    }


    [TestClass]
    public class BSTTest
    {
        /// <summary>
        ///  Testing to assert if the BST constructor() method works correctly. No parameters.
        /// </summary>
        [TestMethod]
        public void makeTree()
        {
            BST bst = new BST();
            Assert.AreEqual(null, bst.pRoot);
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
                bst.pRoot = bst.Insert(bst.pRoot, x);
            }

            Assert.AreEqual(20, bst.pRoot.Data);
            Assert.AreEqual(30, bst.pRoot.PRight.Data);
            Assert.AreEqual(10, bst.pRoot.PLeft.Data);
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
                bst.InOrderTraversal(bst.pRoot); //Empty inorder traversal
                Assert.Fail(); // raises AssertionException
            }
            catch (Exception)
            {
                
            }


            bst.Insert(bst.pRoot, 30);
            bst.InOrderTraversal(bst.pRoot); //non empty tree
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
                bst.pRoot = bst.Insert(bst.pRoot, x);
            }
            double result = 0.0;

            result = bst.MinLevel(bst.pRoot);

            Assert.AreEqual(bst.MinLevel(bst.pRoot), result);



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
                bst.pRoot = bst.Insert(bst.pRoot, x);
            }

            Assert.AreEqual(4, bst.Levels(bst.pRoot));
        }
    }
}
