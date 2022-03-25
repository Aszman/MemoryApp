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
        bool isSaved = false;
        public Settings()
        {
            InitializeComponent();
        }

        private void saveSettings()
        {
            this.isSaved = true;
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
    }
}
