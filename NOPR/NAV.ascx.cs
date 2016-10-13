using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NAV : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Admin_Level"] == null || Session["NOPRUserID"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else
        {
            string  level = Session["Admin_Level"].ToString();
 

      
            if (level !="Admin")
            {
                admin.Visible = false;

            }
        
        }


     
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("Login.aspx");
    }
}