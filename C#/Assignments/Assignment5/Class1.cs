using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class InvalidMarksException : Exception
    {
        public InvalidMarksException(string message) : base(message)
        {
        }
    }
   

public class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            if (marks >= 70 && marks <= 80)
                return fees * 0.20;

            else if (marks > 80 && marks <= 90)
                return fees * 0.30;

            else if (marks > 90)
                return fees * 0.50;

            else
                throw new InvalidMarksException("Marks not eligible for scholarship");
        }
    }
    internal class Class1
    {
        static void Main()
        {
            try
            {
                Scholarship s = new Scholarship();
                double amount = s.Merit(85, 50000);
                Console.WriteLine("Scholarship Amount: " + amount);
            }
            catch (InvalidMarksException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
