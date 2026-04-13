//3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 
using System;
namespace ConsoleApp3
{
    internal class Class2
    {
        static double Add(double a, double b)
        {
            return a + b;
        }
        static double Subtract(double a, double b)
        {
            return a - b;
        }
        static double Multiply(double a, double b)
        {
            return a * b;
        }
        static double Divide(double a, double b)
        {
            return a / b;
        }

        static void Main()
        {
            int n1, n2;
            Console.Write("n1: ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("n2: ");
            n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{Add(n1, n2)}");
            Console.WriteLine($"{Subtract(n1, n2)}");
            Console.WriteLine($"{Multiply(n1, n2)}");
            Console.WriteLine($"{Divide(n1, n2)}");
        }
    }
}
