//3. Write a C# program to sort the elements of a given stack in descending order. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Class2
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();

            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter elements:");

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                stack.Push(num);
            }
            List<int> list = new List<int>(stack);

           
            list.Sort((a, b) => b.CompareTo(a));

           
            stack = new Stack<int>(list);

            Console.WriteLine("Stack elements in descending order:");

            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
        }

    }
}
