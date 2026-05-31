using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrainReservationSystem
{
    class AdminLogin
    {
        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("===== ADMIN LOGIN =====");

            Console.Write("Enter Username: ");
            string user = Console.ReadLine();

            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                Console.WriteLine("Username or Password cannot be empty!");
                Console.ReadKey();
                return;
            }

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM AdminLogin WHERE Username=@u AND Password=@p", con);

                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@p", pass);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    Console.WriteLine("\nLogin Successful ");
                    Console.WriteLine("Welcome Admin!");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();

                    //  GO TO MENU 
                    AdminModule.Menu();
                }
                else
                {
                    Console.WriteLine("\nInvalid Username or Password ");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}

