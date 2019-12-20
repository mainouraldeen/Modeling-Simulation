using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySimulation
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            EndingInventoryAverage.Text = Form1.simSys.PerformanceMeasures.EndingInventoryAverage.ToString();
            ShortageQuantityAverage.Text = Form1.simSys.PerformanceMeasures.ShortageQuantityAverage.ToString();

        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }
    }
}
