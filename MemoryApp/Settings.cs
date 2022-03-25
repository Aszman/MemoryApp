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
    public partial class Settings : Form
    {
        bool isSaved;

        private int initShowTime = 3;  // in seconds
        private double cardsShowTime = 1.5;  // in seconds

        private int boardWidth = 1080;
        private int boardHeight = 920;

        public Settings()
        {
            InitializeComponent();
        }

        private void saveSettings()
        {
            // Initial show time
            initShowTime = trkInit.Value;

            // Cards show time
            cardsShowTime = trkCard.Value/2.0;

            //Board width
            boardWidth = Convert.ToInt32(this.nudWidth.Value);

            //Board height
            boardHeight = Convert.ToInt32(this.nudHeight.Value);

            this.isSaved = true;
            return;
        }

        private void loadValues()
        {
            // Initial show time
            this.lblInV.Text = initShowTime.ToString() + "s";
            this.trkInit.Value = initShowTime;

            // Cards show time
            this.lblCardV.Text = cardsShowTime.ToString() + "s";
            this.trkCard.Value = Convert.ToInt32(cardsShowTime * 2);

            //Board width
            this.nudWidth.Value = boardWidth;

            //Board height
            this.nudHeight.Value = boardHeight;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.saveSettings();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.isSaved)
            { 
                DialogResult response = MessageBox.Show("Do you want to save new settings?",
                   "Saving",
                   MessageBoxButtons.YesNoCancel);

                switch (response)
                {
                    case DialogResult.Yes:
                        this.saveSettings();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            isSaved = true;

            lblBoardW.Text = "Board's width (" + nudWidth.Minimum.ToString()
                    + "-" + nudWidth.Maximum.ToString() + "):";

            lblBoardH.Text = "Board's height (" + nudHeight.Minimum.ToString()
        + "-" + nudHeight.Maximum.ToString() + "):";

            loadValues();
        }

        private void trkInit_ValueChanged(object sender, EventArgs e)
        {
            this.lblInV.Text = this.trkInit.Value.ToString() + "s";

            isSaved = false;
        }

        private void trkCard_ValueChanged(object sender, EventArgs e)
        {
            this.lblCardV.Text = (this.trkCard.Value/2.0).ToString() + "s";

            isSaved = false;
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            isSaved = false;
        }
    }
}
