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
    public partial class PerformanceForm : Form
    {
        public PerformanceForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PerformanceForm_Load(object sender, EventArgs e)
        {
            totalCostLabel.Text = Form1.simSys.PerformanceMeasures.TotalCost.ToString();
            totalLostLabel.Text = Form1.simSys.PerformanceMeasures.TotalLostProfit.ToString();
            netProfitLabel.Text = Form1.simSys.PerformanceMeasures.TotalSalesProfit.ToString();
            totalSalvageLabel.Text = Form1.simSys.PerformanceMeasures.TotalScrapProfit.ToString();
            netProfitLabel.Text = Form1.simSys.PerformanceMeasures.TotalNetProfit.ToString();
            excessDemandLabel.Text = Form1.simSys.PerformanceMeasures.DaysWithMoreDemand.ToString();
            unsoldPapersLabel.Text = Form1.simSys.PerformanceMeasures.DaysWithUnsoldPapers.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
