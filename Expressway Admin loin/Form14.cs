﻿using Microsoft.SqlServer.Server;
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
    public partial class Form14 : Form
      
    {
        private string DriversLicense;
        private int userId;
        string Violations;
        string EorE;
        string VehicleNumber;
        string PaymentMethod;
        int TotalFine;
        string PaymentStatus;
        public Form14(int UserId, string violations, string eorE, string vehicleNumber, string driverLicense, int totalFine)
        {
            InitializeComponent();
            userId = UserId;
            Violations = violations;
            VehicleNumber = vehicleNumber;
            EorE = eorE;
            DriversLicense = driverLicense;
            TotalFine = totalFine;
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string cardnumber = txtCNumber.Text;
            string cvc = txtCVC.Text;
            string expiredate = dateTimePicker1.Text;

            string message = $"Name: {name}\nCard Number: {cardnumber}\nCVV: {cvc}\nExpiration Date: {expiredate}";
            SqlInjectionYes();
            MessageBox.Show(message, "Details Enterd");

            ClearDetails();

            OpenNextPage();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCNumber.Text = "";
            txtCVC.Text = "";
            dateTimePicker1.Value = DateTime.Now; 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ClearDetails()
        {
           
            txtName.Text = "";
            txtCNumber.Text = "";
            txtCVC.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void OpenNextPage()
        {
            
            Form9 form9 = new Form9(userId);
            form9.Show();
            this.Close();
        }

        void SqlInjectionYes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\C# project group AB\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    PaymentStatus = "Payed By Card";
                    DateTime dateAndTime = DateTime.Now;
                    con.Open();
                    string query = "INSERT INTO Payment ([userId],license_number,[fine_cost],payment_status,date_time) VALUES (@userId,@DriversLicense,@TotalFine,@PaymentStatus, @DateAndTime);";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@DriversLicense", DriversLicense);
                        command.Parameters.AddWithValue("@TotalFine", TotalFine);
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                        command.Parameters.AddWithValue("@DateAndTime", dateAndTime);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("EMERGENCY !!. Supervisor will be there soon.", "Emergency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EMERGENCY!!,Supervisor will be there soon.", "Emergency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
