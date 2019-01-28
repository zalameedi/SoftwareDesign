/*
 * Programmer: Zeid Al-Ameedi
 * Date: 01/22/2019
 * PA: Binary Search Tree in C# 
 * Resources: Microsofts C# netframe tutorial
 * + Microsofts C# tutorial on Binary search trees (specifically reminding myself of inOrderTraversals and refrence usage
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Program
    {
        /// <Main>
        /// Main function where everything is essentially run and called.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<string> myLst = new List<string>(); //List to hold input from user
            string usrList = String.Empty;
            BST myTree = new BST();

            Console.WriteLine("Please enter a list of integers seperated by spaces [0,100]: \n"); //Get string from user
            usrList = Console.ReadLine();
            Console.Write("\n");
            myLst = usrList.Split(' ').ToList(); //Splits the string into a List of strings 

            foreach (string temp in myLst.Distinct()) //Iterate through each string in the List<strings> **** Distinct will make sure the list is unique
            {
                int result = 0;
                if (int.TryParse(temp, out int value)) //Parse string into an integer
                {
                    result = value;
                    myTree.pRoot = myTree.Insert(myTree.pRoot, result);
                }
            }

            //Stats
            Console.WriteLine("\nTree Stats: \n");
            Console.Write("inOrder Traversal: ");
            myTree.InOrderTraversal(myTree.pRoot);
            Console.WriteLine("\n   Number of nodes: " + myTree.Count);
            Console.WriteLine(String.Format("   Height of tree: {0}", myTree.Levels(myTree.pRoot)));
            Console.WriteLine(String.Format("   Theoretical: Minimum levels for a tree with {0} nodes is {1}\n", myTree.Count, myTree.MinLevel(myTree.pRoot)));
            Console.WriteLine("\n");
            Console.WriteLine("Program complete.\n");
        }
    }
}
