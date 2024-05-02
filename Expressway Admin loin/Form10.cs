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
using System.Diagnostics;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Data.SqlTypes;
namespace Expressway_Admin_loin
{
    public partial class Form10 : Form
    {

        private string DriversLicense;
        private int userId;
        string Violations;
        string EorE;
        string VehicleNumber;

        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\Expressway Project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True");

        public Form10(int UserId, string violations, string eorE, string vehicleNumber)
        {
            InitializeComponent();

            userId = UserId;
            Violations = violations;
            EorE = eorE;
            VehicleNumber = vehicleNumber;

            try
            {
                
                 con1.Open();

                string query1 = $"SELECT violations FROM ex_violation WHERE vehicle_number = '{VehicleNumber}';";

                using (SqlCommand cmd1 = new SqlCommand(query1, con1))
                {
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        Violations = reader["violations"].ToString(); //check here
                    }
                }
                
                

            }

            catch (Exception ex)

            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        
    

        private void Form10_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectall_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox && control.Name != "selectall")
                {
                    ((CheckBox)control).Checked = selectall.Checked;
                }
            }
        }

        private void btnNX_Click(object sender, EventArgs e)
        {

            string drivingLicense = txtDL.Text;
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
                    
                        con1.Open();

                        string query2 = $"UPDATE ex_violation SET driver_license = '{DriversLicense}' WHERE vehicle_number = '{VehicleNumber}'; ";

                        using (SqlCommand cmd1 = new SqlCommand(query2, con1))
                        {
                            cmd1.ExecuteNonQuery();

                            MessageBox.Show("Data Inserted Successfully");

                            Form11 form11 = new Form11(userId, Violations, EorE, VehicleNumber, DriversLicense);
                            form11.Show();
                            this.Hide();
                        }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);

                }
            }
            

        }

        private void btnCL_Click(object sender, EventArgs e)
        {
            txtDL.Clear();

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }


                /* int IDDL = int.Parse (txtDL.Text);

                 string query2 = $"DELETE Violations WHERE Driver License = {IDDL};";

                 SqlCommand cmd2 = new SqlCommand(query2, con1);

                 try
                 {
                     con1.Open();
                     cmd2.ExecuteNonQuery();
                     con1.Close();
                     MessageBox.Show("Data Cleared");
                 }
                 catch(Exception ex)
                 {
                     MessageBox.Show(ex.Message.ToString());
                 }
                */

            }

            MessageBox.Show("Data cleared successfully");
        }
    }
}
