using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expressway_Admin_loin
{

    public partial class Form4 : Form
    {
        private int userId;
        private string EorE = "entrance";
        int pageNum = 4;
        string VehicleType;
        string VehicleNumber;
        public Form4(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VehicleNumber = txtVehicleNumber.Text;
            if (string.IsNullOrEmpty(txtVehicleNumber.Text))
            {
                MessageBox.Show("Please enter the Vehical number.");
                return;
            }
            if (radioB.Checked)
            {
                VehicleType = "B";
                Form7 form7 = new Form7(userId, EorE, VehicleType, VehicleNumber);
                form7.Show();
                this.Hide();
            }
            else
            {
                if (radioC1.Checked)
                {
                    VehicleType = "C1";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Hide();
                }
                else if (radioC.Checked)
                {
                    VehicleType = "C";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Hide();
                }
                else if (radioCE.Checked)
                {
                    VehicleType = "CE";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Hide();
                }
                else if (radioD1.Checked)
                {
                    VehicleType = "D1";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Hide();
                }
                else
                {
                    VehicleType = "D";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Hide();
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(userId);
            form3.Show();
            this.Hide();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form20 form20 = new Form20(userId,EorE, pageNum);
            form20.Show();
            this.Hide();
        }
    }
}
