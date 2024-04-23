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
    public partial class Form8 : Form
    {
        private int userId;
        private string EorE;
        string VehicleType;
        string VehicleNumber;
        string VehicleCondition;
        string Status;
        string Violations;
        public Form8(int id, string EntranceOrExit, string vehicleType, string vehicleNumber, string vehicleCondition)
        {
            InitializeComponent();
            userId = id;
            EorE = EntranceOrExit;
            VehicleType = vehicleType;
            VehicleNumber = vehicleNumber;
            VehicleCondition = vehicleCondition;
        }

        

        private void selectall_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSelectAll.Checked)
            {
                MessageBox.Show("Are you sure?");

                checkLowSpeed.Checked = true;
                checkOverSpeed.Checked = true;
                checkSeatBelts.Checked = true;
                checkNoSignaling.Checked = true;
                checkDrunk.Checked = true;
                checkUsingMobile.Checked = true;
                checkDriverLicense.Checked = true;
                checkLittering.Checked = true;
                checkCollision.Checked = true;
                checkEmergencyParkingLane.Checked = true;
                checkLicenseForSpecific.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void butNext_Click(object sender, EventArgs e)
        {
            if (checkLowSpeed.Checked)
            {
                Violations += "0 ";
            }
            if (checkOverSpeed.Checked)
            {
                Violations += "1 ";
            }
            if (checkSeatBelts.Checked)
            {
                Violations += "2 ";
            }
            if (checkNoSignaling.Checked)
            {
                Violations += "3 ";
            }
            if (checkDrunk.Checked)
            {
                Violations += "4 ";
            }
            if (checkUsingMobile.Checked)
            {
                Violations += "5 ";
            }
            if (checkDriverLicense.Checked)
            {
                Violations += "6 ";
            }
            if (checkLittering.Checked)
            {
                Violations += "7 ";
            }
            if (checkCollision.Checked)
            {
                Violations += "8 ";
            }
            if (checkEmergencyParkingLane.Checked)
            {
                Violations += "9 ";
            }
            if (checkLicenseForSpecific.Checked)
            {
                Violations += "10 ";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();
                    string query = "INSERT INTO ex_violation (vehicle_number,violations) VALUES (@VehicleNumber,@Violations);";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber);
                        command.Parameters.AddWithValue("@Violations", Violations);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Completed");

                        Form4 form4 = new Form4(userId);
                        form4.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message);
            }
        }
    }
}
