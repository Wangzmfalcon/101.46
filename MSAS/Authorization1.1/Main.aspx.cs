using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        staffs.Visible = false;
        if (Session["staffno"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
            Label1.Text = "Welcome " + Session["staffname"].ToString();

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
        
    }
}