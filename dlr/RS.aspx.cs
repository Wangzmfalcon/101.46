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
        string SQL_update = "update ENM_Staff_Master_List "
                   + "set ENM_Staff_Master_List.AU_EXP_P = '" + Rday + "'"
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
        string SQL_update = "update ENM_Staff_Master_List "
                   + "set ENM_Staff_Master_List.AM_EXP_P = '" + Rday + "'"
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
        string SQL_update = "update Ceritifcate_Monitor "
                   + "set Ceritifcate_Monitor.C_of_A_P = '" + Rday + "'"
                   + " where Record_S ='1'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
         string Rday = TextBox4.Text;
        string SQL_update = "update Ceritifcate_Monitor "
                   + "set Ceritifcate_Monitor.ASL_P = '" + Rday + "'"
                   + " where Record_S ='1'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string Rday = TextBox7.Text;
        string SQL_update = "update Ceritifcate_Monitor "
                   + "set Ceritifcate_Monitor.DSRT_Radio_Licence_P = '" + Rday + "'"
                   + " where Record_S ='1'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        string Rday = TextBox8.Text;
        string SQL_update = "update Ceritifcate_Monitor "
                   + "set Ceritifcate_Monitor.C_of_A_IRL_P = '" + Rday + "'"
                   + " where Record_S ='1'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        string Rday = TextBox5.Text;
        string SQL_update = "update Finding_Control "
                   + "set Finding_Control.The_Alert_Date_P = '" + Rday + "'"
                   + " where Record_S ='1'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    //protected void Button6_Click(object sender, EventArgs e)
    //{
    //    string Rday = TextBox6.Text;
    //    string SQL_update = "update Finding_Control "
    //               + "set Finding_Control.CA_Target_Date_P = '" + Rday + "'"
    //               + " where Record_S ='1'";

    //    using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
    //    {
    //        SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
    //    }
    //    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    //}
    protected void Button13_Click(object sender, EventArgs e)
    {
        string Rday = TextBox9.Text;
        string SQL_update = "update Ceritifcate_Monitor "
                   + "set Ceritifcate_Monitor.ASL_IRL_P = '" + Rday + "'"
                   + " where Record_S ='1'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        string Rday = TextBox10.Text;
        string SQL_update = "update Ceritifcate_Monitor "
                   + "set Ceritifcate_Monitor.Declaration_P = '" + Rday + "'"
                   + " where  Record_S ='1'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        string Rday = TextBox11.Text;
        string SQL_update = "update Ceritifcate_Monitor "
                   + "set Ceritifcate_Monitor.C_of_R_P = '" + Rday + "'"
                   + " where   Record_S ='1'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    }
    //protected void Button16_Click(object sender, EventArgs e)
    //{
    //    string Rday = TextBox12.Text;
    //    string SQL_update = "update Finding_Control "
    //               + "set Finding_Control.PA_Target_Date_P = '" + Rday + "'"
    //               + " where   Record_S ='1'";

    //    using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
    //    {
    //        SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
    //    }
    //    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    //}
}