using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assessment
{
  //3. Using ADO.net classes/methods, insert employee details by calling the procedure
class Employee
 {
      public int Empno { get; set; }
      public string EmpName { get; set; }
      public decimal Empsal { get; set; }
      public char Emptype { get; set; }

     DataAccess access = new DataAccess();

            
public int AddEmployee()
{
   Console.WriteLine("Enter Employee Name :");
   EmpName = Console.ReadLine();

   Console.WriteLine("Enter Employee Salary :");
   Empsal = Convert.ToDecimal(Console.ReadLine());

   Console.WriteLine("Enter Employee Type (F/P) :");
   Emptype = Convert.ToChar(Console.ReadLine());

   return access.InsertEmployee(EmpName, Empsal, Emptype);
}


  public SqlDataReader ShowEmployees()
  {
      return access.DisplayEmployees();
  }
}
    class DataAccess
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        public SqlConnection GetConnection()
        {
            string str = "Data Source=(localdb)\\MSSQLLocalDB;" + "Initial Catalog=Employeemanagement;" +"Integrated Security=True;";
            conn = new SqlConnection(str);
            conn.Open();
            return conn;
        }
        public int InsertEmployee(string name, decimal sal, char type)
        {
            int result = 0;

            try
            {
                conn = GetConnection();
                cmd = new SqlCommand("EmployeeDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", name);
                cmd.Parameters.AddWithValue("@Empsal", sal);
                cmd.Parameters.AddWithValue("@Emptype", type);
                result = cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        //4. Display all employee rows
        public SqlDataReader DisplayEmployees()
        {
            conn = GetConnection();
            cmd = new SqlCommand("SELECT * FROM Employee_Details", conn);
            dr = cmd.ExecuteReader();
            return dr;
        }
    }
   internal class EmployeeInsertion
        {
        static void Main()
        {
            Employee emp = new Employee();

            SqlDataReader dr;

           
            Console.WriteLine("------ Employees Before Insert ------");

            dr = emp.ShowEmployees();

            while (dr.Read())
            {
                Console.WriteLine(
                    $"Empno : {dr["Empno"]} " +
                    $"Name : {dr["EmpName"]} " +
                    $"Salary : {dr["Empsal"]} " +
                    $"Type : {dr["Emptype"]}"
                );
            }

            dr.Close();

            Console.WriteLine();
            Console.WriteLine("------ Add Employee ------");

            int res = emp.AddEmployee();

            if (res > 0)
            {
                Console.WriteLine("Employee Inserted Successfully");
            }
            else
            {
                Console.WriteLine("Insertion Failed");
            }

            Console.WriteLine();

            Console.WriteLine("------ Employees After Insert ------");

            dr = emp.ShowEmployees();

            while (dr.Read())
            {
                Console.WriteLine(
                    $"Empno : {dr["Empno"]} " +
                    $"Name : {dr["EmpName"]} " +
                    $"Salary : {dr["Empsal"]} " +
                    $"Type : {dr["Emptype"]}"
                );
            }

            dr.Close();

            Console.ReadLine();
        }
    }
    }
