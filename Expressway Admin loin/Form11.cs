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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ASUS\source\Repos\Toll-Gate-System_C-sharp-project\Expressway Admin loin\Database1.mdf"";Integrated Security=True");

        private void Form11_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> checkboxNameMap = new Dictionary<int, string>
            {
                { 0, "checkLeftSideOvertake" },
                { 1, "checkSpeed" },
                { 4, "checkDrunkDriving" },
                { 5, "checkMobilePhones" },
                { 6, "checkInvalidLicense" },
                { 7, "checkNoise" },
                { 10, "checkSpecificClassVehicle" }
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the connection
                connection.Open();

                // Loop through all checkboxes on the form
                foreach (CheckBox checkbox in this.Controls.OfType<CheckBox>())
                {
                    // If checkbox is checked, insert its value into database
                    if (checkbox.Checked)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO YourTable (ColumnName) VALUES (@Value)", connection);
                        cmd.Parameters.AddWithValue("@Value", checkbox.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
             
            
            catch
            {
               
                    Form12 form12 = new Form12(12);
                    form12.Show();
                    this.Hide();
                 
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}