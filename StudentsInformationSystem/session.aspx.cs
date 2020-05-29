using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsInformationSystem
{
    public partial class session : System.Web.UI.Page
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

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtsession.Text))
                {
                    lbmsg.Text = "Please Enter The Session";
                }
                else
                {
                    adddata("Insert Into session(sessionname) Values('" + txtsession.Text + "')");

                    txtsession.Text = "";
                    lbmsg.Text = "The Session is Registered";
                }
            }
            catch (Exception ex)
            {
                lbmsg.Text = ex.ToString();
            }
        }
    }
}