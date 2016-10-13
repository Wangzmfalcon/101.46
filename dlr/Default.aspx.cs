using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using SMS.DBUtility;
using System.Data;
using System.Data.OleDb;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        pwd.Text = string.Empty;
    }
    protected void login_Click(object sender, EventArgs e)
    {
        string uid = Request.Form["lgnm"];
        string pwd = Request.Form["pwd"];

        string SQL_Login =
            "select * from User_Info where User_ID =@userid COLLATE  Chinese_PRC_CS_AS and User_Enable='1' ";
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@userid", SqlDbType.VarChar, 50)
            };
        parm[0].Value = uid;
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL_Login, parm))
        {
            if (rdr.Read())
            {
                Session["User_ID"] = rdr["User_ID"].ToString();
                Session["User_PWD"] = rdr["User_PWD"].ToString();
                Session["User_Name"] = rdr["User_Name"].ToString();

                if (pwd == Session["User_PWD"].ToString())
                    Response.Redirect("Home.aspx");
                else
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Wrong password. Please contact administrator.');</script>");


            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Unauthorized user. Please contact administrator.');</script>");
            }
        }

    }
}