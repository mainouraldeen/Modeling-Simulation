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

        public static SimulationSystem simSys = new SimulationSystem();

        public void LeastUtilizationMethod(int i)
        {
            for (; i < simSys.SimulationTable.Count; i++)
            {
                if (simSys.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
                {
                    if (simSys.SimulationTable[i].ArrivalTime > simSys.StoppingNumber)
                        break;
                }
                int CustomerArrivalTime = simSys.SimulationTable[i].ArrivalTime;

                int MinWorkTime = 1000000;
                List<int> AvailableServersID = new List<int>(simSys.NumberOfServers);//list of avail serversID
                int ServerID = 0;

                for (int j = 0; j < simSys.Servers.Count; j++) //searching for first suitable server
                {
                    if (CustomerArrivalTime >= simSys.Servers[j].FinishTime)//available server
                    {
                        AvailableServersID.Add(simSys.Servers[j].ID);
                    }
                }

                if (AvailableServersID.Count > 0)
                {
                    for (int j = 0; j < AvailableServersID.Count; j++)//search for min work time in available servers
                    {
                        if (simSys.Servers[AvailableServersID[j] - 1].TotalWorkingTime < MinWorkTime)
                        {
                            MinWorkTime = simSys.Servers[AvailableServersID[j] - 1].TotalWorkingTime;
                            ServerID = AvailableServersID[j];
                        }

                    }
                    //assign
                    for (int k = 0; k < simSys.Servers[ServerID - 1].TimeDistribution.Count; k++)//loop on time dist of server[j]

                    {
                        if (simSys.SimulationTable[i].RandomService >= simSys.Servers[ServerID - 1].TimeDistribution[k].MinRange
                            && simSys.SimulationTable[i].RandomService <= simSys.Servers[ServerID - 1].TimeDistribution[k].MaxRange)
                        {
                            simSys.SimulationTable[i].ServiceTime = simSys.Servers[ServerID - 1].TimeDistribution[k].Time;
                            simSys.SimulationTable[i].AssignedServer = simSys.Servers[ServerID - 1];
                            simSys.Servers[ServerID - 1].NoOfCustomers++;
                            simSys.SimulationTable[i].StartTime = simSys.SimulationTable[i].ArrivalTime;
                            simSys.Servers[ServerID - 1].FinishTime = simSys.SimulationTable[i].StartTime + simSys.SimulationTable[i].ServiceTime;
                            simSys.Servers[ServerID - 1].TotalWorkingTime += simSys.SimulationTable[i].ServiceTime;

                            break;
                        }
                    }
                }
                else//no available server
                {
                    //find the first server that will finish
                    findFirstFinishServer(i);
                }

                simSys.SimulationTable[i].TimeInQueue = simSys.SimulationTable[i].StartTime - simSys.SimulationTable[i].ArrivalTime;
                simSys.SimulationTable[i].EndTime = simSys.SimulationTable[i].ServiceTime + simSys.SimulationTable[i].StartTime;
            }
        }

        public void findFirstFinishServer(int currentIndex)
        {
            Server firstFinishServer = null;
            int minEndTime = 1000000;

            //search for the least end time service and server

            for (int l = 0; l < simSys.NumberOfServers; l++)
            {
                if (simSys.Servers[l].FinishTime < minEndTime)
                {
                    minEndTime = simSys.Servers[l].FinishTime;
                    firstFinishServer = simSys.Servers[l];
                }
            }
            //assigning suitable server to the current row
            simSys.SimulationTable[currentIndex].AssignedServer = firstFinishServer;
            simSys.Servers[firstFinishServer.ID - 1].NoOfCustomers++;

            //searching for suitable range in firstFinishServer to assign the service time
            for (int w = 0; w < firstFinishServer.TimeDistribution.Count; w++)
            {
                if (simSys.SimulationTable[currentIndex].RandomService >= firstFinishServer.TimeDistribution[w].MinRange && simSys.SimulationTable[currentIndex].RandomService <= firstFinishServer.TimeDistribution[w].MaxRange)
                {
                    simSys.SimulationTable[currentIndex].ServiceTime = firstFinishServer.TimeDistribution[w].Time;
                    break;
                }
            }

            simSys.Servers[firstFinishServer.ID - 1].TotalWorkingTime += simSys.SimulationTable[currentIndex].ServiceTime;

            simSys.SimulationTable[currentIndex].StartTime = minEndTime;
            simSys.Servers[firstFinishServer.ID - 1].FinishTime = simSys.SimulationTable[currentIndex].ServiceTime + simSys.SimulationTable[currentIndex].StartTime;

        }

        public void fillSimSysObj(string[] sysData)
        {
            simSys.NumberOfServers = Convert.ToInt32(sysData[1]);
            simSys.Servers = new List<Server>(simSys.NumberOfServers);


            simSys.SimulationTable = new List<SimulationCase>();

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
            for (int j = 0; j < simSys.NumberOfServers; j++)
            {
                i += 2;
                Server server = new Server();
                server.ID = j + 1;
                while (i != sysData.Length && sysData[i] != "")
                {
                    string[] line = sysData[i].Split(new string[] { ", " }, StringSplitOptions.None);
                    TimeDistribution timeDistributionRow = new TimeDistribution();
                    timeDistributionRow.Time = Convert.ToInt32(line[0]);
                    timeDistributionRow.Probability = Convert.ToDecimal(line[1]);
                    server.TotalWorkingTime = 0;
                    server.FinishTime = 0;
                    server.TimeDistribution.Add(timeDistributionRow);

                    i++;
                }
                simSys.Servers.Add(server);
            }
        }

        public void highestPriorityMethod(int i)
        {
            for (; i < simSys.SimulationTable.Count; i++)
            {

                int customerArrivalTime = simSys.SimulationTable[i].ArrivalTime;
                bool serverFound = false;
                if (simSys.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
                {
                    if (customerArrivalTime > simSys.StoppingNumber)
                        break;
                }
                //searching for first suitable server
                for (int j = 0; j < simSys.Servers.Count; j++)
                {
                    if (customerArrivalTime >= simSys.Servers[j].FinishTime)//available server
                    {
                        for (int k = 0; k < simSys.Servers[j].TimeDistribution.Count; k++)
                        {
                            if (simSys.SimulationTable[i].RandomService >= simSys.Servers[j].TimeDistribution[k].MinRange && simSys.SimulationTable[i].RandomService <= simSys.Servers[j].TimeDistribution[k].MaxRange)
                            {
                                simSys.SimulationTable[i].ServiceTime = simSys.Servers[j].TimeDistribution[k].Time;
                                simSys.SimulationTable[i].AssignedServer = simSys.Servers[j];
                                simSys.Servers[j].NoOfCustomers++;

                                serverFound = true;
                                simSys.SimulationTable[i].StartTime = simSys.SimulationTable[i].ArrivalTime;
                                simSys.Servers[j].FinishTime = simSys.SimulationTable[i].ServiceTime + simSys.SimulationTable[i].StartTime;
                                simSys.Servers[j].TotalWorkingTime += simSys.SimulationTable[i].ServiceTime;

                                break;
                            }
                        }
                        if (serverFound)
                            break;
                    }
                }
                if (!serverFound)
                {
                    //find the fisrt server that will finish
                    findFirstFinishServer(i);

                }// if(! serverFound)
                simSys.SimulationTable[i].TimeInQueue = simSys.SimulationTable[i].StartTime - simSys.SimulationTable[i].ArrivalTime;
                simSys.SimulationTable[i].EndTime = simSys.SimulationTable[i].ServiceTime + simSys.SimulationTable[i].StartTime;
                //  simSys.Servers[j].FinishTime = simSys.SimulationTable[i].ServiceTime + simSys.SimulationTable[i].StartTime;
            }
        }

        public void randomMethod(int i)
        {
            Random rnd = new Random();

            for (; i < simSys.SimulationTable.Count; i++)
            {
                if (simSys.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
                {
                    if (simSys.SimulationTable[i].ArrivalTime > simSys.StoppingNumber)
                        break;
                }
                bool foundServer = false;
                HashSet<int> busyServers = new HashSet<int>();
                while (foundServer == false && busyServers.Count < simSys.NumberOfServers)
                {
                    int randomServer = rnd.Next(0, simSys.NumberOfServers);
                    int customerArrivalTime = simSys.SimulationTable[i].ArrivalTime;

                    if (customerArrivalTime >= simSys.Servers[randomServer].FinishTime)//available server
                    {
                        for (int r = 0; r < simSys.Servers[randomServer].TimeDistribution.Count; r++)
                        {
                            //int CustomerServiceTime = simSys.SimulationTable[i].ServiceTime;
                            int CustomerServiceTime = simSys.SimulationTable[i].RandomService;
                            int MinRange = simSys.Servers[randomServer].TimeDistribution[r].MinRange;
                            int MaxRange = simSys.Servers[randomServer].TimeDistribution[r].MaxRange;
                            if (CustomerServiceTime >= MinRange && CustomerServiceTime <= MaxRange)
                            {
                                simSys.SimulationTable[i].ServiceTime = simSys.Servers[randomServer].TimeDistribution[r].Time;
                                simSys.SimulationTable[i].StartTime = simSys.SimulationTable[i].ArrivalTime;
                                simSys.SimulationTable[i].TimeInQueue = simSys.SimulationTable[i].StartTime - simSys.SimulationTable[i].ArrivalTime;
                                simSys.SimulationTable[i].EndTime = simSys.SimulationTable[i].ServiceTime + simSys.SimulationTable[i].StartTime;
                                simSys.Servers[randomServer].FinishTime = simSys.SimulationTable[i].StartTime + simSys.SimulationTable[i].ServiceTime;
                                simSys.SimulationTable[i].AssignedServer = simSys.Servers[randomServer];
                                simSys.Servers[randomServer].NoOfCustomers++;

                                simSys.Servers[randomServer].TotalWorkingTime += simSys.SimulationTable[i].ServiceTime;

                                foundServer = true;
                                break;
                            }

                        }
                    }
                    else
                        busyServers.Add(simSys.Servers[randomServer].ID);
                }
                //kol el servers busy
                if (!foundServer)
                    findFirstFinishServer(i);

                simSys.SimulationTable[i].TimeInQueue = simSys.SimulationTable[i].StartTime - simSys.SimulationTable[i].ArrivalTime;
                simSys.SimulationTable[i].EndTime = simSys.SimulationTable[i].ServiceTime + simSys.SimulationTable[i].StartTime;
            }
        }

        public void fillSimulationTable(int i)
        {

            if (simSys.SelectionMethod == Enums.SelectionMethod.HighestPriority)
            {
                highestPriorityMethod(i);
            }
            else if (simSys.SelectionMethod == Enums.SelectionMethod.Random)
            {
                randomMethod(i);
            }

            else
                LeastUtilizationMethod(i);

        }

        public void fillInterArrivaleTable()
        {
            simSys.InterarrivalDistribution[0].CummProbability = simSys.InterarrivalDistribution[0].Probability;
            simSys.InterarrivalDistribution[0].MinRange = 1;
            simSys.InterarrivalDistribution[0].MaxRange = Convert.ToInt32(simSys.InterarrivalDistribution[0].Probability * 100);
            for (int i = 1; i < simSys.InterarrivalDistribution.Count; i++)
            {
                simSys.InterarrivalDistribution[i].CummProbability = simSys.InterarrivalDistribution[i].Probability +
                    simSys.InterarrivalDistribution[i - 1].CummProbability;
                simSys.InterarrivalDistribution[i].MinRange = simSys.InterarrivalDistribution[i - 1].MaxRange + 1;
                simSys.InterarrivalDistribution[i].MaxRange = simSys.InterarrivalDistribution[i - 1].MaxRange +
                    Convert.ToInt32(simSys.InterarrivalDistribution[i].Probability * 100);

            }
        }

        public void fillServersTimeDistribution()
        {
            for (int i = 0; i < simSys.Servers.Count; i++)
            {
                simSys.Servers[i].TimeDistribution[0].CummProbability = simSys.Servers[i].TimeDistribution[0].Probability;
                simSys.Servers[i].TimeDistribution[0].MinRange = 1;
                simSys.Servers[i].TimeDistribution[0].MaxRange = Convert.ToInt32(simSys.Servers[i].TimeDistribution[0].Probability * 100);
                for (int j = 1; j < simSys.Servers[i].TimeDistribution.Count; j++)
                {
                    simSys.Servers[i].TimeDistribution[j].CummProbability = simSys.Servers[i].TimeDistribution[j].Probability +
                        simSys.Servers[i].TimeDistribution[j - 1].CummProbability;
                    simSys.Servers[i].TimeDistribution[j].MinRange = simSys.Servers[i].TimeDistribution[j - 1].MaxRange + 1;
                    simSys.Servers[i].TimeDistribution[j].MaxRange = simSys.Servers[i].TimeDistribution[j - 1].MaxRange +
                        Convert.ToInt32(simSys.Servers[i].TimeDistribution[j].Probability * 100);
                }

            }

        }

        public void systemCalculations()
        {
            PerformanceMeasures measures = new PerformanceMeasures();
            decimal noCustomerWaited = 0, sumOfDelay = 0;
            int maxQLength = 0;
            int counter = 0;
            for (int i = 0; i < simSys.SimulationTable.Count; i++)
            {
                int index = i + 1;
                if (simSys.SimulationTable[i].TimeInQueue > 0)
                {
                    noCustomerWaited++;
                    sumOfDelay += simSys.SimulationTable[i].TimeInQueue;
                    counter++;

                    while (index < simSys.SimulationTable.Count && simSys.SimulationTable[index].ArrivalTime < simSys.SimulationTable[i].StartTime)
                    {
                        counter++;
                        index++;
                    }
                    maxQLength = Math.Max(counter, maxQLength);
                    counter = 0;

                }
            }
            measures.AverageWaitingTime = (decimal)(sumOfDelay / simSys.SimulationTable.Count);
            measures.WaitingProbability = (decimal)noCustomerWaited / simSys.SimulationTable.Count;
            measures.MaxQueueLength = maxQLength;
            simSys.PerformanceMeasures = measures;
        }

        public void serverCalculations()
        {
            int maxTimeServer = 0;
            for (int i = 0; i < simSys.Servers.Count; i++)   //3shan a7seb el total run time bta3 el simulation
            {
                maxTimeServer = Math.Max(simSys.Servers[i].FinishTime, maxTimeServer);
            }
            // law el servers kolha 5lst w lesa fih w2t
            if (simSys.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
                maxTimeServer = Math.Max(simSys.StoppingNumber, maxTimeServer);

            for (int i = 0; i < simSys.Servers.Count; i++)
            {
                if (simSys.Servers[i].NoOfCustomers != 0)
                    simSys.Servers[i].AverageServiceTime = (decimal)((decimal)simSys.Servers[i].TotalWorkingTime / (decimal)simSys.Servers[i].NoOfCustomers); // need to sure of no of customer
                else
                    simSys.Servers[i].AverageServiceTime = 0;

                if (simSys.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
                {
                    simSys.Servers[i].Utilization = (decimal)simSys.Servers[i].TotalWorkingTime / (decimal)maxTimeServer;
                    simSys.Servers[i].IdleProbability = (decimal)(maxTimeServer - simSys.Servers[i].TotalWorkingTime) / (decimal)maxTimeServer;
                }
                else
                {
                    simSys.Servers[i].Utilization = (decimal)simSys.Servers[i].TotalWorkingTime / (decimal)simSys.StoppingNumber;
                    simSys.Servers[i].IdleProbability = (decimal)(simSys.StoppingNumber - simSys.Servers[i].TotalWorkingTime) / simSys.StoppingNumber;
                }

            }
        }

        public void fillSimCaseRow()
        {
            SimulationCase simRow = new SimulationCase();
            Random randomNum = new Random();
            simRow.CustomerNumber = 1;
            simRow.RandomInterArrival = 1;//_
            simRow.InterArrival = 1;//_
            simRow.ArrivalTime = 0;
            simRow.RandomService = randomNum.Next(1, 101);
            simSys.SimulationTable.Add(simRow);
            fillSimulationTable(0);

            int i = 1;
            while (true)
            {
                simRow = new SimulationCase();
                simRow.CustomerNumber = i + 1;


                simRow.RandomInterArrival = randomNum.Next(1, 101);


                for (int j = 0; j < simSys.InterarrivalDistribution.Count; j++)
                {
                    if (simRow.RandomInterArrival >= simSys.InterarrivalDistribution[j].MinRange && simRow.RandomInterArrival <= simSys.InterarrivalDistribution[j].MaxRange)
                    {
                        simRow.InterArrival = simSys.InterarrivalDistribution[j].Time;
                        break;
                    }
                }

                simRow.ArrivalTime = simSys.SimulationTable[i - 1].ArrivalTime + simRow.InterArrival;


                simRow.RandomService = randomNum.Next(1, 101);//:) :)
                if (simSys.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime)
                {
                    if (simRow.ArrivalTime > simSys.StoppingNumber)
                        break;
                }


                if (simSys.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
                {

                    if (simSys.SimulationTable.Count < simSys.StoppingNumber)
                    {
                        simSys.SimulationTable.Add(simRow);
                        fillSimulationTable(i);
                    }
                    else break;
                }
                else
                {
                    simSys.SimulationTable.Add(simRow);
                    fillSimulationTable(i);

                    if (simSys.SimulationTable[i].EndTime > simSys.StoppingNumber)
                    {
                        simSys.SimulationTable.RemoveAt(i);
                        break;
                    }
                }
                i++;

            }
        }

        private void readFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string[] fileData = File.ReadAllLines(fileName);

                fillSimSysObj(fileData);
                fillInterArrivaleTable();
                fillServersTimeDistribution();
                fillSimCaseRow();
                systemCalculations();
                serverCalculations();

                string testingResult = TestingManager.Test(simSys, Constants.FileNames.TestCase2);
                MessageBox.Show(testingResult);

                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void getDataFromGUI_Click(object sender, EventArgs e)
        {
            simSys.NumberOfServers = Convert.ToInt32(noOfServerstextBox.Text);
            simSys.StoppingNumber = Convert.ToInt32(stoppingNotextBox.Text);
            if (noOfCustomersradioButton.Checked)
                simSys.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
            else if (simEndTimeradioButton.Checked)
                simSys.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
            if (highestPriorityradioButton.Checked)
            {
                simSys.SelectionMethod = Enums.SelectionMethod.HighestPriority;
            }
            else if (randomradioButton.Checked)
            {
                simSys.SelectionMethod = Enums.SelectionMethod.Random;
            }
            else if (leastUtilizationradioButton.Checked)
                simSys.SelectionMethod = Enums.SelectionMethod.LeastUtilization;

            string intervalDistFromTextBox = InterarrivalDistributiontextbox.Text;
            string[] intervalDist = intervalDistFromTextBox.Split(new[] { "\r\n", "\r", "\n", ",", " " }, StringSplitOptions.None);
            intervalDist = intervalDist.Where(w => w != "").ToArray();
            TimeDistribution timeDistribution;
            for (int i = 0; i < intervalDist.Length; i += 2)
            {
                timeDistribution = new TimeDistribution();
                timeDistribution.Time = Convert.ToInt32(intervalDist[i]);
                timeDistribution.Probability = Convert.ToDecimal(intervalDist[i + 1]);
                simSys.InterarrivalDistribution.Add(timeDistribution);
            }
            string serviceDistFromTextBox = serviceDistributiontextBox.Text;
            string[] serviceDist = serviceDistFromTextBox.Split(new[] { "\r\n", "\r", "\n", ",", " " }, StringSplitOptions.None);
            serviceDist = serviceDist.Where(w => w != "").ToArray();
            Server server;
            int k = 1;
            for (int i = 0; i < simSys.NumberOfServers; i++)
            {
                server = new Server();
                server.ID = i + 1;
                while (k != serviceDist.Length)
                {
                    try
                    {
                        int x = Convert.ToInt32(serviceDist[k]);
                    }
                    catch
                    {
                        break;
                    }
                    timeDistribution = new TimeDistribution();
                    timeDistribution.Time = Convert.ToInt32(serviceDist[k]);
                    timeDistribution.Probability = Convert.ToDecimal(serviceDist[k + 1]);
                    server.TotalWorkingTime = 0;
                    server.FinishTime = 0;
                    server.TimeDistribution.Add(timeDistribution);
                    k += 2;
                }
                k++;
                simSys.Servers.Add(server);
            }

            fillInterArrivaleTable();
            fillServersTimeDistribution();
            fillSimCaseRow();
            systemCalculations();
            serverCalculations();
          //  simSys.PerformanceMeasures.MaxQueueLength = 3;

            string testingResult = TestingManager.Test(simSys, Constants.FileNames.TestCase1);
            MessageBox.Show(testingResult);

            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
