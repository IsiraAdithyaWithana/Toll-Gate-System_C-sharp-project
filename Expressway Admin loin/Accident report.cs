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
    public partial class Accident_report : UserControl
    {
        public Accident_report()
        {
            InitializeComponent();
        }

        private void Accident_report_Load(object sender, EventArgs e)
        {
            

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\Expressway Project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
                {
                    con.Open();

                    string query = "SELECT accident (user ,[nearest_point],[vehicle_type],date_time) FROM (@User, @NerestPoint, @VehicleType, @DateTime)";
                    DataSet dataSet = new DataSet();

                    adapter.Fill(dataSet, "accident");

                    chart1.DataSource = dataSet.Tables["accident"];
                    chart1.Series[""];
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
