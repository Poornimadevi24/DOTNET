//5. Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.
using System;
namespace ConsoleApp3
{
    internal class Class4
    {
        static void Main()
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int result = ComputeSum(num1, num2);

            Console.WriteLine("Result: " + result);
        }
        static int ComputeSum(int a, int b)
        {
            if (a == b)
            {
                return 3 * (a + b);
            }
            else
            {
                return a + b;
            }
        }
    }
}
