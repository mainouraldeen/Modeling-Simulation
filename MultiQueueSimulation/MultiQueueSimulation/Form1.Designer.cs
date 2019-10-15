namespace MultiQueueSimulation
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
            this.readFileButton = new System.Windows.Forms.Button();
            this.getDataFromGUI = new System.Windows.Forms.Button();
            this.noOfServerstextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stoppingNotextBox = new System.Windows.Forms.TextBox();
            this.InterarrivalDistributiontextbox = new System.Windows.Forms.TextBox();
            this.noOfCustomersradioButton = new System.Windows.Forms.RadioButton();
            this.simEndTimeradioButton = new System.Windows.Forms.RadioButton();
            this.randomradioButton = new System.Windows.Forms.RadioButton();
            this.highestPriorityradioButton = new System.Windows.Forms.RadioButton();
            this.leastUtilizationradioButton = new System.Windows.Forms.RadioButton();
            this.serviceDistributiontextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // readFileButton
            // 
            this.readFileButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readFileButton.Location = new System.Drawing.Point(648, 15);
            this.readFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.readFileButton.Name = "readFileButton";
            this.readFileButton.Size = new System.Drawing.Size(129, 64);
            this.readFileButton.TabIndex = 0;
            this.readFileButton.Text = "Browse File";
            this.readFileButton.UseVisualStyleBackColor = true;
            this.readFileButton.Click += new System.EventHandler(this.readFileButton_Click);
            // 
            // getDataFromGUI
            // 
            this.getDataFromGUI.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getDataFromGUI.Location = new System.Drawing.Point(656, 481);
            this.getDataFromGUI.Margin = new System.Windows.Forms.Padding(2);
            this.getDataFromGUI.Name = "getDataFromGUI";
            this.getDataFromGUI.Size = new System.Drawing.Size(121, 55);
            this.getDataFromGUI.TabIndex = 1;
            this.getDataFromGUI.Text = "Collect data";
            this.getDataFromGUI.UseVisualStyleBackColor = true;
            this.getDataFromGUI.Click += new System.EventHandler(this.getDataFromGUI_Click);
            // 
            // noOfServerstextBox
            // 
            this.noOfServerstextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfServerstextBox.Location = new System.Drawing.Point(193, 15);
            this.noOfServerstextBox.Name = "noOfServerstextBox";
            this.noOfServerstextBox.Size = new System.Drawing.Size(183, 27);
            this.noOfServerstextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number Of Servers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Interarrival Distribution:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Selection Method:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stopping Criteria:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stopping Number:";
            // 
            // stoppingNotextBox
            // 
            this.stoppingNotextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stoppingNotextBox.Location = new System.Drawing.Point(193, 62);
            this.stoppingNotextBox.Name = "stoppingNotextBox";
            this.stoppingNotextBox.Size = new System.Drawing.Size(183, 27);
            this.stoppingNotextBox.TabIndex = 9;
            // 
            // InterarrivalDistributiontextbox
            // 
            this.InterarrivalDistributiontextbox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterarrivalDistributiontextbox.Location = new System.Drawing.Point(223, 266);
            this.InterarrivalDistributiontextbox.Multiline = true;
            this.InterarrivalDistributiontextbox.Name = "InterarrivalDistributiontextbox";
            this.InterarrivalDistributiontextbox.Size = new System.Drawing.Size(165, 110);
            this.InterarrivalDistributiontextbox.TabIndex = 11;
            // 
            // noOfCustomersradioButton
            // 
            this.noOfCustomersradioButton.AutoSize = true;
            this.noOfCustomersradioButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfCustomersradioButton.Location = new System.Drawing.Point(5, 18);
            this.noOfCustomersradioButton.Name = "noOfCustomersradioButton";
            this.noOfCustomersradioButton.Size = new System.Drawing.Size(181, 20);
            this.noOfCustomersradioButton.TabIndex = 13;
            this.noOfCustomersradioButton.TabStop = true;
            this.noOfCustomersradioButton.Text = "1- number Of Customers";
            this.noOfCustomersradioButton.UseVisualStyleBackColor = true;
            // 
            // simEndTimeradioButton
            // 
            this.simEndTimeradioButton.AutoSize = true;
            this.simEndTimeradioButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simEndTimeradioButton.Location = new System.Drawing.Point(184, 19);
            this.simEndTimeradioButton.Name = "simEndTimeradioButton";
            this.simEndTimeradioButton.Size = new System.Drawing.Size(168, 20);
            this.simEndTimeradioButton.TabIndex = 14;
            this.simEndTimeradioButton.TabStop = true;
            this.simEndTimeradioButton.Text = "2- simulation End Time";
            this.simEndTimeradioButton.UseVisualStyleBackColor = true;
            // 
            // randomradioButton
            // 
            this.randomradioButton.AutoSize = true;
            this.randomradioButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomradioButton.Location = new System.Drawing.Point(159, 31);
            this.randomradioButton.Name = "randomradioButton";
            this.randomradioButton.Size = new System.Drawing.Size(91, 20);
            this.randomradioButton.TabIndex = 16;
            this.randomradioButton.TabStop = true;
            this.randomradioButton.Text = "2- random";
            this.randomradioButton.UseVisualStyleBackColor = true;
            // 
            // highestPriorityradioButton
            // 
            this.highestPriorityradioButton.AutoSize = true;
            this.highestPriorityradioButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highestPriorityradioButton.Location = new System.Drawing.Point(15, 29);
            this.highestPriorityradioButton.Name = "highestPriorityradioButton";
            this.highestPriorityradioButton.Size = new System.Drawing.Size(138, 20);
            this.highestPriorityradioButton.TabIndex = 15;
            this.highestPriorityradioButton.TabStop = true;
            this.highestPriorityradioButton.Text = "1- highest priority";
            this.highestPriorityradioButton.UseVisualStyleBackColor = true;
            // 
            // leastUtilizationradioButton
            // 
            this.leastUtilizationradioButton.AutoSize = true;
            this.leastUtilizationradioButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leastUtilizationradioButton.Location = new System.Drawing.Point(268, 31);
            this.leastUtilizationradioButton.Name = "leastUtilizationradioButton";
            this.leastUtilizationradioButton.Size = new System.Drawing.Size(139, 20);
            this.leastUtilizationradioButton.TabIndex = 17;
            this.leastUtilizationradioButton.TabStop = true;
            this.leastUtilizationradioButton.Text = "3- least utilization";
            this.leastUtilizationradioButton.UseVisualStyleBackColor = true;
            // 
            // serviceDistributiontextBox
            // 
            this.serviceDistributiontextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceDistributiontextBox.Location = new System.Drawing.Point(223, 398);
            this.serviceDistributiontextBox.Multiline = true;
            this.serviceDistributiontextBox.Name = "serviceDistributiontextBox";
            this.serviceDistributiontextBox.Size = new System.Drawing.Size(165, 138);
            this.serviceDistributiontextBox.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "Service Distribution:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.simEndTimeradioButton);
            this.groupBox1.Controls.Add(this.noOfCustomersradioButton);
            this.groupBox1.Location = new System.Drawing.Point(175, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 63);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.leastUtilizationradioButton);
            this.groupBox2.Controls.Add(this.highestPriorityradioButton);
            this.groupBox2.Controls.Add(this.randomradioButton);
            this.groupBox2.Location = new System.Drawing.Point(176, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 63);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 548);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.serviceDistributiontextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.InterarrivalDistributiontextbox);
            this.Controls.Add(this.stoppingNotextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noOfServerstextBox);
            this.Controls.Add(this.getDataFromGUI);
            this.Controls.Add(this.readFileButton);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Multi Queue Simulation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readFileButton;
        private System.Windows.Forms.Button getDataFromGUI;
        private System.Windows.Forms.TextBox noOfServerstextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stoppingNotextBox;
        private System.Windows.Forms.TextBox InterarrivalDistributiontextbox;
        private System.Windows.Forms.RadioButton noOfCustomersradioButton;
        private System.Windows.Forms.RadioButton simEndTimeradioButton;
        private System.Windows.Forms.RadioButton randomradioButton;
        private System.Windows.Forms.RadioButton highestPriorityradioButton;
        private System.Windows.Forms.RadioButton leastUtilizationradioButton;
        private System.Windows.Forms.TextBox serviceDistributiontextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

