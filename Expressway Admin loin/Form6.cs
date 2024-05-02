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
        int PageNumber;
        public Form6(int id, string EntranceOrExit, string vehicleType, string vehicleNumber, string vehicleCondition, int pageNumber)
        {
            InitializeComponent();
            userId = id;
            EorE = EntranceOrExit;
            VehicleType = vehicleType;
            VehicleNumber = vehicleNumber;
            VehicleCondition = vehicleCondition;
            PageNumber = pageNumber;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioClear.Checked)
            {
                Status = "Clear";
                MessageBox.Show("Ticket is printed");
            }
            else if (radioCheckFromExit.Checked)
            {
                Status = "Check from the exit";
                MessageBox.Show("Ticket is printed");
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
                MessageBox.Show("Please print the ticket before continue");
                return;
            }
            
            try
            {
                using(SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();
                    string query = "INSERT INTO Vehicle (vehicle_number, vehicle_type, conditions, status, [user]) VALUES (@VehicleNumber, @VehicleType, @VehicleCondition, @Status, @userId);";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber);
                        command.Parameters.AddWithValue("@VehicleType", VehicleType);
                        command.Parameters.AddWithValue("@VehicleCondition", VehicleCondition);
                        command.Parameters.AddWithValue("@Status", Status);
                        command.Parameters.AddWithValue("@userId", userId);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Completed");

                        Form8 form8 = new Form8(userId,EorE,VehicleType,VehicleNumber,VehicleCondition);
                        form8.Show();
                        this.Close();
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
            if (PageNumber == 7)
            {
                Form7 form7 = new Form7(userId,EorE,VehicleType,VehicleNumber);
                form7.Show();
                this.Close();
            }
            else
            {
                Form5 form5 = new Form5(userId, EorE, VehicleType, VehicleNumber);
                form5.Show();
                this.Close();
            }
        }

        
    }
}
