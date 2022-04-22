using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MemoryApp
{
    class ManHighScore
    {
        private static ManHighScore instance = null;

        //url to file with saved scores
        private string fileURL = "..\\..\\Scores.txt";

        public List<ScoreItem> items = new List<ScoreItem>();

        private ManHighScore()
        {
            LoadFromFile();
        }

        public static ManHighScore getInstance()
        {
            if (instance == null)
            {
                instance = new ManHighScore();
            }

            return instance;
        }

        public void LoadFromFile()
        {

            if (File.Exists(this.fileURL))
            {
                this.items.Clear();

                string[] lines = File.ReadAllLines(this.fileURL);

                // one score
                foreach (string line in lines)
                {
                    string[] values = line.Split(new char[] { ';' });
                    if (values.Length == 2)
                    {
                        ScoreItem newItem = new ScoreItem();
                        newItem.name = values[0];

                        int _score;
                        if (int.TryParse(values[1], out _score))
                        {
                            newItem.score = _score;
                            this.items.Add(newItem);
                        }
                    }
                }
            }
            else
            {
                File.Create(this.fileURL);
            }

            this.items.Sort((i1, i2) => i2.score.CompareTo(i1.score));
        }

        public void SaveToFile()
        {
            StringBuilder b = new StringBuilder();
            foreach (ScoreItem item in items)
            {
                b.Append(item.name + ";" + item.score + "\n");
            }

            File.WriteAllText(this.fileURL, b.ToString());
        }

        public void AddScore(Score newScore)
        {
            ScoreItem newItem = new ScoreItem();

            newItem.name = newScore.getName();
            newItem.score = newScore.getScore();

            this.items.Add(newItem);
            this.items.Sort((i1, i2) => i2.score.CompareTo(i1.score));

            SaveToFile();
        }

    }

    public class ScoreItem
    {
        public string name;
        public int score;
    }
}
