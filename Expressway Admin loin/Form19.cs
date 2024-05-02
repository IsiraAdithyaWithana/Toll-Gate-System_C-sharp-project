using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Expressway_Admin_loin
{
    public partial class Form19 : Form
    {
        private string connectionString = ("@Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\balas\\OneDrive\\Desktop\\Expressway project C#\\Expressway Admin loin\\Database1.mdf\";Integrated Security=True"))
        public Form19()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form18 form18 = new Form18();
            form18.ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form19_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
