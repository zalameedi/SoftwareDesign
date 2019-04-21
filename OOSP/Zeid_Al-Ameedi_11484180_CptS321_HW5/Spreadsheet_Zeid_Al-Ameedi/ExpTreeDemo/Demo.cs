/***************
 * Zeid Al-Ameedi
 * 03/04/2019
 * CptS321 HW5 - Spreadsheet application
 * 
****************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spreadsheet;
using CptS321;

namespace ExpTreeDemo
{
    class Demo
    {
        static void Main(string[] args)
        {
            ExpressionTree et = new ExpressionTree("A1+B1+C1");
            int choice = 0;
            while (choice != 4)
            {
                Console.WriteLine("Menu (current expression: {0})", et.expression);
                Console.WriteLine("\t1 = Enter a new expression");
                Console.WriteLine("\t2 = Set a variable value");
                Console.WriteLine("\t3 = Evaluate tree");
                Console.WriteLine("\t4 = Quit");
                var input = Console.ReadLine();
                try
                {
                    Convert.ToInt32(input);
                }
                catch
                {
                    input = "10"; // Safe code incase the user wants to enter some corrupt data
                }

                switch (Convert.ToInt32(input))
                {
                    case 1:
                        Console.Write("Enter new expression: ");
                        var temp = Console.ReadLine();
                        et = new ExpressionTree(temp);
                        break;
                    case 2:
                        Console.Write("Enter variable name: ");
                        var old = Console.ReadLine();
                        Console.Write("Enter variable value: ");
                        var newv = Console.ReadLine();
                        et.SetVariable(old, Convert.ToDouble(newv));
                        break;
                    case 3:
                        Console.WriteLine("\nTree Evaluate = {0}\n", et.Evaluate());
                        break;
                    case 4:
                        choice = 4;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Done");
        }
    }
}
