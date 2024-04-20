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
        private int userId;
        public Form9(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void butDone_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\source\repos\]\Toll-Gate-System_C-sharp-project\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    connection.Open();
                    string vehicleNumber = txtVehicleNumber.Text;

                    string query = $"SELECT status FROM Vehicle WHERE vehicle_number='{vehicleNumber}';";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        string result = command.ExecuteScalar()?.ToString();

                        lblStatus.Text = result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void butNext_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form20 form20 = new Form20();
            form20.Show();
            this.Hide ();
        }
    }
}
