using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryTesting;
using InventoryModels;
using System.IO;

namespace InventorySimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static SimulationSystem simSys = new SimulationSystem();

        private void Readfile_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                
                string[] fileData = File.ReadAllLines(fileName);
                
                FillSimSysObj(fileData);
                //MessageBox.Show("Done!!");
                FillDistribution();
                FillSimulationTable();
                string[] splitedFilName = fileName.Split(Path.DirectorySeparatorChar);
                string testing = TestingManager.Test(simSys, splitedFilName[splitedFilName.Length - 1]);
          
                MessageBox.Show(testing);

                Form2 f2 = new Form2();
                f2.Show();
                //this.Close();
                this.Hide();
                





            }
        }

        public void FillSimSysObj(string[] sysData)
        {
            simSys.OrderUpTo = Convert.ToInt32(sysData[1]);
            simSys.ReviewPeriod = Convert.ToInt32(sysData[4]);
            simSys.StartInventoryQuantity = Convert.ToInt32(sysData[7]);
            simSys.StartLeadDays = Convert.ToInt32(sysData[10]);
            simSys.StartOrderQuantity = Convert.ToInt32(sysData[13]);
            simSys.NumberOfDays = Convert.ToInt32(sysData[16]);

            int i = 19;
            for (i=19; i<24;i++)
            {
                string[] Demand_line = sysData[i].Split(new string[] { ", " }, StringSplitOptions.None);
                Distribution demandDistributionRow = new Distribution();
                demandDistributionRow.Value = Convert.ToInt32(Demand_line[0]);
                demandDistributionRow.Probability = Convert.ToDecimal(Demand_line[1]);
                simSys.DemandDistribution.Add(demandDistributionRow);
                
            }
            i = 26;
            while (i < sysData.Count())
            {
                string[] Demand_line = sysData[i].Split(new string[] { ", " }, StringSplitOptions.None);
                Distribution LeadDistributionRow = new Distribution();
                LeadDistributionRow.Value = Convert.ToInt32(Demand_line[0]);
                LeadDistributionRow.Probability = Convert.ToDecimal(Demand_line[1]);
                simSys.LeadDaysDistribution.Add(LeadDistributionRow);
                i++;


            }

        }
       
        public void FillDistribution()
        {   
            //Demand Distribution
            simSys.DemandDistribution[0].CummProbability = simSys.DemandDistribution[0].Probability;
            simSys.DemandDistribution[0].MinRange = 0;
            simSys.DemandDistribution[0].MaxRange =Convert.ToInt32(simSys.DemandDistribution[0].Probability *100);

            for (int i = 1; i < simSys.DemandDistribution.Count; i++)
            {  
                simSys.DemandDistribution[i].CummProbability = simSys.DemandDistribution[i].Probability +simSys.DemandDistribution[i - 1].CummProbability;
                simSys.DemandDistribution[i].MinRange = simSys.DemandDistribution[i - 1].MaxRange + 1;
                simSys.DemandDistribution[i].MaxRange = Convert.ToInt32(simSys.DemandDistribution[i].CummProbability* 100);
            }
            //Lead Distribution
            simSys.LeadDaysDistribution[0].CummProbability = simSys.LeadDaysDistribution[0].Probability;
            simSys.LeadDaysDistribution[0].MinRange = 1;
            simSys.LeadDaysDistribution[0].MaxRange = Convert.ToInt32(simSys.LeadDaysDistribution[0].Probability * 100);

            for (int i = 1; i < simSys.LeadDaysDistribution.Count; i++)
            {
                simSys.LeadDaysDistribution[i].CummProbability = simSys.LeadDaysDistribution[i].Probability + simSys.LeadDaysDistribution[i - 1].CummProbability;
                simSys.LeadDaysDistribution[i].MinRange = simSys.LeadDaysDistribution[i - 1].MaxRange + 1;
                simSys.LeadDaysDistribution[i].MaxRange = Convert.ToInt32(simSys.LeadDaysDistribution[i].CummProbability * 100);
            }


        }

        public void FillSimulationTable()
        {
            SimulationCase SimRow;
            int shortageSum = 0;
            int EndingInventoryTotal = 0;
            int ShortageTotal=0;
            Random rand = new Random();
            int cycleNumber = 1, cycleCounter = 1,index = 0,dummy=0;
           
            for (int day=1; day<=simSys.NumberOfDays; day++)
            {
                //first 5 columns
                SimRow = new SimulationCase();
                SimRow.Day = day; 
                SimRow.Cycle = cycleNumber;
                SimRow.DayWithinCycle = cycleCounter; // day % (simSys.ReviewPeriod + 1) + 1;
                cycleCounter++;
                if (cycleCounter > simSys.ReviewPeriod)
                {
                    cycleCounter = 1;
                    cycleNumber++;
                }

                if (day == 1)
                {
                    SimRow.BeginningInventory = simSys.StartInventoryQuantity;
                    SimRow.DaysUntillArrives = simSys.StartLeadDays - 1;
                    
                }
                else
                {
                    
                    SimRow.DaysUntillArrives = simSys.SimulationTable[day-2].DaysUntillArrives-1;
                    if (SimRow.DaysUntillArrives == -1)
                    {
                        dummy++;
                        if (dummy==1)//3shan 3aiza awl mara bs yst5dm start order quantity
                            SimRow.BeginningInventory = simSys.StartOrderQuantity + simSys.SimulationTable[day - 2].EndingInventory;

                        else
                            SimRow.BeginningInventory = simSys.SimulationTable[index - 1].OrderQuantity + simSys.SimulationTable[day - 2].EndingInventory;
                      
                    }
                    else if (SimRow.DaysUntillArrives!=-1)
                        SimRow.BeginningInventory = simSys.SimulationTable[day - 2].EndingInventory;
                }
                //Demand
                int randomDemand = rand.Next(1, 101);
                SimRow.RandomDemand = randomDemand;
                for (int r = 0; r < simSys.DemandDistribution.Count; r++)
                {
                    if (randomDemand >= simSys.DemandDistribution[r].MinRange && randomDemand <= simSys.DemandDistribution[r].MaxRange)
                    {
                        SimRow.Demand = simSys.DemandDistribution[r].Value;
                        break;
                    }
                }
                // Ending Inventory & shortage
                if (SimRow.BeginningInventory>=SimRow.Demand)
                {
                    if (shortageSum == 0)
                    {
                        SimRow.EndingInventory = SimRow.BeginningInventory - SimRow.Demand;
                        SimRow.ShortageQuantity = 0;

                    }
                    else if (shortageSum + SimRow.Demand > SimRow.BeginningInventory)
                    {
                        SimRow.EndingInventory = 0;
                        SimRow.ShortageQuantity = shortageSum + (SimRow.Demand - SimRow.BeginningInventory);
                        shortageSum = SimRow.ShortageQuantity;
                    }
                    else //there is shortage but less than or equal beginning Inventory
                    {
                        SimRow.EndingInventory = SimRow.BeginningInventory - SimRow.Demand - shortageSum;
                        SimRow.ShortageQuantity = 0;
                        shortageSum = 0;
                    }
                    
                }
                else//demand>beginning Inventory
                {
                    SimRow.EndingInventory = 0;

                    if (shortageSum == 0)//no shortage before
                    {
                        SimRow.ShortageQuantity = SimRow.Demand - SimRow.BeginningInventory;
                        shortageSum = SimRow.ShortageQuantity;
                    }

                    else //if there is shortage
                    {
                        SimRow.ShortageQuantity = shortageSum + (SimRow.Demand - SimRow.BeginningInventory);
                        shortageSum = SimRow.ShortageQuantity;
                    }   
                    

                }
                EndingInventoryTotal += SimRow.EndingInventory;
                ShortageTotal += SimRow.ShortageQuantity;
                // Order Quantity & lead time
                if (SimRow.DayWithinCycle == simSys.ReviewPeriod)
                {
                    SimRow.OrderQuantity = simSys.OrderUpTo - SimRow.EndingInventory + (SimRow.ShortageQuantity);
                    index = day;
                    SimRow.RandomLeadDays = rand.Next(1, 101);
                    for (int j = 0; j < simSys.LeadDaysDistribution.Count(); j++)
                    {
                        if (SimRow.RandomLeadDays >= simSys.LeadDaysDistribution[j].MinRange && SimRow.RandomLeadDays <= simSys.LeadDaysDistribution[j].MaxRange)
                        {
                            SimRow.LeadDays = simSys.LeadDaysDistribution[j].Value;
                            break;
                        }
                    }
                    SimRow.DaysUntillArrives = SimRow.LeadDays;
                }
                else
                {
                    SimRow.OrderQuantity = 0;
                    SimRow.RandomLeadDays = 0;
                    SimRow.LeadDays = 0;
               
                }

                simSys.SimulationTable.Add(SimRow);
               
            }
            Performance(EndingInventoryTotal, ShortageTotal);
        }

        public void Performance(int Ending_Inventory, int shortage)
        {
            simSys.PerformanceMeasures.EndingInventoryAverage = (decimal)Ending_Inventory / simSys.NumberOfDays;
            simSys.PerformanceMeasures.ShortageQuantityAverage =(decimal) shortage / simSys.NumberOfDays;
        }
    
       
    }
}
