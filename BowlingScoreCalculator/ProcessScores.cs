using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    class ProcessScores
    {
        Scores myScores = new Scores();

        public void ProcessTheseScores()
        {
            myScores.GetScores();
            foreach (Score score in myScores.BowlingScores)
            {
                score.TotalScore = FindTotalScore(score.FrameScores);
                Console.WriteLine("Frames: " + score.FrameScores);
                Console.WriteLine("Total: " + score.TotalScore);
                myScores.UpdateTotalScore(score.Id, score.TotalScore);
            }
            Console.ReadLine();
        }
        public int FindTotalScore(string frameScores)
        {
            List<char> rolls = new List<char>();
            rolls = BuildAllRolls(frameScores);
            return ParseFramesForTotal(rolls);
        }
        public List<char> BuildAllRolls(string frameScores)
        {
            char space = ' ';
            List<char> theseRolls = new List<char>();
            for (int i = 0; i < frameScores.Length; i++)
            {
                if (!frameScores[i].Equals(space))
                {
                    theseRolls.Add(frameScores[i]);
                }
            }    
            return theseRolls;
        }

        public int ParseFramesForTotal(List<char> rolls)
        {
            char strike = 'X';
            char spare = '/';
            int total = 0;
            int roll = 0;
            for(int frame = 1; frame < 11; frame++)
            {
                if (rolls[roll] == strike)
                {
                    total += GetStrikeValue(rolls, roll);
                    roll += 1;
                }
                else if (rolls[roll+1] != spare)
                {
                    total += GetOpenFrameValue(rolls, roll);
                    roll += 2;
                }
                else
                {
                    total += GetSpareValue(rolls, roll);
                    roll += 2;
                }
            }
            return total;
        }
        public int GetSpareValue(List<char> rolls, int thisRoll)
        {
            char strike = 'X';
            int spareValue = 10;
            if (rolls[thisRoll + 2] == strike)
                spareValue += 10;
            else
                spareValue += (int)Char.GetNumericValue(rolls[thisRoll + 2]);
            return spareValue;
        }
        public int GetOpenFrameValue(List<char> rolls, int thisRoll)
        {
            int value = 0;
            value = ((int)Char.GetNumericValue(rolls[thisRoll])) + ((int)Char.GetNumericValue(rolls[thisRoll + 1]));
            return value;
        }
        public int GetStrikeValue(List<char> rolls, int thisRoll)
        {
            char strike = 'X';
            char spare = '/';
            int strikeValue = 10;
            if (rolls[thisRoll + 1] == strike)
                strikeValue += 10;
            else
                strikeValue += (int)Char.GetNumericValue(rolls[thisRoll + 1]);

            if (rolls[thisRoll + 2] == strike)
                strikeValue += 10;
            else if (rolls[thisRoll + 2] == spare)
                strikeValue += (10-(int)Char.GetNumericValue(rolls[thisRoll + 1]));
            else
                strikeValue += (int)Char.GetNumericValue(rolls[thisRoll + 2]);
            return strikeValue;
        }
    }
}
