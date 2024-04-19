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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\source\repos\Toll-Gate-System_C-sharp-project\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();

                    string UserName = txtUsername.Text;
                    string Password = txtPassword.Text;

                    string query = $"SELECT password, user_position FROM [User] WHERE username = '{UserName}';";

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
                                    Form3 form3 = new Form3();
                                    form3.Show();
                                    this.Hide();
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
                                    Form16 form16 = new Form16();
                                    form16.Show();
                                    this.Hide();
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
    }
}
