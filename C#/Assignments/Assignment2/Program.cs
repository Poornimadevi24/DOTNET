//1.Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation. You should do it twice: Use the console. Write and use {0}.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program
    {
        static void Main()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);
            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);
            Console.Read();
        }
        
    }
}
