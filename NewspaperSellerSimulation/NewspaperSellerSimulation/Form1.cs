using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;
using System.IO;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PictureBox pb1 = new PictureBox();
            pb1.ImageLocation = "simulation.png";
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        public static SimulationSystem simSys = new SimulationSystem();

        public void fillSimSysObj(string[] sysData)
        {
            simSys.NumOfNewspapers = Convert.ToInt32(sysData[1]);
            simSys.NumOfRecords = Convert.ToInt32(sysData[4]);
            simSys.PurchasePrice = Convert.ToDecimal(sysData[7]);
            simSys.ScrapPrice = Convert.ToDecimal(sysData[10]);
            simSys.SellingPrice = Convert.ToDecimal(sysData[13]);

            //DayTypeDistributionTable
            string[] Day_line = sysData[16].Split(new string[] { ", " }, StringSplitOptions.None);
            for (int j = 0; j < 3; j++)
            {
                DayTypeDistribution dayTypeDistributionRow = new DayTypeDistribution();
                if (j == 0) { dayTypeDistributionRow.DayType = Enums.DayType.Good; }
                else if (j == 1) { dayTypeDistributionRow.DayType = Enums.DayType.Fair; }
                else if (j == 2) { dayTypeDistributionRow.DayType = Enums.DayType.Poor; }

                dayTypeDistributionRow.Probability = Convert.ToDecimal(Day_line[j]);
                simSys.DayTypeDistributions.Add(dayTypeDistributionRow);
                 //lsaaa
            }

            int i = 19;
            while (i < sysData.Count() )
            {
                string[] Demand_line = sysData[i].Split(new string[] { ", " }, StringSplitOptions.None);
                DemandDistribution demandDistributionRow = new DemandDistribution();
                demandDistributionRow.Demand =Convert.ToInt32(Demand_line[0]);
                for (int j = 1; j <= 3; j++)
                {
                    DayTypeDistribution dayTypeDistributionRow = new DayTypeDistribution();
                    if (j == 1) { dayTypeDistributionRow.DayType = Enums.DayType.Good; }
                    if (j == 2) { dayTypeDistributionRow.DayType = Enums.DayType.Fair; }
                    if (j == 3) { dayTypeDistributionRow.DayType = Enums.DayType.Poor; }
                    dayTypeDistributionRow.Probability = Convert.ToDecimal(Demand_line[j]);
                    demandDistributionRow.DayTypeDistributions.Add(dayTypeDistributionRow);
                }

                simSys.DemandDistributions.Add(demandDistributionRow);
                i++;
            }
        }

        public void ReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string[] fileData = File.ReadAllLines(fileName);

                fillSimSysObj(fileData);
                //MessageBox.Show("Done!!");
                fillTypeOfNewsdayTable();
                fillDemandDistribution();
                FillSimulationTable();
                calcPerformances();
                string testing = TestingManager.Test(simSys, Constants.FileNames.TestCase3);
                MessageBox.Show(testing);
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();               


            }
        }

        public void FillSimulationTable()
        {
            Random rand = new Random();
            for (int i=0; i< simSys.NumOfRecords;i++)
            {
                SimulationCase simRow = new SimulationCase();
                simRow.DayNo = i + 1;
                
                simRow.RandomNewsDayType = rand.Next(1, 101);//chech if 101 is included or not
                simRow.RandomDemand = rand.Next(1, 101);

                /////////////////////Day Type///////////////////////////////
                for (int j=0; j<simSys.DayTypeDistributions.Count();j++)
                {
                    if (simRow.RandomNewsDayType>=simSys.DayTypeDistributions[j].MinRange && simRow.RandomNewsDayType <= simSys.DayTypeDistributions[j].MaxRange)
                    {
                        simRow.NewsDayType = simSys.DayTypeDistributions[j].DayType;
                        break;
                    }
                }
                ///////////////////////Demand///////////////////////////////
                for (int j=0; j<simSys.DemandDistributions.Count();j++)
                {
                    int DaytypeListSize = simSys.DemandDistributions[j].DayTypeDistributions.Count();
                    for (int k=0; k<DaytypeListSize ;k++)
                    {
                        if (simRow.NewsDayType==simSys.DemandDistributions[j].DayTypeDistributions[k].DayType &&
                            simRow.RandomDemand >= simSys.DemandDistributions[j].DayTypeDistributions[k].MinRange &&
                            simRow.RandomDemand <= simSys.DemandDistributions[j].DayTypeDistributions[k].MaxRange)
                        {
                            simRow.Demand = simSys.DemandDistributions[j].Demand;
                            break;
                        }

                    }
                    
                }
                ////////////////////////Calculations///////////////////////////

                ///////////////////////Cost///////////////////////////////
                simRow.DailyCost = simSys.NumOfNewspapers * simSys.PurchasePrice;
                
                //////////////////////Sales Profit///////////////////////
                if (simRow.Demand <= simSys.NumOfNewspapers)
                    simRow.SalesProfit = simRow.Demand * simSys.SellingPrice;
                else
                    simRow.SalesProfit = simSys.NumOfNewspapers * simSys.SellingPrice;

                //////////////////////Lost//////////////////////////////
                if (simRow.Demand > simSys.NumOfNewspapers)
                    simRow.LostProfit = (simRow.Demand - simSys.NumOfNewspapers) * (simSys.SellingPrice - simSys.PurchasePrice);
                else
                    simRow.LostProfit = 0;

                ////////////////////////Scrap//////////////////////////////
                if (simRow.Demand < simSys.NumOfNewspapers)
                    simRow.ScrapProfit = (simSys.NumOfNewspapers - simRow.Demand) * simSys.ScrapPrice;
                else
                    simRow.ScrapProfit = 0;
                ////////////////////////////////////////////////////////////
                simRow.DailyNetProfit = (simRow.SalesProfit - simRow.DailyCost - simRow.LostProfit + simRow.ScrapProfit);

                simSys.SimulationTable.Add(simRow);
            }
        }
        public void fillTypeOfNewsdayTable()
        {
            simSys.DayTypeDistributions[0].CummProbability = simSys.DayTypeDistributions[0].Probability;
            simSys.DayTypeDistributions[0].MinRange = 1;
            simSys.DayTypeDistributions[0].MaxRange = Convert.ToInt32(simSys.DayTypeDistributions[0].Probability * 100);
            for (int i = 1; i < simSys.DayTypeDistributions.Count; i++)
            {
                simSys.DayTypeDistributions[i].CummProbability = simSys.DayTypeDistributions[i].Probability +
                    simSys.DayTypeDistributions[i - 1].CummProbability;
                simSys.DayTypeDistributions[i].MinRange = simSys.DayTypeDistributions[i - 1].MaxRange + 1;
                simSys.DayTypeDistributions[i].MaxRange = simSys.DayTypeDistributions[i - 1].MaxRange +
                    Convert.ToInt32(simSys.DayTypeDistributions[i].Probability * 100);

            }
        }

        public void fillDemandDistribution()
        {
            for (int k = 0; k < 3; k++)
            {
                simSys.DemandDistributions[0].DayTypeDistributions[k].CummProbability = simSys.DemandDistributions[0].DayTypeDistributions[k].Probability;
                simSys.DemandDistributions[0].DayTypeDistributions[k].MinRange = 1;
                simSys.DemandDistributions[0].DayTypeDistributions[k].MaxRange = Convert.ToInt32(simSys.DemandDistributions[0].DayTypeDistributions[k].Probability * 100);
            }
            for (int i = 1; i < simSys.DemandDistributions.Count; i++)
            {
                for (int j = 0; j < simSys.DemandDistributions[i].DayTypeDistributions.Count; j++)
                {
                    simSys.DemandDistributions[i].DayTypeDistributions[j].CummProbability = simSys.DemandDistributions[i].DayTypeDistributions[j].Probability +
                        simSys.DemandDistributions[i - 1].DayTypeDistributions[j].CummProbability;
                    simSys.DemandDistributions[i].DayTypeDistributions[j].MinRange = simSys.DemandDistributions[i - 1].DayTypeDistributions[j].MaxRange + 1;
                    simSys.DemandDistributions[i].DayTypeDistributions[j].MaxRange = simSys.DemandDistributions[i - 1].DayTypeDistributions[j].MaxRange +
                        Convert.ToInt32(simSys.DemandDistributions[i].DayTypeDistributions[j].Probability * 100);
                }

            }

        }

        public void calcPerformances()
        {
            decimal totalRevenue = 0, totalCost = 0, totalLostProfit = 0, totalSalvage = 0, NetProfit = 0;
            int excessDemandDays = 0, unsoldPapers = 0;
            for (int i = 0; i < simSys.NumOfRecords; i++)
            {
                totalRevenue += simSys.SimulationTable[i].SalesProfit;
                totalCost += simSys.PurchasePrice * simSys.NumOfNewspapers; // hal de hna wala bara el loop??
                totalLostProfit += simSys.SimulationTable[i].LostProfit;
                totalSalvage += simSys.SimulationTable[i].ScrapProfit;
                if (simSys.SimulationTable[i].LostProfit > 0)
                    excessDemandDays++;
                if (simSys.SimulationTable[i].ScrapProfit > 0)
                    unsoldPapers++;
                NetProfit += simSys.SimulationTable[i].DailyNetProfit;
            }

            PerformanceMeasures measures = new PerformanceMeasures();
            measures.DaysWithMoreDemand = excessDemandDays;
            measures.DaysWithUnsoldPapers = unsoldPapers;
            measures.TotalCost = totalCost;
            measures.TotalLostProfit = totalLostProfit;
            measures.TotalNetProfit = NetProfit;
            measures.TotalSalesProfit = totalRevenue;
            measures.TotalScrapProfit = totalSalvage;
            simSys.PerformanceMeasures = measures;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
