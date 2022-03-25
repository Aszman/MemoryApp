using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryApp
{
    public partial class MainMenu : Form
    {
        public Settings settings;
        Game game;

        public enum Difficulties { EASY, NORMAL, HARD };

        public Difficulties chosenDifficulty = Difficulties.EASY;
       

        public MainMenu()
        {
            InitializeComponent();
            settings = new Settings();
            this.boxDiff.SelectedIndex = 0; 
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if( this.txtName.TextLength == 0)
            {
                this.btnPlay.Enabled = false;
            }
            else
            {
                this.btnPlay.Enabled = true;
            }
        }

        private void btnSett_Click(object sender, EventArgs e)
        {
            settings.ShowDialog();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            game = new Game(this);
            game.Show();
        }

        private void boxDiff_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.boxDiff.SelectedIndex)
            {
                case 0:
                    this.chosenDifficulty = Difficulties.EASY;
                    break;

                case 1:
                default:
                    this.chosenDifficulty = Difficulties.NORMAL;
                    break;

                case 2:
                    this.chosenDifficulty = Difficulties.HARD;
                    break;
            }
        }
    }
}
