using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    public class CricketTeam
    {
        public void PointsCalculate(int num)
        {
            int sum = 0;
            Console.WriteLine("Enter the Scores: ");
            for(int i=0;i<num;i++)
            {
                int score = Convert.ToInt32(Console.ReadLine());
                sum += score;

            }
            double avg = (double)sum / num;
            Console.WriteLine("No of Matches: " + num);
            Console.WriteLine("Total Score: " + sum);
            Console.WriteLine("Average Score: " + avg);
        }
    }

    internal class Programe
    {
        static void Main()
        {
            CricketTeam team = new CricketTeam();
            Console.WriteLine("Enter number of matches: ");
            int matches = Convert.ToInt32(Console.ReadLine());
            team.PointsCalculate(matches);


        }
    }
}
