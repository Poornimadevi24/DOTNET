using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    internal class FileHandling
    {
        static void Main()
        {
            Console.Write("Enter file path: ");
            string filepath = Console.ReadLine();

            Console.Write("Enter text to append: ");
            string text = Console.ReadLine();
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true)) 
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine("Text appended Successfully");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
