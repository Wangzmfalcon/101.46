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
public partial class Position : System.Web.UI.Page
{
    public string userstring = "";
    DataTable dtranglist = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        userstring = Request["user"];
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
            this.titlelist.DataSource = dt;
            this.titlelist.DataBind();




      


        }




    }




    public string trstyle(int i)
    {

        string ret_s = "";
        if (findrangelist(Eval("Position").ToString()))
            ret_s = "<div style=\"width:400px\"><input name=\"items\" checked=\"true\" type=\"checkbox\" id=\"CheckBox" + Eval("Position") + "\" />" + Eval("Position") + " </div>";
        else
            ret_s = "<div style=\"width:400px\"><input name=\"items\" type=\"checkbox\" id=\"CheckBox" + Eval("Position") + "\" />" + Eval("Position") + " </div>";


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

    protected void savedateClick(object sender, EventArgs e)
    {
        //删除以往记录
        string SQL_update = " delete MSAS_Position_S where StaffID='" + userstring + "'";

        using (SqlConnection conn = new SqlConnection(SqlHelper1.Conn))
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
        //插入新记录
        string rangetext = Request.Form["savetxt"];   
        string[] sArray = rangetext.Split('|');
       
        for (int i = 0; i < sArray.Length; i++)
        {

            if (sArray[i] != "")
            {
                string key = sArray[i].Replace("CheckBox", "");

                string SQL_insert = "  INSERT INTO  MSAS_Position_S (StaffID,Position) values (@StaffID,@Position)";

                SqlParameter[] parms = new SqlParameter[]{
                     new SqlParameter("@StaffID",  SqlDbType.VarChar, 50),
                     new SqlParameter("@Position", SqlDbType.VarChar, 50)
      
               };
                parms[0].Value = userstring;
                parms[1].Value = key;
                using (SqlConnection conn = new SqlConnection(SqlHelper1.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert, parms);
                    if (actionrows > 0)
                    {
                       // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data success');</script>");

                  
                    }
                    else
                    {
                       // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data faild');</script>");
                    }
                }


            }
      

        }
        //Response.Redirect("Staffin.aspx");
        Response.AddHeader("Refresh", "0");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");

    }
}