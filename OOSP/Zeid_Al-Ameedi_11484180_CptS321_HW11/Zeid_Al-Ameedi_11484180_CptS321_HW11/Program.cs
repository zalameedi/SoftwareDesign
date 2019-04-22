using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeid_Al_Ameedi_11484180_CptS321_HW11
{
    class Program
    {
        /// <summary>
        /// Main program that contains all the logic for our program.
        /// Creates new tree and calls all three of the new inorder trav methods
        /// in the order of 3,2,1 then prompts user for again?
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string option = "y";

            while (option != "n")
            {
                List<int> myLst = new List<int>();
                string usrList = String.Empty;
                BST myTree = new BST();
                Random random = new Random();

                int randomNum = random.Next(20, 30);
                for (int i = 0; i <= randomNum; i++)
                {
                    myTree.Root = myTree.Insert(myTree.Root, random.Next(0, 101));
                }

                //3
                Console.WriteLine("Traversal of the tree with NO Stack and NO recursion.");
                myTree.InOrderTraversal3(myTree.Root);
                Console.WriteLine();

                //2
                Console.WriteLine("Traversal of the tree with Stack and NO recursion.");
                myTree.InOrderTraversal2(myTree.Root);
                Console.WriteLine();

                //1
                Console.WriteLine("Traversal of the tree with recursion.");
                myTree.InOrderTraversal1(myTree.Root);
                Console.WriteLine();

                //Prompt user for option//
                Console.WriteLine("Again? (y/n)");
                option = Console.ReadLine().ToLower();
            }
        }
    }
}
