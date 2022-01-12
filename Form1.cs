using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseConn
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Db.mdf;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == " " || txtpassword.Text == "")
                MessageBox.Show("Please fill mandotory fields");
            else if (txtpassword.Text != txtconfirmpassword.Text)
                MessageBox.Show("Password do not match");
            else {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
           
                    SqlCommand sqlcmd = new SqlCommand("UserAdd", sqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserName", txtusername.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Password", txtpassword.Text.Trim());
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("You can Login");
                    clear();
                }
            }
        }

        void clear()
        {
            txtusername.Text = txtpassword.Text = txtconfirmpassword.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
