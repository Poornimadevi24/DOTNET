//1. Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Program
    {
        static string RemoveChar(string str, int position)
        {
            if (position < 0 || position >= str.Length)
            {
                return "Invalid position";
            }

            return str.Remove(position, 1);
        }
        static void Main()
        {
            Console.WriteLine(RemoveChar("Python", 1));
            Console.WriteLine(RemoveChar("Python", 0));
            Console.WriteLine(RemoveChar("Python", 4)); 

        }
    }
}
