using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsInformationSystem
{
    public partial class students : System.Web.UI.Page
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
            System.Data.DataTable dtgetdepartment = new System.Data.DataTable();
            dtgetdepartment = getdatabase("Select * From department");
            if (dtgetdepartment.Rows.Count > 0)
            {
                for (var i = 0; i < dtgetdepartment.Rows.Count; i++)
                {
                    ddldepartment.Items.Add(dtgetdepartment.Rows[i]["department"].ToString());
                }
            }
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            try
            {

                System.Data.DataTable dtgetdepartment = new System.Data.DataTable();

                dtgetdepartment = getdatabase("Select * From department");
                if (string.IsNullOrEmpty(txtlastname.Text))
                {
                    lbmsg.Text = "Please Enter the Last Name";
                }
                else if (string.IsNullOrEmpty(txtothername.Text))
                {
                    lbmsg.Text = "Please Enter the Other Names";
                }
                else if (string.IsNullOrEmpty(ddldepartment.Text))
                {
                    lbmsg.Text = "Please Select the Department";
                }
                else if (string.IsNullOrEmpty(txtmatnumber.Text))
                {
                    lbmsg.Text = "Please Enter MAT Number";
                }
                else if (string.IsNullOrEmpty(txtstartsession.Text))
                {
                    lbmsg.Text = "Please Enter The Student's Start Session";
                }
                else if (string.IsNullOrEmpty(txtendsession.Text))
                {
                    lbmsg.Text = "Please Enter The Student's End Session";
                }
                else
                {
                    adddata("Insert Into students(lastname,othernames,matnumber,gender,department,startsession,endsession) Values('" + txtlastname.Text + "','" + txtothername.Text + "','" + txtmatnumber.Text + "','" + ddlgender.Text + "','" + ddldepartment.Text + "','" + txtstartsession.Text + "','" + txtendsession.Text + "')");

                    txtlastname.Text = "";
                    txtothername.Text = "";
                    txtmatnumber.Text = "";
                    // ddldepartment.Text = ""
                    txtstartsession.Text = "";
                    txtendsession.Text = "";
                    // ddldepartment.Items.Clear()
                    lbmsg.Text = "The Student is Registered";
                }
            }
            catch (Exception ex)
            {
                lbmsg.Text = ex.ToString();
            }
        }
    }
}