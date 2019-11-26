using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BearingMachineSimulation
{
    public partial class Proposed_simulation_table : Form
    {
        public Proposed_simulation_table()
        {
            InitializeComponent();
            fillGirdViewColumns();
            fillDatagridview();
        }

        public void fillGirdViewColumns()
        {
            char ch = 'A';
            for (int i = 0; i < Form1.simSys.NumberOfBearings; i++)
            {
                dataGridView1.Columns.Add(ch.ToString(), "      " + "Bearing  *" + (i + 1).ToString() + "*\n         " + ch.ToString() + "\nLife hours");
                ch = Convert.ToChar(ch + 1);
                     
            }
            dataGridView1.Columns.Add(ch.ToString(), "      " + ch.ToString() + "\nFirst failure");
            ch = Convert.ToChar(ch + 1);

            dataGridView1.Columns.Add(ch.ToString(), "      " + ch.ToString() + "\n Accumulated life hours");
            ch = Convert.ToChar(ch + 1);

            dataGridView1.Columns.Add(ch.ToString(), "      " + ch.ToString() + "\nRandom digit");
            ch = Convert.ToChar(ch + 1);

            dataGridView1.Columns.Add(ch.ToString(), "      " + ch.ToString() + "\nDelay");
            ch = Convert.ToChar(ch + 1);
        }

        public void fillDatagridview()
        {
            for (int i = 0; i < Form1.simSys.ProposedSimulationTable.Count; i++)
            {
                int col = 0;
                dataGridView1.Rows.Add();
                for (int j = 0; j < Form1.simSys.ProposedSimulationTable[i].Bearings.Count; j++)
                {

                    dataGridView1.Rows[i].Cells[col].Value = Form1.simSys.ProposedSimulationTable[i].Bearings[j].Hours.ToString();                   
                    col ++;
                }
                dataGridView1.Rows[i].Cells[col].Value = Form1.simSys.ProposedSimulationTable[i].FirstFailure.ToString();
                col++;
                dataGridView1.Rows[i].Cells[col].Value = Form1.simSys.ProposedSimulationTable[i].AccumulatedHours.ToString();
                col++;
                dataGridView1.Rows[i].Cells[col].Value = Form1.simSys.ProposedSimulationTable[i].RandomDelay.ToString();
                col++;
                dataGridView1.Rows[i].Cells[col].Value = Form1.simSys.ProposedSimulationTable[i].Delay.ToString();                
            }
        }

        private void showPerformanceButton_Click(object sender, EventArgs e)
        {
            Performance performance = new Performance();
            performance.Show();
            this.Hide();
        }
    }
}
