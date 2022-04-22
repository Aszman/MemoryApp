
namespace MemoryApp
{
    partial class frmHighScore
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
            this.listScore = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listScore
            // 
            this.listScore.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listScore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colScore});
            this.listScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listScore.HideSelection = false;
            this.listScore.Location = new System.Drawing.Point(0, 0);
            this.listScore.Name = "listScore";
            this.listScore.Size = new System.Drawing.Size(247, 309);
            this.listScore.TabIndex = 0;
            this.listScore.UseCompatibleStateImageBehavior = false;
            this.listScore.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 120;
            // 
            // colScore
            // 
            this.colScore.Text = "Score";
            this.colScore.Width = 121;
            // 
            // frmHighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 309);
            this.Controls.Add(this.listScore);
            this.Name = "frmHighScore";
            this.Text = "HighScore";
            this.Load += new System.EventHandler(this.HighScore_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listScore;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colScore;
    }
}