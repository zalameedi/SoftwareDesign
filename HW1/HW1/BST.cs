using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class BST
    {
        public Node pRoot { get; set; }
        public int Count { get; set; } //Counting the height of the Tree for later

        /// <summary>
        /// Default Constructor for the binary search tree
        /// </summary>
        public BST()
        {
            pRoot = null;
        }

        /// <summary>
        /// Insert - Checks to see if pRoot is empty (Tree is empty) if so initialize it as the first node to be inserted. 
        /// Then begins to check if it belongs on the right side (meaning data is greater) so it checks the child of the root first then recursively its branch respectively if no spot is found.
        /// Likewise for the left side. Must return node so it can recursively be called to return next node when going through branches.
        /// </summary>
        /// <param name="pRoot">Pass in the head or root of the tree</param>
        /// <param name="mdata">New data to be inserted</param>
        /// <returns></returns>
        public Node Insert(Node pRoot, int mdata)
        {
            if (pRoot == null)
            {
                pRoot = new Node(mdata);
            }
            else if (pRoot.Data < mdata)
            {
                if (pRoot.PRight == null)
                {
                    pRoot.PRight = new Node(mdata);
                }
                else
                {
                    pRoot.PRight = Insert(pRoot.PRight, mdata);
                }
            }
            else if (pRoot.Data > mdata)
            {
                if (pRoot.PLeft == null)
                {
                    pRoot.PLeft = new Node(mdata);
                }
                else
                {
                    pRoot.PLeft = Insert(pRoot.PLeft, mdata);
                }
            }
            return pRoot;
            }


        /// <summary>
        /// inOrderTraversal checks to see if Tree is empty, then recursively prints left branch then right branch is data entries.
        /// </summary>
        /// <param name="node">Indicating the current node to be worked on... Could be called root as well</param>
        public void InOrderTraversal(Node node)
        {
            try
            {
                if(node == null)
                {
                    return;
                }
                else
                InOrderTraversal(node.PLeft);
                Console.Write(node.Data + " ");
                InOrderTraversal(node.PRight);
                this.Count++;
            }

            catch(Exception)
            {
                Console.WriteLine("The tree is empty.");
            }
        }

        /// <summary>
        /// Returns the minimum level of tree when comparing left side or right side. This was more clever and accurate then
        /// the formula found online was floor(log_2(n)) will give the minimum but didn't seem to return the results I was expecting.
        /// This seems to pass most edge cases however.
        /// </summary>
        /// <param name="root">Starts counting from the below the root passed in.</param>
        /// <returns></returns>
        ///Found the formula https://cs.stackexchange.com/questions/6277/why-is-the-minimum-height-of-a-binary-tree-log-2n1-1
        public double MinLevel(Node root)
        {
            if (root != null)
                return Math.Ceiling(Math.Log(Count) + 1);
            return 0;
        }

        /// <summary>
        /// Finds the depth of the tree (how far down it goes) returns the number incremented.
        /// </summary>
        /// <param name="root">Starts from the root then counts below</param>
        /// <returns></returns>
        public int Levels(Node root)
        {
            int result = 0;
            if (root != null)
                return 1 + Math.Max(Levels(root.PLeft), Levels(root.PRight)); //calculates which ever one has the higher depth then returns it

            return result;
        }

    }
    }


