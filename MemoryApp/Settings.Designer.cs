
namespace MemoryApp
{
    partial class Settings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblInit = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trkInit = new System.Windows.Forms.TrackBar();
            this.lblInV = new System.Windows.Forms.Label();
            this.lblCards = new System.Windows.Forms.Label();
            this.trkCard = new System.Windows.Forms.TrackBar();
            this.lblCardV = new System.Windows.Forms.Label();
            this.lblBoardW = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lblBoardH = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.trkInit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.Location = new System.Drawing.Point(70, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 31);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.Location = new System.Drawing.Point(236, 214);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 31);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblInit
            // 
            this.lblInit.AutoSize = true;
            this.lblInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInit.Location = new System.Drawing.Point(17, 38);
            this.lblInit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInit.Name = "lblInit";
            this.lblInit.Size = new System.Drawing.Size(125, 20);
            this.lblInit.TabIndex = 2;
            this.lblInit.Text = "Initial show time:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(206, 38);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 26);
            this.textBox1.TabIndex = 3;
            // 
            // trkInit
            // 
            this.trkInit.LargeChange = 2;
            this.trkInit.Location = new System.Drawing.Point(150, 38);
            this.trkInit.Margin = new System.Windows.Forms.Padding(2);
            this.trkInit.Maximum = 12;
            this.trkInit.Name = "trkInit";
            this.trkInit.Size = new System.Drawing.Size(140, 45);
            this.trkInit.TabIndex = 5;
            this.trkInit.Value = 3;
            this.trkInit.ValueChanged += new System.EventHandler(this.trkInit_ValueChanged);
            // 
            // lblInV
            // 
            this.lblInV.AutoSize = true;
            this.lblInV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInV.Location = new System.Drawing.Point(304, 41);
            this.lblInV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInV.Name = "lblInV";
            this.lblInV.Size = new System.Drawing.Size(39, 20);
            this.lblInV.TabIndex = 6;
            this.lblInV.Text = "15 s";
            // 
            // lblCards
            // 
            this.lblCards.AutoSize = true;
            this.lblCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCards.Location = new System.Drawing.Point(11, 87);
            this.lblCards.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCards.Name = "lblCards";
            this.lblCards.Size = new System.Drawing.Size(130, 20);
            this.lblCards.TabIndex = 7;
            this.lblCards.Text = "Cards show time:";
            // 
            // trkCard
            // 
            this.trkCard.LargeChange = 2;
            this.trkCard.Location = new System.Drawing.Point(150, 87);
            this.trkCard.Margin = new System.Windows.Forms.Padding(2);
            this.trkCard.Maximum = 5;
            this.trkCard.Minimum = 1;
            this.trkCard.Name = "trkCard";
            this.trkCard.Size = new System.Drawing.Size(140, 45);
            this.trkCard.TabIndex = 8;
            this.trkCard.Value = 3;
            this.trkCard.ValueChanged += new System.EventHandler(this.trkCard_ValueChanged);
            // 
            // lblCardV
            // 
            this.lblCardV.AutoSize = true;
            this.lblCardV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCardV.Location = new System.Drawing.Point(304, 87);
            this.lblCardV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCardV.Name = "lblCardV";
            this.lblCardV.Size = new System.Drawing.Size(43, 20);
            this.lblCardV.TabIndex = 9;
            this.lblCardV.Text = "1.5 s";
            // 
            // lblBoardW
            // 
            this.lblBoardW.AutoSize = true;
            this.lblBoardW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBoardW.Location = new System.Drawing.Point(11, 133);
            this.lblBoardW.Name = "lblBoardW";
            this.lblBoardW.Size = new System.Drawing.Size(108, 20);
            this.lblBoardW.TabIndex = 10;
            this.lblBoardW.Text = "Board\'s width:";
            // 
            // nudWidth
            // 
            this.nudWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudWidth.Location = new System.Drawing.Point(277, 132);
            this.nudWidth.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(70, 24);
            this.nudWidth.TabIndex = 12;
            this.nudWidth.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // lblBoardH
            // 
            this.lblBoardH.AutoSize = true;
            this.lblBoardH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBoardH.Location = new System.Drawing.Point(11, 166);
            this.lblBoardH.Name = "lblBoardH";
            this.lblBoardH.Size = new System.Drawing.Size(115, 20);
            this.lblBoardH.TabIndex = 13;
            this.lblBoardH.Text = "Board\'s height:";
            // 
            // nudHeight
            // 
            this.nudHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudHeight.Location = new System.Drawing.Point(277, 166);
            this.nudHeight.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(70, 24);
            this.nudHeight.TabIndex = 14;
            this.nudHeight.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.lblBoardH);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.lblBoardW);
            this.Controls.Add(this.lblCardV);
            this.Controls.Add(this.trkCard);
            this.Controls.Add(this.lblCards);
            this.Controls.Add(this.lblInV);
            this.Controls.Add(this.trkInit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblInit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Memory Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkInit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblInit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar trkInit;
        private System.Windows.Forms.Label lblInV;
        private System.Windows.Forms.Label lblCards;
        private System.Windows.Forms.TrackBar trkCard;
        private System.Windows.Forms.Label lblCardV;
        private System.Windows.Forms.Label lblBoardW;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label lblBoardH;
        private System.Windows.Forms.NumericUpDown nudHeight;
    }
}