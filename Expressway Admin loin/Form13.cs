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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Expressway_Admin_loin
{
    public partial class Form13 : Form
    {
        private string DriversLicense;
        private int userId;
        string Violations;
        string EorE;
        string VehicleNumber;
        string PaymentMethod;
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }
        private string UserName;
        private string Password;

        

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                    {
                        con.Open();
                        UserName = txtusername.Text;
                        Password = txtpassword.Text;

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
                                        Form12 form12 = new Form12(userId, Violations, EorE, VehicleNumber, DriversLicense);
                                        form12.Show();
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
                                        int id = Convert.ToInt32(reader["Id"]);
                                        Form16 form16 = new Form16(id);
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
        }
    }
}
