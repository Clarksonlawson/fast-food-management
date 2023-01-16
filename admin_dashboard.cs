using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Year_Project
{
    public partial class admin_dashboard : Form
    {
        public admin_dashboard()
        {
            InitializeComponent();
        }

        private void admin_dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = "Hello " + globals.fullname + "!";
        }
    }
}
