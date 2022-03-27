using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                string text = File.ReadAllText(this.fileURL);
            }
            else
            {
                File.Create(this.fileURL);
            }
        }
    }

    public class Item
    {
        public String name;
        public int score;
    }
}
