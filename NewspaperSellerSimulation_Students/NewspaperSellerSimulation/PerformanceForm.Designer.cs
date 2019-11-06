namespace NewspaperSellerSimulation
{
    partial class PerformanceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.totalLostLabel = new System.Windows.Forms.Label();
            this.totalProfitLabel = new System.Windows.Forms.Label();
            this.netProfitLabel = new System.Windows.Forms.Label();
            this.totalSalvageLabel = new System.Windows.Forms.Label();
            this.excessDemandLabel = new System.Windows.Forms.Label();
            this.unsoldPapersLabel = new System.Windows.Forms.Label();
            this.totalCostLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Lost Profit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Cost";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unsold Papers Days";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-207, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Sales Revenue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "Excess Demand Days";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Sales";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(67, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 30);
            this.label7.TabIndex = 6;
            this.label7.Text = "Total Salvage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(80, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 30);
            this.label8.TabIndex = 7;
            this.label8.Text = "Net Profit";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 583);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // totalLostLabel
            // 
            this.totalLostLabel.AutoSize = true;
            this.totalLostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLostLabel.Location = new System.Drawing.Point(356, 50);
            this.totalLostLabel.Name = "totalLostLabel";
            this.totalLostLabel.Size = new System.Drawing.Size(79, 29);
            this.totalLostLabel.TabIndex = 9;
            this.totalLostLabel.Text = "label9";
            // 
            // totalProfitLabel
            // 
            this.totalProfitLabel.AutoSize = true;
            this.totalProfitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalProfitLabel.Location = new System.Drawing.Point(356, 128);
            this.totalProfitLabel.Name = "totalProfitLabel";
            this.totalProfitLabel.Size = new System.Drawing.Size(92, 29);
            this.totalProfitLabel.TabIndex = 10;
            this.totalProfitLabel.Text = "label10";
            // 
            // netProfitLabel
            // 
            this.netProfitLabel.AutoSize = true;
            this.netProfitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netProfitLabel.Location = new System.Drawing.Point(356, 295);
            this.netProfitLabel.Name = "netProfitLabel";
            this.netProfitLabel.Size = new System.Drawing.Size(92, 29);
            this.netProfitLabel.TabIndex = 11;
            this.netProfitLabel.Text = "label11";
            // 
            // totalSalvageLabel
            // 
            this.totalSalvageLabel.AutoSize = true;
            this.totalSalvageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSalvageLabel.Location = new System.Drawing.Point(356, 209);
            this.totalSalvageLabel.Name = "totalSalvageLabel";
            this.totalSalvageLabel.Size = new System.Drawing.Size(92, 29);
            this.totalSalvageLabel.TabIndex = 12;
            this.totalSalvageLabel.Text = "label12";
            // 
            // excessDemandLabel
            // 
            this.excessDemandLabel.AutoSize = true;
            this.excessDemandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excessDemandLabel.Location = new System.Drawing.Point(356, 369);
            this.excessDemandLabel.Name = "excessDemandLabel";
            this.excessDemandLabel.Size = new System.Drawing.Size(92, 29);
            this.excessDemandLabel.TabIndex = 13;
            this.excessDemandLabel.Text = "label13";
            // 
            // unsoldPapersLabel
            // 
            this.unsoldPapersLabel.AutoSize = true;
            this.unsoldPapersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unsoldPapersLabel.Location = new System.Drawing.Point(356, 444);
            this.unsoldPapersLabel.Name = "unsoldPapersLabel";
            this.unsoldPapersLabel.Size = new System.Drawing.Size(92, 29);
            this.unsoldPapersLabel.TabIndex = 14;
            this.unsoldPapersLabel.Text = "label14";
            // 
            // totalCostLabel
            // 
            this.totalCostLabel.AutoSize = true;
            this.totalCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCostLabel.Location = new System.Drawing.Point(356, 513);
            this.totalCostLabel.Name = "totalCostLabel";
            this.totalCostLabel.Size = new System.Drawing.Size(92, 29);
            this.totalCostLabel.TabIndex = 15;
            this.totalCostLabel.Text = "label15";
            // 
            // PerformanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(609, 582);
            this.Controls.Add(this.totalCostLabel);
            this.Controls.Add(this.unsoldPapersLabel);
            this.Controls.Add(this.excessDemandLabel);
            this.Controls.Add(this.totalSalvageLabel);
            this.Controls.Add(this.netProfitLabel);
            this.Controls.Add(this.totalProfitLabel);
            this.Controls.Add(this.totalLostLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Name = "PerformanceForm";
            this.Text = "Performance";
            this.Load += new System.EventHandler(this.PerformanceForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label totalLostLabel;
        private System.Windows.Forms.Label totalProfitLabel;
        private System.Windows.Forms.Label netProfitLabel;
        private System.Windows.Forms.Label totalSalvageLabel;
        private System.Windows.Forms.Label excessDemandLabel;
        private System.Windows.Forms.Label unsoldPapersLabel;
        private System.Windows.Forms.Label totalCostLabel;
    }
}