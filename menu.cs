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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {

        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_login login = new admin_login();
            login.Show();
        }
    }
}
