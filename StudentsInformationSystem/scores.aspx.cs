using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsInformationSystem
{
    public partial class scores : System.Web.UI.Page
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
            System.Data.DataTable dtgetstudent = new System.Data.DataTable();
            System.Data.DataTable dtgetcourse = new System.Data.DataTable();
            dtgetsession = getdatabase("Select * From session");
            dtgetstudent = getdatabase("Select * From students");
            dtgetcourse = getdatabase("Select * From courses");
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
            if (dtgetstudent.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ddlmatnumber.Text))
                {
                    for (var i = 0; i < dtgetstudent.Rows.Count; i++)
                    {
                        ddlmatnumber.Items.Add(dtgetstudent.Rows[i]["matnumber"].ToString());
                    }
                }
            }
            if (dtgetcourse.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ddlcourse.Text))
                {
                    for (var i = 0; i < dtgetcourse.Rows.Count; i++)
                    {
                        ddlcourse.Items.Add(dtgetcourse.Rows[i]["coursecode"].ToString());
                    }
                }
            }

        }

        protected void btnsbmit_Click(object sender, EventArgs e)
        {
            try
            {

                System.Data.DataTable tempgetdatabase = null;
                tempgetdatabase = new System.Data.DataTable();
                MySql.Data.MySqlClient.MySqlConnection cn = new MySql.Data.MySqlClient.MySqlConnection();
                MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter();
                MySql.Data.MySqlClient.MySqlCommand cm = new MySql.Data.MySqlClient.MySqlCommand();
                string strconnection = "";
                strconnection = "Server=localhost;Port=3306;Database=studentsrecord;Uid=root;Pwd=prayer;";
                System.Data.DataTable dtgetsession = new System.Data.DataTable();
                System.Data.DataTable dtgetstudent = new System.Data.DataTable();
                System.Data.DataTable dtgetcourse = new System.Data.DataTable();
                System.Data.DataTable dtgetdepartment = new System.Data.DataTable();
                string grade = "";
                dtgetdepartment = getdatabase("Select * From department");
                if (ddlmatnumber.Text == "")
                {
                    lbmsg.Text = "Please Enter the MAT Number";
                }
                else if (ddlsession.Text == "")
                {
                    lbmsg.Text = "Please Select The Session";
                }
                else if (ddlsemester.Text == "")
                {
                    lbmsg.Text = "Please Select the Semester";
                }
                else if (ddlcourse.Text == "")
                {
                    lbmsg.Text = "Please Select The Course Code";
                }
                else if (txtscore.Text == "")
                {
                    lbmsg.Text = "Please Enter The Student's Score";
                }
                else if (ddllevel.Text == "")
                {
                    lbmsg.Text = "Please Select The Student's Level";
                }

                else if (System.Convert.ToDouble((txtscore.Text).ToString()) >= 70)
                {
                    grade = "A";
                }
                else if (System.Convert.ToDouble((txtscore.Text).ToString()) < 70 & System.Convert.ToDouble((txtscore.Text).ToString()) > 59)
                {
                    grade = "B";
                }
                else if (System.Convert.ToDouble((txtscore.Text).ToString()) > 49 & System.Convert.ToDouble((txtscore.Text).ToString()) < 60)
                {
                    grade = "C";
                }
                else if (System.Convert.ToDouble((txtscore.Text).ToString()) > 39 & System.Convert.ToDouble((txtscore.Text).ToString()) < 50)
                {
                    grade = "D";
                }
                // these four lines above can also work without thr ToString Method as shown below
                else if (System.Convert.ToDouble(txtscore.Text) > 29 & System.Convert.ToDouble(txtscore.Text) < 40)
                {
                    grade = "E";
                }
                else
                {
                    grade = "F";
                }
                //'Dim session As String
                //'Dim student As String
                //'Dim course As String

                //' dtgetsales = getdatabase(" select * from product where productid=" & intproductid)
                //' dtgetexpirydate = getdatabase("select * from expirydate where productname ='" & ProductName1 & "'order by expirydateid")
                DateTime tdate = System.DateTime.Now;

                dtgetsession = getdatabase("Select sessionid from session where sessionname='" + ddlsession.Text + "'");
                dtgetstudent = getdatabase("Select studentid from students where matnumber='" + ddlmatnumber.Text + "'");
                dtgetcourse = getdatabase("Select courseid from courses where coursecode='" + ddlcourse.Text + "'");
                strconnection = "Server=localhost;Port=3306;Database=studentsrecord;Uid=root;Pwd=prayer;";
                cn.ConnectionString = strconnection;
                cn.Open();
                cm.CommandText = "Insert Into scores(sessionid,semester,level,studentid,courseid,score,grade,entrydate) Values('" + System.Convert.ToInt32(dtgetsession.Rows[0]["sessionid"]) + "','" + ddlsemester.Text + "','" + ddllevel.Text + "','" + System.Convert.ToInt32(dtgetstudent.Rows[0]["studentid"]) + "','" + System.Convert.ToInt32(dtgetcourse.Rows[0]["courseid"]) + "','" + txtscore.Text + "','" + grade + "','" + tdate + "')";
                cm.Connection = cn;
                cm.ExecuteNonQuery();
                cn.Close();
                txtscore.Text = "";
                ddllevel.Text = "";
                grade = "";
                lbmsg.Text = "The Student's Score  is Entered";
            }
            catch (Exception ex)
            {
                lbmsg.Text = ex.ToString();
            }
        }
    }
}