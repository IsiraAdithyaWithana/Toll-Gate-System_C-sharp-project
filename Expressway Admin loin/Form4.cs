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
            //MessageBox.Show(txtVehicalNum.Text);
            if (string.IsNullOrEmpty(txtVehicalNum.Text))
            {
                MessageBox.Show("Please enter the Vehical number.");
                return;
            }
            if (VehicalTypeB.Checked)
            {
                Form7 form7 = new Form7();
                form7.Show();
                return;
            }
          

            Form5 form5 = new Form5(userId);
            form5.Show();
            this.Hide();
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
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form20 form20 = new Form20(userId,EorE, pageNum);
            form20.Show();
            this.Hide();
        }
    }
}
