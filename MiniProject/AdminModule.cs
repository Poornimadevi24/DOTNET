using System;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    class AdminModule
    {
        static string ReadInput(string message)
        {
            Console.Write(message + ": ");
            string input = Console.ReadLine();

            if (input == "0")
                throw new OperationCanceledException();

            return input;
        }
        // =========================
        // ADMIN MENU
        // =========================
        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== ADMIN MENU =====");
                Console.WriteLine("1. View Trains (Class Wise)");
                Console.WriteLine("2. Add Train + Classes");
                Console.WriteLine("3. Delete Train (Soft)");
                Console.WriteLine("4. View Bookings");
                Console.WriteLine("5. View Cancellations");
                Console.WriteLine("6. View ALL Bookings");
                Console.WriteLine("7. Admin Cancel Booking");
                Console.WriteLine("8. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int ch))
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadKey();
                    continue;
                }

                switch (ch)
                {
                    case 1: ViewTrains(); break;
                    case 2: AddTrain(); break;
                    case 3: DeleteTrain(); break;
                    case 4: ViewBookings(); break;
                    case 5: ViewCancellations(); break;
                    case 6: ViewAllBookings(); break;
                    case 7: AdminCancelBooking(); break;
                    case 8: return;
                    default: Console.WriteLine("Invalid choice!"); break;
                }

                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
            }
        }

        // =========================
        // VIEW TRAINS
        // =========================
        public static void ViewTrains()
        {
            Console.Clear();
         

            Console.WriteLine("======================================");
            Console.WriteLine("             VIEW TRAINS ");
            Console.WriteLine("======================================");
            Console.WriteLine("Enter 0 at any time to return back.");
            Console.WriteLine();

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
                SELECT t.TrainNo,t.TrainName, t.SourceStation, t.DestinationStation, c.ClassType, c.Availability, c.Charges FROM TrainDetails t
               LEFT JOIN TrainClasses c ON t.TrainNo = c.TrainNo WHERE t.IsDeleted = 0 ORDER BY t.TrainNo", con);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("===== TRAIN LIST (CLASS WISE) =====\n");

                bool found = false;

                while (dr.Read())
                {
                    found = true;

                    Console.WriteLine(
                        $"{dr["TrainNo"]} | {dr["TrainName"]} | " +
                        $"{dr["SourceStation"]} -> {dr["DestinationStation"]} | " +
                        $"Class: {dr["ClassType"]} | Seats: {dr["Availability"]} | Rs:{dr["Charges"]}");
                }

                if (!found)
                    Console.WriteLine("No trains found!");

                dr.Close();
            }

            Console.ReadKey();
        }

        // =========================
        // ADD TRAIN (FIXED FULL SAFE)
        // =========================
        public static void AddTrain()
        {
            Console.Clear();
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("            ADD TRAIN     ");
            Console.WriteLine("======================================");
            Console.WriteLine("Enter 0 at any time to return back.");
            Console.WriteLine();

            int trainNo;
            string name;
            string src;
            string dest;

            try
            {
                trainNo = int.Parse(ReadInput("Enter Train No"));
                name = ReadInput("Enter Train Name");
                src = ReadInput("Enter Source Station");
                dest = ReadInput("Enter Destination Station");
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

                // CHECK DUPLICATE
                SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM TrainDetails WHERE TrainNo=@no", con);

                check.Parameters.AddWithValue("@no", trainNo);

                if ((int)check.ExecuteScalar() > 0)
                {
                    Console.WriteLine("Train already exists!");
                    Console.ReadKey();
                    return;
                }

                SqlTransaction tx = con.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand(@"
                INSERT INTO TrainDetails
                (TrainNo, TrainName, SourceStation, DestinationStation, IsDeleted)
                VALUES (@no, @name, @src, @dest, 0)", con, tx);

                    cmd.Parameters.AddWithValue("@no", trainNo);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@src", src);
                    cmd.Parameters.AddWithValue("@dest", dest);

                    cmd.ExecuteNonQuery();

                    // DEFAULT CLASSES
                    InsertClass(con, tx, trainNo, "Sleeper", 50, 500);
                    InsertClass(con, tx, trainNo, "3AC", 40, 1200);
                    InsertClass(con, tx, trainNo, "2AC", 30, 2000);

                    tx.Commit();

                    Console.WriteLine("Train + Classes Added Successfully!");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    Console.WriteLine("Error while adding train!");
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
        }
        // =========================
        // INSERT CLASS (IMPORTANT)
        // =========================
        private static void InsertClass(SqlConnection con, SqlTransaction tx,
            int trainNo, string type, int seats, decimal charge)
        {
            SqlCommand cmd = new SqlCommand(@"
                INSERT INTO TrainClasses
                (TrainNo, ClassType, Availability, Charges)
                VALUES (@no, @type, @seat, @charge)", con, tx);

            cmd.Parameters.AddWithValue("@no", trainNo);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@seat", seats);
            cmd.Parameters.AddWithValue("@charge", charge);

            cmd.ExecuteNonQuery();
        }

        // =========================
        // SOFT DELETE TRAIN
        // =========================
        public static void DeleteTrain()
        {
            Console.Clear();
            Console.Write("Are you sure? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
                return;
            Console.Write("Train No: ");
            int t = int.Parse(Console.ReadLine());

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE TrainDetails SET IsDeleted=1 WHERE TrainNo=@t", con);

                cmd.Parameters.AddWithValue("@t", t);

                Console.WriteLine(cmd.ExecuteNonQuery() > 0
                    ? "Deleted Successfully"
                    : "Train Not Found");
            }

            Console.ReadKey();
        }

        // =========================
        // BOOKINGS
        // =========================
        public static void ViewBookings()
        {
            Console.Clear();
           

            Console.WriteLine("======================================");
            Console.WriteLine("            VIEW BOOKINGS");
            Console.WriteLine("======================================");
            Console.WriteLine("Enter 0 at any time to return back.");
            Console.WriteLine();

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM BookingDetails", con);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("===== BOOKINGS =====");

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"{dr["BookingId"]} | {dr["Username"]} | Train:{dr["TrainNo"]} | Tickets:{dr["NoOfTickets"]} | Rs.{dr["Amount"]}");
                }
            }

            Console.ReadKey();
        }

        // =========================
        // CANCELLATIONS
        // =========================
        public static void ViewCancellations()
        {
            Console.Clear();
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("            VIEW CANCELLATIONS     ");
            Console.WriteLine("======================================");
            Console.WriteLine("Enter 0 at any time to return back.");
            Console.WriteLine();

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM CancellationDetails", con);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("===== CANCELLATIONS =====");

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"{dr["CId"]} | Booking:{dr["BookingId"]} | Tickets:{dr["NoTickets"]} | Refund:{dr["RefundAmount"]}");
                }
            }

            Console.ReadKey();
        }

        // =========================
        // ALL BOOKINGS
        // =========================
        public static void ViewAllBookings()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("             VIEW TRAINS ");
            Console.WriteLine("======================================");
            Console.WriteLine("Enter 0 at any time to return back.");

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM BookingDetails", con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"{dr["BookingId"]} | {dr["Username"]} | Train:{dr["TrainNo"]} | Tickets:{dr["NoOfTickets"]} | Rs.{dr["Amount"]} | {dr["Status"]}");
                }
            }

            Console.ReadKey();
        }

        // =========================
        // ADMIN CANCEL BOOKING
        // =========================
        public static void AdminCancelBooking()
        {
            Console.Clear();
            Console.WriteLine("Enter Booking ID (or 0 to go back): ");
            int id = int.Parse(Console.ReadLine());

            if (id == 0)
            {
                return; // goes back to Admin Menu
            }

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT TrainNo, NoOfTickets, Amount, ClassType
                    FROM BookingDetails
                    WHERE BookingId=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    Console.WriteLine("Booking not found!");
                    return;
                }

                int trainNo = (int)dr["TrainNo"];
                int tickets = (int)dr["NoOfTickets"];
                decimal amount = (decimal)dr["Amount"];
                string cls = dr["ClassType"].ToString();

                dr.Close();

                new SqlCommand(
                    "UPDATE BookingDetails SET Status='Cancelled' WHERE BookingId=@id", con)
                {
                    Parameters = { new SqlParameter("@id", id) }
                }.ExecuteNonQuery();

                decimal refund = amount * 0.9m;

                SqlCommand ins = new SqlCommand(
                    "INSERT INTO CancellationDetails VALUES(@b,GETDATE(),@t,@r)", con);

                ins.Parameters.AddWithValue("@b", id);
                ins.Parameters.AddWithValue("@t", tickets);
                ins.Parameters.AddWithValue("@r", refund);
                ins.ExecuteNonQuery();

                SqlCommand upd = new SqlCommand(@"
                    UPDATE TrainClasses
                    SET Availability = Availability + @t
                    WHERE TrainNo=@tn AND ClassType=@cls", con);

                upd.Parameters.AddWithValue("@t", tickets);
                upd.Parameters.AddWithValue("@tn", trainNo);
                upd.Parameters.AddWithValue("@cls", cls);

                upd.ExecuteNonQuery();

                Console.WriteLine($"Refund: Rs.{refund}");
            }

            Console.ReadKey();
        }
    }
}