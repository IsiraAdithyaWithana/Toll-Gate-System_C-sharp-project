using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Expressway_Admin_loin
{
    public partial class Form3 : Form
    {
        private int userId;

        public Form3(int id)
        {
            InitializeComponent();
            userId = id;
        }

        public Form3()
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGateNumber.Text))
            {
                MessageBox.Show("Please enter the gate number.");
                return;
            }
            if (string.IsNullOrEmpty(txtPoliceID.Text))
            {
                MessageBox.Show("Please enter the Police ID.");
                return;
            }
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ASUS\source\Repos\Toll-Gate-System_C-sharp-project\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();
                    string gateNumber = txtGateNumber.Text;
                    string policeOfficer = txtPoliceID.Text;
                    DateTime dateAndTime = DateTime.Now;
                    int user = userId;

                    string query = "INSERT INTO gate_control (police_officer, [user], [time], gate_number) VALUES (@PoliceOfficer, @User, @DateAndTime, @GateNumber)";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@PoliceOfficer", policeOfficer);
                        command.Parameters.AddWithValue("@User", user);
                        command.Parameters.AddWithValue("@DateAndTime", dateAndTime);
                        command.Parameters.AddWithValue("@GateNumber", gateNumber);

                        command.ExecuteNonQuery();
                    }
                }
                if (radioEntrance.Checked)
                {
                    Form4 form4 = new Form4(userId);
                    form4.Show();
                    this.Hide();
                }
                else if (radioExit.Checked)
                {

                    Form9 form9 = new Form9(userId);
                    form9.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please select the gate.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void txtGateNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPoliceID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
