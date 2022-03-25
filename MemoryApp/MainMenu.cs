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
        Settings settings;
        Game game;
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
    }
}
