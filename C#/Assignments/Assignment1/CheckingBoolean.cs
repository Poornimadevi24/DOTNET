//2. Write a C# Sharp program to check whether a given number is positive or negative.
using System;

class Program
{
    static void Main()
    {
        int num;

        Console.Write("Enter a number: ");
        num = Convert.ToInt32(Console.ReadLine());

        if (num >= 0)
        {
            Console.WriteLine(num + " is a positive number");
        }
        else
        {
            Console.WriteLine(num + " is a negative number");
        }
    }
}
