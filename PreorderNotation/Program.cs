using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Evaluater of a Prefix expression
///  Program converts the expression in to the Binary Expression Tree
///  If a tree is constructed, program will return the result.
/// </summary>

namespace PreorderNotation
{
    enum NodeType { LEAF, NODE}     
    interface INode
    {
        NodeType getNode();
    }
    class Node : INode
    {
        NodeType nodeT = NodeType.NODE;
       
        // operator
        public char op { get; }
        public INode left { get; }         
        public INode right { get; }         
        public Node(INode l,char o,INode r)  
        {
            left = l;
            op = o;
            right = r;
        }
       public NodeType getNode()     
       {
            return nodeT;
       }
       public char getOperator() 
       {
            return op;
       }   
    }
    class Leaf : INode
    {
        // Operand
        int num;     
        NodeType nodeT = NodeType.LEAF;       
        public NodeType getNode()           
        {
            return nodeT;
        }
        public Leaf(int n)      
        {
            num = n;
        }
        public int getValue()       
        {
            return num;
        }
    }
    class ExpressionTree
    {
        public static INode root;
        public static void build(string expr)
        {
            string[] operators = new string[] { "+", "-", "*", "/", "~" };          
            string[] tokens = expr.Split(' ');
            Stack<INode> NodeStack = new Stack<INode>();
            // Reading expression as Postfix (from right to left)
            for (int i = tokens.Length-1; i >= 0; --i)          
            {
                    if (int.TryParse(tokens[i], out int num))     
                    {
                        INode l = new Leaf(num);               
                        NodeStack.Push(l);
                    }
                    else if (!int.TryParse(tokens[i], out num) && !operators.Contains(tokens[i]) ) 
                    {
                        Console.WriteLine("Format Error");   
                        Environment.Exit(0);             
                    }
                    else
                    {
                        // unary minus
                        if (tokens[i] == "~")          
                        {
                            if (NodeStack.Count == 0)           
                            {
                                Console.WriteLine("Format Error");
                                Environment.Exit(0);
                            }
                            int temp = ((Leaf)NodeStack.Pop()).getValue();
                            // Not storing the unary minus in to the tree. Just applying it.
                            temp = -temp;                      
                            INode tempN = new Leaf(temp);
                            NodeStack.Push(tempN);
                        }
                        else
                        {
                            // not enough operands in an expression
                            if (NodeStack.Count < 2)        
                            {
                                Console.WriteLine("Format Error");
                                Environment.Exit(0);
                            }
                            INode l = NodeStack.Pop();              
                            INode r = NodeStack.Pop();
                            root = new Node(l, Convert.ToChar(tokens[i]), r);       
                            NodeStack.Push(root);
                            // Create a node and store pointer at the node to the stack
                        }
                }
            }
            // more operands in an expression
            if (NodeStack.Count() > 1 )
            {
                Console.WriteLine("Format Error");
                Environment.Exit(0);
            }
        }
       
    }
    class Result
    {
        // Tree Traversal
        public static int evalTree(INode node,int result)
        {
            if (node == null) { return result; }
            if(node.getNode() == NodeType.LEAF)
            {
                return ((Leaf)node).getValue();     
            }
            else
            {
                Node n = (Node)node;
                int op1 = evalTree(n.left,result);
                int op2 = evalTree(n.right,result);
                result = compute(op1, op2, n.getOperator());        
            }
            return result;
        }

        // Compute expression
        public static int compute(int op1, int op2, char op)
        {
            int result = 0;
            try
            {
                switch (op)
                {
                    case '+':
                        result = checked(op1 + op2);
                        break;
                    case '-':
                        result = checked(op1 - op2);
                        break;
                    case '*':
                        result = checked(op1 * op2);
                        break;
                    case '/':
                        if (op2 == 0)
                        {
                            Console.WriteLine("Divide Error");
                            Environment.Exit(0);
                        }
                        result = checked(op1 / op2);
                        break;
                    default:
                        break;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow Error");
                Environment.Exit(0);
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string expr = Console.ReadLine();
            ExpressionTree.build(expr);
            int result = Result.evalTree(ExpressionTree.root, 0);
            Console.WriteLine(result);
        }
    }
}
