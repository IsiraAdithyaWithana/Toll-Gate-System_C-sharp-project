using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        string VehicleType;
        string VehicleNumber;
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
            VehicleNumber = txtVehicleNumber.Text;
            if (string.IsNullOrEmpty(txtVehicleNumber.Text))
            {
                MessageBox.Show("Please enter the Vehical number.");
                return;
            }
            if (radioB.Checked)
            {
                VehicleType = "B";
                Form7 form7 = new Form7(userId, EorE, VehicleType, VehicleNumber);
                form7.Show();
                this.Close();
            }
            else
            {
                if (radioC1.Checked)
                {
                    VehicleType = "C1";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Close();
                }
                else if (radioC.Checked)
                {
                    VehicleType = "C";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Hide();
                }
                else if (radioCE.Checked)
                {
                    VehicleType = "CE";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Close();
                }
                else if (radioD1.Checked)
                {
                    VehicleType = "D1";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Close();
                }
                else
                {
                    VehicleType = "D";
                    Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                    form5.Show();
                    this.Close();
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\C# project by isira\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con1.Open();
                    string query1 = $"SELECT user_position FROM [User] WHERE id = '{userId}';";
                    using (SqlCommand cmd = new SqlCommand(query1, con1))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string userPosition = reader["user_position"].ToString();
                            if (userPosition == "admin")
                            {
                                btnMenu.Visible = true;
                            }
                            else
                            {
                                btnMenu.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(userId);
            form3.Show();
            this.Close();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form20 form20 = new Form20(userId,EorE, pageNum);
            form20.Show();
            this.Close();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EMERGENCY!!,Supervisor will be there soon.", "Emergency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
