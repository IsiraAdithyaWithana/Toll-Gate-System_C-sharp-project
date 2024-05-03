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
using System.Windows.Forms.DataVisualization.Charting;

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
            chart1.ChartAreas[0].AxisX.Title = "Month";
            chart1.ChartAreas[0].AxisY.Title = "Accident Count";

            try
            {
                Dictionary<string, int> accidentCounts = GetAccidentCounts();
                AddSeriesToChart();
                BindDataToChart(accidentCounts);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private Dictionary<string, int> GetAccidentCounts()
        {
            Dictionary<string, int> accidentCounts = new Dictionary<string, int>();

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\balas\OneDrive\Desktop\C# project by isira\Expressway project C#\Expressway Admin loin\Database1.mdf"";Integrated Security=True"))
            {
                con.Open();
                string query = "SELECT date_time FROM accident";

                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime dateTime = Convert.ToDateTime(reader["date_time"]);
                    string monthYear = dateTime.ToString("MMM-yyyy");

                    if (!accidentCounts.ContainsKey(monthYear))
                    {
                        accidentCounts[monthYear] = 0;
                    }
                    accidentCounts[monthYear]++;
                }
            }

            return accidentCounts;
        }

        private void BindDataToChart(Dictionary<string, int> accidentCounts)
        {
            foreach (var entry in accidentCounts)
            {
                chart1.Series["AccidentCount"].Points.AddXY(entry.Key, entry.Value);
            }
        }

        private void AddSeriesToChart()
        {
            Series series = new Series("AccidentCount");
            series.ChartType = SeriesChartType.Column; 
            chart1.Series.Add(series);
        }
    }
}
