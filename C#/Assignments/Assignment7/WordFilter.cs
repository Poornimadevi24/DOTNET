using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    internal class Class1
    {
        static void Main()
        {
            var words = new[] { "mum", "amsterdam", "bloom" };
            var result = words
                .Where(w => w.StartsWith("a") && w.EndsWith("m"));
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }
}
