using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SMS.DBUtility;
using System.Data;
using System.Data.OleDb;
using System.IO;


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
    protected void download1_Click(object sender, EventArgs e)
    {
        //查找是否存在
        string SQL =
      "select * from BCSS_DATE where SEQ =@seq and STATUS='NEW' ";
        SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@seq", SqlDbType.VarChar, 50),
      
            };
        //删除页面  DEL权限
        
        parm[0].Value = seq.Text.ToString().Trim();
        int flag = 1;
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL, parm))
        {
            if (rdr.Read())
            {
            }
            else
            {
                flag = 0;//不存在
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('The record is not exit');</script>");
            }
        }
        //删除
        if (flag == 1)
        {
         string SQLDEL ="  UPDATE BCSS_DATE"
             +" SET STATUS='DEL'"
             + " where SEQ='" + seq.Text.ToString().Trim()+"'";
         using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
         {
             SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQLDEL);
         }
         ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete success');</script>");
        }



    }
}