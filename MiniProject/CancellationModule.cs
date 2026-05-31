using System;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    class CancellationModule
    {
       
        public static void CancelTicket(string username)
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("             CANCELLATION  TICKET    ");
            Console.WriteLine("======================================");

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                // STEP 1: SHOW ONLY ACTIVE BOOKINGS
                SqlCommand view = new SqlCommand(@"
                    SELECT BookingId, TrainNo, ClassType, NoOfTickets, Amount
                    FROM BookingDetails
                    WHERE Username=@u AND Status='Booked'", con);

                view.Parameters.AddWithValue("@u", username);

                SqlDataReader dr = view.ExecuteReader();

                Console.WriteLine("\n===== YOUR ACTIVE BOOKINGS =====");

                bool found = false;

                while (dr.Read())
                {
                    found = true;
                    Console.WriteLine(
                        $"{dr["BookingId"]} | Train:{dr["TrainNo"]} | Class:{dr["ClassType"]} | Tickets:{dr["NoOfTickets"]} | Rs.{dr["Amount"]}");
                }

                dr.Close();

                if (!found)
                {
                    Console.WriteLine("No active bookings found!");
                    Console.ReadKey();
                    return;
                }

                // STEP 2: SELECT BOOKING
                Console.Write("Are you sure? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                    return;
                Console.Write("\nEnter Booking ID to cancel: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadKey();
                    return;
                }

                // STEP 3: GET BOOKING DETAILS 
                SqlCommand get = new SqlCommand(@"
                    SELECT TrainNo, ClassType, NoOfTickets, Amount, Status
                    FROM BookingDetails
                    WHERE BookingId=@id AND Username=@u", con);

                get.Parameters.AddWithValue("@id", id);
                get.Parameters.AddWithValue("@u", username);

                SqlDataReader r = get.ExecuteReader();

                if (!r.Read())
                {
                    Console.WriteLine("Booking not found!");
                    r.Close();
                    Console.ReadKey();
                    return;
                }

                if (r["Status"].ToString() == "Cancelled")
                {
                    Console.WriteLine("Booking already cancelled!");
                    r.Close();
                    Console.ReadKey();
                    return;
                }

                int trainNo = Convert.ToInt32(r["TrainNo"]);
                string cls = r["ClassType"].ToString();
                int tickets = Convert.ToInt32(r["NoOfTickets"]);
                decimal amount = Convert.ToDecimal(r["Amount"]);

                r.Close();

                // STEP 4: UPDATE STATUS (CANCEL BOOKING)
                SqlCommand up = new SqlCommand(@"
                    UPDATE BookingDetails
                    SET Status='Cancelled'
                    WHERE BookingId=@id AND Username=@u", con);

                up.Parameters.AddWithValue("@id", id);
                up.Parameters.AddWithValue("@u", username);

                up.ExecuteNonQuery();

                // STEP 5: REFUND CALCULATION
                decimal refund = amount * 0.9m;

                SqlCommand ins = new SqlCommand(@"
                    INSERT INTO CancellationDetails
                    (BookingId, CancelDate, NoTickets, RefundAmount)
                    VALUES(@b, GETDATE(), @t, @r)", con);

                ins.Parameters.AddWithValue("@b", id);
                ins.Parameters.AddWithValue("@t", tickets);
                ins.Parameters.AddWithValue("@r", refund);

                ins.ExecuteNonQuery();

                // STEP 6: RESTORE SEATS
                SqlCommand seat = new SqlCommand(@"
                    UPDATE TrainClasses
                    SET Availability = Availability + @t
                    WHERE TrainNo=@tn AND ClassType=@cls", con);

                seat.Parameters.AddWithValue("@t", tickets);
                seat.Parameters.AddWithValue("@tn", trainNo);
                seat.Parameters.AddWithValue("@cls", cls);

                seat.ExecuteNonQuery();

                Console.WriteLine("\nCancellation Successful!");
                Console.WriteLine($"Refund Amount: Rs.{refund}");

                Console.ReadKey();
            }
        }
    }
}