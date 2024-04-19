using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Expressway_Admin_loin
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGateNumber.Text))
            {
                MessageBox.Show("Please enter the gate number.");
                return; // Exit the event handler
            }
            if (string.IsNullOrEmpty(txtPoliceID.Text))
            {
                MessageBox.Show("Please enter the Police ID.");
                return; // Exit the event handler
            }







            if (radioEntrance.Checked)
            {
                Form4 form4 = new Form4();
                form4.Show();
                this.Hide();
            }
            else if (radioExit.Checked)
            {

                Form9 form9 = new Form9();
                form9.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select the gate.");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void txtGateNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPoliceID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
