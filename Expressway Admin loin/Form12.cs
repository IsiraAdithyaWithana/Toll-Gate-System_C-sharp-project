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
    public partial class Form12 : Form
    {
        private int userId;
        private string EorE = "Payment";
        int pageNum = 12;
        string PaymentMethod;
        public Form12(int id)

        {
            InitializeComponent();
            userId = id;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chcashpayment.Checked)
            {
                chcashpayment.Checked = false;
            }
            else if (chcardpayment.Checked)
            {
                chcardpayment.Checked = false;
            }
            else if (chonlinetransfer.Checked)
            {
                chonlinetransfer.Checked = false;
            }
            else
            {
                ch14days.Checked = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chcashpayment.Checked)
            {
                string Message = "Print the penalty sheet";
                string title = "Conformation";
                DialogResult result = MessageBox.Show(Message, title, MessageBoxButtons.YesNo);


            }
            else if (chcardpayment.Checked)
            {
                Form14 form14 = new Form14();
                this.Hide();
                form14.Show();
            }
            else if (chonlinetransfer.Checked)
            {
                Form22 form22 = new Form22();
                this.Hide();
                form22.Show();
            }
            else
            {
                string Message = "Print the penalty sheet";
                string title = "Conformation";
                DialogResult result = MessageBox.Show(Message, title, MessageBoxButtons.YesNo);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
    }
