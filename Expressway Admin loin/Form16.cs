﻿using System;
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
    public partial class Form16 : Form
    {
        private int userId;

        public Form16(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(userId);
            form3.Show();
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form17 form17 = new Form17(userId);
            form17.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form19 form19 = new Form19(userId);
            form19.Show();
            this.Close();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EMERGENCY !!. Supervisor will be there soon.", "Emergency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("EMERGENCY!!,Supervisor will be there soon.", "Emergency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
