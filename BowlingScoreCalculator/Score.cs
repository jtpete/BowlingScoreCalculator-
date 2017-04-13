using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    public class Score
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private string frameScores;
        public string FrameScores { get { return frameScores; } set { frameScores = value; } }
        private int totalScore;
        public int TotalScore { get { return totalScore; } set { totalScore = value; } }
    }
}
