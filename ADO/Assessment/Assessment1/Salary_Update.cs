using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Assessment
{
    
    class EmployeeService
    {
        EmployeeDataAccess dataAccess = new EmployeeDataAccess();

        public decimal IncreaseSalaryBy100(int empId)
        {
            return dataAccess.IncreaseSalary(empId);
        }

        public SqlDataReader FetchAllEmployees()
        {
            return dataAccess.FetchAllEmployees();
        }
    }

    class EmployeeDataAccess
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public SqlConnection GetConnection()
        {
            string str =
                "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=Employeemanagement;" +
                "Integrated Security=True;";

            conn = new SqlConnection(str);
            conn.Open();
            return conn;
        }

        public decimal IncreaseSalary(int empId)
        {
            decimal updatedSalary = 0;

            conn = GetConnection();

            cmd = new SqlCommand("UpdateEmpSalary", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Empno", empId);

            SqlParameter outParam = new SqlParameter();
            outParam.ParameterName = "@UpdatedSalary";
            outParam.SqlDbType = SqlDbType.Decimal;
            outParam.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(outParam);

            cmd.ExecuteNonQuery();

            updatedSalary = Convert.ToDecimal(outParam.Value);

            return updatedSalary;
        }

        
        public SqlDataReader FetchAllEmployees()
        {
            conn = GetConnection();

            cmd = new SqlCommand("SELECT * FROM Employee_Details", conn);

            dr = cmd.ExecuteReader();
            return dr;
        }
    }

    class Salary_Update
    {
        static void Main()
        {
            EmployeeService service = new EmployeeService();
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();

          
            Console.WriteLine("\n------ BEFORE UPDATE ------");

            SqlDataReader dr = dataAccess.FetchAllEmployees();

            while (dr.Read())
            {
                Console.WriteLine(
                    $"Empno: {dr["Empno"]} " +
                    $"Name: {dr["EmpName"]} " +
                    $"Salary: {dr["Empsal"]} " +
                    $"Type: {dr["Emptype"]}"
                );
            }
            dr.Close();

            Console.WriteLine("\nEnter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            decimal updated = service.IncreaseSalaryBy100(id);

            Console.WriteLine("\nUpdated Salary = " + updated);

            Console.WriteLine("\n------ AFTER UPDATE ------");

            SqlDataReader dr2 = dataAccess.FetchAllEmployees();

            while (dr2.Read())
            {
                Console.WriteLine(
                    $"Empno: {dr2["Empno"]} " +
                    $"Name: {dr2["EmpName"]} " +
                    $"Salary: {dr2["Empsal"]} " +
                    $"Type: {dr2["Emptype"]}"
                );
            }
            dr2.Close();

            Console.ReadLine();
        }
    }
}