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
    public partial class Form20 : Form
    {
        private int userId;
        private string EorE;
        int ReturnPage;
        public Form20(int id, string EntranceOrExit,int returnPage)
        {
            InitializeComponent();
            userId = id;
            EorE = EntranceOrExit;
            ReturnPage = returnPage;
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EorE == "entrance")
            {
                Form4 form4 = new Form4(userId);
                form4.Show();
                this.Hide();
            }
            else
            {
                Form9 form9 = new Form9(userId);
                form9.Show();
                this.Hide();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    conn.Open();
                    string AccidentSite = txtAccidentSite.Text;
                    string VehicleType = "";
                    DateTime dateAndTime = DateTime.Now;

                    foreach (CheckBox checkBox in this.Controls.OfType<CheckBox>())
                    {
                        if (checkBox.Checked)
                        {
                            VehicleType += checkBox.Text + ",";
                        }
                    }

                    string query = "INSERT INTO accident ([user], nearest_point, vehicle_type, [date_time]) VALUES (@User, @Accidentsite, @Vehicletype, @DateAndTime);";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@User", userId);
                        command.Parameters.AddWithValue("@Accidentsite", AccidentSite);
                        command.Parameters.AddWithValue("@Vehicletype", VehicleType);
                        command.Parameters.AddWithValue("@DateAndTime", dateAndTime);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string formClassName = $"Form{ReturnPage}";

                    Type formType = Type.GetType("Expressway_Admin_loin." + formClassName);

                    if(ReturnPage == 4)
                    {
                        Form4 form4 = new Form4(userId);
                        form4.Show();
                        this.Hide();
                    }
                    else if(ReturnPage == 9)
                    {
                        Form9 form9 = new Form9(userId);
                        form9.Show();
                        this.Hide();
                    }

                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtAccident_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
