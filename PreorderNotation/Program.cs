using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderNotation
{
    enum NodeType { LEAF, NODE}
    enum Data { NUMBER, OPERATOR };
    enum Operator { MULT, ADD, SUB, DIV, MINUS }
    interface INode
    {
        void setData(Data c);
        Data getData();
    }
  
    abstract class Node : INode
    {
        Data data { get; set; }
        INode right { get; set; }
        INode left { get; set; }

        public void setData(Data d)
        {
            data = d;
        }
        public abstract Data getData();
    }
  
    class Operand : Node
    {
    
        int num { get; set; }
        
      
        

    }
    class Operator : Node
    {
        Data data;
        char op { get; set; }
        public void setData(Data c)
        {
            data = c;
        }
        public Data getData()
        {
            return data;
        }
    }

    class PreorderNotation
    {
        public static int evaluate(string expr)
        {
            char[] operators = new char[] { '+', '-', '*', '/', '~' };
            string[] tokens = expr.Split(' ');
            foreach (string token in tokens.Reverse())
            {
                int num;
                if (int.TryParse(token,out num) && !token.Equals(operators))
                {

                }
                else if (!int.TryParse(token, out num) && !token.Equals(operators))
                {
                    Console.WriteLine("Format Error");
                    Environment.Exit(0);
                }
                else
                {

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
