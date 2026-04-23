using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge4
{
    class Distance
    {
        public int Kilometer;
        public Distance(int Kilometer)
        {
            this.Kilometer = Kilometer;
        }
        public static Distance Add(Distance d1, Distance d2)
        {
            return new Distance(d1.Kilometer + d2.Kilometer);
        }
        public void Display()
        {
            Console.WriteLine("Distance Covered: " + Kilometer +"Km");
        }
    }
   
    class Test
    {
        static void Main()
        {
            Console.WriteLine("Enter d1 values in (Km): ");
            int d1value = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter d2 values in (Km): ");
            int d2value = Convert.ToInt32(Console.ReadLine());
            Distance d1 = new Distance(d1value);
            Distance d2 = new Distance(d2value);
            Distance d3 = Distance.Add(d1, d2);
            d3.Display();



        }
    }
}
