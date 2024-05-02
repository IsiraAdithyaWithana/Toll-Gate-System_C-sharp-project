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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string UserName;
        private string Password;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();

                    UserName = txtUsername.Text;
                    Password = txtPassword.Text;

                    string query = $"SELECT password, user_position, Id FROM [User] WHERE username = '{UserName}';";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string dbPassword = reader["password"].ToString();
                            string userPosition = reader["user_position"].ToString();

                            if (userPosition == "user")
                            {
                                if (dbPassword == Password)
                                {
                                    int id = Convert.ToInt32(reader["Id"]);
                                    Form3 form3 = new Form3(id);
                                    form3.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Unsuccessful data entry. Please check your Password again");
                                }
                            }
                            else
                            {
                                if (dbPassword == Password)
                                {
                                    int id = Convert.ToInt32(reader["Id"]);
                                    Form16 form16 = new Form16(id);
                                    form16.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Ünsuccessful data entry. Please check your Password again");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found. Please check your username again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured: " + ex.Message);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
