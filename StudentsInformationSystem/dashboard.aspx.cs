using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace StudentsInformationSystem
{
    
    public partial class dashboard : System.Web.UI.Page
    {
        public string matnumber;
        public string strstartsession;
        public string strendsession;
        public string strinstitution;

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
            string struser = Convert.ToString(Session["username"]);

            string strpassword = Convert.ToString(Session["password"]);

            btnenterscores.Visible = true;
            System.Data.DataTable dtgetuser = new System.Data.DataTable();
            System.Data.DataTable dtgettranscript = new System.Data.DataTable();
            dtgettranscript = getdatabase("Select * From transcript");
            dtgetuser = getdatabase("Select * From admin Where username='" + struser + "' And password='" + strpassword + "' ;");
            if (dtgetuser.Rows.Count > 0)
            {
               
                if (Convert.ToString(dtgetuser.Rows[0]["userrole"]) == "Score Entering Officer")
                {
                    //divtranscript.Visible = false;
                    divusers.Visible = false;
                    divstudents.Visible = true;
                    divscores.Visible = true;
                    lbluserrole.Text = "Score Entering Officer";


                }
                else if (Convert.ToString(dtgetuser.Rows[0]["userrole"]) == "Verification Officer")
                {
                    //divtranscript.Visible = true;
                    divusers.Visible = false;
                    divstudents.Visible = true;
                    divscores.Visible = true;
                    btnenterscores.Visible = false;
                    //btngeneratetranscript.Visible = false;
                    lbluserrole.Text = "Verification Officer";
                    if (dtgettranscript.Rows.Count > 0)
                    {
                        for (var i = 0; i < dtgettranscript.Rows.Count; i++)
                        {
                            if (dtgettranscript.Rows[i]["approvalstatus"].ToString() != "Verified Awaiting Approval" && dtgettranscript.Rows[i]["approvalstatus"].ToString() != "Approval Successful")
                            {
                                divtranscriptStatus.Visible = true;
                                ddlgeneratedTranscript.Items.Add(dtgettranscript.Rows[i]["matnumber"].ToString());
                                btnmoveforactio.Text = "Move For Verification";
                                btnviewtranscript.Visible = false;

                            }
                        }
                    }


                }
                else if (Convert.ToString(dtgetuser.Rows[0]["userrole"]) == "Admin")
                {
                    divtranscript.Visible = false;
                    divusers.Visible = true;
                    divstudents.Visible = true;
                    divscores.Visible = false;
                    lbluserrole.Text = "Admin";

                }
                else if (Convert.ToString(dtgetuser.Rows[0]["userrole"]) == "Transcript Approval Officer")
                {
                    divtranscript.Visible = true;
                    btnenterscores.Visible = false;
                    divusers.Visible = false;
                    divstudents.Visible = true;
                    btngeneratetranscript.Visible = false;
                    divscores.Visible = true;
                    //btngeneratetranscript.Visible = False
                    lbluserrole.Text = "Transcript Approval Officer";
                    if (dtgettranscript.Rows.Count > 0)
                    {
                        for (var i = 0; i < dtgettranscript.Rows.Count; i++)
                        {
                            if (dtgettranscript.Rows[i]["approvalstatus"].ToString() == "Verified Awaiting Approval" && dtgettranscript.Rows[i]["approvalstatus"].ToString() != "Approval Successful")
                            {
                                divtranscriptStatus.Visible = true;
                                ddlgeneratedTranscript.Items.Add(dtgettranscript.Rows[i]["matnumber"].ToString());
                                btnmoveforactio.Text = "Move For Approval";
                                btnviewtranscript.Visible = false;
                            }
                        }
                    }

                }

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnmoveforactio_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dtgettranscript = new System.Data.DataTable();
            dtgettranscript = getdatabase("Select * From transcript where matnumber='" + ddlgeneratedTranscript.Text + "'");
            if (dtgettranscript.Rows.Count > 0)
            {
                matnumber = dtgettranscript.Rows[0]["matnumber"].ToString();
                Session["matnumber"] = matnumber;
                strstartsession = dtgettranscript.Rows[0]["startsession"].ToString();
                strendsession = dtgettranscript.Rows[0]["endsession"].ToString();
                strinstitution = dtgettranscript.Rows[0]["institution"].ToString();

            }
            Session["matnumber"] = matnumber;
            Session["startsession"] = strstartsession;
            Session["endsession"] = strendsession;
            Session["institution"] = strinstitution;
            Response.Redirect("generatetranscript.aspx");

        }

        protected void btngeneratetranscript_Click(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewtranscript.aspx");

        }

        protected void btnbulkupload_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadScores.aspx");
        }

        protected void btnuploadsstudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadStudents.aspx");

        }

        protected void btnmanageStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("session.aspx");
        }

        protected void btnaddstudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("students.aspx");

        }

        protected void btnadddepartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("department.aspx");
        }
    }
}