using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1
{
    class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Department { get; set; }
        public double Salary { get; set; }
    }
    internal class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("==================================");
                Console.WriteLine("Enter your choice:  ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.Please enter a number.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        AddEmployee(employees);
                        break;

                    case 2:
                        ViewEmployee(employees);
                        break;

                    case 3:
                        SearchEmployee(employees);
                        break;

                    case 4:
                        UpdateEmployee(employees);
                        break;

                    case 5:
                        DeleteEmployee(employees);
                        break;

                    case 6:
                        exit = true;
                        Console.WriteLine("Exiting Program...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice. Try again.");
                        break;
                }
            }
        }
        static void AddEmployee(List<Employee> employees)
        {
            Employee emp = new Employee();
            Console.Write("Enter Employee Id: ");
            emp.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter name: ");
            emp.Name = Console.ReadLine();
            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();
            Console.Write("Enter Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());
            employees.Add(emp);
            Console.WriteLine("Employee added Successfully!");
        }
        static void ViewEmployee(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found");
                return;
            }
            Console.WriteLine("\n--- Employee List ---");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID:{emp.Id},Name: {emp.Name},Dept:{emp.Department},Salart:{emp.Salary}");
            }
        }
        static void SearchEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID to Search: ");
            int id = int.Parse(Console.ReadLine());
            Employee emp = null;

            foreach (var e in employees)
            {
                if (e.Id == id)
                {
                    emp = e;
                    break;
                }
            }
            if (emp != null)
            {
                Console.WriteLine($"Found ID:{emp.Id},Name:{emp.Name},Dept:{emp.Department},Salary:{emp.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        static void UpdateEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID to Update: ");
            int id = int.Parse(Console.ReadLine());
            Employee emp = null;

            foreach (var e in employees)
            {
                if (e.Id == id)
                {
                    emp = e;
                    break;
                }
            }
            if (emp != null)
            {
                Console.Write("Enter new Name: ");
                emp.Name = Console.ReadLine();

                Console.Write("Enter new Department: ");
                emp.Department = Console.ReadLine();

                Console.Write("Enter new Salary: ");
                emp.Salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Employee updated successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        static void DeleteEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Employee emp = null;

            foreach (var e in employees)
            {
                if (e.Id == id)
                {
                    emp = e;
                    break;
                }
            }

            if (emp != null)
            {
                employees.Remove(emp);
                Console.WriteLine("Employee deleted successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

        }
    }
}