using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsInformationSystem
{
    public partial class UploadStudents : System.Web.UI.Page
    {
        private System.Data.DataTable getdatabase(string strcommand)
        {
            System.Data.DataTable tempgetdatabase = null;
            tempgetdatabase = new System.Data.DataTable();
            MySql.Data.MySqlClient.MySqlConnection cn = new MySql.Data.MySqlClient.MySqlConnection();
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter();
            MySql.Data.MySqlClient.MySqlCommand cm = new MySql.Data.MySqlClient.MySqlCommand();
            string strconnection = "";
            strconnection = "Server=localhost;Port=3306;Database=studentsrecord;Uid=root;Pwd=prayer;";
            cn.ConnectionString = strconnection;
            cn.Open();
            cm.CommandText = strcommand;
            ad.SelectCommand = cm;
            cm.Connection = cn;
            System.Data.DataTable dt = new System.Data.DataTable();
            ad.Fill(dt);
            tempgetdatabase = dt;
            cn.Close();
            return tempgetdatabase;
        }
        public void adddata(string strinsert)
        {
            MySql.Data.MySqlClient.MySqlConnection cn = new MySql.Data.MySqlClient.MySqlConnection();
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter();
            MySql.Data.MySqlClient.MySqlCommand cm = new MySql.Data.MySqlClient.MySqlCommand();

            string strconnection = "";
            strconnection = "server= localhost;port=3306;database=studentsrecord;uid=root;pwd=prayer";
            cn.ConnectionString = strconnection;
            cn.Open();
            cm.CommandText = strinsert;
            cm.Connection = cn;
            cm.ExecuteNonQuery();
            cn.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dtgetsession = new System.Data.DataTable();
            System.Data.DataTable dtgetdepartment = new System.Data.DataTable();
            System.Data.DataTable dtgetcourse = new System.Data.DataTable();
            dtgetsession = getdatabase("Select * From session");
            dtgetdepartment = getdatabase("Select * From department");
            string struser = Convert.ToString(Session["username"]);

            string strpassword = Convert.ToString(Session["password"]);

            if (dtgetsession.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ddlsession.Text))
                {
                    for (var i = 0; i < dtgetsession.Rows.Count; i++)
                    {
                        ddlsession.Items.Add(dtgetsession.Rows[i]["sessionname"].ToString());
                    }
                }
            }
            if (dtgetdepartment.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ddldepartment.Text))
                {
                    for (var i = 0; i < dtgetdepartment.Rows.Count; i++)
                    {
                        ddldepartment.Items.Add(dtgetdepartment.Rows[i]["department"].ToString());
                    }
                }
            }
        }

        protected void btnsbmit_Click(object sender, EventArgs e)
        {
            try
            {
                int strsessionid = 0;
                System.Data.DataTable tempgetdatabase = null;
                tempgetdatabase = new System.Data.DataTable();
                MySql.Data.MySqlClient.MySqlConnection cn = new MySql.Data.MySqlClient.MySqlConnection();
                MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter();
                MySql.Data.MySqlClient.MySqlCommand cm = new MySql.Data.MySqlClient.MySqlCommand();
                string strconnection = "";
                strconnection = "Server=localhost;Port=3306;Database=studentsrecord;Uid=root;Pwd=prayer;";
                System.Data.DataTable dtgetsession = new System.Data.DataTable();
                System.Data.DataTable dtgetdepartment = new System.Data.DataTable();
                System.Data.DataTable dtgetstudents = new System.Data.DataTable();

                string grade = "";
                dtgetdepartment = getdatabase("Select * From department Where department='" + ddldepartment.Text + "'");
                if (ddldepartment.Text == "")
                {
                    lbmsg.Text = "Please Select the Department";
                }
                else if (ddlsession.Text == "")
                {
                    lbmsg.Text = "Please Select The Session";
                }
                DateTime tdate = System.DateTime.Now;

                dtgetsession = getdatabase("Select * from session where sessionname='" + ddlsession.Text + "'");

                dtgetstudents = getdatabase("Select * from students where startsession='" + ddlsession.Text + "'");
                if (dtgetstudents.Rows.Count > 0)
                {
                    strconnection = "Server=localhost;Port=3306;Database=studentsrecord2;Uid=root;Pwd=prayer;";
                    cn.ConnectionString = strconnection;
                    cm.Connection = cn;

                    cn.Open();

                    for (int i = 0; i < dtgetstudents.Rows.Count - 1; i++)
                    {

                        cm.CommandText = "Insert Into students(lastname,othernames,matnumber,gender,department,startsession,endsession) Values('" + dtgetstudents.Rows[i]["lastname"].ToString() + "','" + dtgetstudents.Rows[i]["othernames"].ToString() + "','" + dtgetstudents.Rows[i]["matnumber"].ToString() + "','" + dtgetstudents.Rows[i]["gender"].ToString() + "','" + dtgetstudents.Rows[i]["department"].ToString() + "','" + dtgetstudents.Rows[i]["startsession"].ToString() + "','" + dtgetstudents.Rows[i]["endsession"].ToString() + "')";
                    cm.ExecuteNonQuery();
                    }
                    cn.Close();

                }
                lbmsg.Text = "The Students' Information  are Successfully Uploaded";
            }
            catch (Exception ex)
            {
                lbmsg.Text = ex.ToString();
            }

        }
    }
}