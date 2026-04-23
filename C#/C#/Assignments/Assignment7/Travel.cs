using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary3
{
    internal class Travel
    {
        public string CalculateConcession(int age, double totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double discountedFare = totalFare - (totalFare * 0.30);
                return $"Senior Citizen - Fare after 30% concession: {discountedFare}";
            }
            else
            {
                return $"Ticket Booked - Fare: {totalFare}";
            }
        }
    }
}
