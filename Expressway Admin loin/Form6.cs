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
    public partial class Form6 : Form
    {
        private int userId;
        private string EorE;
        string VehicleType;
        string VehicleNumber;
        string VehicleCondition;
        public Form6(int id, string EntranceOrExit, string vehicleType, string vehicleNumber, string vehicleCondition)
        {
            InitializeComponent();
            userId = id;
            EorE = EntranceOrExit;
            VehicleType = vehicleType;
            VehicleNumber = vehicleNumber;
            VehicleCondition = vehicleCondition;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                Form9 form9 = new Form9(9); 
                form9.Show(); 
                this.Hide();
            }
            else if (radioButton2.Checked)
            {
                Form9 form9 = new Form9(9);
                form9.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select Clear or check from the exit");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBK_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(4);
            form4.Show();
            this.Hide();
        }
    }
}
