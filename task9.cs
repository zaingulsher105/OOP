using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    internal class Program
    {
        static int add( int n1, int n2)
        {
            return n1 + n2;
        }
        static void Main(string[] args)
        {
            Console.Write(" enter first number : ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write(" enter second number : ");
            int num2 = int.Parse(Console.ReadLine());
            int result = add(num1, num2);
            Console.Write(" sum is  : ");
            Console.Write(result);
            Console.Read();



        }
    }
}
