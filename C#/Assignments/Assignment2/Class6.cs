//2.	Write a program in C# to accept a word from the user and display the reverse of it. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Class6
    {
        static void Main()
        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            char[] arr = word.ToCharArray();
            Array.Reverse(arr);

            string reversed = new string(arr);

            Console.WriteLine("Reversed word: " + reversed);
            Console.Read();
        }

    }
}
