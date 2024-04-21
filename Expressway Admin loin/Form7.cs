using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expressway_Admin_loin
{
    public partial class Form7 : Form
    {
        private int userId;
        private string EorE;
        string VehicleType;
        string VehicleNumber;
        public Form7(int id, string EntranceOrExit, string vehicleType, string vehicleNumber)
        {
            InitializeComponent();
            userId = id;
            EorE = EntranceOrExit;
            VehicleType = vehicleType;
            VehicleNumber = vehicleNumber;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSelectAll.Checked)
            {
                MessageBox.Show("Are you sure?");

                checkLights.Checked = true;
                checkBrakes.Checked = true;
                checkTires.Checked = true;
                checkWindAndMirrors.Checked = true;
                checkDashIndicators.Checked = true;
                checkSeatBelts.Checked = true;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
