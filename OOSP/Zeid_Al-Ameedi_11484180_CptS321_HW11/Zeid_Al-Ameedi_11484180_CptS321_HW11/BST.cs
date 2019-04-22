using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeid_Al_Ameedi_11484180_CptS321_HW11
{
    public class BST
    {
        public Node Root { get; set; }
        public int Count { get; set; } //Counting the height of the Tree for later

        /// <summary>
        /// Default Constructor for the binary search tree
        /// </summary>
        public BST()
        {
            Root = null;
        }

        /// <summary>
        /// Insert - Checks to see if Root is empty (Tree is empty) if so initialize it as the first node to be inserted. 
        /// Then begins to check if it belongs on the right side (meaning data is greater) so it checks the child of the root first then recursively its branch respectively if no spot is found.
        /// Likewise for the left side. Must return node so it can recursively be called to return next node when going through branches.
        /// </summary>
        /// <param name="root">Pass in the head or root of the tree</param>
        /// <param name="mdata">New data to be inserted</param>
        /// <returns></returns>
        public Node Insert(Node root, int mdata)
        {
            if (root == null)
            {
                root = new Node(mdata);
            }
            else if (root.Data < mdata)
            {
                if (root.PRight == null)
                {
                    root.PRight = new Node(mdata);
                }
                else
                {
                    root.PRight = Insert(root.PRight, mdata);
                }
            }
            else if (root.Data > mdata)
            {
                if (root.PLeft == null)
                {
                    root.PLeft = new Node(mdata);
                }
                else
                {
                    root.PLeft = Insert(root.PLeft, mdata);
                }
            }
            return root;
        }

        /// <summary>
        /// inOrderTraversal checks to see if Tree is empty, then recursively prints left branch then right branch is data entries.
        /// </summary>
        /// <param name="node">Indicating the current node to be worked on... Could be called root as well</param>
        public void InOrderTraversal(Node node)
        {
            try
            {
                if (node == null)
                {
                    return;
                }
                else
                    InOrderTraversal(node.PLeft);
                Console.Write(node.Data + " ");
                InOrderTraversal(node.PRight);
                this.Count++;
            }
            catch (Exception)
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

        /// <summary>
        /// This inorder traversal will be the standard method of printing.
        /// Two recursive calls that grab all the left+right branch and print them out
        /// Will be used to ensure other methods are met to our standards
        /// </summary>
        /// <param name="node"></param>
        public void InOrderTraversal1(Node node)
        {
            try
            {
                if (node == null)
                {
                    return;
                }
                else
                    InOrderTraversal(node.PLeft);
                Console.Write(node.Data + " ");
                InOrderTraversal(node.PRight);
            }
            catch (Exception)
            {
                Console.WriteLine("The tree is empty.");
            }
        }

        /// <summary>
        /// Method 2 of our InOrderTraversal
        /// This is different in the sense that no recursion is present.
        /// The use of stack is implemented that simply uses a flag to indicate all nodes were accounted for.
        /// The stack will push everything on the left, pop everything (same for right) and read it.
        /// Once done the flag is set to true and loop ends
        /// </summary>
        /// <param name="root"></param>
        public void InOrderTraversal2(Node root)
        {
            bool flag = false;
            Stack<Node> treeStack = new Stack<Node>();
            Node cur = new Node();
            cur = root;

            while (flag != true)
            {
                if (cur != null)
                {
                    treeStack.Push(cur);
                    cur = cur.PLeft;
                }
                else
                {
                    if (treeStack.Count != 0)
                    {
                        cur = treeStack.Pop();
                        Console.Write(cur.Data + " ");
                        cur = cur.PRight;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
        }

        public void InOrderTraversal3(Node root)
        {
            Node cur = new Node();
            cur = root;
            Node prev = new Node();

            while (cur != null)
            {
                if (cur.PLeft == null)
                {
                    Console.Write(cur.Data + " ");
                    cur = cur.PRight;
                }
                else
                {
                    prev = cur.PLeft;
                    while (prev.PRight != null && prev.PRight != cur)
                    {
                        prev = prev.PRight;
                    }
                    if (prev.PRight == null)
                    {
                        prev.PRight = cur;
                        cur = cur.PLeft;
                    }
                    else
                    {
                        prev.PRight = null;
                        Console.Write(cur.Data + " ");
                        cur = cur.PRight;
                    }
                }
            }
        }
    }
}
