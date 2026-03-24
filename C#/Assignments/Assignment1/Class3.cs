//4. Write a C# Sharp program that prints the multiplication table of a number as input.

using System;


namespace ConsoleApp3
{
    internal class Class3
    {
        static void Main()
        {
            int num;
            Console.Write("Enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{num} * {i} = {num * i}");
            }

        }
    }
}
