using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderNotation
{
    enum NodeType { LEAF, NODE}
    enum Data { NUMBER, OPERATOR };
    enum Op { MULT, ADD, SUB, DIV, MINUS }
    
    interface INode
    {
        NodeType getNode();
        void setNode(NodeType t);
    }

    class Node 
    {
        NodeType nodeT;
        int num;
       public NodeType getNode()
       {
            return NodeType.NODE;
       }
       public void setNode(NodeType t)
        {
            nodeT = t;
        }
        public int getValue()
        {
            return num;
        }
        public void setValue(int n)
        {
            num = n;
        }
       public Node right { get; set; }
       public Node left { get; set; }
       
    }
  
    class Operand : Node
    {
        public int num { get; }
        public Operand(int n)
        {
            num = n;
        }
        
    }
    class Leaf : INode
    {
        char op { get; set; }
        NodeType nodeT;
        public NodeType getNode()
        {
            return NodeType.NODE;
        }
        public void setNode(NodeType t)
        {
            nodeT = t;
        }
        public Operator(char o)
        {
            op = o;
        }
    }

    class PreorderNotation
    {
        public static int buildTree(string expr)
        {
            char[] operators = new char[] { '+', '-', '*', '/', '~' };
            string[] tokens = expr.Split(' ');
            Stack<Node> NodeStack = new Stack<Node>();
            foreach (string token in tokens.Reverse())
            {
                int num;
                if (int.TryParse(token,out num) && !token.Equals(operators))
                {
                    Node n = new Operand(num);
                    n.left = null;
                    n.right = null;
                    n.data = Data.NUMBER;
                    NodeStack.Push(n);
                }
                else if (!int.TryParse(token, out num) && !token.Equals(operators))
                {
                    Console.WriteLine("Format Error");
                    Environment.Exit(0);
                }
                else
                {

                    if (token.Equals(operators) && !token.Equals('~'))
                    {
                        if ( NodeStack.Count == 0)
                        {
                            Console.WriteLine("Format Error");
                            Environment.Exit(0);
                        }
                        int temp = ((Operand)NodeStack.Pop()).num;
                        temp = -temp;
                        Node tempN = new Operand(temp);
                        tempN.left = null;
                        tempN.right = null;
                        NodeStack.Push(tempN);
                    }
                    else
                    {
                        if ( NodeStack.Count < 2)
                        {
                            Console.WriteLine("Format Error");
                            Environment.Exit(0);
                        }
                        Node internal = new Operator
                    }
                }   
            }

            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
          
            // PreorderNotation.evaluate(expression);
        }
    }
}
