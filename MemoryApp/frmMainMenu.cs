using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryApp
{
    public partial class frmMainMenu : Form
    {
        frmSettings settingsForm;
        frmHighScore highScore;
        frmGame game;

        public enum Difficulties { EASY, NORMAL, HARD };

        public Difficulties chosenDifficulty = Difficulties.NORMAL;
        public String playerName;

        Regex reg = new Regex("^[a-zA-Z0-9]*$");

        public frmMainMenu()
        {
            InitializeComponent();
            settingsForm = new frmSettings();
            highScore = frmHighScore.getInstance();

            this.boxDiff.SelectedIndex = 1; // set selected difficulty to EASY
        }

        
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if( this.txtName.TextLength == 0) // if user typed own name he can play, instead can't
            {
                this.btnPlay.Enabled = false;
                this.lblFor.Visible = false;

            }
            else if (reg.IsMatch(this.txtName.Text))
            {
                this.btnPlay.Enabled = true;
                this.lblFor.Visible = false;
            }
            else
            {
                this.btnPlay.Enabled = false;
                this.lblFor.Visible = true;
            }
        }

        // open settings window
        private void btnSett_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        // choosing difficulty
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

        // saves player's name to variable and start the game's window
        private void btnPlay_Click(object sender, EventArgs e)
        {
            playerName = txtName.Text;

            this.Hide();
            game = new frmGame(this);
            game.Show();
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            highScore.ShowDialog();
        }
    }
}