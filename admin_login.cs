using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Final_Year_Project
{
    public partial class admin_login : Form
    {
        public admin_login()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void admin_login_Load(object sender, EventArgs e)
        {
           
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            //Form form = new Form();
            //Thread t1 = new Thread((
            //  using (Modal modal = new )
                  

            //    ));
            connection.con.Open();
            globals.email = emailBox.Text;
            globals.password = passwordBox.Text;
            if (!check_details(globals.email, globals.password))
            {
                MessageBox.Show("A User with this email " + globals.email + " was not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (DataRow row in globals.table.Rows)
                {
                    globals.fullname = row["fullname"].ToString();
                    globals.employee_id = row["employee_id"].ToString();
                    globals.username = row["username"].ToString();
                }
                //MessageBox.Show("A User with this email " + globals.email + " was found: \nFullname: "+globals.fullname+" ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                admin_dashboard dashboard = new admin_dashboard();
                dashboard.Show();
            }
            connection.con.Close();
        }

        public bool check_details(string email, string password)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();
            cmd.CommandText = "SELECT * FROM admin WHERE email = @email AND password= @password";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", hash_password(password));
            cmd.Connection = connection.con;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);
            globals.table = table;
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = true;
            passwordBox.PasswordChar = '\0';
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            guna2PictureBox2.Visible = false;
            guna2PictureBox1.Visible = true;
            passwordBox.PasswordChar = '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {
            guna2CustomCheckBox1.Checked = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_registration register = new admin_registration();
            register.Show();
        }

        private string hash_password(string password)
        {
            byte[] source;
            byte[] data;
            source = ASCIIEncoding.ASCII.GetBytes(password);
            data = new MD5CryptoServiceProvider().ComputeHash(source);
            return Convert.ToBase64String(data);
        }
    }
}
