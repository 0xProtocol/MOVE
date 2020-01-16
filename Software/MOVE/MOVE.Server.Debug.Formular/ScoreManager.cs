using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace MOVE.Server.Debug.Formular
{
    class ScoreManager
    {
        private static ScoreManager _instance = new ScoreManager();
        List<Score> _scoresList = new List<Score>();

        string _connectstring = @"Data Source=-MARKUS\SQLEXPRESS; Initial Catalog=MOVE_Highscore; Integrated Security=True;";

        private ScoreManager()
        {

        }

        public static ScoreManager GetInstance()
        {
            return _instance;
        }

        public List<Score> GetScoreList()
        {
            return _scoresList;
        }

        public List<Score> GetSortedScoreList()
        {
            SortList();
            return _scoresList;
        }

        public void SaveScoreToCSV(string name, int points)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream("highscore.csv", FileMode.Append);
                sw = new StreamWriter(fs);

                Score s = new Score(name, points, DateTime.Now);
                sw.WriteLine(s);
            }
            catch (Exception)
            {
                
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        public void LoadScoreFromCSV()
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                _scoresList.Clear();
                fs = new FileStream("highscore.csv", FileMode.Open);
                sr = new StreamReader(fs);
                string res = string.Empty;

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] column = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    Score s = new Score(column[0], Convert.ToInt32(column[1]), Convert.ToDateTime(column[2]));
                    _scoresList.Add(s);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }

        public void LoadScoresFromDB()
        {
            try
            {
                _scoresList.Clear();
                SqlConnection cnn = new SqlConnection(_connectstring);
                SqlCommand readCommand = new SqlCommand("SELECT PlayerName, Points FROM Scores", cnn);
                cnn.Open();
                SqlDataReader myReader = readCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //Score s = new Score(myReader["PlayerName"].ToString(), Convert.ToInt32(myReader["Points"].ToString()));
                    //_scoresList.Add(s);
                }

                cnn.Close();
            }
            catch (Exception)
            {
                
            }
        }

        public void SaveScoreToDB(string name, string points)
        {
            string sql = "insert into Scores ([PlayerName], [Points]) values(@name,@points)";

            using (SqlConnection cnn = new SqlConnection(_connectstring))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@points", SqlDbType.Int).Value = points;

                        int rowsAdded = cmd.ExecuteNonQuery();
                        /*if (rowsAdded > 0)
                            return true;
                        else
                            return false;*/
                    }

                    cnn.Close();
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void SortList()
        {
            List<Score> sortedList = _scoresList.OrderByDescending(s => s.Points).ToList();
            _scoresList.Clear();
            foreach (Score s in sortedList)
            {
                _scoresList.Add(s);
            }
        }
    }
}
