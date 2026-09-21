using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" enter the marks : ");
            float marks = float.Parse(Console.ReadLine());
            if(marks > 50)
            {
                Console.Write(" u are passed ");
            }
            else
            {
                Console.Write(" u are failed ");
            }
            Console.Read();
        }
    }
}
