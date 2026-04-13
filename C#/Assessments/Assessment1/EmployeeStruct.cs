using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codechallenge1
{
    struct DateOfBirth
    {
        public int Day;
        public int Month;
        public int Year;
    }

    struct Employee
    {
        public string Name;
        public DateOfBirth DOB; 
    }

    internal class Class1
    {
        static void Main()
        {
            Employee[] emp = new Employee[2];

            for (int i = 0; i < emp.Length; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}:");

                Console.Write("Name of the employee: ");
                emp[i].Name = Console.ReadLine();

                Console.Write("Input day of birth: ");
                emp[i].DOB.Day = int.Parse(Console.ReadLine());

                Console.Write("Input month of birth: ");
                emp[i].DOB.Month = int.Parse(Console.ReadLine());

                Console.Write("Input year of birth: ");
                emp[i].DOB.Year = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\n--- Employee Details ---");

            for (int i = 0; i < emp.Length; i++)
            {
                Console.WriteLine($"\nEmployee {i + 1}:");
                Console.WriteLine("Name: " + emp[i].Name);
                Console.WriteLine($"DOB: {emp[i].DOB.Day:D2}/ {emp[i].DOB.Month:D2}/{emp[i].DOB.Year}");
            }
        }
    }
}
