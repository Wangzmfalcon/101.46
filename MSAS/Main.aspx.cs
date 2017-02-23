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
        ////menu判断
        //if (Session["Admin_Level"] == null)
        //{ Session["Admin_Level"] = "0"; }
        //int level = Convert.ToInt32(Session["Admin_Level"].ToString());
        //if (level < 100)
        //{

        //}
        //if (level < 70)
        //{
        //    Authors.Visible = false;
        //}

        //if (level < 60)
        //{
        //    Author.Visible = false;
        //}
        //if (level < 10)
        //{
        //    staffs.Visible = false;
        //}

       

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