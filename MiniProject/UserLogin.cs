using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem
{
    class UserLogin
    {
        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("===== USER LOGIN =====");

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
                    "SELECT COUNT(*) FROM UserLogin WHERE Username=@u AND Password=@p", con);

                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@p", pass);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    Console.WriteLine("\nLogin Successful ");
                    Console.WriteLine($"Welcome {user}");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();

                    // Go to user menu
                    UserModule.Menu(user);
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