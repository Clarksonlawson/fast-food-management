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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2ProgressBar1.Value +=1;
            if (guna2ProgressBar1.Value >= 100)
            {
                timer1.Stop();
                this.Hide();
                menu men = new menu();
                men.Show();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
