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
    public partial class Form15 : Form
    {
        private string DriversLicense;
        private int userId;
        string Violations;
        string EorE;
        string VehicleNumber;


        public Form15(int UserId, string violations, string eorE, string vehicleNumber)
        {
            InitializeComponent();
            userId = UserId;
            Violations = violations;
            EorE = eorE;
            VehicleNumber = vehicleNumber;
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }

        private void btnNX_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\isira\Desktop\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    conn.Open();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void selectall_CheckedChanged(object sender, EventArgs e)
        {
            if(selectall.Checked)
            {

            }
        }
    }
}
