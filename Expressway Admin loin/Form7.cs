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
        public Form7(int id, string EntranceOrExit)
        {
            InitializeComponent();
            userId = id;
            EorE = EntranceOrExit;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cxbSelectAll.Checked)
            {
                MessageBox.Show("Are you sure?");

                cxbLights.Checked = true;
                cxbbrakes.Checked = true;
                cxbTires.Checked = true;
                cxbWindandMirrors.Checked = true;
                cxbDashboardIndi.Checked = true;
                cxbSeatBelts.Checked = true;

            }
            Form8 form8 = new Form8();
            this.Hide();
            form8.ShowDialog();
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
