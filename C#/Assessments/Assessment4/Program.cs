using CodeChallenge4.Factory;
using CodeChallenge4.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeChallenge4.Factory.ReportFactory;

namespace CodeChallenge4
{
     class Program
    {
        static void Main()
        {
            Console.WriteLine("Select report type (Chart / Tabular / Summary):");
            string type = Console.ReadLine();
            try
            {
                IReportGenerator report =
                    ReportGeneratorFactory.CreateReportGenerator(type);

                report.Generate();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

    }


    }
}
