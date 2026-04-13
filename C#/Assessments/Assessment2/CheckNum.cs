using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Class2
    {
        static void CheckNumber(int num)
        {
            if (num < 0)
                throw new Exception("Number cannot be Negative");
        }
        static void Main()
        {
            try
            {
                Console.Write("Enter a Number: ");
                int n = int.Parse(Console.ReadLine());
                CheckNumber(n);
                Console.WriteLine("Valid number");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.Read();
        }
    }
}
