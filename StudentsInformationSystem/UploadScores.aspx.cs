using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsInformationSystem
{
    public partial class Upload : System.Web.UI.Page
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
                System.Data.DataTable dtgetscores = new System.Data.DataTable();

                string grade = "";
                dtgetdepartment = getdatabase("Select * From department Where department='"+ ddldepartment.Text +"'");
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
                strsessionid =Convert.ToInt32 (dtgetsession.Rows[0]["sessionid"].ToString());
                dtgetscores= getdatabase("Select * from scores where sessionid='" + strsessionid + "'");
                if(dtgetscores.Rows.Count>0)
                {
                    strconnection = "Server=localhost;Port=3306;Database=studentsrecord2;Uid=root;Pwd=prayer;";
                    cn.ConnectionString = strconnection;
                    cm.Connection = cn;

                    cn.Open();

                    for (int i = 0; i < dtgetscores.Rows.Count - 1; i++)
                    {
                        cm.CommandText = "Insert Into scores(sessionid,semester,level,studentid,courseid,score,grade,gradepoint) Values('" + System.Convert.ToInt32(dtgetscores.Rows[i]["sessionid"]) + "','" + dtgetscores.Rows[i]["semester"].ToString() + "','" + dtgetscores.Rows[i]["level"].ToString() + "','" + Convert.ToInt32(dtgetscores.Rows[i]["studentid"].ToString()) + "','" + System.Convert.ToInt32(dtgetscores.Rows[i]["courseid"]) + "','" + dtgetscores.Rows[i]["score"].ToString() + "','" + dtgetscores.Rows[i]["grade"].ToString() + "','" + Convert.ToDouble(dtgetscores.Rows[i]["gradepoint"].ToString()) + "')";
                        cm.ExecuteNonQuery();

                    }
                    cn.Close();

                }
                lbmsg.Text = "The Students Scores  are Successfully Uploaded";
            }
            catch (Exception ex)
            {
                lbmsg.Text = ex.ToString();
            }

        }
    }
}