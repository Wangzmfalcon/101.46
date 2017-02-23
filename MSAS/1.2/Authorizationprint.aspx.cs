using System;
using System.Collections.Generic;
using SMS.DBUtility;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userNo"] == null)
        {
            Response.Redirect("AuthorizationSelect.aspx");
        }
        string StaffID = Session["userNo"].ToString();


        //personal info
        string SQL_name = "select StaffName,License,LicenseExpired,Category  "
              + " from MSAS_HRInfo"
              + " where StaffID='" + StaffID + "'"
              + " and HRstatus='0'";//0是在职 ，1是离职





        using (SqlDataReader rdr = SqlHelper1.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_name))
        {

            if (rdr.Read())
            {
                Label1.Text = Convert.ToString(rdr.GetSqlValue(1));//name
                Label2.Text = Convert.ToString(rdr.GetSqlValue(0));//license
                Label3.Text = Convert.ToString(rdr.GetDateTime(2).ToShortDateString());//licenseexpiry
                Label9.Text = Convert.ToString(rdr.GetSqlValue(3));//licenseexpiry
                Label4.Text = "AM" + StaffID;//staffid
            }

        }
        //Authorization info

        string SQL_Auth = "select Project,Range,Level, isnull(stamp,''),ExpireDate "
         + " from MSAS_AuthorizationList "
          + " where StaffID='" + StaffID + "'"
          + " AND Vaild ='1'"//有效
          + " and Status<>'2'";//2是删除了的数据


        DataTable dt = new DataTable();
        dt.Columns.Add("Project", typeof(string));
        dt.Columns.Add("Range", typeof(string));
        dt.Columns.Add("Level", typeof(string));
        dt.Columns.Add("Stamp", typeof(string));
        dt.Columns.Add("ExpireDate", typeof(string));
        using (SqlDataReader rdr = SqlHelper1.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_Auth))
        {

            while (rdr.Read())
            {
                DataRow row = dt.NewRow();
                row["Project"] = Convert.ToString(rdr.GetSqlValue(0));//Project
                row["Range"] = Convert.ToString(rdr.GetSqlValue(1));//Range
                row["Level"] = Convert.ToString(rdr.GetSqlValue(2));//Level          
                row["Stamp"] = Convert.ToString(rdr.GetSqlValue(3));//Stamp
                row["ExpireDate"] = Convert.ToDateTime(rdr.GetDateTime(4)).ToShortDateString();//ExpireDate

                dt.Rows.Add(row);

            }

        }
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {

            tc.Style.Add("word-break", "break-all");


        }
    }

}