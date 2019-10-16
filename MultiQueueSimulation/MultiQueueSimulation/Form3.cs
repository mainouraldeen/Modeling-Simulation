using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MultiQueueSimulation
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        public void FillComboBox()
        {
            int noOfServers=Form1.simSys.NumberOfServers;
            for(int i = 0; i < noOfServers; i++)
            {
                servercomboBox.Items.Add(i + 1);
            }
        }

        private void servercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int serverID = Convert.ToInt32(servercomboBox.Text);
            statechart.Series["busy"].Points.Clear();

            //int col = 5 + (3 * serverID-1);
            for (int i = 0; i < Form1.simSys.SimulationTable.Count; i++)
            {
                if (Form1.simSys.SimulationTable[i].AssignedServer.ID == serverID - 1)
                {
                   // statechart.Series[0].ChartType = SeriesChartType.Column;
                  int p1 = statechart.Series[0].Points.AddXY(Form1.simSys.SimulationTable[i].StartTime, 1);
                  int p2 = statechart.Series[0].Points.AddXY(Form1.simSys.SimulationTable[i].EndTime, 1);

                }
            }
        }
    }
}