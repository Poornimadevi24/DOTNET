using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }
    internal class Class2
    {
        static void Main()
        {
            var employees = new List<Employee>
{
    new Employee { EmpId = 1, EmpName = "Arun", EmpCity = "Bangalore", EmpSalary = 50000 },
    new Employee { EmpId = 2, EmpName = "John", EmpCity = "Chennai", EmpSalary = 40000 },
    new Employee { EmpId = 3, EmpName = "Meena", EmpCity = "Bangalore", EmpSalary = 60000 }
};

         
            Console.WriteLine("All Employees:");
            employees.ForEach(e => Console.WriteLine($"{e.EmpName} - {e.EmpSalary}"));

        
            Console.WriteLine("\nSalary > 45000:");
            employees.Where(e => e.EmpSalary > 45000)
                 .ToList()
         .ForEach(e => Console.WriteLine(e.EmpName));

          
            Console.WriteLine("\nBangalore Employees:");
            employees.Where(e => e.EmpCity == "Bangalore")
                     .ToList()
                     .ForEach(e => Console.WriteLine(e.EmpName));

         
            Console.WriteLine("\nSorted by Name:");
            employees.OrderBy(e => e.EmpName)
                     .ToList()
                     .ForEach(e => Console.WriteLine(e.EmpName));

        }

    }
}
