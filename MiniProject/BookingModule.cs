using System;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    class BookingModule
    {
        static string ReadInput(string message)
        {
            Console.Write(message + ": ");
            string input = Console.ReadLine();

            if (input == "0")
                throw new OperationCanceledException();

            return input;
        }

        public static void BookTicket(string username)
        {
            try
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("            BOOK TICKET");
                Console.WriteLine("======================================");
                Console.WriteLine("Enter 0 at any time to return back.");
                Console.WriteLine();

                using (SqlConnection con = DBHelper.GetConnection())
                {
                    con.Open();

                    // STEP 1
                    string from = ReadInput("Enter Source");
                    string to = ReadInput("Enter Destination");

                    SqlCommand cmd = new SqlCommand(@"
                 SELECT t.TrainNo, t.TrainName, tc.ClassType, tc.Availability, tc.Charges FROM TrainDetails t   LEFT JOIN  TrainClasses tc  ON t.TrainNo = tc.TrainNo
                 WHERE t.SourceStation = @f AND t.DestinationStation = @t AND t.IsDeleted = 0 ORDER BY t.TrainNo, tc.ClassType", con);

                    cmd.Parameters.AddWithValue("@f", from);
                    cmd.Parameters.AddWithValue("@t", to);

                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine("\n================================================================================");
                    Console.WriteLine("Train No\tTrain Name\t\tClass\tSeats\tPrice");
                    Console.WriteLine("================================================================================");

                    bool found = false;

                    while (dr.Read())
                    {
                        found = true;

                        Console.WriteLine(
                            $"{dr["TrainNo"]}\t\t" +
                            $"{dr["TrainName"],-20}" +
                            $"{dr["ClassType"],-8}" +
                            $"{dr["Availability"],-8}" +
                            $"Rs.{dr["Charges"]}");
                    }

                    dr.Close();

                    if (!found)
                    {
                        Console.WriteLine("No trains found!");
                        Console.ReadKey();
                        return;
                    }

                    // STEP 2
                    int trainNo = Convert.ToInt32(ReadInput("\nEnter Train No"));

                    // STEP 3
                    SqlCommand classCmd = new SqlCommand(@"
                        SELECT ClassType, Availability, Charges
                        FROM TrainClasses
                        WHERE TrainNo=@t", con);

                    classCmd.Parameters.AddWithValue("@t", trainNo);

                    SqlDataReader cr = classCmd.ExecuteReader();

                    Console.WriteLine("\n===== CLASSES =====");

                    bool classFound = false;

                    while (cr.Read())
                    {
                        classFound = true;
                        Console.WriteLine($"{cr["ClassType"]} | Seats:{cr["Availability"]} | Rs:{cr["Charges"]}");
                    }

                    cr.Close();

                    if (!classFound)
                    {
                        Console.WriteLine("No class found!");
                        Console.ReadKey();
                        return;
                    }

                    // STEP 4
                    string classType = ReadInput("\nEnter Class Type");

                    // STEP 5
                    SqlCommand get = new SqlCommand(@"
                        SELECT Availability, Charges
                        FROM TrainClasses
                        WHERE TrainNo=@t AND ClassType=@c", con);

                    get.Parameters.AddWithValue("@t", trainNo);
                    get.Parameters.AddWithValue("@c", classType);

                    SqlDataReader r = get.ExecuteReader();

                    if (!r.Read())
                    {
                        Console.WriteLine("Invalid Class!");
                        Console.ReadKey();
                        return;
                    }

                    int available = Convert.ToInt32(r["Availability"]);
                    decimal charge = Convert.ToDecimal(r["Charges"]);

                    r.Close();

                    // STEP 6
                    DateTime travelDate = Convert.ToDateTime(ReadInput("Enter Travel Date (yyyy-mm-dd)"));

                    int tickets = Convert.ToInt32(ReadInput("Enter Tickets (Max 3)"));

                    if (tickets > 3)
                    {
                        Console.WriteLine("Max 3 tickets allowed!");
                        Console.ReadKey();
                        return;
                    }

                    if (tickets > available)
                    {
                        Console.WriteLine("Not enough seats!");
                        Console.ReadKey();
                        return;
                    }

                    string passengers = ReadInput("Enter Passengers");
                    string journeyType = ReadInput("Enter Journey Type (Oneway/Return)");

                    decimal amount = charge * tickets;

                    if (journeyType.ToLower() == "return")
                        amount *= 2;

                    // STEP 7 INSERT
                    SqlCommand insert = new SqlCommand(@"
                        INSERT INTO BookingDetails
                        (Username, BookDate, TravelDate, TrainNo, ClassType, Passengers, NoOfTickets, Amount, JourneyType, Status)
                        VALUES
                        (@u, GETDATE(), @td, @tn, @cls, @p, @nt, @amt, @jt, 'Booked');
                        SELECT SCOPE_IDENTITY();", con);

                    insert.Parameters.AddWithValue("@u", username);
                    insert.Parameters.AddWithValue("@td", travelDate);
                    insert.Parameters.AddWithValue("@tn", trainNo);
                    insert.Parameters.AddWithValue("@cls", classType);
                    insert.Parameters.AddWithValue("@p", passengers);
                    insert.Parameters.AddWithValue("@nt", tickets);
                    insert.Parameters.AddWithValue("@amt", amount);
                    insert.Parameters.AddWithValue("@jt", journeyType);

                    int bookingId = Convert.ToInt32(insert.ExecuteScalar());

                    // STEP 8 UPDATE SEATS
                    SqlCommand update = new SqlCommand(@"
                        UPDATE TrainClasses
                        SET Availability = Availability - @t
                        WHERE TrainNo=@tn AND ClassType=@cls", con);

                    update.Parameters.AddWithValue("@t", tickets);
                    update.Parameters.AddWithValue("@tn", trainNo);
                    update.Parameters.AddWithValue("@cls", classType);

                    update.ExecuteNonQuery();

                    Console.WriteLine("\nBooking Successful!");
                    Console.WriteLine($"PNR: {bookingId}{trainNo}");

                    // ⭐ PRINT TICKET HERE
                    PrintTicket(bookingId, username, trainNo, classType, from, to, travelDate, passengers, tickets, journeyType, amount);

                    Console.ReadKey();
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to User Menu...");
                Console.ReadKey();
            }
        }

        // =========================
        // PRINT TICKET
        // =========================
        static void PrintTicket(
            int bookingId,
            string username,
            int trainNo,
            string classType,
            string from,
            string to,
            DateTime travelDate,
            string passengers,
            int tickets,
            string journeyType,
            decimal amount)
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("         TRAIN E - TICKET             ");
            Console.WriteLine("======================================");
            Console.WriteLine($"Booking ID   : {bookingId}");
            Console.WriteLine($"PNR No       : {bookingId}{trainNo}");
            Console.WriteLine($"User         : {username}");
            Console.WriteLine($"Train No     : {trainNo}");
            Console.WriteLine($"Class        : {classType}");
            Console.WriteLine($"From         : {from}");
            Console.WriteLine($"To           : {to}");
            Console.WriteLine($"Travel Date  : {travelDate:dd-MM-yyyy}");
            Console.WriteLine($"Passengers   : {passengers}");
            Console.WriteLine($"Tickets      : {tickets}");
            Console.WriteLine($"Journey Type : {journeyType}");
            Console.WriteLine($"Total Amount : Rs.{amount}");
            Console.WriteLine("======================================");
            Console.WriteLine("          HAPPY JOURNEY                ");
            Console.WriteLine("======================================");

            Console.WriteLine("\nPress any key to continue...");
        }
    }
}