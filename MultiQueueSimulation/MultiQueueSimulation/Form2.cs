using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiQueueSimulation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            fillGirdViewColumns();
            fillGirdViewRows();
        }


        public void fillGirdViewColumns()
        {

            dataGridView1.Columns.Add("A", "   A \n Customer Number");
            dataGridView1.Columns.Add("B", "   B \n Random Digits For Arrival");
            dataGridView1.Columns.Add("C", "   C \n Time between arrivals");
            dataGridView1.Columns.Add("D", "   D \n Clock time of arrival");
            dataGridView1.Columns.Add("E", "   E \n Random Digits for service");
            char ch = 'F';
            //for b3dd el servers
            for (int i = 0; i < Form1.simSys.NumberOfServers; i++)
            {
                for (int j = 0; j < 3; j++)
                {
       
                    dataGridView1.Columns.Add(ch.ToString(), "   "+ch.ToString()+"\nTime Service begins");
                    ch = Convert.ToChar(ch + 1);
                    
                    dataGridView1.Columns.Add(ch.ToString(), "   "+ ch.ToString() + "\n Service time");
                    ch = Convert.ToChar(ch + 1);
            
                    dataGridView1.Columns.Add(ch.ToString(), "   "+ ch.ToString() + "\n Time service ends");
                    ch = Convert.ToChar(ch + 1);

                }
            }
            dataGridView1.Columns.Add(ch.ToString(), "   "+ ch.ToString() + "\n Time in Queue");

        }

        public void fillGirdViewRows()
        {
            /*
            for(int i=0;i<Form1.simSys.StoppingNumber;i++)
            {
                dataGridView1.Rows.Add(new object[] 
                { Form1.simSys.SimulationTable[i].CustomerNumber+1,
                Form1.simSys.SimulationTable[i].RandomInterArrival,
                Form1.simSys.SimulationTable[i].InterArrival,
                Form1.simSys.SimulationTable[i].ArrivalTime,
                Form1.simSys.SimulationTable[i].RandomService,
                });
            }
            */
            dataGridView1.DataSource = Form1.simSys.SimulationTable;
        }


        }
}
