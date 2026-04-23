//3.	Write a program in C# to accept two words from user and find out if they are same.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Class7
    {
        static void Main()
        {
            Console.Write("Enter first word: ");
            string word1 = Console.ReadLine();

            Console.Write("Enter second word: ");
            string word2 = Console.ReadLine();

            if (word1.Equals(word2))
                Console.WriteLine("Both words are same");
            else
                Console.WriteLine("Words are different");
        }

    }
}
