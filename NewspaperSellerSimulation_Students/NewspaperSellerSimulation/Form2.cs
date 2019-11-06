using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewspaperSellerSimulation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            fillDatagridview();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformanceForm pf = new PerformanceForm();
            pf.Show();

        }
        public void fillDatagridview()
        {
            dataGridView1.Columns.Add("A", "      A \n Day");
            dataGridView1.Columns.Add("B", "      B \n Random Digits For Type Of Newsday");
            dataGridView1.Columns.Add("C", "      C \n Type of newsday");
            dataGridView1.Columns.Add("D", "      D \n Random Digits for demand");
            dataGridView1.Columns.Add("E", "      E \n Demand");
            dataGridView1.Columns.Add("F", "      F \n Revenue from sales");
            dataGridView1.Columns.Add("G", "      G \n Lost profit from excess demand");
            dataGridView1.Columns.Add("H", "      H \n Salvage from sale of scrap");
            dataGridView1.Columns.Add("I", "      I \n Daily profit");

            for (int i = 0; i < Form1.simSys.NumOfRecords; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                Form1.simSys.SimulationTable[i].DayNo,
                Form1.simSys.SimulationTable[i].RandomNewsDayType,
                Form1.simSys.SimulationTable[i].NewsDayType,
                Form1.simSys.SimulationTable[i].RandomDemand,
                Form1.simSys.SimulationTable[i].Demand,
                Form1.simSys.SimulationTable[i].SalesProfit,
                Form1.simSys.SimulationTable[i].LostProfit,
                Form1.simSys.SimulationTable[i].ScrapProfit,
                Form1.simSys.SimulationTable[i].DailyNetProfit,

                });
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {


        }
    }
}
