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
    public partial class Form12 : Form
    {
        private string DriversLicense;
        private int userId;
        string Violations;
        string EorE;
        string VehicleNumber;
        string PaymentMethod;
        int TotalFine;
        string PaymentStatus;
        public Form12(int UserId, string violations, string eorE, string vehicleNumber, string driverLicense, int totalFine)
        {
            InitializeComponent();
            userId = UserId;
            Violations = violations;
            EorE = eorE;
            VehicleNumber = vehicleNumber;
            DriversLicense = driverLicense;
            TotalFine = totalFine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chcashpayment.Checked)
            {
                chcashpayment.Checked = false;
            }
            else if (chcardpayment.Checked)
            {
                chcardpayment.Checked = false;
            }
            else if (chonlinetransfer.Checked)
            {
                chonlinetransfer.Checked = false;
            }
            else
            {
                ch14days.Checked = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chcashpayment.Checked)
            {
                DialogResult result = MessageBox.Show("Did money get paid?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SqlInjectionYes();
                }
                else
                {
                    return;
                }
            }
            else if (chcardpayment.Checked)
            {
                Form14 form14 = new Form14();
                form14.ShowDialog();
            }
            else if (chonlinetransfer.Checked)
            {
                Form22 form22 = new Form22();
                form22.ShowDialog();
            }
            else if (ch14days.Checked)
            {
                SqlInjectionNo();
            }
        }

        void SqlInjectionYes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    PaymentStatus = "Payed";
                    con.Open();
                    string query = "INSERT INTO Payment ([userId],license_number,[fine_cost],payment_status) VALUES (@userId,@DriversLicense,@TotalFine,@PaymentStatus);";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@DriversLicense", DriversLicense);
                        command.Parameters.AddWithValue("@TotalFine", TotalFine);
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message);
            }
        }

        void SqlInjectionNo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    PaymentStatus = "Pending";
                    con.Open();
                    string query = "INSERT INTO Payment ([userId],license_number,[fine_cost],payment_status) VALUES (@userId,@DriversLicense,@TotalFine,@PaymentStatus);";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@DriversLicense", DriversLicense);
                        command.Parameters.AddWithValue("@TotalFine", TotalFine);
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11(userId, Violations, EorE, VehicleNumber, DriversLicense);
            form11.Show();
            this.Hide();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
    }
