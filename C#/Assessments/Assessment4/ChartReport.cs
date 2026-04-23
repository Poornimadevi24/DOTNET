using CodeChallenge4.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge4.Models
{
    public class ChartReportGenerator : IReportGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generating Chart Report...");
        }
    }
}
