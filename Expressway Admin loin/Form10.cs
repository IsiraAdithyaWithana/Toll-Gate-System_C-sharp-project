using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;
using System.Linq.Expressions;
namespace Expressway_Admin_loin
{
    public partial class Form10 : Form
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\Expressway Project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True");

        public Form10()
        {

            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectall_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnNX_Click(object sender, EventArgs e)
        {

            try
            {



                con1.Open();

                int IDDL = int.Parse(txtDL.Text);
                bool selectAll = selectall.Checked;
                bool overSpeed = overspeed.Checked;
                bool lowSpeed = lowspeed.Checked;
                bool seatBelts = seatbelts.Checked;
                bool Signals = signal.Checked;
                bool Drugs = drugs.Checked;
                bool mobilePhone = mobilephone.Checked;
                bool invalidLicense = invalidDL.Checked;
                bool Littering = littering.Checked;
                bool collisionLC = collision.Checked;
                bool parkingLane = parkinglane.Checked;
                bool specificLicense = specificDL.Checked;

                foreach (Control control in this.Controls)
                {
                    if (control is CheckBox && ((CheckBox)control).Checked)
                    {

                        string query = $"INSERT INTO Violation (Id,Select All,Low Speed/inner lane,Overspeed,Not using seat belts,Drunk driving,Using mobile phones,Invalid driver license,Littering the road,Collision during lane change,Misuse E.Parklane,Classless driver license) " +
                    $"VALUES ({IDDL},'{selectAll}',{lowSpeed},{overSpeed},{seatBelts},{Signals},{Drugs},{mobilePhone},{invalidLicense},{Littering},{collisionLC},{parkingLane},{specificLicense});";


                        using (SqlCommand cmd = new SqlCommand(query, con1))
                        {
                            cmd.Parameters.AddWithValue("IDDL", txtDL);
                            cmd.Parameters.AddWithValue("selectAll", selectall.Checked);
                            cmd.Parameters.AddWithValue("overSpeed", overspeed.Checked);
                            cmd.Parameters.AddWithValue("lowspeed", lowspeed.Checked);
                            cmd.Parameters.AddWithValue("seatBelts", seatbelts.Checked);
                            cmd.Parameters.AddWithValue("Signals", signal.Checked);
                            cmd.Parameters.AddWithValue("Drugs", drugs.Checked);
                            cmd.Parameters.AddWithValue("mobilePhone", mobilephone.Checked);
                            cmd.Parameters.AddWithValue("invalidlicense", invalidDL.Checked);
                            cmd.Parameters.AddWithValue("Littering", littering.Checked);
                            cmd.Parameters.AddWithValue("collisionLC", collision.Checked);
                            cmd.Parameters.AddWithValue("parkingLane", parkinglane.Checked);
                            cmd.Parameters.AddWithValue("specificLicese", specificDL.Checked);



                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            

            MessageBox.Show("Data saved Successfully!"); 
            
            }

        
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }


            /*try
            {
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
                MessageBox.Show("Violations selected Successfully!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
           
           



        }

        private void btnCL_Click(object sender, EventArgs e)
        {
           /* int IDDL = int.Parse (txtDL.Text);

            string query2 = $"DELETE Violations WHERE Driver License = {IDDL};";

            SqlCommand cmd2 = new SqlCommand(query2, con1);

            try
            {
                con1.Open();
                cmd2.ExecuteNonQuery();
                con1.Close();
                MessageBox.Show("Data Cleared");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           */

        }
    }
}
