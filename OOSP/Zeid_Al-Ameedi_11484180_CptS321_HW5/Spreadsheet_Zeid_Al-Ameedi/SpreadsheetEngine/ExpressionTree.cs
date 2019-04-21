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
            string name=string.Empty;
            double val=0.0;
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
                catch(KeyNotFoundException)
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
        /// Builds the tree and has cases that it'll watch out for 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Node BuildTree(string expression)
        {
            double val;
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                switch (expression[i])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        OperatorNode newbie = new OperatorNode(expression[i]);
                        if (root == null)
                        {
                            root = newbie;
                        }
                        newbie.left = BuildTree(expression.Substring(0, i));
                        newbie.right = BuildTree(expression.Substring(i + 1));
                        return newbie;
                }
            }
            if (Double.TryParse(expression, out val))
            {
                return new ValueNode(val);
            }
            else
            {
                return new VariableNode(expression);
            }
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
