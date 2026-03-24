//1. Write a C# Sharp program to accept two integers and check whether they are equal or not. 

using System;
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;

             Console.Write("num1: ");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("num2: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            if (num1 == num2)
            {
                Console.WriteLine(num1 + " and " + num2 + " are equal");
            }
            else
            {
                Console.WriteLine(num1 + " and " + num2 + " are not equal");
            }
        }
    }
}
