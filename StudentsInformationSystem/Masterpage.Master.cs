using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsInformationSystem
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["adminid"] == null))
            {
                lnklogin.Visible = false;
                lnklogout.Visible = true;
                lnkdashboard.Visible = true;

            }
            else
            {
                lnklogin.Visible = true;
                lnklogout.Visible = false;
                lnkdashboard.Visible = false;

            }


        }
    }
}