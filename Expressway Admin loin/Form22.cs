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
        string EorE;
        int TotalFine;
        string PaymentStatus;
        public Form22(int userid, string driversLicense, int totalFine, string eorE)
        {
            InitializeComponent();
            userId = userid;
            DriversLicense = driversLicense;
            TotalFine = totalFine;
            EorE = eorE;
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
            if(string.IsNullOrEmpty(ReferenceNumber))
            {
                MessageBox.Show("Please Enter the Reference Number");
                return;
            }
            else
            {
                SqlInjectionOnline(ReferenceNumber);
            }
        }

        void SqlInjectionOnline(string rN)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    PaymentStatus = "Payed";
                    con.Open();
                    string query = "INSERT INTO Payment ([userId],license_number,[fine_cost],payment_status,online_reference) VALUES (@userId,@DriversLicense,@TotalFine,@PaymentStatus,@rN);";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@DriversLicense", DriversLicense);
                        command.Parameters.AddWithValue("@TotalFine", TotalFine);
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                        command.Parameters.AddWithValue("@rN", rN);

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("The reference number was inserted");
                    Form9 form9 = new Form9(userId);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message);
            }
        }
    }
}
