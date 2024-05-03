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
    public partial class Form17 : Form
    {
        private int userId;
        public Form17(int UserId)
        {
            InitializeComponent();
            userId = UserId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fine_report button2 = new Fine_report();
            addUserControle(button2);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form17_Load(object sender, EventArgs e)
        {
            
        }

        private void addUserControle(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accident_report button1 = new Accident_report();
            addUserControle(button1); 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16(userId);
            form16.Show();
            this.Close();
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
    }

}
