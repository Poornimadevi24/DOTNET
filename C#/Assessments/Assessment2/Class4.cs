using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Class4
    {
       public delegate int Calculator(int a, int b);
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }
        public static void PerformOperation(int x, int y, Calculator calc, string operationName)
        {
            int result = calc(x, y);
            Console.WriteLine($"{operationName} Result: {result}");
        }

        static void Main()
        {
            Console.WriteLine("Enter First number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Calculator add = new Calculator(Add);
            Calculator sub = new Calculator(Subtract);
            Calculator mul = new Calculator(Multiply);
            PerformOperation(num1, num2, add, "Addition");
            PerformOperation(num1, num2, sub, "Subtraction");
            PerformOperation(num1, num2, mul, "Multiplication");
            Console.Read();
        }

    }
}
