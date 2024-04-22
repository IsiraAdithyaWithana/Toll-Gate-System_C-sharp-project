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

namespace Expressway_Admin_loin
{
    public partial class Form6 : Form
    {
        private int userId;
        private string EorE;
        string VehicleType;
        string VehicleNumber;
        string VehicleCondition;
        string Status;
        public Form6(int id, string EntranceOrExit, string vehicleType, string vehicleNumber, string vehicleCondition)
        {
            InitializeComponent();
            userId = id;
            EorE = EntranceOrExit;
            VehicleType = vehicleType;
            VehicleNumber = vehicleNumber;
            VehicleCondition = vehicleCondition;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioClear.Checked)
            {
                Status = "Clear";
            }
            else if (radioCheckFromExit.Checked)
            {
                Status = "Check from the exit";
            }
            else
            {
                MessageBox.Show("Please select Clear or check from the exit");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Status))
            {
                MessageBox.Show("Please print the bill before continue");
                return;
            }
            
            try
            {
                using(SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();
                    string query = "INSERT INTO Vehicle (vehicle_number, vehicle_type, conditions, status) VALUES (@VehicleNumber, @VehicleType, @VehicleCondition, @Status);";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber);
                        command.Parameters.AddWithValue("@VehicleType", VehicleType);
                        command.Parameters.AddWithValue("@VehicleCondition", VehicleCondition);
                        command.Parameters.AddWithValue("@Status", Status);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Completed");

                        Form4 form4 = new Form4(userId);
                        form4.Show();
                        this.Hide();
                    }
                }
            }
            catch(Exception ex)
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

        private void btnBK_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
