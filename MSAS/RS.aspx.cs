using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
public partial class Home : System.Web.UI.Page
{

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["staffno"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {


            Label1.Text = "Welcome " + Session["staffname"].ToString();

            if (!IsPostBack)
            {
                string path = Server.MapPath(Request.ApplicationPath) + "/mail.ini";
                try
                {
                    StringBuilder totext = new StringBuilder(255);
                    int i = GetPrivateProfileString("mail", "l_ex", "", totext, 255, path);
                    TextBox1.Text = totext.ToString();
                    StringBuilder cctext = new StringBuilder(255);
                    int i1 = GetPrivateProfileString("mail", "a_ex", "", cctext, 255, path);
                    TextBox2.Text = cctext.ToString();
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('无法获取配置文件，请联系管理员');</script>");
                }


            }
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{

    //    string path = Server.MapPath(Request.ApplicationPath) + "/mail.ini";
    //    WritePrivateProfileString("mail", "to", TextBox1.Text, path);
    //    //string path = Server.MapPath(Request.ApplicationPath);
    //    //string s = TextBox1.Text;
    //    //File.WriteAllText(path + "/mail.ini",s);
    //    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('修改成功');</script>");
    //}

    protected void Button2_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath(Request.ApplicationPath) + "/mail.ini";
        WritePrivateProfileString("mail", "a_ex", TextBox2.Text, path);
        //string path = Server.MapPath(Request.ApplicationPath);
        //string s = TextBox1.Text;
        //File.WriteAllText(path + "/mail.ini",s);
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Modify success');</script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath(Request.ApplicationPath) + "/mail.ini";
        WritePrivateProfileString("mail", "l_ex", TextBox1.Text, path);
        //string path = Server.MapPath(Request.ApplicationPath);
        //string s = TextBox1.Text;
        //File.WriteAllText(path + "/mail.ini",s);
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Modify success');</script>");
    }
}