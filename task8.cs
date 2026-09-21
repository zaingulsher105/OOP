using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write(" enter the number ");
                num[i] = int.Parse(Console.ReadLine());

            }
            int largest = 0;
            for (int i = 0; i < 3; i++)
            {
                if (num[i] > largest)
                {
                    largest = num[i];
                }
             }
            Console.Write(" the number is ");
            Console.Write(largest);
            Console.Read();

        }
    }
}