/*1. Create a console application and add class named Employee with following field. Employee Class : EmployeeID (Integer) FirstName (String) LastName (String) Title (String) DOB (Date) DOJ (Date) City (String)*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignments
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
   
}