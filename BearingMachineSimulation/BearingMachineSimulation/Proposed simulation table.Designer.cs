namespace BearingMachineSimulation
{
    partial class Proposed_simulation_table
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
            this.showPerformanceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 13);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1404, 665);
            this.dataGridView1.TabIndex = 2;
            // 
            // showPerformanceButton
            // 
            this.showPerformanceButton.Location = new System.Drawing.Point(585, 687);
            this.showPerformanceButton.Name = "showPerformanceButton";
            this.showPerformanceButton.Size = new System.Drawing.Size(317, 70);
            this.showPerformanceButton.TabIndex = 3;
            this.showPerformanceButton.Text = "Show performance";
            this.showPerformanceButton.UseVisualStyleBackColor = true;
            this.showPerformanceButton.Click += new System.EventHandler(this.showPerformanceButton_Click);
            // 
            // Proposed_simulation_table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1409, 769);
            this.Controls.Add(this.showPerformanceButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Proposed_simulation_table";
            this.Text = "Proposed_simulation_table";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button showPerformanceButton;
    }
}