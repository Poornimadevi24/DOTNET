using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    abstract class Student
    {
        public String Name;
        public int StudentId;
        public double Grade;
        public abstract bool IsPassed(double grade);

    }
    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }
    internal class Program
    {
        static void Main()
        {
            Student ug = new Undergraduate() { Name = "Mary", StudentId = 01, Grade = 75 };
            Student g = new Graduate() { Name = "John", StudentId = 02, Grade = 78 };
            Console.WriteLine("Undergraduate Passed: " + ug.IsPassed(ug.Grade));
            Console.WriteLine("Undergraduate Passed: " + g.IsPassed(g.Grade));
            Console.Read();
        }
    }
}