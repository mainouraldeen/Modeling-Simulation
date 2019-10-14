﻿namespace MultiQueueSimulation
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
            this.getGuiFile = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // readFileButton
            // 
            this.readFileButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readFileButton.Location = new System.Drawing.Point(747, 8);
            this.readFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.readFileButton.Name = "readFileButton";
            this.readFileButton.Size = new System.Drawing.Size(121, 55);
            this.readFileButton.TabIndex = 0;
            this.readFileButton.Text = "Browse File";
            this.readFileButton.UseVisualStyleBackColor = true;
            this.readFileButton.Click += new System.EventHandler(this.readFileButton_Click);
            // 
            // getGuiFile
            // 
            this.getGuiFile.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getGuiFile.Location = new System.Drawing.Point(747, 309);
            this.getGuiFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.getGuiFile.Name = "getGuiFile";
            this.getGuiFile.Size = new System.Drawing.Size(121, 55);
            this.getGuiFile.TabIndex = 1;
            this.getGuiFile.Text = "Collect data";
            this.getGuiFile.UseVisualStyleBackColor = true;
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
            this.label2.Location = new System.Drawing.Point(12, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Interarrival Distribution:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 157);
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
            this.InterarrivalDistributiontextbox.Location = new System.Drawing.Point(224, 195);
            this.InterarrivalDistributiontextbox.Multiline = true;
            this.InterarrivalDistributiontextbox.Name = "InterarrivalDistributiontextbox";
            this.InterarrivalDistributiontextbox.Size = new System.Drawing.Size(183, 71);
            this.InterarrivalDistributiontextbox.TabIndex = 11;
            // 
            // noOfCustomersradioButton
            // 
            this.noOfCustomersradioButton.AutoSize = true;
            this.noOfCustomersradioButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfCustomersradioButton.Location = new System.Drawing.Point(193, 115);
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
            this.simEndTimeradioButton.Location = new System.Drawing.Point(372, 116);
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
            this.randomradioButton.Location = new System.Drawing.Point(337, 158);
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
            this.highestPriorityradioButton.Location = new System.Drawing.Point(193, 156);
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
            this.leastUtilizationradioButton.Location = new System.Drawing.Point(446, 158);
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
            this.serviceDistributiontextBox.Location = new System.Drawing.Point(224, 288);
            this.serviceDistributiontextBox.Multiline = true;
            this.serviceDistributiontextBox.Name = "serviceDistributiontextBox";
            this.serviceDistributiontextBox.Size = new System.Drawing.Size(183, 71);
            this.serviceDistributiontextBox.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "Service Distribution:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(877, 371);
            this.Controls.Add(this.serviceDistributiontextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.leastUtilizationradioButton);
            this.Controls.Add(this.randomradioButton);
            this.Controls.Add(this.highestPriorityradioButton);
            this.Controls.Add(this.simEndTimeradioButton);
            this.Controls.Add(this.noOfCustomersradioButton);
            this.Controls.Add(this.InterarrivalDistributiontextbox);
            this.Controls.Add(this.stoppingNotextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noOfServerstextBox);
            this.Controls.Add(this.getGuiFile);
            this.Controls.Add(this.readFileButton);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Multi Queue Simulation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readFileButton;
        private System.Windows.Forms.Button getGuiFile;
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
    }
}

