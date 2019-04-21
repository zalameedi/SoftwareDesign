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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// The expression tree class. This tree is used to host nodes that are either operators or operands.
    /// It uses a dictionary to store variable names/values when assigning a var.
    /// The tree builds expressions so far and will be worked on since this is only the 2nd part of the assignment.
    /// </summary>
    public class ExpressionTree
    {
        private Node root;
        public static Dictionary<string, double> var = new Dictionary<string, double>();
        public string expression { get; private set; }

        /// <summary>
        /// Constructor that clears the dictionary and builds a tree with some default expression.
        /// </summary>
        /// <param name="expression"></param>
        public ExpressionTree(string expression)
        {
            var.Clear();
            this.expression = expression;
            BuildTree(expression);
        }

        /// <summary>
        /// KEEP IN MIND. All nodes will get their own class but for now they're not coupled correctly because I cannot get reflection
        /// to work. Will make sure I get it done in HW6. This way I can spend more time understanding LINQ and reflection.
        /// This is the abstract class Node with a method to be overriden that evaluates an expression.
        /// </summary>
        private abstract class Node
        {
            public abstract double Evaluate();
        }

        /// <summary>
        /// Variable node that grabs the dictionarys value when provided a key [name] and returns it. If not available it'll return a 0.
        /// </summary>
        private class VariableNode : Node
        {
            string name = string.Empty;
            double val = 0.0;
            public VariableNode(string name)
            {
                this.name = name;
                val = 0.0;
            }

            /// <summary>
            /// Overriden evaluate that extracts from the dictionary and returns it. Helper function!
            /// </summary>
            /// <returns></returns>
            public override double Evaluate()
            {
                try
                {
                    val = var[name];
                }
                catch (KeyNotFoundException)
                {
                    val = 0.0;
                }
                return val;
            }
        }

        /// <summary>
        /// Operator Node. ALSO WILL GET IT'S OWN CLASS IN THE FUTURE. For now it
        /// uses basic logical operators to find the correct operand implementation. Returns that operation between the LHS and RHS of tree.
        /// Only supports 1 operation for instance (x OP y) that's it FOR NOW.
        /// </summary>
        private class OperatorNode : Node
        {
            public Node left, right;
            char operand;
            public OperatorNode(char x)
            {
                operand = x;
                left = null;
                right = null;
            }
            public override double Evaluate()
            {
                if (operand == '+')
                {
                    return this.left.Evaluate() + this.right.Evaluate();
                }
                else if (operand == '-')
                {
                    return this.left.Evaluate() - this.right.Evaluate();
                }
                else if (operand == '*')
                {
                    return this.left.Evaluate() * this.right.Evaluate();
                }
                else if (operand == '/')
                {
                    return this.left.Evaluate() / this.right.Evaluate();
                }
                else
                {
                    return 0.0;
                }
            }
        }

        /// <summary>
        /// Value node class used for the return of a value from dictionary, remember each node will get a class.
        /// </summary>
        private class ValueNode : Node
        {
            double val;
            public ValueNode(double val)
            {
                this.val = val;
            }
            public override double Evaluate()
            {
                return val;
            }
        }

        /// <summary>
        /// Builds the tree also has a stack that we'll use to 
        /// keep track of the list's items. Shunting algorithm and precedence
        /// will now be applied right away before items are read/to tree.
        /// Observe the following algorithm. We use a regular expression to store the possible combinations (-,/,+,*,(,))
        /// Symbols are partitoned out using the regular expression. Then we throw the entire list through shunting algorithm
        /// We then iterate through the list returned and use the stack to push,pop out items accordingly.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private Node BuildTree(string expression)
        {
            var nodeStack = new Stack<Node>();
            string pattern = @"([-/\+\*\(\)])"; 
            var tokens = Regex.Split(expression, pattern).Where(s => s != String.Empty).ToList<string>();
            foreach (var tok in ShuntingAlgo(tokens))
            {
                if (Char.IsLetter(tok[0]))
                {
                    nodeStack.Push(new VariableNode(tok));

                }
                else if (Char.IsDigit(tok[0]))
                {
                    nodeStack.Push(new ValueNode(Double.Parse(tok)));

                }
                else
                {
                    var on = new OperatorNode(tok[0]);
                    on.right = nodeStack.Pop();
                    on.left = nodeStack.Pop();
                    nodeStack.Push(on);
                }
            }
            root = nodeStack.Pop();
            return root;
        }


        

        /// <summary>
        /// Function to switch the precedence and return a certain number
        /// that'll assert position relative to math rules
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private static int PrecedenceOperation(string symbol)
        {
            switch (symbol)
            {
                case "*": case "/": return 2;
                case "+": case "-": return 1;
                case "(": return 0;
                case ")": return 3;
                default:
                    return -1;
            }
        }

        /// <summary>
        ///  shunting-yard algorithm is a method for parsing mathematical expressions specified in infix notation. 
        ///  It can produce either a postfix notation string, also known as Reverse Polish notation (RPN), or an abstract syntax tree (AST). The algorithm was invented by 
        ///  Edsger Dijkstra and named the "shunting yard" 
        ///  algorithm because its operation resembles that of a railroad shunting yard.
        ///  https://en.wikipedia.org/wiki/Shunting-yard_algorithm
        ///  Algorithm was helped by geeksforgeeks and stackoverflow
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        private List<string> ShuntingAlgo(List<string> symbols)
        {
            var opstack = new Stack<string>();
            var output = new List<string>();

            foreach (var tok in symbols)
            {
                switch (tok)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        while (opstack.Count > 0)
                        {
                            if (PrecedenceOperation(opstack.Peek()) < PrecedenceOperation(tok))
                            {
                                break;
                            }
                            output.Add(opstack.Pop());
                        }
                        opstack.Push(tok);
                        break;
                    case "(":
                        opstack.Push(tok);
                        break;
                    case ")":
                        while (opstack.Count > 0 && opstack.Peek() != "(")
                        {
                            output.Add(opstack.Pop());
                        }
                        opstack.Pop();
                        break;
                    default: 
                        output.Add(tok);
                        break;
                }
            }
            while (opstack.Count > 0)
            {
                output.Add(opstack.Pop());
            }
            return output;
        }

        /// <summary>
        /// ExpTree's set variable method
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="variableValue"></param>
        public void SetVariable(string variableName, double variableValue)
        {
            try
            {
                var.Add(variableName, variableValue);
            }
            catch
            {
                var[variableName] = variableValue;
            }
        }

        /// <summary>
        /// Evaluate function that calls a recursive helper function called evaluate that works off the root
        /// </summary>
        /// <returns></returns>
        public double Evaluate()
        {
            return root.Evaluate();
        }
    }
}
