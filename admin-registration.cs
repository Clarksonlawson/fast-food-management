using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Final_Year_Project
{
    public partial class admin_registration : Form
    {
        public admin_registration()
        {
            InitializeComponent();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            admin_login login = new admin_login();
            login.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            guna2PictureBox4.Visible = false;
            guna2PictureBox3.Visible = true;
            passBox.PasswordChar = '\0';
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            guna2PictureBox3.Visible = false;
            guna2PictureBox4.Visible = true;
            passBox.PasswordChar = '*';
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            connection.con.Open();
            if (nameBox.Text != "" && emailBox.Text != "" && usernameBox.Text != "" && employeeBox.Text != "" && passBox.Text != "" && confirmBox.Text != "")
            {
                globals.fullname = nameBox.Text;
                globals.email = emailBox.Text;
                globals.username = usernameBox.Text;
                globals.employee_id = employeeBox.Text;
                if (passBox.Text == confirmBox.Text)
                {
                    globals.password = passBox.Text;
                    if (!check_admin(globals.email))
                    {
                        string encry_pass = hash_password(globals.password);
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection.con;
                        cmd.CommandText = "INSERT INTO admin(`fullname`, `email`, `username`, `employee_id`, `password`) VALUES (@fullname, @email, @username, @employee, @password)";
                        cmd.Parameters.AddWithValue("@fullname", globals.fullname);
                        cmd.Parameters.AddWithValue("@email", globals.email);
                        cmd.Parameters.AddWithValue("@username", globals.username);
                        cmd.Parameters.AddWithValue("@employee", globals.employee_id);
                        cmd.Parameters.AddWithValue("@password", encry_pass);

                        try
                        {
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                admin_login login= new admin_login();
                                login.Show();
                            }
                            else
                            {
                                MessageBox.Show("Failed to insert data into database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (MySqlException ex)
                        {
                              MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Account already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Both passwords supplied do not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Fields cannot be left empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connection.con.Close();
        }
        public bool check_admin(string email)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM admin WHERE email = @email";
            cmd.Connection = connection.con;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private string hash_password(string password)
        {
            byte[] source;
            byte[] data;
            source = ASCIIEncoding.ASCII.GetBytes(password);
            data= new MD5CryptoServiceProvider().ComputeHash(source);
            return Convert.ToBase64String(data);
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = true;
            passBox.PasswordChar = '\0';
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            guna2PictureBox2.Visible = false;
            guna2PictureBox1.Visible = true;
            passBox.PasswordChar = '*';
        }
    }
}
