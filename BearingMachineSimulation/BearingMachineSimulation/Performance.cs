using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BearingMachineSimulation
{
    public partial class Performance : Form
    {
        public Performance()
        {
            InitializeComponent();
        }

        private void Performance_Load(object sender, EventArgs e)
        {
            costOfBearingLabel.Text = Form1.simSys.CurrentPerformanceMeasures.BearingCost.ToString();
            costOfDowntimeLabel.Text = Form1.simSys.CurrentPerformanceMeasures.DowntimeCost.ToString();
            costOfDelayTimeLabel.Text = Form1.simSys.CurrentPerformanceMeasures.DelayCost.ToString();
            costOfRepairpersonLabel.Text = Form1.simSys.CurrentPerformanceMeasures.RepairPersonCost.ToString();
            totalCostLabel.Text = Form1.simSys.CurrentPerformanceMeasures.TotalCost.ToString();

            costOfBearingProposedLabel.Text = Form1.simSys.ProposedPerformanceMeasures.BearingCost.ToString();
            costOfDowntimeProposedLabel.Text = Form1.simSys.ProposedPerformanceMeasures.DowntimeCost.ToString();
            costOfDelayTimeProposedLabel.Text = Form1.simSys.ProposedPerformanceMeasures.DelayCost.ToString();
            costOfRepairpersonProposedLabel.Text = Form1.simSys.ProposedPerformanceMeasures.RepairPersonCost.ToString();
            totalCostProposedLabel.Text = Form1.simSys.ProposedPerformanceMeasures.TotalCost.ToString();

            if (Form1.simSys.ProposedPerformanceMeasures.TotalCost < Form1.simSys.CurrentPerformanceMeasures.TotalCost)
                label3.Text = "Proposed Policy is better!";
            else
                label3.Text = "Current Polisy is better!!";
        }
    }
}
