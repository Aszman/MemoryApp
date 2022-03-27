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
        static Settings instance = null;
        //states
        bool isSaved; //changes are up-to-date
        bool isStartup; // changes in layout are make by synchronizing values 
       
        public int initShowTime = 5;  // in seconds, normally 15 now for dev is set 5;
        public double cardsShowTime = 1.5;  // in seconds

        public int boardWidth = 1080;
        public readonly int boardWidthMax = 1600;
        public readonly int boardWidthMin = 800;
        
        public int boardHeight = 720;
        public readonly int boardHeightMax = 900;
        public readonly int boardHeightMin = 600;

        private Settings()
        {
            InitializeComponent();

            //set maximum and minimum size of game's board
            this.nudWidth.Maximum = boardWidthMax;
            this.nudWidth.Minimum= boardWidthMin;

            this.nudHeight.Maximum = boardHeightMax;
            this.nudHeight.Minimum = boardHeightMin;
        }

        public static Settings getInstance()
        {
            if (instance == null)
            {
                instance = new Settings();
            }

            return instance;
        }

        // loading form from memory
        private void Settings_Load(object sender, EventArgs e)
        {
            isStartup = true;
            isSaved = true;

            lblBoardW.Text = "Board's width (" + boardWidthMin.ToString()
                    + "-" + boardWidthMax.ToString() + "):";

            lblBoardH.Text = "Board's height (" + boardHeightMin.ToString()
            + "-" + boardHeightMax.ToString() + "):";

            loadValues();

            isStartup = false;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.isSaved) // if not saved, it warns user about it
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

        // loads values from object variables
        private void loadValues()
        {
            // Initial show time
            this.lblInV.Text = initShowTime.ToString() + " s";
            this.trkInit.Value = initShowTime / 5;

            // Cards show time
            this.lblCardV.Text = cardsShowTime.ToString() + " s";
            this.trkCard.Value = Convert.ToInt32(cardsShowTime * 2);

            //Board width
            this.nudWidth.Value = boardWidth;

            //Board height
            this.nudHeight.Value = boardHeight;
        }

        // saves values from controls to variables inside form
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

                
            this.isSaved = true; //successfull saving
            return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.saveSettings();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trkInit_ValueChanged(object sender, EventArgs e)
        {
            this.lblInV.Text = (this.trkInit.Value * 5).ToString() + " s";

            if (!isStartup)
            {
                isSaved = false;
            }
        }

        private void trkCard_ValueChanged(object sender, EventArgs e)
        {
            this.lblCardV.Text = (this.trkCard.Value/2.0).ToString() + " s";

            if (!isStartup)
            {
                isSaved = false;
            }
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            if (!isStartup)
            {
                isSaved = false;
            }
        }
    }
}
