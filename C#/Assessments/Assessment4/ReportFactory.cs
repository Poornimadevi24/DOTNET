using CodeChallenge4.Interface;
using CodeChallenge4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge4.Factory
{
    class ReportFactory
    {
        public class ReportGeneratorFactory
        {
            public static IReportGenerator CreateReportGenerator(string type)
            {
                switch (type.ToLower())
                {
                    case "chart":
                        return new ChartReportGenerator();

                    case "tabular":
                        return new TabularReportGenerator();

                    case "summary":
                        return new SummaryReportGenerator();

                    default:
                        throw new ArgumentException("Invalid report type selected");
                }
            }
        }

    }
}
    

