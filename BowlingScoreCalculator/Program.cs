using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessScores myScores = new ProcessScores();
            myScores.ProcessTheseScores();
        }
    }
}
