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

        private int userId;
        public Form19(int id)
        {
            InitializeComponent();
            userId = id;
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
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\C# project by isira\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();

                    string query = @"
                        SELECT U.Id, U.Name, COUNT(P.userId) AS Fines
                        FROM [User] U
                        LEFT JOIN Payment P ON U.Id = P.userId
                        GROUP BY U.Id, U.Name
                        ORDER BY U.Id";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("EMERGENCY !!. Supervisor will be there soon.", "Emergency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("EMERGENCY!!,Supervisor will be there soon.", "Emergency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
