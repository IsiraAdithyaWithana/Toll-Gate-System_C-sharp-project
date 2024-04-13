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
        public Form5()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked) 
            {
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;

            }
            else
            {
                checkBox2.Checked= false;
                checkBox3.Checked= false;
                checkBox4.Checked= false;
                checkBox5.Checked= false;
                checkBox6.Checked= false;
                checkBox7.Checked= false;
                checkBox8.Checked= false;
                checkBox9.Checked= false;

            }
        }


    }
}
