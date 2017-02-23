using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Diagnostics;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string uid = Request.Form["lgnm"];
        string pwd = Request.Form["pwd"];
        string AccessRightSqlstr = "select a.* from ACARS_User a where username ='" + uid + "' and password = '" + pwd + "'";
        DataSet dscheck = SqlHelper.ExecuteDataset(SqlHelper.NX_APPconnectionString, CommandType.Text, AccessRightSqlstr);
        if (dscheck.Tables[0].Rows.Count > 0)
        {
            string IPaddress = HttpContext.Current.Request.UserHostAddress.ToString();
            string LoginWay = "";
            if (Equals(IPaddress.Substring(0, 7), "192.168"))
            {
                LoginWay = "Intranet";
            }
            else
            {
                LoginWay = "Extranet";
            }

            string sqlstr = "select a.* from ACARS_User a where username ='" + uid + "' and password = '" + pwd + "'";
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.NX_APPconnectionString, CommandType.Text, sqlstr);
            string insertlog = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["staffno"] = ds.Tables[0].Rows[0]["username"].ToString().Trim();
                Session["staffname"] = (Convert.ToString(ds.Tables[0].Rows[0]["SURNAME"]) + " " + Convert.ToString(ds.Tables[0].Rows[0]["FORENAME"]) + "," + Convert.ToString(ds.Tables[0].Rows[0]["PREFERRED"])).TrimEnd(',');
                insertlog = "EXEC CreatUserLoginLog '" + ds.Tables[0].Rows[0]["username"].ToString().Trim() + "',"
                + "'" + IPaddress + "','','" + LoginWay + "'";
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.NX_APPconnectionString, CommandType.Text, insertlog);

                string Location = ds.Tables[0].Rows[0]["Location"].ToString().Trim();
                //string str2 = Location.Substring(0,3);
                //Session["Loca"] = str2;
                Server.Transfer("Main.aspx");
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



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SendEmail.aspx");
    }
}
