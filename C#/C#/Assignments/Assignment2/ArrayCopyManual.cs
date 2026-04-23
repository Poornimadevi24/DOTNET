//3.Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions, write your own logic)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Class4
    {
        static void Main()
        {
            int[] source = { 1, 2, 3, 4, 5 };
            int[] destination = new int[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                destination[i] = source[i];
            }

            Console.WriteLine("Copied array:");
            foreach (int num in destination)
            {
                Console.Write(num + " ");
            }
            Console.Read();
        }
    }
}
