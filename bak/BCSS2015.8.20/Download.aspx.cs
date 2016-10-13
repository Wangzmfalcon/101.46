using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Drawing;
using System.IO;

public partial class Home : System.Web.UI.Page
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
    protected void download1_Click(object sender, EventArgs e)
    {
       
        //查询数据
        string SQL = "  SELECT  SEQ,USER_ID,CREAT_TIME,STATION,STAFF_NO,FLIGHT_NO,DEP_DT"
            + "    ,SEAT_NUM,REASON,MEMBER,NATIONALITY,AGE,GENDER,CITY "
            + "    ,VAL_01,VAL_02,VAL_03,VAL_04,VAL_05,VAL_06,VAL_07 "
            + "    ,VAL_08,VAL_09,VAL_10,VAL_11,VAL_12,VAL_13,LCHAR01 "
            + "    FROM BCSS_DATE "
            + "   where STATUS='NEW' "
            + "   and (CAST(DEP_DT AS date) between '" + from.Value + "' and '" + to.Value + "')";

        //存放数据的dt
        DataTable dt = new DataTable();
        dt.Columns.Add("SEQ", typeof(string));
        dt.Columns.Add("USER_ID", typeof(string));
        dt.Columns.Add("CREAT_TIME", typeof(string));
        dt.Columns.Add("STATION", typeof(string));
        dt.Columns.Add("STAFF_NO", typeof(string));
        dt.Columns.Add("FLIGHT_NO", typeof(string));
        dt.Columns.Add("DEP_DT", typeof(string));
        dt.Columns.Add("SEAT_NUM", typeof(string));
        dt.Columns.Add("REASON", typeof(string));
        dt.Columns.Add("MEMBER", typeof(string));
        dt.Columns.Add("NATIONALITY", typeof(string));
        dt.Columns.Add("AGE", typeof(string));
        dt.Columns.Add("GENDER", typeof(string));
        dt.Columns.Add("CITY", typeof(string));
        dt.Columns.Add("VAL_01", typeof(string));
        dt.Columns.Add("VAL_02", typeof(string));
        dt.Columns.Add("VAL_03", typeof(string));
        dt.Columns.Add("VAL_04", typeof(string));
        dt.Columns.Add("VAL_05", typeof(string));
        dt.Columns.Add("VAL_06", typeof(string));
        dt.Columns.Add("VAL_07", typeof(string));
        dt.Columns.Add("VAL_08", typeof(string));
        dt.Columns.Add("VAL_09", typeof(string));
        dt.Columns.Add("VAL_10", typeof(string));
        dt.Columns.Add("VAL_11", typeof(string));
        dt.Columns.Add("VAL_12", typeof(string));
        dt.Columns.Add("VAL_13", typeof(string));
        dt.Columns.Add("LCHAR01", typeof(string));
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL))
        {

            while (rdr.Read())
            {
                DataRow row = dt.NewRow();
                row["SEQ"] = Convert.ToString(rdr.GetSqlValue(0));
                row["USER_ID"] = Convert.ToString(rdr.GetSqlValue(1));
                row["CREAT_TIME"] = Convert.ToString(rdr.GetSqlValue(2));
                row["STATION"] = Convert.ToString(rdr.GetSqlValue(3));
                row["STAFF_NO"] = Convert.ToString(rdr.GetSqlValue(4));
                row["FLIGHT_NO"] = Convert.ToString(rdr.GetSqlValue(5));
                row["DEP_DT"] = Convert.ToString(rdr.GetSqlValue(6));
                row["SEAT_NUM"] = Convert.ToString(rdr.GetSqlValue(7));
                row["REASON"] = Convert.ToString(rdr.GetSqlValue(8));
                row["MEMBER"] = Convert.ToString(rdr.GetSqlValue(9));
                row["NATIONALITY"] = Convert.ToString(rdr.GetSqlValue(10));
                row["AGE"] = Convert.ToString(rdr.GetSqlValue(11));
                row["GENDER"] = Convert.ToString(rdr.GetSqlValue(12));
                row["CITY"] = Convert.ToString(rdr.GetSqlValue(13));
                row["VAL_01"] = Convert.ToString(rdr.GetSqlValue(14));
                row["VAL_02"] = Convert.ToString(rdr.GetSqlValue(15));
                row["VAL_03"] = Convert.ToString(rdr.GetSqlValue(16));
                row["VAL_04"] = Convert.ToString(rdr.GetSqlValue(17));
                row["VAL_05"] = Convert.ToString(rdr.GetSqlValue(18));
                row["VAL_06"] = Convert.ToString(rdr.GetSqlValue(19));
                row["VAL_07"] = Convert.ToString(rdr.GetSqlValue(20));
                row["VAL_08"] = Convert.ToString(rdr.GetSqlValue(21));
                row["VAL_09"] = Convert.ToString(rdr.GetSqlValue(22));
                row["VAL_10"] = Convert.ToString(rdr.GetSqlValue(23));
                row["VAL_11"] = Convert.ToString(rdr.GetSqlValue(24));
                row["VAL_12"] = Convert.ToString(rdr.GetSqlValue(25));
                row["VAL_13"] = Convert.ToString(rdr.GetSqlValue(26));
                row["LCHAR01"] = Convert.ToString(rdr.GetSqlValue(27));

                dt.Rows.Add(row);
            }
        }


        //插入 gridview
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //下载
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("Input.xls", Encoding.UTF8).ToString());
        Response.ContentType = "application/ms-excel";
        this.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        GridView1.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }

    //下载需要
    public override void VerifyRenderingInServerForm(Control control)
    {

 

    }


  

}