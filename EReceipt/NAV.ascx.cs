using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NAV : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Manage_Level"] == null || Session["UserID"] == null || Session["Receipt"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else
        {
            int level = Convert.ToInt32(Session["Manage_Level"].ToString());
            int Receipt = Convert.ToInt32(Session["Receipt"].ToString());

            if (level < 50)
            {
                report.Visible = false;

            }
            if (level < 70)
            {
                setting.Visible = false;

            }
            if (level < 100)
            {
                admin.Visible = false;

            }
            if (Receipt == 0)
            {
                add.Visible = false;
                manage.Visible = false;
            }
        }


     
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("Login.aspx");
    }
}