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
            this.SuspendLayout();
            // 
            // ReadFile
            // 
            this.ReadFile.BackColor = System.Drawing.Color.Coral;
            this.ReadFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReadFile.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadFile.ForeColor = System.Drawing.Color.Snow;
            this.ReadFile.Location = new System.Drawing.Point(463, 418);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(156, 34);
            this.ReadFile.TabIndex = 0;
            this.ReadFile.Text = "Read Data";
            this.ReadFile.UseVisualStyleBackColor = false;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1087, 542);
            this.Controls.Add(this.ReadFile);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "NewsPapers System";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadFile;
    }
}