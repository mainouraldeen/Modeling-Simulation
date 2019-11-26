using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BearingMachineTesting;
using BearingMachineModels;
using System.IO;

namespace BearingMachineSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static SimulationSystem simSys = new SimulationSystem();
        public static List<int> countOfBearings= new List<int>();

        public void fillSimSysObj(string[] sysData)
        {
            simSys.DowntimeCost = Convert.ToInt32(sysData[1]);
            simSys.RepairPersonCost = Convert.ToInt32(sysData[4]);
            simSys.BearingCost = Convert.ToInt32(sysData[7]);
            simSys.NumberOfHours = Convert.ToInt32(sysData[10]);
            simSys.NumberOfBearings = Convert.ToInt32(sysData[13]);
            simSys.RepairTimeForOneBearing = Convert.ToInt32(sysData[16]);
            simSys.RepairTimeForAllBearings = Convert.ToInt32(sysData[19]);
            int i = 22;
            while (sysData[i] != "")
            {
                string[] line = sysData[i].Split(new string[] { ", " }, StringSplitOptions.None);
                TimeDistribution delayTimeDistribution = new TimeDistribution();
                delayTimeDistribution.Time = Convert.ToInt32(line[0]);
                delayTimeDistribution.Probability = Convert.ToDecimal(line[1]);
                simSys.DelayTimeDistribution.Add(delayTimeDistribution);
                i++;
            }
            i+=2;
            while (i != sysData.Length)
            {
                string[] line = sysData[i].Split(new string[] { ", " }, StringSplitOptions.None);
                TimeDistribution bearingTimeDistribution = new TimeDistribution();
                bearingTimeDistribution.Time = Convert.ToInt32(line[0]);
                bearingTimeDistribution.Probability = Convert.ToDecimal(line[1]);
                simSys.BearingLifeDistribution.Add(bearingTimeDistribution);
                i++;
            }
        }

        public void fillDelayTimeDistributionTable()
        {
            simSys.DelayTimeDistribution[0].CummProbability = simSys.DelayTimeDistribution[0].Probability;
            simSys.DelayTimeDistribution[0].MinRange = 1;
            simSys.DelayTimeDistribution[0].MaxRange = Convert.ToInt32(simSys.DelayTimeDistribution[0].Probability * 100);
            for (int i = 1; i < simSys.DelayTimeDistribution.Count; i++)
            {
                simSys.DelayTimeDistribution[i].CummProbability = simSys.DelayTimeDistribution[i].Probability +
                    simSys.DelayTimeDistribution[i - 1].CummProbability;
                simSys.DelayTimeDistribution[i].MinRange = simSys.DelayTimeDistribution[i - 1].MaxRange + 1;
                simSys.DelayTimeDistribution[i].MaxRange = simSys.DelayTimeDistribution[i - 1].MaxRange +
                    Convert.ToInt32(simSys.DelayTimeDistribution[i].Probability * 100);
            }
        }

        public void fillBearingLifeDistributionTable()
        {
            simSys.BearingLifeDistribution[0].CummProbability = simSys.BearingLifeDistribution[0].Probability;
            simSys.BearingLifeDistribution[0].MinRange = 1;
            simSys.BearingLifeDistribution[0].MaxRange = Convert.ToInt32(simSys.BearingLifeDistribution[0].Probability * 100);
            for (int i = 1; i < simSys.BearingLifeDistribution.Count; i++)
            {
                simSys.BearingLifeDistribution[i].CummProbability = simSys.BearingLifeDistribution[i].Probability +
                    simSys.BearingLifeDistribution[i - 1].CummProbability;
                simSys.BearingLifeDistribution[i].MinRange = simSys.BearingLifeDistribution[i - 1].MaxRange + 1;
                simSys.BearingLifeDistribution[i].MaxRange = simSys.BearingLifeDistribution[i - 1].MaxRange +
                    Convert.ToInt32(simSys.BearingLifeDistribution[i].Probability * 100);

            }
        }

        public int totalDelay = 0;
        public void fillCurrentSimlationTable()
        {
            
            CurrentSimulationCase currentSimulation;
            Random randomNum = new Random();
            for (int j = 0; j < simSys.NumberOfBearings; j++)
            {
                int currentAccumelatedHours = 0;
                int countBearings = 0;

                while (true)
                {
                    countBearings++;
                    Bearing bearing = new Bearing();
                    bearing.Index = j + 1;
                    //////////////////////////////////////////////Hours//////////////////////////////////////////////
                    currentSimulation = new CurrentSimulationCase();
                    bearing.RandomHours = randomNum.Next(1, 101);
                    for (int i = 0; i < simSys.BearingLifeDistribution.Count(); i++)
                    {
                        if (bearing.RandomHours >= simSys.BearingLifeDistribution[i].MinRange && bearing.RandomHours <= simSys.BearingLifeDistribution[i].MaxRange)
                        {
                            bearing.Hours = simSys.BearingLifeDistribution[i].Time;
                            break;
                        }
                    }
                    currentAccumelatedHours += bearing.Hours;
                    currentSimulation.Bearing = bearing;
                    currentSimulation.AccumulatedHours = currentAccumelatedHours;

                    /////////////////////////////////////////////////Delay/////////////////////////////////////////
                    currentSimulation.RandomDelay = randomNum.Next(1, 100);
                    for (int i = 0; i < simSys.DelayTimeDistribution.Count(); i++)
                    {
                        if (currentSimulation.RandomDelay >= simSys.DelayTimeDistribution[i].MinRange && currentSimulation.RandomDelay <= simSys.DelayTimeDistribution[i].MaxRange)
                        {
                            currentSimulation.Delay = simSys.DelayTimeDistribution[i].Time;
                            break;
                        }
                    }   
                 
                    totalDelay += currentSimulation.Delay;
                    simSys.CurrentSimulationTable.Add(currentSimulation);
                    if (currentAccumelatedHours >= simSys.NumberOfHours)
                        break;
                }
                countOfBearings.Add(countBearings);
            }                       

        }

        public void calcCurrentPerformance()
        {
            PerformanceMeasures currentPerformance = new PerformanceMeasures();
            int totalNumOfBearigns = simSys.CurrentSimulationTable.Count;
            currentPerformance.BearingCost = totalNumOfBearigns * simSys.BearingCost;
            currentPerformance.DelayCost = totalDelay * simSys.DowntimeCost;
            currentPerformance.DowntimeCost = totalNumOfBearigns * simSys.RepairTimeForOneBearing * simSys.DowntimeCost;
            currentPerformance.RepairPersonCost = (totalNumOfBearigns * simSys.RepairTimeForOneBearing * simSys.RepairPersonCost) / 60;
            currentPerformance.TotalCost = currentPerformance.BearingCost + currentPerformance.DelayCost + currentPerformance.DowntimeCost + currentPerformance.RepairPersonCost;
            simSys.CurrentPerformanceMeasures = currentPerformance;
        }

        public int totalDelayProposed = 0;
        public void fillProposedSimlationTable()
        {
            int i = 0, accHours = 0;
            Random randomNum = new Random();
            while (true)
            {
                ProposedSimulationCase proposedSimulationCase = new ProposedSimulationCase();
                int sum = 0, generalSum = 0;
                int index = 1;
                List<Bearing> currentBearing = new List<Bearing>();
                ///////////////////////////////////////////first bearing////////////////////////////////////////
                if (i < countOfBearings[0])
                    currentBearing.Add(simSys.CurrentSimulationTable[i].Bearing);
                else
                {                    
                    Bearing bearing = new Bearing();
                    index = 1;
                    bearing.RandomHours = randomNum.Next(1, 101);
                    bearing.Index = index;
                    for (int k = 0; k < simSys.BearingLifeDistribution.Count(); k++)
                    {
                        if (bearing.RandomHours >= simSys.BearingLifeDistribution[k].MinRange && bearing.RandomHours <= simSys.BearingLifeDistribution[k].MaxRange)
                        {
                            bearing.Hours = simSys.BearingLifeDistribution[k].Time;
                            break;
                        }
                    }
                    currentBearing.Add(bearing);
                }
                /////////////////////////////////////////////rest of bearings//////////////////////////////////////
                generalSum += countOfBearings[0];
                for (int j = 0; j < simSys.NumberOfBearings-1; j++)
                {
                    sum += countOfBearings[j];
                    generalSum += countOfBearings[j+1];
                    if (i + sum < generalSum)
                        currentBearing.Add(simSys.CurrentSimulationTable[i+sum].Bearing);
                    else
                    {
                        Bearing bearing = new Bearing();
                        index = j + 2;
                        bearing.RandomHours = randomNum.Next(1, 101);
                        bearing.Index = index;
                        for (int k = 0; k < simSys.BearingLifeDistribution.Count(); k++)
                        {
                            if (bearing.RandomHours >= simSys.BearingLifeDistribution[k].MinRange && bearing.RandomHours <= simSys.BearingLifeDistribution[k].MaxRange)
                            {
                                bearing.Hours = simSys.BearingLifeDistribution[k].Time;
                                break;
                            }
                        }
                        currentBearing.Add(bearing);
                    }
                }
                /////////////////////////////////////////////////////delay/////////////////////////////////////
                proposedSimulationCase.RandomDelay = randomNum.Next(1, 100);
                for (int l = 0; l < simSys.DelayTimeDistribution.Count(); l++)
                {
                    if (proposedSimulationCase.RandomDelay >= simSys.DelayTimeDistribution[l].MinRange && proposedSimulationCase.RandomDelay <= simSys.DelayTimeDistribution[l].MaxRange)
                    {
                        proposedSimulationCase.Delay = simSys.DelayTimeDistribution[l].Time;
                        break;
                    }
                }
                totalDelayProposed += proposedSimulationCase.Delay;
                //////////////////////////////////////////////first failure///////////////////////////////////////
                int minHour = int.MaxValue;
                for(int l =0; l<currentBearing.Count; l++)
                {
                    if (currentBearing[l].Hours < minHour)
                        minHour = currentBearing[l].Hours;
                }
                proposedSimulationCase.Bearings = currentBearing;
                proposedSimulationCase.FirstFailure = minHour;
                accHours += minHour;
                proposedSimulationCase.AccumulatedHours = accHours; 

                simSys.ProposedSimulationTable.Add(proposedSimulationCase);
                if (proposedSimulationCase.AccumulatedHours >= simSys.NumberOfHours)
                    break;
                i++;
            }


        }

        public void calcProposedPerformance()
        {
            PerformanceMeasures proposedPerformance = new PerformanceMeasures();
            int totalNumOfBearigns = simSys.ProposedSimulationTable.Count * simSys.NumberOfBearings;
            proposedPerformance.BearingCost = totalNumOfBearigns * simSys.BearingCost;
            proposedPerformance.DelayCost = totalDelayProposed * simSys.DowntimeCost;
            proposedPerformance.DowntimeCost = simSys.ProposedSimulationTable.Count * simSys.RepairTimeForAllBearings * simSys.DowntimeCost;
            proposedPerformance.RepairPersonCost = (simSys.ProposedSimulationTable.Count * simSys.RepairTimeForAllBearings * simSys.RepairPersonCost) / 60;
            proposedPerformance.TotalCost = proposedPerformance.BearingCost + proposedPerformance.DelayCost + proposedPerformance.DowntimeCost + proposedPerformance.RepairPersonCost;
            simSys.ProposedPerformanceMeasures = proposedPerformance;
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
                fillDelayTimeDistributionTable();
                fillBearingLifeDistributionTable();
                fillCurrentSimlationTable();
                calcCurrentPerformance();
                fillProposedSimlationTable();
                calcProposedPerformance();
                string[] splitedFilName = fileName.Split(Path.DirectorySeparatorChar);
                string testing = TestingManager.Test(simSys, splitedFilName[splitedFilName.Length-1]);
                MessageBox.Show(testing);
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
        }
    }
}
