using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
   

    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine("Book: " + BookName + ", Author: " + AuthorName);
        }
    }
   

public class BookShelf
    {
        private Books[] bookList = new Books[5];

        public Books this[int index]
        {
            get
            {
                return bookList[index];
            }
            set
            {
                bookList[index] = value;
            }
        }
    }
    internal class Class2
    {
        static void Main()
        {
            BookShelf shelf = new BookShelf();

            shelf[0] = new Books("C# Basics", "John");
            shelf[1] = new Books("OOP Concepts", "Alice");
            shelf[2] = new Books("Data Structures", "Bob");
            shelf[3] = new Books("Algorithms", "Charlie");
            shelf[4] = new Books("Database Systems", "David");

            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }
        }
    }
}
