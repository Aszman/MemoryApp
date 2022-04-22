using System;
using System.Windows.Forms;

namespace MemoryApp
{
    public partial class frmSettings : Form
    {
        private ManSettings settingsManager;
        //states
        bool isSaved; //changes are up-to-date
        bool isStartup; // changes in layout are make by synchronizing values 
       
        public frmSettings()
        {
            settingsManager = ManSettings.getInstance();

            InitializeComponent();

            //set maximum and minimum size of game's board
            this.nudWidth.Maximum = ManSettings.boardWidthMax;
            this.nudWidth.Minimum = ManSettings.boardWidthMin;

            this.nudHeight.Maximum = ManSettings.boardHeightMax;
            this.nudHeight.Minimum = ManSettings.boardHeightMin;

            lblBoardW.Text = "Board's width (" + ManSettings.boardWidthMin.ToString()
                    + "-" + ManSettings.boardWidthMax.ToString() + "):";

            lblBoardH.Text = "Board's height (" + ManSettings.boardHeightMin.ToString()
            + "-" + ManSettings.boardHeightMax.ToString() + "):";
        }


        // loading form from memory
        private void Settings_Load(object sender, EventArgs e)
        {
            isStartup = true;
            isSaved = true;

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

        // loads values from manager variables
        private void loadValues()
        {
            // Initial show time
            this.lblInV.Text = settingsManager.initCardsShowTime.ToString() + " s";
            this.trkInit.Value = settingsManager.initCardsShowTime / 5;

            // Cards show time
            this.lblCardV.Text = settingsManager.cardsFaceUpShowTime.ToString() + " s";
            this.trkCard.Value = Convert.ToInt32(settingsManager.cardsFaceUpShowTime * 2);

            //Board width
            this.nudWidth.Value = settingsManager.boardWidth;

            //Board height
            this.nudHeight.Value = settingsManager.boardHeight;
        }

        // saves values from controls to variables inside manager
        private void saveSettings()
        {
            // Initial show time
            settingsManager.initCardsShowTime = trkInit.Value*5;

            // Cards show time
            settingsManager.cardsFaceUpShowTime = trkCard.Value/2.0;

            //Board width
            settingsManager.boardWidth = Convert.ToInt32(this.nudWidth.Value);

            //Board height
            settingsManager.boardHeight = Convert.ToInt32(this.nudHeight.Value);

                
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
