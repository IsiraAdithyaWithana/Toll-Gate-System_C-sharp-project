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
    public partial class Form9 : Form
    {
        readonly string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ASUS\source\Repos\Toll-Gate-System_C-sharp-project\Expressway Admin loin\Database1.mdf"";Integrated Security=True";
        public Form9()
        {
            InitializeComponent();
        }

        private void butDone_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ASUS\source\Repos\Toll-Gate-System_C-sharp-project\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                    {
                        connection.Open();

                        string query = "SELECT YourColumnName FROM YourTable WHERE YourCondition";

                        // Create a command to execute the query
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Execute the command and get the result
                            string result = command.ExecuteScalar()?.ToString();

                            // Update the label with the retrieved data
                            lblStatus.Text = result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
