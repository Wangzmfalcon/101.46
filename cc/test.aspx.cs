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


        //if (!Page.IsPostBack)
        //{ 
        //  string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info where Crew_Info.Rcd_Status ='NEW'"
        //          + " order by Crew_Info.Staff_No";


        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("StaffNo(StaffName)", typeof(string));
        //    using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Staff))
        //    {
        //        while (rdr.Read())
        //        {
        //            DataRow row = dt.NewRow();
        //            row["StaffNo(StaffName)"] = Convert.ToString(rdr.GetSqlValue(0)) + "(" + Convert.ToString(rdr.GetSqlValue(1)) + ")";


        //            dt.Rows.Add(row);
        //        }

        //    }

        //    this.CheckBoxList1.DataSource = dt;
        //    this.CheckBoxList1.DataTextField = "StaffNo(StaffName)";
        //    this.CheckBoxList1.DataValueField = "StaffNo(StaffName)";
        //    this.CheckBoxList1.DataBind();
        //}

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
}