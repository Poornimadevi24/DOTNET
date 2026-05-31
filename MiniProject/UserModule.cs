using System;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    class UserModule
    {
        static string ReadInput(string message)
        {
            Console.Write(message + ": ");
            string input = Console.ReadLine();

            if (input == "0")
                throw new OperationCanceledException();

            return input;
        }
        public static void Menu(string username)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== USER MENU =====");
                Console.WriteLine("Welcome: " + username);
                Console.WriteLine("1. Search Trains");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. Cancel Ticket");
                Console.WriteLine("4. View My Bookings");
                Console.WriteLine("5. Logout");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int ch))
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadKey();
                    continue;
                }

                switch (ch)
                {
                    case 1:
                        SearchTrains();
                        break;

                    case 2:
                        BookingModule.BookTicket(username);
                        break;

                    case 3:
                        CancellationModule.CancelTicket(username);
                        break;

                    case 4:
                        ViewMyBookings(username);
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
            }
        }

        // =========================
        // SEARCH TRAINS 
        // =========================
        static void SearchTrains()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("            SEARCH TRAIN");
            Console.WriteLine("======================================");
            Console.WriteLine("Enter 0 at any time to return back.");
            Console.WriteLine();

            string from;
            string to;

            try
            {
                from = ReadInput("Enter From Station");
                to = ReadInput("Enter To Station");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation Cancelled");
                Console.ReadKey();
                return;
            }

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                t.TrainNo,
                t.TrainName,
                t.SourceStation,
                t.DestinationStation,
                c.ClassType,
                c.Availability,
                c.Charges
            FROM TrainDetails t
            LEFT JOIN TrainClasses c ON t.TrainNo = c.TrainNo
            WHERE t.SourceStation = @from
            AND t.DestinationStation = @to
            AND t.IsDeleted = 0
            ORDER BY t.TrainNo, c.ClassType", con);

                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\n===== AVAILABLE TRAINS =====");

                bool found = false;

                while (dr.Read())
                {
                    found = true;

                    Console.WriteLine(
                        $"{dr["TrainNo"]} | {dr["TrainName"]} | " +
                        $"{dr["SourceStation"]} -> {dr["DestinationStation"]} | " +
                        $"Class:{dr["ClassType"]} | Seats:{dr["Availability"]} | Rs:{dr["Charges"]}");
                }

                if (!found)
                    Console.WriteLine("No trains found!");

                dr.Close();
            }

            Console.ReadKey();
        }

        // =========================
        // VIEW MY BOOKINGS 
        // =========================
        static void ViewMyBookings(string username)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("            VIEW MY BOOKINGS       ");
            Console.WriteLine("======================================");
            Console.WriteLine("Enter 0 at any time to return back.");
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT BookingId, TrainNo, ClassType, NoOfTickets, Amount, JourneyType, TravelDate, Status
            FROM BookingDetails
            WHERE Username=@u
            ORDER BY BookingId DESC", con);

                cmd.Parameters.AddWithValue("@u", username);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\n==============================================");
                Console.WriteLine("             YOUR BOOKINGS                   ");
                Console.WriteLine("==============================================");

                bool hasData = false;

                while (dr.Read())
                {
                    hasData = true;

                    string status = dr["Status"] == DBNull.Value ? "Booked" : dr["Status"].ToString();

                    Console.WriteLine(
                        $"{dr["BookingId"]} | Train:{dr["TrainNo"]} | Class:{dr["ClassType"]} | " +
                        $"Tickets:{dr["NoOfTickets"]} | Rs.{dr["Amount"]} | " +
                        $"{dr["JourneyType"]} | {Convert.ToDateTime(dr["TravelDate"]).ToString("dd-MM-yyyy")} | {status}");
                }

                if (!hasData)
                    Console.WriteLine("No bookings found!");

                dr.Close();
            }

            Console.WriteLine("==============================================");
            Console.ReadKey();
        }
    }
}
