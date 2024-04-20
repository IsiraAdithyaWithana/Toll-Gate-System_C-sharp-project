using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form20(int id, string EntranceOrExit)
        {
            InitializeComponent();
            userId = id;
            EorE = EntranceOrExit;
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
    }
}
