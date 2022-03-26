
namespace MemoryApp
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timInit = new System.Windows.Forms.Timer(this.components);
            this.timShow = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timInit
            // 
            this.timInit.Tick += new System.EventHandler(this.timInit_Tick);
            // 
            // timShow
            // 
            this.timShow.Tick += new System.EventHandler(this.timShow_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.MinimumSize = new System.Drawing.Size(604, 495);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.Game_ResizeEnd);
            this.Resize += new System.EventHandler(this.Game_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timInit;
        private System.Windows.Forms.Timer timShow;
    }
}