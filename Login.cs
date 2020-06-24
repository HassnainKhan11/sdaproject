using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace finall_project_school
{
    class Login     //singleton
    {
        public Login() { }

        public static Login instance = null;
        public static Login Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Login();
                }
                return instance;
            }
        }

        Database_Connection DBcon = new Database_Connection();

        public bool LoginUser(string username, string password, string user)
        {


            DBcon.SQL_Con();
            DBcon.con.Open();

            DataTable dt = null;

            if (user == "admin" || user == "Select User")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from admin where admin_username = '" + username + "' and admin_password = '" + password + "'", DBcon.con);
                dt = new DataTable();
                sda.Fill(dt);
            }

            else if (user == "student")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from student where std_username = '" + username + "' and std_password = '" + password + "'", DBcon.con);
                dt = new DataTable();
                sda.Fill(dt);
            }

            else if (user == "teacher")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from teacher where t_username = '" + username + "' and t_password = '" + password + "'", DBcon.con);
                dt = new DataTable();
                sda.Fill(dt);
            }

            if (dt.Rows[0][0].ToString() == "1")
            {
                DBcon.con.Close();
                return true;
            }

            DBcon.con.Close();
            return false;

        }



        public bool SignUpUser(string username, string email, string password, string user)
        {

            DBcon.SQL_Con();
            DBcon.con.Open();

            if (username == "" || email == "" || password == "")
            {
                return false;
            }


            try
            {

                if (user == "admin")
                {
                    DBcon.cmd = new SqlCommand("insert into admin(admin_username, admin_email, admin_password) values('" + username + "','" + email + "','" + password + "') ", DBcon.con);
                }

                else if (user == "student")
                {
                    DBcon.cmd = new SqlCommand("insert into student(std_username, std_email, std_password) values('" + username + "','" + email + "','" + password + "') ", DBcon.con);
                }

                else if (user == "teacher")
                {
                    DBcon.cmd = new SqlCommand("insert into teacher(t_username, t_email, t_password) values('" + username + "','" + email + "','" + password + "') ", DBcon.con);
                }

                DBcon.cmd.ExecuteNonQuery();
                DBcon.con.Close();
                return true;

            }

            catch (Exception)
            {
                DBcon.con.Close();
                return false;
            }

        }



    }
}
