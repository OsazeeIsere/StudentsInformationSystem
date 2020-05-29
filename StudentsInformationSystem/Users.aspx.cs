using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsInformationSystem
{
    public partial class Users : System.Web.UI.Page
    {
        clssettings x = new clssettings(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["username"] == null))
            {
                Response.Redirect("login.aspx");
            }
            else
            {

                System.Data.DataTable dtgetadmin = new System.Data.DataTable();
                dtgetadmin = x.getdatabase("Select * From admin Where username='" + Session["username"].ToString() + "' And password='" + Session["password"].ToString() + "'");

                lbusername.Text = Convert.ToString(Session["username"]);
            }
            if (!IsPostBack)
            {
                getdepartments();
                getuserroles();
            }

        }

        protected void btnenter_Click(object sender, EventArgs e)
        {
            try
            {

                System.Data.DataTable dtgetuser = new System.Data.DataTable();


                if (string.IsNullOrEmpty(txtusername.Text))
                {
                    lbmsg.Text = "Please Enter the user Name";
                }
                else if (string.IsNullOrEmpty(txtsurname.Text))
                {
                    lbmsg.Text = "Please Enter the Surname";
                }
                else if (string.IsNullOrEmpty(ddldepartment.Text))
                {
                    lbmsg.Text = "Please Select the Department";
                }
                else if (string.IsNullOrEmpty(txttel.Text))
                {
                    lbmsg.Text = "Please Enter Phone Number";
                }
                else if (string.IsNullOrEmpty(txtemail.Text))
                {
                    lbmsg.Text = "Please Enter The Email";
                }
                else if (string.IsNullOrEmpty(lbusername.Text))
                {
                    lbmsg.Text = "Please Who Are You?";
                }
                else
                {


                    x.AddData("Insert into user(surname, othernames, phonenumber, email, department, userrole, createdby) Values('" + txtsurname.Text + "','" + txtothernames.Text + "','" + txttel.Text + "','" + txtemail.Text + "','" + ddldepartment.Text + "','" + ddluserrole.Text + "','admin')");


                    int intlastid = x.getlastid("user", "userid");
                    string strinsert = "Insert Into admin(userid,userrole,username,password,createdby) Values(" + intlastid + ",'" + ddluserrole.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "','Admin');";
                    x.AddData(strinsert);
                    txtusername.Text = "";
                    txtsurname.Text = "";
                    txtothernames.Text = "";
                    txtemail.Text = "";
                    // ddldepartment.Text = ""
                    txttel.Text = "";
                    ddldepartment.Text = "None";
                    ddluserrole.Text = "None";
                    // ddldepartment.Items.Clear()

                    lbmsg.Text = "The User is Registered";
                }
            }
            catch (Exception ex)
            {
                lbmsg.Text = ex.ToString();
            }

        }
        public void getdepartments()
        {
            try
            {

                System.Data.DataTable dtgetdepartments = new System.Data.DataTable();
                dtgetdepartments = x.getdatabase("Select * From department");

                ddldepartment.Items.Clear();
                if (dtgetdepartments.Rows.Count > 0)
                {
                    ListItem itm = new ListItem();

                    for (var i = 0; i < dtgetdepartments.Rows.Count; i++)
                    {
                        itm = new ListItem();
                        itm.Value = Convert.ToString(dtgetdepartments.Rows[i]["department"]);
                        itm.Text = dtgetdepartments.Rows[i]["department"].ToString() + " (" + dtgetdepartments.Rows[i]["faculty"].ToString() + ")";
                        ddldepartment.Items.Add(itm);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();

            }
        }
        public void getuserroles()
        {
            try
            {

                System.Data.DataTable dtgetdepartments = new System.Data.DataTable();
                dtgetdepartments = x.getdatabase("Select * From userrole");

                ddluserrole.Items.Clear();
                if (dtgetdepartments.Rows.Count > 0)
                {
                    ListItem itm = new ListItem();

                    for (var i = 0; i < dtgetdepartments.Rows.Count; i++)
                    {
                        itm = new ListItem();
                        itm.Value = Convert.ToString(dtgetdepartments.Rows[i]["role"]);
                        itm.Text = dtgetdepartments.Rows[i]["role"].ToString();
                        ddluserrole.Items.Add(itm);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();

            }
        }

    }
}