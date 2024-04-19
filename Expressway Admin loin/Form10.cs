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
namespace Expressway_Admin_loin
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\DELL\OneDrive - NSBM\Desktop\NSBM\C#lab\Highway_project\Expressway Admin loin\Database1.mdf"";Integrated Security=True");

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
            int IDDL = int.Parse(txtDL.Text);
            bool selectAll = bool.Parse(selectall.Text);
            bool overSpeed = bool.Parse(overspeed.Text);
            bool lowSpeed = bool.Parse(lowspeed.Text);
            bool seatBelts = bool.Parse(seatbelts.Text);
            bool Signals = bool.Parse(signal.Text);
            bool Drugs = bool.Parse(drugs.Text);
            bool mobilePhone = bool.Parse(mobilephone.Text);
            bool invalidLicense = bool.Parse(invalidDL.Text);
            bool Littering = bool.Parse(littering.Text);
            bool collisionLC = bool.Parse(collision.Text);
            bool parkingLane = bool.Parse(parkinglane.Text);
            bool specificLicense = bool.Parse(specificDL.Text);

            string query = $"INSERT INTO Violations (Driver License,Select All,Low Speed/inner lane,Overspeed,Not using seat belts,Drunk driving,Using mobile phones,Invalid driver license,Littering the road,Collision during lane change,Misuse E.Parklane,Classless driver license) " +
                $"VALUES ({IDDL},'{selectAll}',{lowSpeed},{overSpeed},{seatBelts},{Signals},{Drugs},{mobilePhone},{invalidLicense},{Littering},{collisionLC},{parkingLane},{specificLicense});";
            
            SqlCommand cmd = new SqlCommand(query, con1);

        }
    }
}
