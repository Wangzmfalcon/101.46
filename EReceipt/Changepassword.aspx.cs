using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.IO;
using System.Data.SqlClient;
public partial class Changepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Manage_Level"] == null || Session["UserID"] == null || Session["Receipt"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else
        {
            username.Value = Session["UserID"].ToString();
        }
        
    }
    protected void Save_Click(object sender, EventArgs e)
    {

        string password = Request.Form["password"];
        string password1 = Request.Form["password1"];
        if (password == password1)
        {
           //修改密码

            string SQL_update = " update ERS_User set Password='" + password + "' where User_Id='" + Session["UserID"].ToString() + "'";

            using (SqlConnection conn = new  SqlConnection(SqlHelper.Conn))
            {
                int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
                if (actionrows > 0)
                {
                    //写SQL 日志
                    string SQL_insert = "INSERT INTO ERS_Log (User_Id,Log_Time,Log_IP,Sys_Log) values(@User_Id,@Log_Time,@Log_IP,@Sys_Log)";
                    SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@User_Id", SqlDbType.VarChar, 50),
                    new SqlParameter("@Log_Time", SqlDbType.DateTime),
                    new SqlParameter("@Log_IP", SqlDbType.VarChar, 50),
                    new SqlParameter("@Sys_Log", SqlDbType.VarChar, 100),
   
                 };
                    parms[0].Value = Session["UserID"].ToString();
                    parms[1].Value = DateTime.Now;
                    parms[2].Value = Session["IP"].ToString();
                    parms[3].Value = "Change password";
                    using (SqlConnection conn1 = new SqlConnection(SqlHelper.Conn))
                    {
                        int actionrows1 = SqlHelper.ExecuteNonQuery(conn1, CommandType.Text, SQL_insert, parms);
                        if (actionrows1 > 0)
                        {
                            //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");

                        }
                        else
                        {
                            //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                        }
                    }

                    Response.Write( "<script>alert('Password changed success , please use the new password to login again.');</script>");
                    Response.Write("<script  language='javascript'>window.location='Login.aspx'</script>");


                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Password changedfaild , please contact the administrator.');</script>");
                }
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('The passwords you typed do not match. Type the same password in both text boxes.');</script>");
        }
       
    }
}