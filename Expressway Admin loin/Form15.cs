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
    public partial class Form15 : Form
    {
        private string DriversLicense;
        private string id;


        public Form15()
        {
            InitializeComponent();
            id = id;

        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }

        private void btnNX_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    conn.Open();
                    string DriversLicense = txtDL.Text;
                    string ViolationTypes = "";

                    foreach (CheckBox checkBox in this.Controls.OfType<CheckBox>())
                    {
                        if (checkBox.Checked)
                        {
                            ViolationTypes += checkBox.Text + ",";
                        }
                    }
                    String query = "INSERT INTO ex_violation ([id], driver_licence, violations) VALUES (@vehicle_number, @driver_license, @violations);";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@DriversLicense", DriversLicense);
                        command.Parameters.AddWithValue("@ViolationTypes", ViolationTypes);

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
    }
}
