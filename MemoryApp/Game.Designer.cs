
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
            this.lblLine = new System.Windows.Forms.Label();
            this.boxPause = new System.Windows.Forms.PictureBox();
            this.btnSett = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.boxPause)).BeginInit();
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
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLine.Location = new System.Drawing.Point(0, 500);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(1600, 2);
            this.lblLine.TabIndex = 0;
            // 
            // boxPause
            // 
            this.boxPause.Image = global::MemoryApp.Properties.Resources.pauseIcon;
            this.boxPause.Location = new System.Drawing.Point(366, 505);
            this.boxPause.Name = "boxPause";
            this.boxPause.Size = new System.Drawing.Size(50, 50);
            this.boxPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boxPause.TabIndex = 2;
            this.boxPause.TabStop = false;
            this.boxPause.Click += new System.EventHandler(this.boxPause_Click);
            // 
            // btnSett
            // 
            this.btnSett.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSett.Location = new System.Drawing.Point(12, 517);
            this.btnSett.Name = "btnSett";
            this.btnSett.Size = new System.Drawing.Size(80, 30);
            this.btnSett.TabIndex = 3;
            this.btnSett.Text = "Settings";
            this.btnSett.UseVisualStyleBackColor = true;
            this.btnSett.Click += new System.EventHandler(this.btnSett_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnSett);
            this.Controls.Add(this.boxPause);
            this.Controls.Add(this.lblLine);
            this.MinimumSize = new System.Drawing.Size(604, 495);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Shown += new System.EventHandler(this.Game_Shown);
            this.ResizeEnd += new System.EventHandler(this.Game_ResizeEnd);
            this.Resize += new System.EventHandler(this.Game_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.boxPause)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timInit;
        private System.Windows.Forms.Timer timShow;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.PictureBox boxPause;
        private System.Windows.Forms.Button btnSett;
    }
}