using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryApp
{
    public partial class HighScore : Form
    {
        private static HighScore instance = null;
        private String fileURL = "..\\..\\Scores.txt";

        private List<Item> items = new List<Item>();
        private HighScore()
        {
            InitializeComponent();
            LoadFromFile();
        }

        public static HighScore getInstance()
        {
            if(instance == null)
            {
                instance = new HighScore();
            }

            return instance;
        }

        private void LoadFromFile()
        {
            if (File.Exists(this.fileURL))
            {
                string[] lines = File.ReadAllLines(this.fileURL);
                
                // one score
                foreach(string line in lines)
                {
                    string[] values = line.Split(new char[] { ';' });
                    if(values.Length == 2)
                    {
                        Item newItem = new Item();
                        newItem.name = values[0];

                        int _score;
                        if(int.TryParse(values[1], out _score))
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

            this.items.Sort((i1, i2 )=> i2.score.CompareTo(i1.score));
        }

        private void SaveToFile()
        {
            StringBuilder b = new StringBuilder();
            foreach (Item item in items)
            {
                b.Append(item.name + ";" + item.score + "\n");
            }

            File.WriteAllText(this.fileURL, b.ToString());
        }

        public void AddScore(Score newScore)
        {
            Item newItem = new Item();

            newItem.name = newScore.getName();
            newItem.score = newScore.getScore();

            this.items.Add(newItem);
            this.items.Sort((i1, i2) => i2.score.CompareTo(i1.score));

            SaveToFile();
        }


        private void HighScore_Load(object sender, EventArgs e)
        {
            listScore.Items.Clear();
            foreach(Item item in items)
            {
                ListViewItem l_item = new ListViewItem(new string[] { item.name, item.score.ToString() });

                listScore.Items.Add(l_item);
            }
        }
    }

    public class Item
    {
        public String name;
        public int score;
    }
}
