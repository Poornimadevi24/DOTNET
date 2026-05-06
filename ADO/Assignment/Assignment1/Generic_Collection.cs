//2. Create a Generic List Collection empList and populate it with the following records.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignments
{
    internal class Generic_Collection
    {
        static void Main()
        {
         List<Employee> empList = new List<Employee>
     {
        new Employee { EmployeeID=1001, FirstName="Malcolm", LastName="Daruwalla", Title="Manager", DOB=new DateTime(1984,11,16), DOJ=new DateTime(2011,6,8), City="Mumbai"},
        new Employee { EmployeeID=1002, FirstName="Asdin", LastName="Dhalla", Title="AsstManager", DOB=new DateTime(1984,8,20), DOJ=new DateTime(2012,7,7), City="Mumbai"},
        new Employee { EmployeeID=1003, FirstName="Madhavi", LastName="Oza", Title="Consultant", DOB=new DateTime(1987,11,14), DOJ=new DateTime(2015,4,12), City="Pune"},
        new Employee { EmployeeID=1004, FirstName="Saba", LastName="Shaikh", Title="SE", DOB=new DateTime(1990,6,3), DOJ=new DateTime(2016,2,2), City="Pune"},
        new Employee { EmployeeID=1005, FirstName="Nazia", LastName="Shaikh", Title="SE", DOB=new DateTime(1991,3,8), DOJ=new DateTime(2016,2,2), City="Mumbai"},
        new Employee { EmployeeID=1006, FirstName="Amit", LastName="Pathak", Title="Consultant", DOB=new DateTime(1989,11,7), DOJ=new DateTime(2014,8,8), City="Chennai"},
        new Employee { EmployeeID=1007, FirstName="Vijay", LastName="Natrajan", Title="Consultant", DOB=new DateTime(1989,12,2), DOJ=new DateTime(2015,6,1), City="Mumbai"},
        new Employee { EmployeeID=1008, FirstName="Rahul", LastName="Dubey", Title="Associate", DOB=new DateTime(1993,11,11), DOJ=new DateTime(2014,11,6), City="Chennai"},
        new Employee { EmployeeID=1009, FirstName="Suresh", LastName="Mistry", Title="Associate", DOB=new DateTime(1992,8,12), DOJ=new DateTime(2014,12,3), City="Chennai"},
        new Employee { EmployeeID=1010, FirstName="Sumit", LastName="Shah", Title="Manager", DOB=new DateTime(1991,4,12), DOJ=new DateTime(2016,1,2), City="Pune"}
    };
            DateTime date2015 = new DateTime(2015, 1, 1);
            DateTime date1990 = new DateTime(1990, 1, 1);

            //1. Display a list of all the employee who have joined before 1/1/2015
            var res1 = empList.Where(e => e.DOJ < date2015);
            Console.WriteLine("Joined before 1/1/2015: " + res1.Count());
            //2. Display a list of all the employee whose date of birth is after 1/1/1990
            var res2 = empList.Where(e => e.DOB > date1990);
            Console.WriteLine(" DOB after 1/1/1990: " + res2.Count());
            //3. Display a list of all the employee whose designation is Consultant and Associate
            var res3 = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            Console.WriteLine("Consultant & Associate: " + res3.Count());
            //4. Display total number of employees
            Console.WriteLine("Total Employees: " + empList.Count());
            //5. Display total number of employees belonging to “Chennai”
            Console.WriteLine("Chennai Employees: " + empList.Count(e => e.City == "Chennai"));
            //6. Display highest employee id from the list
            Console.WriteLine("Highest Employee ID: " + empList.Max(e => e.EmployeeID));
            //7. Display total number of employee who have joined after 1/1/2015
            Console.WriteLine("Joined after 1/1/2015: " + empList.Count(e => e.DOJ > date2015));
            //8. Display total number of employee whose designation is not “Associate”
            Console.WriteLine("Not Associate: " + empList.Count(e => e.Title != "Associate"));
            //9. Display total number of employee based on City
            var cout = empList.GroupBy(e => e.City).Select(g => new { City = g.Key, Count = g.Count() });
            Console.WriteLine("Count by City:");
            foreach (var item in cout)
            Console.WriteLine(item.City + " : " + item.Count);
            //10. Display total number of employee based on city and title
            var emp = empList.GroupBy(e => new { e.City, e.Title }).Select(g => new { g.Key.City, g.Key.Title, Count = g.Count() });
            Console.WriteLine("Count by City & Title:");
            foreach (var item in emp)
            Console.WriteLine(item.City + " - " + item.Title + " : " + item.Count);
            //11. Display total number of employee who is youngest in the list
            var youngest = empList.OrderByDescending(e => e.DOB).First();
            Console.WriteLine("Youngest Employee: " + youngest.FirstName + " " + youngest.LastName);
        }
    }
}
