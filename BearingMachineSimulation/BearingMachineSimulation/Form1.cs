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
            for (int j = 0; j <= simSys.NumberOfBearings; j++)
            {
                int currentAccumelatedHours = 0;
                Bearing bearing = new Bearing();
                bearing.Index = j+1;
                while (true)
                {
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
                        if (currentSimulation.Delay >= simSys.DelayTimeDistribution[i].MinRange && currentSimulation.Delay <= simSys.DelayTimeDistribution[i].MaxRange)
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

                string testing = TestingManager.Test(simSys, Constants.FileNames.TestCase1);
                MessageBox.Show(testing);

            }
        }
    }
}
