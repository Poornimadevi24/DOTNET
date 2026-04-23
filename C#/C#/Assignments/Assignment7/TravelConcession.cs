using System;
using ClassLibrary3
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        const double TotalFare = 500;
        static void Main()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            ConcessionCalculator calculator = new ConcessionCalculator();

            string result = calculator.CalculateConcession(age, TotalFare);

            Console.WriteLine($"\nPassenger Name: {name}");
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
