using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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


    protected void Submit_Click(object sender, EventArgs e)
    {
        string uid = Request.Form["username"];
        string pwd = Request.Form["password"];
        string AccessRightSqlstr = "select a.* from ACARS_User a where username ='" + uid + "' and password = '" + pwd + "'";
        DataSet dscheck = SqlHelper.ExecuteDataset(SqlHelper.NX_APPconnectionString, CommandType.Text, AccessRightSqlstr);
        if (dscheck.Tables[0].Rows.Count > 0)
        {
            string IPaddress = HttpContext.Current.Request.UserHostAddress.ToString();
            string LoginWay = "";
            //if (Equals(IPaddress.Substring(0, 7), "192.168") || Equals(IPaddress, "::1"))
            //{
            //    LoginWay = "Intranet";
            //}
            //else
            //{
            //    LoginWay = "Extranet";
            //}

            string sqlstr = "select a.* from ACARS_User a where username ='" + uid + "' and password = '" + pwd + "'";
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.NX_APPconnectionString, CommandType.Text, sqlstr);
          
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["StaffID"] = ds.Tables[0].Rows[0]["username"].ToString().Trim();
                Session["StaffName"] = (Convert.ToString(ds.Tables[0].Rows[0]["SURNAME"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["FORENAME"]) + "," + Convert.ToString(ds.Tables[0].Rows[0]["PREFERRED"])).TrimEnd(',');
                string insertlog = DateTime.Now.ToString() + " " + Session["StaffID"].ToString() + " " + Session["StaffName"].ToString()+ " Login ";
               
               // int result = SqlHelper.ExecuteNonQuery(SqlHelper.NX_APPconnectionString, CommandType.Text, insertlog);
                Write(insertlog);
         
                Server.Transfer("Home.aspx");

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Login failed! Unauthorized access, please contact Administrator');</script>");

            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Login failed! Please check your Staff NO. and Password.');</script>");

        }

    }
}