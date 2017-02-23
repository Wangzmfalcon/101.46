using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;
using System.IO;
using System.Globalization;//日期格式化
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;



public partial class Main : System.Web.UI.Page
{
    DataTable dtranglist = new DataTable();
    public string userstring = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        userstring = Request["userid"];
   
        if (Session["staffno"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Label1.Text = "Welcome " + Session["staffname"].ToString();
            SqlDataAdapter psd = new SqlDataAdapter("select Position  from MSAS_Position_S  where StaffID='" + userstring + "'  ", SqlHelper1.Conn);
            psd.Fill(dtranglist);

            //position
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select id,Position  from MSAS_Position   order by id", SqlHelper1.Conn);
            sda.Fill(dt);
            this.positionlist.DataSource = dt;
            this.positionlist.DataBind();
        }


    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");

    }


    public string positionstyle(int i)
    {
        string ret_s = "<tr>";

        if (findrangelist(Eval("Position").ToString()))
        {
            ret_s = "<td class=\"td20\"><input name=\"items\" checked=\"true\" type=\"checkbox\" id=\"CheckBox" + Eval("Position") + "\" /></td><td class=\"td80\">" + Eval("Position") + " </td>";
        }
        else
        {
            ret_s = "<td class=\"td20\"><input name=\"items\" type=\"checkbox\" id=\"CheckBox" + Eval("Position") + "\" /></td><td class=\"td80\">" + Eval("Position") + " </td>";
        }

        ret_s = ret_s + "<td class=\"td20\"><input name=\"items1\" type=\"checkbox\" id=\"CheckBoxx" + Eval("Position") + "\" /></td><td class=\"td80\">" + Eval("Position") + " </td>";
        ret_s =ret_s+ "</tr>";
        return ret_s;

    }


    public bool findrangelist(string title)
    {
        bool result = false;

        for (int i = 0; i < dtranglist.Rows.Count; i++)
        {
            if (title == dtranglist.Rows[i][0].ToString())
            {
                result = true;
            }

        }

        return result;
    }
}