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
        private string EorE = "exit";
        int pageNum = 9;
        string VehicleNumber = "";
        public Form9(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void butDone_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    connection.Open();
                    VehicleNumber = txtVehicleNumber.Text;

                    string query = $"SELECT status FROM Vehicle WHERE vehicle_number='{VehicleNumber}';";

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
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();
                    string query = "SELECT violations FROM ex_violation WHERE vehicle_number = @VehicleNumber";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@VehicleNumber", VehicleNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string violations = reader["violations"].ToString();
                                if (string.IsNullOrEmpty(violations))
                                {
                                    DeleteData();
                                }
                                else
                                {
                                    MessageBox.Show("Alert: One or more violations are found");
                                    Form15 form15 = new Form15(userId, violations, EorE, VehicleNumber);
                                    form15.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No record found for the specified vehicle number.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void DeleteData()
        {

            try
            {
                using(SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();
                    string deleteQuery = "DELETE FROM ex_violation WHERE vehicle_number = @VehicleNumber";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, con))
                    {
                        deleteCommand.Parameters.AddWithValue("@VehicleNumber", VehicleNumber);
                        int rowsAffected = deleteCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("No violations found. The record has been deleted.");
                        }
                        else
                        {
                            MessageBox.Show("No violations found, but the record was not deleted.");
                        }
                    }
                    lblStatus.Text = ".............................";
                    txtVehicleNumber.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form20 form20 = new Form20(userId,EorE,pageNum);
            form20.Show();
            this.Hide ();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con1.Open();
                    string query1 = $"SELECT user_position FROM [User] WHERE id = '{userId}';";
                    using (SqlCommand cmd = new SqlCommand(query1, con1))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string userPosition = reader["user_position"].ToString();
                            if (userPosition == "admin")
                            {
                                btnMenu.Visible = true;
                            }
                            else
                            {
                                btnMenu.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16(userId);
            form16.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }
    }
}
