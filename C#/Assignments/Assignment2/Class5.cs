//1.Write a program in C# to accept a word from the user and display the length of it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Class5
    {
        static void Main()
        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            Console.WriteLine("Length: " + word.Length);
            Console.Read();
        }

    }
}
