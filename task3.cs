using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" enter the lenght : ");
            float length = float.Parse(Console.ReadLine());
            float area = length * length;
            Console.Write(" the area is : ");
            Console.Write(area);
            Console.Read();
        }
    }
}
