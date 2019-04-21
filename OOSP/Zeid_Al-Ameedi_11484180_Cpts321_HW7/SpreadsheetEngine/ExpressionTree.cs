using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        protected Dictionary<string, double> variableDict;

        public string expression;

        /// <summary>
        /// Constructor that clears the dictionary and builds a tree with some default expression.
        /// </summary>
        /// <param name="expression"></param>
        public ExpressionTree(string expression)
        {
            this.expression = expression;

            variableDict = new Dictionary<string, double>();

            this.root = Compile(expression);


        }

        /// <summary>
        /// ExpTree's set variable method
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="variableValue"></param>
        public void SetVariable(string varName, double varValue)
        {
            variableDict[varName] = varValue;
        }

        public double Evaluate()
        {
            if (root != null)
            {
                return Evaluate(root);
            }
            else
            {
                return double.NaN;
            }
        }


        /// <summary>
        /// Better implementation that checks and evaluates off dict right away.
        /// Evaluate is self explained that returns the value (new or assigned)
        /// </summary>
        /// <returns></returns>
        private double Evaluate(Node node)
        {
            ValueNode constnode = node as ValueNode;
            if (constnode != null)
            {
                return constnode.OpValue;
            }
            VariableNode varnode = node as VariableNode;
            if (varnode != null)
            {
                return variableDict[varnode.Name];
            }
            OperatorNode opnode = node as OperatorNode;
            if (opnode != null)
            {
                switch (opnode.Op)
                {
                    case '+':
                        return Evaluate(opnode.Left) + Evaluate(opnode.Right);

                    case '-':
                        return Evaluate(opnode.Left) - Evaluate(opnode.Right);

                    case '*':
                        return Evaluate(opnode.Left) * Evaluate(opnode.Right);

                    case '/':
                        return Evaluate(opnode.Left) / Evaluate(opnode.Right);
                }

            }

            return 0;
        }

        /// <summary>
        /// Helper function to get the lower partition of the expression
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static int GetLowOpIndex(string exp)
        {
            int parenthCounter = 0;
            int index = -1;
            for (int i = exp.Length - 1; i >= 0; i--)
            {
                switch (exp[i])
                {
                    case ')':
                        parenthCounter--;
                        break;
                    case '(':
                        parenthCounter++;
                        break;
                    case '+':
                    case '-':
                        if (parenthCounter == 0)
                        {
                            return i;
                        }
                        break;

                    case '*':
                    case '/':
                        if (parenthCounter == 0 && index == -1)
                        {
                            index = i;
                        }
                        break;
                }

            }
            if (parenthCounter != 0)
            {
                return -2;
            }
            return index;

        }

        /// <summary>
        /// Helper FN to build each parsed our variable
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        private Node BuildSimple(string term)
        {
            double num;
            if (double.TryParse(term, out num))
            {
                return new ValueNode(num);
            }
            SetVariable(term, 0);
            return new VariableNode(term);

        }

        /// <summary>
        /// Compiles the tree, had to rehash it to work with our new features
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private Node Compile(string exp)
        {
            exp = exp.Replace(" ", "");

            if (exp[0] == '(')
            {
                int counter = 1;

                for (int i = 1; i < exp.Length; i++)
                {
                    if (exp[i] == ')')
                    {
                        counter--;
                        if (counter == 0)
                        {
                            if (i == exp.Length - 1)
                            {
                                return Compile(exp.Substring(1, exp.Length - 2));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (exp[i] == '(')
                    {
                        counter++;
                    }
                }
                if (counter != 0)
                {
                    Console.WriteLine("Parentheses not matched!");
                    exp = "ERROR";
                    return null;
                }
            }
            int index = GetLowOpIndex(exp);
            if (index != -1 && index != -2)
            {
                return new OperatorNode(exp[index], Compile(exp.Substring(0, index)), Compile(exp.Substring(index + 1)));
            }
            else if (index == -2)
            {
                Console.WriteLine("Parentheses not matched!");
                this.expression = "ERROR";
                return null;
            }
            return BuildSimple(exp);

        }


        /// <summary>
        /// KEEP IN MIND. All nodes will get their own class but for now they're not coupled correctly because I cannot get reflection
        /// to work. Will make sure I get it done in HW6. This way I can spend more time understanding LINQ and reflection.
        /// This is the abstract class Node with a method to be overriden that evaluates an expression.
        /// </summary>
        private abstract class Node
        {
            protected string name;
            protected double opValue;
            public string Name
            {
                get { return name; }
                set
                {
                    if (name == value)
                        return;

                    name = value;
                }
            }

            /// <summary>
            /// Returns the operators value
            /// </summary>
            public double OpValue
            {
                get { return opValue; }
                set
                {
                    if (opValue == value)
                        return;

                    opValue = value;
                }
            }

        }

        /// <summary>
        /// Value node function that sets the value
        /// to whatever number was passed in
        /// </summary>
        private class ValueNode : Node
        {
            public ValueNode(double number)
            {
                opValue = number;
            }

        }

        /// <summary>
        /// Variable node that assigns the name of var
        /// </summary>
        private class VariableNode : Node
        {
            public VariableNode(string varName)
            {
                name = varName;
            }

        }

        /// <summary>
        /// Operator node function meant to assign an operator to be parsed later
        /// </summary>
        private class OperatorNode : Node
        {
            private char op;
            private Node left, right;

            public OperatorNode(char Op, Node Left, Node Right)
            {
                op = Op;
                left = Left;
                right = Right;
            }

            public char Op
            {
                get { return op; }
            }

            public Node Left
            {
                get { return left; }
            }
            public Node Right
            {
                get { return right; }
            }

        }

        /// <summary>
        /// ExpTree's get variable method
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="variableValue"></param>
        public string[] GetVariables()
        {
            return variableDict.Keys.ToArray();
        }
    }

}
