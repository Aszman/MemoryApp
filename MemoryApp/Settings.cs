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
        
        public int initShowTime = 15;  // in seconds
        public double cardsShowTime = 1.5;  // in seconds

        public int boardWidth = 1080;
        public int boardWidthMax = 1600;
        public int boardWidthMin = 800;
        
        public int boardHeight = 720;
        public int boardHeightMax = 900;
        public int boardHeightMin = 600;


        public Settings()
        {
            InitializeComponent();
            this.nudWidth.Maximum = boardWidthMax;
            this.nudWidth.Minimum= boardWidthMin;

            this.nudHeight.Maximum = boardHeightMax;
            this.nudHeight.Minimum = boardHeightMin;
        }

        private void saveSettings()
        {
            // Initial show time
            initShowTime = trkInit.Value*5;

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
            this.lblInV.Text = initShowTime.ToString() + " s";
            this.trkInit.Value = initShowTime/5;

            // Cards show time
            this.lblCardV.Text = cardsShowTime.ToString() + " s";
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

            lblBoardW.Text = "Board's width (" + boardWidthMin.ToString()
                    + "-" + boardWidthMax.ToString() + "):";

            lblBoardH.Text = "Board's height (" + boardHeightMin.ToString()
        + "-" + boardHeightMax.ToString() + "):";

            loadValues();
        }

        private void trkInit_ValueChanged(object sender, EventArgs e)
        {
            this.lblInV.Text = (this.trkInit.Value * 5).ToString() + " s";

            isSaved = false;
        }

        private void trkCard_ValueChanged(object sender, EventArgs e)
        {
            this.lblCardV.Text = (this.trkCard.Value/2.0).ToString() + " s";

            isSaved = false;
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            isSaved = false;
        }
    }
}
