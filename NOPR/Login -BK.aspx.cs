using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["NOPRUserID"] = null;
        Session["Manage_Level"] = null;
        Session["Station"] = null;
        Session["Receipt"] = null;
    }



    public void Write(string data)
    {

        //获得字节数组
        StreamWriter sw = File.AppendText(Server.MapPath(Request.ApplicationPath) + "/system.log");
        //string  data = "Hello World!";
        //开始写入
        sw.WriteLine(data);

        //清空缓冲区、关闭流
        sw.Flush();
        sw.Close();


    }


    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string uid = Request.Form["username"];
        string pwd = Request.Form["password"];   
     
        string AccessRightSqlstr = "select a.* from ACARS_User a where username ='" + uid + "' and password = '" + pwd + "'";

        //检查账号密码
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.NX_APPconnectionString, CommandType.Text, AccessRightSqlstr))
        {
            if (rdr.Read())
            {
                Session["NOPRUserID"] = uid;
                //检查账号权限
                string AdminSqlstr = "select a.* from NOPR_User a where NOPR_UserName ='" + uid + "'";
                using (SqlDataReader adminrdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, AdminSqlstr))
                {
                    if (adminrdr.Read())
                    {
                        Session["Admin_Level"] = Convert.ToString(adminrdr.GetSqlValue(1));
                        //进入系统
                        Server.Transfer("Home.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('You have no right to sign the system, please contact the admin .');</script>");
                    
                    }

                }

              
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Login failed! Please check your Staff NO. and Password.');</script>");

            }

        }


    }
}