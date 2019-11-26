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
    public partial class Form2 : Form
    {
        public Form2()
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
                dataGridView1.Columns.Add(ch.ToString(), "      " + "Bearing  *" + (i + 1).ToString() + "*\n         " + ch.ToString() + "\nRandom digit");
                ch = Convert.ToChar(ch + 1);

                dataGridView1.Columns.Add(ch.ToString(), "      " + ch.ToString() + "\nlife hours");
                ch = Convert.ToChar(ch + 1);

                dataGridView1.Columns.Add(ch.ToString(), "      " + ch.ToString() + "\nAccumulated life hours");
                ch = Convert.ToChar(ch + 1);

                dataGridView1.Columns.Add(ch.ToString(), "      " + ch.ToString() + "\nRandom digit");
                ch = Convert.ToChar(ch + 1);

                dataGridView1.Columns.Add(ch.ToString(), "      " + ch.ToString() + "\nDelay");
                ch = Convert.ToChar(ch + 1);
            }
        }

        public void fillDatagridview()
        {
            int col = 0, index = 0;
            for (int j = 0; j < Form1.countOfBearings.Count; j++)
            {
                for (int i = 0; i < Form1.countOfBearings[j]; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[col].Value = Form1.simSys.CurrentSimulationTable[index].Bearing.RandomHours.ToString();
                    dataGridView1.Rows[i].Cells[col + 1].Value = Form1.simSys.CurrentSimulationTable[index].Bearing.Hours.ToString();
                    dataGridView1.Rows[i].Cells[col + 2].Value = Form1.simSys.CurrentSimulationTable[index].AccumulatedHours.ToString();
                    dataGridView1.Rows[i].Cells[col + 3].Value = Form1.simSys.CurrentSimulationTable[index].RandomDelay.ToString();
                    dataGridView1.Rows[i].Cells[col + 4].Value = Form1.simSys.CurrentSimulationTable[index].Delay.ToString();
                    index++;
                }
                col += 5;
            }
        }

        private void showProposedTable_Click(object sender, EventArgs e)
        {
            Proposed_simulation_table proposed_Simulation = new Proposed_simulation_table();
            proposed_Simulation.Show();
            this.Hide();
        }
    }
}
