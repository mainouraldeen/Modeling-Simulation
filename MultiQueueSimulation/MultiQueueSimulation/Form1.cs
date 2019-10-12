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
        public SimulationSystem simSys = new SimulationSystem();
        
        public void fillSimSysObj(string[] sysData) //we need to add endline wehna bna5od l data mn l gui
        {
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
        public void fillInterArrivaleTable(SimulationSystem simSystem)
        {
            simSystem.InterarrivalDistribution[0].CummProbability = simSystem.InterarrivalDistribution[0].Probability;
            simSystem.InterarrivalDistribution[0].MinRange = 1;
            simSystem.InterarrivalDistribution[0].MaxRange = Convert.ToInt32(simSystem.InterarrivalDistribution[0].Probability * 100);
            for(int i=1; i<simSystem.InterarrivalDistribution.Count; i++)
            {
                simSystem.InterarrivalDistribution[i].CummProbability = simSystem.InterarrivalDistribution[i].Probability + 
                    simSystem.InterarrivalDistribution[i - 1].CummProbability;
                simSystem.InterarrivalDistribution[i].MinRange = simSystem.InterarrivalDistribution[i - 1].MaxRange + 1;
                simSystem.InterarrivalDistribution[i].MaxRange = simSystem.InterarrivalDistribution[i - 1].MaxRange +
                    Convert.ToInt32(simSystem.InterarrivalDistribution[i].Probability * 100);

            }
        }
        public void fillServersTimeDistribution(SimulationSystem simSystem)
        {
            for(int i=0; i<simSystem.Servers.Count; i++)
            {
                simSystem.Servers[i].TimeDistribution[0].CummProbability = simSystem.Servers[i].TimeDistribution[0].Probability;
                simSystem.Servers[i].TimeDistribution[0].MinRange = 1;
                simSystem.Servers[i].TimeDistribution[0].MaxRange = Convert.ToInt32(simSystem.Servers[i].TimeDistribution[0].Probability * 100);
                for (int j = 1; j < simSystem.Servers[i].TimeDistribution.Count; j++) 
                {
                    simSystem.Servers[i].TimeDistribution[j].CummProbability = simSystem.Servers[i].TimeDistribution[j].Probability +
                        simSystem.Servers[i].TimeDistribution[j - 1].CummProbability;
                    simSystem.Servers[i].TimeDistribution[j].MinRange = simSystem.Servers[i].TimeDistribution[j - 1].MaxRange + 1;
                    simSystem.Servers[i].TimeDistribution[j].MaxRange = simSystem.Servers[i].TimeDistribution[j-1].MaxRange +
                        Convert.ToInt32(simSystem.Servers[i].TimeDistribution[j].Probability * 100);
                }

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
                fillInterArrivaleTable(simSys);
                fillServersTimeDistribution(simSys);
                fillSimCaseRow();
                MessageBox.Show("DONE");
            }

        }

        public void fillSimCaseRow()
        {
            SimulationCase simRow = new SimulationCase();
            Random randomNum = new Random();
            simRow.CustomerNumber = 0;
            simRow.RandomInterArrival = -1;
            simRow.InterArrival = -1;
            simRow.ArrivalTime = 0;
            simRow.RandomService = randomNum.Next(1, 100);
            simSys.SimulationTable.Add(simRow);

            for (int i = 1; i < simSys.StoppingNumber; i++)
            {
                simRow = new SimulationCase();
                simRow.CustomerNumber = i;
                //
                
                simRow.RandomInterArrival = randomNum.Next(1, 100);
                //
 
                for (int j = 0; j < simSys.InterarrivalDistribution.Count; j++)
                {
                    if (simRow.RandomInterArrival >= simSys.InterarrivalDistribution[j].MinRange && simRow.RandomInterArrival <= simSys.InterarrivalDistribution[j].MaxRange)
                    {
                        simRow.InterArrival = j;
                    }
                }
                //
                simRow.ArrivalTime = simSys.SimulationTable[i - 1].ArrivalTime + simRow.InterArrival;

                //
                simRow.RandomService = randomNum.Next(1, 100);
                simSys.SimulationTable.Add(simRow);

         

            }


        }

    }
}
