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
        string VehicleCondition;
        int PageNumber = 7;
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
                string Message = "Are you sure?";
                string title = "Conformation";
                DialogResult result = MessageBox.Show(Message, title, MessageBoxButtons.YesNo);
                checkLights.Checked = true;
                checkBrakes.Checked = true;
                checkTires.Checked = true;
                checkWindAndMirrors.Checked = true;
                checkDashIndicators.Checked = true;
                checkSeatBelts.Checked = true;
            }
            else
            {
                checkLights.Checked = false;
                checkBrakes.Checked = false;
                checkTires.Checked = false;
                checkWindAndMirrors.Checked = false;
                checkDashIndicators.Checked = false;
                checkSeatBelts.Checked = false;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(userId);
            form4.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkLights.Checked)
            {
                VehicleCondition += "8 ";
            }
            if (checkBrakes.Checked)
            {
                VehicleCondition += "9 ";
            }
            if (checkTires.Checked)
            {
                VehicleCondition += "10 ";
            }
            if (checkWindAndMirrors.Checked)
            {
                VehicleCondition += "11 ";
            }
            if (checkDashIndicators.Checked)
            {
                VehicleCondition += "12 ";
            }
            if (checkSeatBelts.Checked)
            {
                VehicleCondition += "13 ";
            }
            Form6 form6 = new Form6(userId, EorE, VehicleType, VehicleNumber, VehicleCondition, PageNumber);
            form6.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("EMERGENCY !!. Supervisor will be there soon.", "Emergency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EMERGENCY!!,Supervisor will be there soon.", "Emergency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
