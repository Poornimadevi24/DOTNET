//2. Write a program in C# Sharp to create a file and write an array of strings to the file. Also Read from the file
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Class1
    {
       static void Main()
        {
          string path = "sample.txt";

            string[] lines = {
            "Hello World",
            "Welcome to C#",
            "File Handling Example",
            "Goodbye!"
        };

           
            File.WriteAllLines(path, lines);
            Console.WriteLine("Data written to file.");

           
            string[] readLines = File.ReadAllLines(path);

            Console.WriteLine("\nReading from file:");
            foreach (string line in readLines)
            {
                Console.WriteLine(line);
            }
            Console.Read();
        }
    }
}

