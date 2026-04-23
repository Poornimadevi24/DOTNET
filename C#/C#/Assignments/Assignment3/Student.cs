/*2. Create a class called student which has data members like rollno, name, class, Semester, branch, int [] marks=new int marks [5](marks of 5 subjects )

-Pass the details of student like rollno, name, class, SEM, branch in constructor

-For marks write a method called GetMarks() and give marks for all 5 subjects

-Write a method called displayresult, which should calculate the average marks

-If marks of any one subject is less than 35 print result as failed
-If marks of all subject is >35,but average is < 50 then also print result as failed
-If avg > 50 then print result as passed.

-Write a DisplayData() method to display all object members values.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Student
    {
        int rollNo;
        string name;
        string studentClass;
        int semester;
        string branch;
        int[] marks = new int[5];

       
        public Student(int rollNo, string name, string studentClass, int semester, string branch)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.studentClass = studentClass;
            this.semester = semester;
            this.branch = branch;
        }

        public void GetMarks(int m1, int m2, int m3, int m4, int m5)
        {
            marks[0] = m1;
            marks[1] = m2;
            marks[2] = m3;
            marks[3] = m4;
            marks[4] = m5;
        }

        public void DisplayResult()
        {
            int total = 0;
            bool fail = false;

            foreach (int m in marks)
            {
                if (m < 35)
                    fail = true;

                total += m;
            }

            double avg = total / 5.0;
            Console.WriteLine("Average: " + avg);

            if (fail || avg < 50)
                Console.WriteLine("Result: FAILED");
            else
                Console.WriteLine("Result: PASSED");
        }

        public void DisplayData()
        {
            Console.WriteLine("\n--- Student Details ---");
            Console.WriteLine("Roll No: " + rollNo);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Class: " + studentClass);
            Console.WriteLine("Semester: " + semester);
            Console.WriteLine("Branch: " + branch);

            Console.Write("Marks: ");
            foreach (int m in marks)
                Console.Write(m + " ");
            Console.WriteLine();
        }

        static void Main()
        {
            Student s = new Student(1, "Alice", "BSc", 3, "CS");
            s.GetMarks(60, 70, 80, 55, 65);
            s.DisplayData();
            s.DisplayResult();
        }
    }
}
