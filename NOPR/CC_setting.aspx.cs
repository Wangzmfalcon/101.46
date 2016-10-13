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

public partial class CC_setting : System.Web.UI.Page
{
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin_Level"] == null || Session["NOPRUserID"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else
        {

            if (!IsPostBack)
            {
                string path = Server.MapPath(Request.ApplicationPath) + "/mail.ini";
                try
                {

                    StringBuilder cctext = new StringBuilder(255);
                    int i1 = GetPrivateProfileString("mail", "cc", "", cctext, 255, path);
                    TextBox1.Text = cctext.ToString();
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('无法获取配置文件，请联系管理员');</script>");
                }


            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath(Request.ApplicationPath) + "/mail.ini";
        WritePrivateProfileString("mail", "cc", TextBox1.Text, path);
        //string path = Server.MapPath(Request.ApplicationPath);
        //string s = TextBox1.Text;
        //File.WriteAllText(path + "/mail.ini",s);
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Edit success');</script>");

    }
}