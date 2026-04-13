/*2.Write a program in C# to accept ten marks and display the following
	a.	Total
	b.	Average
	c.	Minimum marks
	d.	Maximum marks
	e.	Display marks in ascending order
	f.	Display marks in descending order*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Class3
    {
        static void Main()
        {
            int[] marks = new int[10];
            int sum = 0;

            Console.WriteLine("Enter 10 marks:");

            for (int i = 0; i < 10; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
                sum += marks[i];
            }

            int min = marks[0];
            int max = marks[0];

            for (int i = 0; i < 10; i++)
            {
                if (marks[i] < min)
                    min = marks[i];

                if (marks[i] > max)
                    max = marks[i];
            }

            double avg = (double)sum / 10;

           
            for (int i = 0; i < 10 - 1; i++)
            {
                for (int j = 0; j < 10 - i - 1; j++)
                {
                    if (marks[j] > marks[j + 1])
                    {
                        int temp = marks[j];
                        marks[j] = marks[j + 1];
                        marks[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nTotal: " + sum);
            Console.WriteLine("Average: " + avg);
            Console.WriteLine("Minimum: " + min);
            Console.WriteLine("Maximum: " + max);

            Console.WriteLine("Ascending Order:");
            foreach (int m in marks)
                Console.Write(m + " ");

            Console.WriteLine("\nDescending Order:");
            for (int i = 9; i >= 0; i--)
                Console.Write(marks[i] + " ");
            Console.Read();
        }
    }
}
