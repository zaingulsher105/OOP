using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Mass Laptop\\Programming\\2nd semester\\Week1\\lab\\textfile.txt";
            StreamWriter filevariable = new StreamWriter(path, true);
            filevariable.WriteLine("hello");
            filevariable.Flush();
            filevariable.Close();
        }
    }
}
