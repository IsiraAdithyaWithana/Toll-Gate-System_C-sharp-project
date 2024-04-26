using System;
using System.Collections;
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
    public partial class Form15 : Form
    {
        private string DriversLicense;
        private int userId;
        string Violations;
        string EorE;
        string VehicleNumber;


        public Form15(int UserId, string violations, string eorE, string vehicleNumber)
        {
            InitializeComponent();
            userId = UserId;
            Violations = violations;
            EorE = eorE;
            VehicleNumber = vehicleNumber;

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\Expressway Project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();
                    string query = $"SELECT violations FROM ex_violation WHERE vehicle_number = '{VehicleNumber}';";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if(reader.Read())
                        {
                            Violations = reader["violations"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> checkboxNameMap = new Dictionary<int, string>
            {
                { 0, "lowspeed" },
                { 1, "overspeed" },
                { 2, "seatbelts" },
                { 3, "signal" },
                { 4, "drugs" },
                { 5, "mobilephone" },
                { 6, "invalidDL" },
                { 7, "littering" },
                { 8, "collision" },
                { 9,"parkinglane" },
                { 10, "specificDL" }
            };
            if (!string.IsNullOrEmpty(Violations))
            {
                string[] violationValues = Violations.Split(' ');

                foreach (string violation in violationValues)
                {
                    if (int.TryParse(violation, out int violationNumber))
                    {
                        if (checkboxNameMap.ContainsKey(violationNumber))
                        {
                            string checkboxName = checkboxNameMap[violationNumber];

                            Control[] foundControls = Controls.Find(checkboxName, true);

                            if (foundControls.Length > 0 && foundControls[0] is CheckBox)
                            {
                                CheckBox checkBox = (CheckBox)foundControls[0];

                                checkBox.Checked = true;
                            }
                        }
                    }
                }
            }
        }

        private void btnNX_Click(object sender, EventArgs e)
        {
            string drivingLicense = txtDrivingLicense.Text;
            if (string.IsNullOrEmpty(drivingLicense))
            {
                MessageBox.Show("Please enter the driving license number");
                return;
            }
            else
            {
                try
                {
                    DriversLicense = drivingLicense;
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\Expressway Project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                    {
                        con.Open();
                        string query1 = $"UPDATE ex_violation SET driver_license = '{DriversLicense}' WHERE vehicle_number = '{VehicleNumber}';";

                        using (SqlCommand command = new SqlCommand(query1, con))
                        {
                            command.ExecuteNonQuery();

                            MessageBox.Show("Completed");

                            Form11 form11 = new Form11(userId, Violations, EorE, VehicleNumber, DriversLicense);
                            form11.Show();
                            this.Hide();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);

                }
            }
        }

        private void selectall_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCL_Click(object sender, EventArgs e)
        {
            txtDrivingLicense.Text = "";
        }

        private void txtDrivingLicense_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
