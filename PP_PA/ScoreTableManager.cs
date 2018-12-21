using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class ScoreTableManager
    {
        private StreamWriter scoreTable;

        public ScoreTableManager()
        {
            CreatePath();
        }

        public void AddScoreToFile(Player player)
        {
            if (IsHigherScore(player.Resources.Score))
            {
                scoreTable = File.AppendText(Utils.scoreTableFilePath);
                scoreTable.WriteLine(player.Username + "-" + player.Resources.Score + "-" + DateTime.Now.ToUniversalTime());
                scoreTable.Close();
            }
        }

        public bool IsHigherScore(int score)
        {
            string lastScoreLine = GetScores()[0].ToString();
            string[] lineSplit = lastScoreLine.Split('-');
            if (score > int.Parse(lineSplit[1]))
                return true;

            return false;
        }

        public void CreatePath()
        {
            if (!Directory.Exists(Utils.dataFolderPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(Utils.dataFolderPath);
            }
        }

        public ArrayList GetScores()
        {
            try
            {
                StreamReader sr = new StreamReader(Utils.scoreTableFilePath);
                string line = "";

                ArrayList textArray = new ArrayList();

                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                        textArray.Add(line);
                }

                sr.Close();

                textArray.Reverse();

                return textArray;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        
    }
}
