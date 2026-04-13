/*1.Write a Program to assign integer values to an array  and then print the following
	a.	Average value of Array elements
	b.	Minimum and Maximum value in an array */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Class2
    {
        static void Main()
        {
            int[] arr = { 10, 20, 30, 40, 50 };

            int sum = 0;
            int min = arr[0];
            int max = arr[0];

            foreach (int num in arr)
            {
                sum += num;

                if (num < min)
                    min = num;

                if (num > max)
                    max = num;
            }

            double avg = (double)sum / arr.Length;

            Console.WriteLine("Average: " + avg);
            Console.WriteLine("Minimum: " + min);
            Console.WriteLine("Maximum: " + max);
            Console.Read();

         }
}
}
