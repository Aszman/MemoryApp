using System;
using System.Windows.Forms;

namespace MemoryApp
{
    public partial class frmHighScore : Form
    {
        ManHighScore highScoreManager;
 
       public frmHighScore()
        {
            InitializeComponent();

            highScoreManager = ManHighScore.getInstance();


            highScoreManager.LoadFromFile();
        }

        private void HighScore_Load(object sender, EventArgs e)
        {
            listScore.Items.Clear();
            foreach(ScoreItem item in highScoreManager.items)
            {
                ListViewItem l_item = new ListViewItem(new string[] { item.name, item.score.ToString() });

                listScore.Items.Add(l_item);
            }
        }
    }


}
