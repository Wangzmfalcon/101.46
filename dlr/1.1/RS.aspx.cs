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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Rday = TextBox1.Text;
        string SQL_update = "update DLR_ENM_Staff_Master_List "
                   + "set DLR_ENM_Staff_Master_List.AU_EXP_P = '" + Rday + "'"
                   + " where 1=1";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);         
        }  
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string Rday = TextBox2.Text;
        string SQL_update = "update DLR_ENM_Staff_Master_List "
                   + "set DLR_ENM_Staff_Master_List.AM_EXP_P = '" + Rday + "'"
                   + " where 1=1";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        string Rday = TextBox3.Text;
        string SQL_update = "update DLR_Ceritifcate_Monitor "
                   + "set DLR_Ceritifcate_Monitor.C_of_A_P = '" + Rday + "'"
                   + " where 1=1";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
         string Rday = TextBox4.Text;
        string SQL_update = "update DLR_Ceritifcate_Monitor "
                   + "set DLR_Ceritifcate_Monitor.Station_Licence_P = '" + Rday + "'"
                   + " where 1=1";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string Rday = TextBox7.Text;
        string SQL_update = "update DLR_Ceritifcate_Monitor "
                   + "set DLR_Ceritifcate_Monitor.Radio_Licence_P = '" + Rday + "'"
                   + " where 1=1";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        string Rday = TextBox8.Text;
        string SQL_update = "update DLR_Ceritifcate_Monitor "
                   + "set DLR_Ceritifcate_Monitor.Insurance_P = '" + Rday + "'"
                   + " where 1=1";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        string Rday = TextBox5.Text;
        string SQL_update = "update DLR_Finding_Control "
                   + "set DLR_Finding_Control.Final_Issue_Date_P = '" + Rday + "'"
                   + " where 1=1";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string Rday = TextBox6.Text;
        string SQL_update = "update DLR_Finding_Control "
                   + "set DLR_Finding_Control.Final_Due_Date_P = '" + Rday + "'"
                   + " where 1=1";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
}