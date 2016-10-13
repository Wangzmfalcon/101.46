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

public partial class changepassword : System.Web.UI.Page
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
    protected void login_Click(object sender, EventArgs e)
    {
        string uid = lgnm.Text;
        string opwd = oldpwd.Text;
        string npwd = newpwd.Text;
        string npwd2 = newpwd2.Text;
        if (uid == "" || opwd == "" || npwd == "" || npwd2 == "")
        { 
            //Response.Write("<script>alert('Please fill in the information .')</script>");
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please fill in the information .');</script>");
        }
        else if (uid != Session["User_ID"].ToString() || opwd != Session["User_PWD"].ToString())
        { 
            //Response.Write("<script>alert('Wrong useID or password .')</script>"); 
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Wrong useID or password .');</script>");
        }
        else if (npwd != npwd2)
        { 
            //Response.Write("<script>alert('Two passwords are not the same .')</script>"); 
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Two passwords are not the same .');</script>");
        }
        else if (npwd == opwd)
        { 
            //Response.Write("<script>alert('Password can not the same as the old one .')</script>");
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Password can not the same as the old one .');</script>");
        }
        else
        {
            string SQL_ChangePWD =
           "update   User_info set   User_info.User_PWD =@userpwd where   User_info.User_ID =@userid";
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@userpwd", SqlDbType.VarChar, 50),
                new SqlParameter("@userid", SqlDbType.VarChar, 50)
            };
            parm[0].Value = npwd;
            parm[1].Value = uid;


            SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_ChangePWD, parm);


            
            Response.Write("<script>alert('Password has been changed , please log in  again .')</script>");
            //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Password has been changed , please log in  again .');</script>");
 
            Response.Write("<script  language='javascript'>window.location='Default.aspx'</script>");
        }


    }
}