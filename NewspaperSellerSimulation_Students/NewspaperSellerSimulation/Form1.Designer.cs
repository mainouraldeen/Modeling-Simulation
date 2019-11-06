namespace NewspaperSellerSimulation
{
    partial class Form1
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
            this.ReadFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReadFile
            // 
            this.ReadFile.BackColor = System.Drawing.Color.CadetBlue;
            this.ReadFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReadFile.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadFile.ForeColor = System.Drawing.Color.Snow;
            this.ReadFile.Location = new System.Drawing.Point(303, 483);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(156, 34);
            this.ReadFile.TabIndex = 0;
            this.ReadFile.Text = "View The Data";
            this.ReadFile.UseVisualStyleBackColor = false;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-7, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 143);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(102, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Newspaper Seller System";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(776, 577);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ReadFile);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.HelpButton = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewsPapers System";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}