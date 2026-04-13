//2.Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
  internal class Class1
    {
        static string SwapFirstLast(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }

            char first = str[0];
            char last = str[str.Length - 1];

            return last + str.Substring(1, str.Length - 2) + first;
        }
        static void Main()
        {
            Console.WriteLine(SwapFirstLast("abcd")); 
            Console.WriteLine(SwapFirstLast("a"));    
            Console.WriteLine(SwapFirstLast("xy"));   
        }
    }
}
