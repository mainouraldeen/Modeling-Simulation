namespace MultiQueueSimulation
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.showChartsbutton = new System.Windows.Forms.Button();
            this.serverMeasursButton = new System.Windows.Forms.Button();
            this.servercomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.probOfIdleServerTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.avgServiceTimeTextBox = new System.Windows.Forms.TextBox();
            this.utilizationTextBox = new System.Windows.Forms.TextBox();
            this.maxQLengthTextBox = new System.Windows.Forms.TextBox();
            this.probOfWaitTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.avgWaitingTimeTextBox = new System.Windows.Forms.TextBox();
            this.systemMeasursButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1917, 695);
            this.dataGridView1.TabIndex = 3;
            // 
            // showChartsbutton
            // 
            this.showChartsbutton.Location = new System.Drawing.Point(754, 857);
            this.showChartsbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showChartsbutton.Name = "showChartsbutton";
            this.showChartsbutton.Size = new System.Drawing.Size(223, 52);
            this.showChartsbutton.TabIndex = 4;
            this.showChartsbutton.Text = "Show Charts";
            this.showChartsbutton.UseVisualStyleBackColor = true;
            this.showChartsbutton.Click += new System.EventHandler(this.showChartsbutton_Click);
            // 
            // serverMeasursButton
            // 
            this.serverMeasursButton.Location = new System.Drawing.Point(323, 93);
            this.serverMeasursButton.Name = "serverMeasursButton";
            this.serverMeasursButton.Size = new System.Drawing.Size(336, 46);
            this.serverMeasursButton.TabIndex = 5;
            this.serverMeasursButton.Text = "Show server performance measurs";
            this.serverMeasursButton.UseVisualStyleBackColor = true;
            this.serverMeasursButton.Click += new System.EventHandler(this.serverMeasursButton_Click);
            // 
            // servercomboBox
            // 
            this.servercomboBox.FormattingEnabled = true;
            this.servercomboBox.Location = new System.Drawing.Point(23, 52);
            this.servercomboBox.Name = "servercomboBox";
            this.servercomboBox.Size = new System.Drawing.Size(153, 28);
            this.servercomboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose server number";
            // 
            // probOfIdleServerTextBox
            // 
            this.probOfIdleServerTextBox.Location = new System.Drawing.Point(233, 54);
            this.probOfIdleServerTextBox.Name = "probOfIdleServerTextBox";
            this.probOfIdleServerTextBox.Size = new System.Drawing.Size(176, 26);
            this.probOfIdleServerTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(632, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Utilization";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Average service time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Probability for idle server";
            // 
            // avgServiceTimeTextBox
            // 
            this.avgServiceTimeTextBox.Location = new System.Drawing.Point(428, 54);
            this.avgServiceTimeTextBox.Name = "avgServiceTimeTextBox";
            this.avgServiceTimeTextBox.Size = new System.Drawing.Size(176, 26);
            this.avgServiceTimeTextBox.TabIndex = 14;
            // 
            // utilizationTextBox
            // 
            this.utilizationTextBox.Location = new System.Drawing.Point(625, 54);
            this.utilizationTextBox.Name = "utilizationTextBox";
            this.utilizationTextBox.Size = new System.Drawing.Size(176, 26);
            this.utilizationTextBox.TabIndex = 15;
            // 
            // maxQLengthTextBox
            // 
            this.maxQLengthTextBox.Location = new System.Drawing.Point(1516, 54);
            this.maxQLengthTextBox.Name = "maxQLengthTextBox";
            this.maxQLengthTextBox.Size = new System.Drawing.Size(176, 26);
            this.maxQLengthTextBox.TabIndex = 21;
            // 
            // probOfWaitTextBox
            // 
            this.probOfWaitTextBox.Location = new System.Drawing.Point(1305, 54);
            this.probOfWaitTextBox.Name = "probOfWaitTextBox";
            this.probOfWaitTextBox.Size = new System.Drawing.Size(176, 26);
            this.probOfWaitTextBox.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1075, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Average waiting time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1310, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Probability of wait";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1523, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Maximum queue length";
            // 
            // avgWaitingTimeTextBox
            // 
            this.avgWaitingTimeTextBox.Location = new System.Drawing.Point(1070, 52);
            this.avgWaitingTimeTextBox.Name = "avgWaitingTimeTextBox";
            this.avgWaitingTimeTextBox.Size = new System.Drawing.Size(176, 26);
            this.avgWaitingTimeTextBox.TabIndex = 16;
            // 
            // systemMeasursButton
            // 
            this.systemMeasursButton.Location = new System.Drawing.Point(1202, 93);
            this.systemMeasursButton.Name = "systemMeasursButton";
            this.systemMeasursButton.Size = new System.Drawing.Size(336, 46);
            this.systemMeasursButton.TabIndex = 22;
            this.systemMeasursButton.Text = "Show system performance measurs";
            this.systemMeasursButton.UseVisualStyleBackColor = true;
            this.systemMeasursButton.Click += new System.EventHandler(this.systemMeasursButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1912, 923);
            this.Controls.Add(this.systemMeasursButton);
            this.Controls.Add(this.maxQLengthTextBox);
            this.Controls.Add(this.probOfWaitTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.avgWaitingTimeTextBox);
            this.Controls.Add(this.utilizationTextBox);
            this.Controls.Add(this.avgServiceTimeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.probOfIdleServerTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.servercomboBox);
            this.Controls.Add(this.serverMeasursButton);
            this.Controls.Add(this.showChartsbutton);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi Queue Simulation Result";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button showChartsbutton;
        private System.Windows.Forms.Button serverMeasursButton;
        private System.Windows.Forms.ComboBox servercomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox probOfIdleServerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox avgServiceTimeTextBox;
        private System.Windows.Forms.TextBox utilizationTextBox;
        private System.Windows.Forms.TextBox maxQLengthTextBox;
        private System.Windows.Forms.TextBox probOfWaitTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox avgWaitingTimeTextBox;
        private System.Windows.Forms.Button systemMeasursButton;
    }
}