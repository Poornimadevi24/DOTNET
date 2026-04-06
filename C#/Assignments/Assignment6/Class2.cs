using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Class2
    {
        static void Main()
        {
            string path = "sample.txt";

            if (File.Exists(path))
            {
                int lineCount = File.ReadAllLines(path).Length;
                Console.WriteLine("Number of lines in file: " + lineCount);
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
            Console.Read();
        }
    }
}
