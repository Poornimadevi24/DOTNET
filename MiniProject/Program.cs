using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("===== TRAIN RESERVATION SYSTEM =====");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number (1-3).");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AdminLogin.Login();
                        break;

                    case 2:
                        UserLogin.Login();
                        break;

                    case 3:
                        Console.WriteLine("Exiting system... Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please select 1-3.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
