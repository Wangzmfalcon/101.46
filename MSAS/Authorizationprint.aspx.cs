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
        string SQL_name = "select StaffName,License,(DATENAME(dd,a.LicenseExpired)+'-'+SUBSTRING(DATENAME(mm,a.LicenseExpired),0,4)+'-'+DATENAME(yyyy,a.LicenseExpired)),Category  "
              + " from MSAS_HRInfo a"
              + " where StaffID='" + StaffID + "'"
              + " and HRstatus='0'";//0是在职 ，1是离职





        using (SqlDataReader rdr = SqlHelper1.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_name))
        {
        
            if (rdr.Read())
            {

                string a = Convert.ToString(rdr.GetSqlValue(1));
                string b = Convert.ToString(rdr.GetSqlValue(2));
                if (Convert.ToString(rdr.GetSqlValue(1)) != "")
                {
                 Label1.Text = "MAR-66 " + Convert.ToString(rdr.GetSqlValue(1));//license
                Label4.Text = "MAR-66 " + Convert.ToString(rdr.GetSqlValue(1));//license
                
                }
                else 
                
                {   Label1.Text = "N/A";//license
                Label4.Text = "N/A";//license 
                }

                if (Convert.ToString(rdr.GetSqlValue(2)) != "Null")
                {
                    Label2.Text = Convert.ToString(rdr.GetSqlValue(2));//LicenseExpired
                    Label3.Text =  Convert.ToString(rdr.GetSqlValue(2));//LicenseExpired

                }
                else
                {
                    Label2.Text = "N/A";//LicenseExpired
                    Label3.Text = "N/A";//LicenseExpired 
                }
                  

                name.Text = Convert.ToString(rdr.GetSqlValue(0));//name
                name1.Text = Convert.ToString(rdr.GetSqlValue(0));//name



                if (Convert.ToString(rdr.GetSqlValue(3)) != "")
                {
                    Label5.Text = Convert.ToString(rdr.GetSqlValue(3));//Category
                    Label9.Text = Convert.ToString(rdr.GetSqlValue(3));//Category

                }
                else
                {
                    Label5.Text = "N/A";//Category
                    Label9.Text = "N/A";//Category
                }

             



                //Label2.Text = Convert.ToString(rdr.GetSqlValue(2));//LicenseExpired
                //Label3.Text = Convert.ToString(rdr.GetSqlValue(2));//LicenseExpired
                staffid.Text = "AM" + StaffID;//staffid
                staffid1.Text = "AM" + StaffID;//staffid
            }

        }
        //Authorization info

        string SQL_Auth = "select Project,Range,Level, isnull(stamp,''),replace(Convert(varchar(11),ExpireDate,106 ),' ','-') "
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
                row["ExpireDate"] = Convert.ToString(rdr.GetSqlValue(4));//ExpireDate

                dt.Rows.Add(row);

            }

        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {

            tc.Style.Add("word-break", "break-all");


        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {

            tc.Style.Add("word-break", "break-all");


        }
    }
}