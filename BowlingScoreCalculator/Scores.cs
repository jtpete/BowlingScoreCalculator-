using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoreCalculator
{
    class Scores
    {
        private List<Score> bowlingScores = new List<Score>();
        public List<Score> BowlingScores { get { return bowlingScores; } set { bowlingScores = value; } }
        SqlConnection mydb = new SqlConnection("Server=LAPTOP-MR3G567K; Database=BowlingScores;Integrated Security=true;");

        public void GetScores()
        {
            try
            {
                mydb.Open();
                string getScoresQuery = "SELECT * FROM Scores";
                SqlCommand myCmd = new SqlCommand(getScoresQuery, mydb);
                SqlDataReader myRead = myCmd.ExecuteReader();
                while (myRead.Read())
                {
                    Score aScore = new Score();
                    aScore.FrameScores = myRead.GetString(1);
                    aScore.Id = (int)myRead[0];
                    bowlingScores.Add(aScore);
                }
                myRead.Close();

            }
            catch(Exception e)
            {
                Console.Write("Getting Scores From DB --- " + e);
                Console.ReadLine();
            }
            finally
            {
                mydb.Close();
            }
        }
        public void UpdateTotalScore(int ScoreId, int totalScore)
        {
            try
            {
                mydb.Open();
                string updateQuery = $"UPDATE Scores SET Total_Score={totalScore} WHERE Score_Id={ScoreId}";
                SqlCommand myCmd = new SqlCommand(updateQuery, mydb);
                myCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write("Updating Total Score --- " + e);
                Console.ReadLine();
            }
            finally
            {
                mydb.Close();
            }
        }
    }
}
