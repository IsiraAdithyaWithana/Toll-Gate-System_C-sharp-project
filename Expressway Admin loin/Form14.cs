using Microsoft.SqlServer.Server;
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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string cardnumber = txtCNumber.Text;
            string cvc = txtCVC.Text;
            string expiredate = dateTimePicker1.Text;

            string message = $"Name: {name}\nCard Number: {cardnumber}\nCVV: {cvc}\nExpiration Date: {expiredate}";
            MessageBox.Show(message, "Details Enterd");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCNumber.Text = "";
            txtCVC.Text = "";
            dateTimePicker1.Value = DateTime.Now; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ticket is printed");

            ClearDetails();
        }
    }
}
