using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;
using System.IO;
namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void fillSimSysObj(string[] sysData) //we need to add endline wehna bna5od l data mn l gui
        {
            SimulationSystem simSys = new SimulationSystem();
            simSys.NumberOfServers = Convert.ToInt32(sysData[1]);
            simSys.Servers = new List<Server>(simSys.NumberOfServers);
            
            simSys.StoppingNumber = Convert.ToInt32(sysData[4]);
            if (Convert.ToInt32(sysData[7]) == 1)
            {
                simSys.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
            }
            else
                simSys.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;

            if (Convert.ToInt32(sysData[10]) == 1)
            {
                simSys.SelectionMethod = Enums.SelectionMethod.HighestPriority;
            }
            else if (Convert.ToInt32(sysData[10]) == 2)
            {
                simSys.SelectionMethod = Enums.SelectionMethod.Random;
            }
            else
                simSys.SelectionMethod = Enums.SelectionMethod.LeastUtilization;

            int i = 13;
            while (sysData[i] != "")
            {
                string[] line = sysData[i].Split(new string[] { ", " }, StringSplitOptions.None);
                TimeDistribution timeDistributionRow = new TimeDistribution();
                timeDistributionRow.Time = Convert.ToInt32(line[0]);
                timeDistributionRow.Probability = Convert.ToDecimal(line[1]);
                simSys.InterarrivalDistribution.Add(timeDistributionRow);

                i++;
            }
            for(int j =0; j < simSys.NumberOfServers; j++)
            {
                i += 2;
                Server server = new Server();
                while (i != sysData.Length && sysData[i] != "")
                {
                    string[] line = sysData[i].Split(new string[] { ", " }, StringSplitOptions.None);
                    TimeDistribution timeDistributionRow = new TimeDistribution();
                    timeDistributionRow.Time = Convert.ToInt32(line[0]);
                    timeDistributionRow.Probability = Convert.ToDecimal(line[1]);

                    server.TimeDistribution.Add(timeDistributionRow);

                    i++;
                }
                simSys.Servers.Add(server);
            }
        }
        private void readFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string fileName = openFileDialog.FileName;
                string []fileData = File.ReadAllLines(fileName);
                fillSimSysObj(fileData);

                MessageBox.Show("DONE");
            }

        }
    }
}
