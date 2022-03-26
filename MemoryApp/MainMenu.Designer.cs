
namespace MemoryApp
{
    partial class MainMenu
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSett = new System.Windows.Forms.Button();
            this.lblDiff = new System.Windows.Forms.Label();
            this.boxDiff = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName.Location = new System.Drawing.Point(57, 53);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(128, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Write your name:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtName.Location = new System.Drawing.Point(209, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 26);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPlay.Location = new System.Drawing.Point(155, 138);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(90, 40);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnSett
            // 
            this.btnSett.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSett.Location = new System.Drawing.Point(155, 194);
            this.btnSett.Name = "btnSett";
            this.btnSett.Size = new System.Drawing.Size(90, 40);
            this.btnSett.TabIndex = 3;
            this.btnSett.Text = "Settings";
            this.btnSett.UseVisualStyleBackColor = true;
            this.btnSett.Click += new System.EventHandler(this.btnSett_Click);
            // 
            // lblDiff
            // 
            this.lblDiff.AutoSize = true;
            this.lblDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDiff.Location = new System.Drawing.Point(112, 91);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(73, 20);
            this.lblDiff.TabIndex = 4;
            this.lblDiff.Text = "Difficulty:";
            // 
            // boxDiff
            // 
            this.boxDiff.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.boxDiff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxDiff.FormattingEnabled = true;
            this.boxDiff.Items.AddRange(new object[] {
            "Easy (12 cards)",
            "Normal (36 cards)",
            "Hard (80 cards)"});
            this.boxDiff.Location = new System.Drawing.Point(209, 93);
            this.boxDiff.Name = "boxDiff";
            this.boxDiff.Size = new System.Drawing.Size(100, 21);
            this.boxDiff.TabIndex = 6;
            this.boxDiff.SelectedIndexChanged += new System.EventHandler(this.boxDiff_SelectedIndexChanged);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.boxDiff);
            this.Controls.Add(this.lblDiff);
            this.Controls.Add(this.btnSett);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(100, 100);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSett;
        private System.Windows.Forms.Label lblDiff;
        private System.Windows.Forms.ComboBox boxDiff;
    }
}

