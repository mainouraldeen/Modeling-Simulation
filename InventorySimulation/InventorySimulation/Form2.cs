using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySimulation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FillDataGridView();
        }
        public void FillDataGridView()
        {
            dataGridView1.Columns.Add("A", "      A \n Day");
            dataGridView1.Columns.Add("B", "      B \n Cycle");
            dataGridView1.Columns.Add("C", "      C \n DayWithinCycle");
            dataGridView1.Columns.Add("D", "      D \n BeginningInventory");
            dataGridView1.Columns.Add("E", "      E \n RandomDemand");
            dataGridView1.Columns.Add("F", "      F \n Demand");
            dataGridView1.Columns.Add("G", "      G \n EndingInventory");
            dataGridView1.Columns.Add("H", "      H \n ShortageQuantity");
            dataGridView1.Columns.Add("I", "      I\n OrderQuantity");
            dataGridView1.Columns.Add("J", "      J \n RandomLeadDays");
            dataGridView1.Columns.Add("K", "      K \n LeadDays");
            //dataGridView1.Columns.Add("L", "      L \n DaysToArrive");
            
            for (int i = 0; i < Form1.simSys.NumberOfDays; i++)
            {
                
                    dataGridView1.Rows.Add(new object[]
                {
                Form1.simSys.SimulationTable[i].Day,
                Form1.simSys.SimulationTable[i].Cycle,
                Form1.simSys.SimulationTable[i].DayWithinCycle,
                Form1.simSys.SimulationTable[i].BeginningInventory,
                Form1.simSys.SimulationTable[i].RandomDemand,
                Form1.simSys.SimulationTable[i].Demand,
                Form1.simSys.SimulationTable[i].EndingInventory,
                Form1.simSys.SimulationTable[i].ShortageQuantity,
                Form1.simSys.SimulationTable[i].OrderQuantity,
                Form1.simSys.SimulationTable[i].RandomLeadDays,
                Form1.simSys.SimulationTable[i].LeadDays,
                //Form1.simSys.SimulationTable[i].DaysUntillArrives
                

                });
            }

        }

        private void Performancebutton_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
            this.Close();
        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            this.Close();
        }
    }
}
