using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["User_ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        else
            Label1.Text = "Welcome " + Session["User_Name"].ToString();

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (getright(Session["User_ID"].ToString(), "1") == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Unauthorized user. Please contact administrator.');</script>");
        }
        else
        {
            Response.Redirect("Report1.aspx");
        }
    }
    public bool getright(string userid, string reportid)
    {
        bool permission = false;
        string SQL = "select 'X' from BCSS_REPORT WHERE USERID='" + userid + "'  AND REPORTID='" + reportid + "'";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL))
        {
            if (rdr.Read())
            {
                permission = true;
            }
            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Unauthorized user. Please contact administrator.');</script>");
            }
        }
        return permission;

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        Response.Redirect("Satisfaction.aspx");
        //if (getright(Session["User_ID"].ToString(), "1") == false)
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Unauthorized user. Please contact administrator.');</script>");
        //}
        //else
        //{
        //    Response.Redirect("Report1.aspx");
        //}
    }
}