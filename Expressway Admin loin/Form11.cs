using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expressway_Admin_loin
{
    public partial class Form11 : Form
    {
        private string DriversLicense;
        private int userId;
        string Violations;
        string EorE;
        string VehicleNumber;
        int TotalFine = 0;

        public Form11(int UserId, string violations, string eorE, string vehicleNumber, string driverLicense)
        {
            InitializeComponent();
            userId = UserId;
            Violations = violations;
            EorE = eorE;
            VehicleNumber = vehicleNumber;
            DriversLicense = driverLicense;
        }
        private void Form11_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> checkboxNameMap = new Dictionary<int, string>
            {
                { 0, "checkLeftSideOvertake" },
                { 1, "checkSpeed" },
                { 4, "checkDrunkDriving" },
                { 5, "checkMobilePhones" },
                { 6, "checkInvalidLicense" },
                { 7, "checkNoise" },
                { 10, "checkSpecificClassVehicle" }
            };
            if (!string.IsNullOrEmpty(Violations))
            {
                string[] violationValues = Violations.Split(' ');

                foreach (string violation in violationValues)
                {
                    if (int.TryParse(violation, out int violationNumber))
                    {
                        if (checkboxNameMap.ContainsKey(violationNumber))
                        {
                            string checkboxName = checkboxNameMap[violationNumber];

                            Control[] foundControls = Controls.Find(checkboxName, true);

                            if (foundControls.Length > 0 && foundControls[0] is CheckBox)
                            {
                                CheckBox checkBox = (CheckBox)foundControls[0];

                                checkBox.Checked = true;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInvalidLicense.Checked)
            {
                TotalFine += 1000;
            }
            if (checkDrunkDriving.Checked)
            {
                TotalFine += 25000;
            }
            if (checkLeftSideOvertake.Checked)
            {
                TotalFine += 1000;
            }
            if (checkSpeed.Checked)
            {
                TotalFine += 3000;
            }
            if (checkMobilePhones.Checked)
            {
                TotalFine += 1000;
            }
            if (checkNoise.Checked)
            {
                TotalFine += 1000;
            }
            if (checkSpecificClassVehicle.Checked)
            {
                TotalFine += 1000;
            }
            Form12 form12 = new Form12(userId, Violations, EorE, VehicleNumber, DriversLicense, TotalFine);
            form12.Show();
            this.Hide();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}