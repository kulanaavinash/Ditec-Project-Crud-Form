using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace SkillsInternational
{
    public partial class Loginpage : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DISMT73N;Initial Catalog=Skills;Integrated Security=True");
        string cs = "Data Source=LAPTOP-DISMT73N;Initial Catalog=Skills;Integrated Security=True";

        int i = 0;

        public Loginpage()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (usertxt.Text == "Admin" && passwordtxt.Text == "Skills@123")
            {
                new Register().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Invalid Login Credentials ,Please check username and password and Try again");
                usertxt.Clear();
                passwordtxt.Clear();
                usertxt.Focus();
            }*/

           
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='" + usertxt.Text + "' AND password='" + passwordtxt.Text + "'", con);
            
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
               
                this.Hide();
                new Register().Show();
            }
            else
                MessageBox.Show("Invalid Login Credentials ,Please check username and password and Try again");
                 usertxt.Clear();
                 passwordtxt.Clear();
                 usertxt.Focus();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure ,Do you really want to Exit....?", "EXIT", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();

            }
            else if (dialog == DialogResult.No) 
            {
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usertxt.Clear();
            passwordtxt.Clear();
            usertxt.Focus();
        }
    }
}
