using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace finall_project_school
{
    public partial class login_Form1 : Form
    {
        public login_Form1()
        {
            InitializeComponent();
        }

        Database_Connection DBcon = new Database_Connection();

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool Check = false;

        private void buttonlogin_Click(object sender, EventArgs e)
        {

            Login Log = new Login();
            home_page home = new home_page();

            Check = false;

            Check = Log.LoginUser(textBoxuser.Text, textBoxPass.Text, select_user.Text);

            if (Check == true)
            {
                MessageBox.Show("Login Successfull");
                home.select_user = select_user.Text;
                this.Hide();
                home.Show();
            }

            else
        	{
                MessageBox.Show("Login Unsuccessfull");
            }

        }

        private void login_Form1_Load(object sender, EventArgs e)
        {
            //select_user.Hide();
        }

        private void login_Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        resister_Form2 reg;

        private void label3_Click(object sender, EventArgs e)
        {
            reg = new resister_Form2();
            this.Hide();
            reg.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
