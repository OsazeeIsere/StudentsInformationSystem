using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsInformationSystem
{
    public partial class login : System.Web.UI.Page
    {
        private void checkcredentials()
        {
            try
            {
                System.Data.DataTable dtgetadmin = new System.Data.DataTable();

                dtgetadmin = getdatabase("Select * From admin Where username='" + txtusername.Text + "' And password='" + txtpassword.Text + "'");
                if (dtgetadmin.Rows.Count > 0)
                {
                    Session.Add("username", txtusername.Text);
                    Session.Add("password", txtpassword.Text);
                    Session.Add("adminid", dtgetadmin.Rows[0]["adminid"].ToString());
                    Response.Redirect("dashboard.aspx");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            checkcredentials();
           MasterPage x = new MasterPage();
         
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {

        }
    }
}