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

namespace SkillsInternational
{
    public partial class Register : Form
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DISMT73N;Initial Catalog=Skills;Integrated Security=True");
        string cs = "Data Source=LAPTOP-DISMT73N;Initial Catalog=Skills;Integrated Security=True";


        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;


        public Register()
        {
            InitializeComponent();
            DisplayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void DisplayData()
        {
            SqlCommand sqlComm = new SqlCommand("select regNo from [dbo].[Registration]", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlComm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0]);

            }

        }



        string GENDER;
        private void button1_Click_1(object sender, EventArgs e)
        {

            con.Open  ();
            SqlDataAdapter command = new SqlDataAdapter("INSERT INTO Registration(regNo,firstName,lastName,dateOfBirth,gender, address,email,mobilePhone,homePhone,parentName,nic,contactNo)VALUES ('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox10.Text + "','" + GENDER + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')", con);
            command.SelectCommand.ExecuteNonQuery();
           
            con.Close();
            MessageBox.Show("Record Added Successfully");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = "Female";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Select firstName,lastName,dateOfBirth,gender, address,email,mobilePhone,homePhone,parentName,nic,contactNo from Registration where regNo =@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
            SqlDataReader da = cmd.ExecuteReader();
            while(da.Read())
            {
                textBox1.Text = da.GetValue(0).ToString();
                textBox2.Text = da.GetValue(1).ToString();
                textBox10.Text = da.GetValue(2).ToString();
                textBox3.Text = da.GetValue(4).ToString();
                textBox4.Text = da.GetValue(5).ToString();
                textBox5.Text = da.GetValue(6).ToString();
                textBox6.Text = da.GetValue(7).ToString();
                textBox7.Text = da.GetValue(8).ToString();
                textBox8.Text = da.GetValue(9).ToString();
                textBox9.Text = da.GetValue(10).ToString();







            }

            con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            {
                con.Open();
                SqlCommand command = new SqlCommand("update Registration set firstName ='" + textBox1.Text + "',lastName ='" + textBox2.Text + "',dateOfBirth ='" + textBox10.Text + "',address ='" + textBox3.Text + "',email ='" + textBox4.Text + "', mobilePhone='" + textBox5.Text + "',homePhone ='" + textBox6.Text + "',parentName ='" + textBox7.Text + "',nic ='" + textBox8.Text + "',contactNo ='" + textBox9.Text + "' where regNo = '" + int.Parse(comboBox1.Text) + "'", con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Sucessfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();

            }
            









        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure, Do you really want to Delete this Record....?", "Delete record", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {
                con.Open();
                SqlCommand command = new SqlCommand("Delete Registration where regNo = '" + comboBox1.Text + "' ", con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();



            }
            else
            {
                MessageBox.Show("Record Details Not Deleted Successfully.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear(); 
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
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
    }



}

