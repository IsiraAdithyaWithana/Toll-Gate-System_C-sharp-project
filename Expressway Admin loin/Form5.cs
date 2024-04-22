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
    public partial class Form5 : Form
    {
        private int userId;
        private string EorE;
        string VehicleType;
        string VehicleNumber;
        public Form5(int id, string EntranceOrExit, string vehicleType, string vehicleNumber)
        {
            InitializeComponent();
            userId = id;
            EorE = EntranceOrExit;
            VehicleType = vehicleType;
            VehicleNumber = vehicleNumber;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkSelectAll.Checked) 
            {
                checkHeadLight.Checked = true;
                checkSignalLight.Checked = true;
                checkBrakeLight.Checked = true;
                checkParkingLight.Checked = true;
                checkDimLight.Checked = true;
                checkLongVehicleBoard.Checked = true;
                checkWipers.Checked = true;
                checkConditions.Checked = true;

            }
            else
            {
                checkHeadLight.Checked= false;
                checkSignalLight.Checked= false;
                checkBrakeLight.Checked= false;
                checkParkingLight.Checked= false;
                checkDimLight.Checked= false;
                checkLongVehicleBoard.Checked= false;
                checkWipers.Checked= false;
                checkConditions.Checked= false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(userId);
            form4.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
