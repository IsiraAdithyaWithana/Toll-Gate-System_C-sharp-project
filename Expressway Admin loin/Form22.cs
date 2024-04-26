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
    public partial class Form22 : Form
    {
        string ReferenceNumber;
        private string DriversLicense;
        private int userId;
        string Violations;
        string EorE;
        string VehicleNumber;
        string PaymentMethod;
        int TotalFine;
        string PaymentStatus;
        public Form22()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void Form22_Load(object sender, EventArgs e)
        {

        }

        private void VehicalTypeB_Click(object sender, EventArgs e)
        {
            ReferenceNumber = txtReferenceNumber.Text;
            SqlInjectionOnline();
        }

        void SqlInjectionOnline()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    PaymentStatus = "Payed";
                    con.Open();
                    string query = "INSERT INTO Payment ([userId],license_number,[fine_cost],payment_status,online_reference) VALUES (@userId,@DriversLicense,@TotalFine,@PaymentStatus,@ReferenceNumber);";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@DriversLicense", DriversLicense);
                        command.Parameters.AddWithValue("@TotalFine", TotalFine);
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                        command.Parameters.AddWithValue("@ReferenceNumber", ReferenceNumber);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message);
            }
        }
    }
}
