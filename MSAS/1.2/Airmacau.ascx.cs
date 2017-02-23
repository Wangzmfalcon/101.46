using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    { //menu判断
        if (Session["Admin_Level"] == null)
        { Session["Admin_Level"] = "0"; }
        int level = Convert.ToInt32(Session["Admin_Level"].ToString());
        if (level < 100)
        {
            Admin.Visible = false;
            Reminder.Visible = false;
        }
        if (level < 70)
        {
            Authors.Visible = false;
        }

        if (level < 60)
        {
            Author.Visible = false;
        }
        if (level < 10)
        {
            staffs.Visible = false;
        }

    }

}