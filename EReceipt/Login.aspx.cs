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
        Session["UserID"] = null;
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
        string IPaddress = HttpContext.Current.Request.UserHostAddress.ToString();
        Session["IP"] = IPaddress;
        string AccessRightSqlstr = "select a.* from ERS_User a where User_Id ='" + uid + "' and Password = '" + pwd + "'";


        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, AccessRightSqlstr))
        {
            if (rdr.Read())
            {
                Session["UserID"] = Convert.ToString(rdr.GetSqlValue(0));
                Session["ERS_User"] = Convert.ToString(rdr.GetSqlValue(1));
                Session["Manage_Level"] = Convert.ToString(rdr.GetSqlValue(4));
                //Session["Station"] = Convert.ToString(rdr.GetSqlValue(5));
                Session["Receipt"] = Convert.ToString(rdr.GetSqlValue(6));

                //查找Station 权限
                string SQL_Station = "Select Station from ERS_Range where  User_Id ='" + uid + "'";

                using (SqlDataReader rdr_station = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Station))
                {
                    if (rdr_station.Read())
                    {
                        Session["Station"] = Convert.ToString(rdr_station.GetSqlValue(0));
                    }
                }


                //更新登录时间

                string SQL_update = " update ERS_User set Last_Login_Time='" + DateTime.Now.ToString() + "' where User_Id ='" + uid + "' and Password = '" + pwd + "'";

                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
                    if (actionrows > 0)
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");

                    }
                    else
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                    }
                }
                //写日志
                //string logdata = DateTime.Now.ToString() + " " + Session["UserID"].ToString() + " Login at " + IPaddress;
                //Write(logdata);
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
                parms[3].Value = "Login";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert,parms);
                    if (actionrows > 0)
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");

                    }
                    else
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                    }
                }

                //进入系统
                Server.Transfer("Home.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Login failed! Please check your UserName and Password.');</script>");

            }

        }


    }
}