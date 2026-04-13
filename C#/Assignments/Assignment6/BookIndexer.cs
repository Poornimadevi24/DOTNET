/*1.Create a class called Books with BookName and AuthorName as members. Instantiate the class through constructor and also write a method Display() to display the details. 
Create an Indexer of Books Object to store 5 books in a class called BookShelf.Using the indexer method assign values to the books and display the same.
Hint(use Aggregation/composition)*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
  internal class Program
    { 
    class Books
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

    class BookShelf
    {
        private Books[] books = new Books[5];

      
        public Books this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
    }

    
    static void Main()
    {
            BookShelf shelf = new BookShelf();

            
            shelf[0] = new Books("The Alchemist", "Paulo Coelho");
            shelf[1] = new Books("1984", "George Orwell");
            shelf[2] = new Books("Wings of Fire", "A.P.J Abdul Kalam");
            shelf[3] = new Books("Hamlet", "William Shakespeare");
            shelf[4] = new Books("Harry Potter", "J.K. Rowling");

          
            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }
            Console.Read();
    }
}
  }

