using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;


public partial class Training_Records_Print : System.Web.UI.Page
{
    public int count = 0;
    public int total = 1;
    public int remainder = 0;
    public DataTable dt = new DataTable();
    public string staffname = "";
    public string staffid = "";
    public string title = "";
    public string datejoin = "";
    public string div = "";
    public string birthdate = "";
    public string license = "";
    public string licenseexpiry = "";
    public int pagesize = 10;
    public string today = DateTime.Now.ToString("dd-MMM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

    protected void Page_Load(object sender, EventArgs e)
    {

        string staffno = Request.QueryString["staffno"];


        //getpersonal  info

        string SQL_query_all = "SELECT A.StaffName,A.StaffID,A.Title,A.DateOfJoin,A.Division,A.Birthdate,A.License,A.LicenseExpired  from MSAS_HRInfo A where StaffID='" + staffno + "' ";

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_query_all))
        {
            if (rdr.Read())
            {
                staffname = Convert.ToString(rdr.GetSqlValue(0));
                staffid = "AM" + Convert.ToString(rdr.GetSqlValue(1));
                title = Convert.ToString(rdr.GetSqlValue(2));

                if (Convert.ToString(rdr.GetSqlValue(3)) == "Null" || Convert.ToString(rdr.GetSqlValue(3)) == "NULL")
                    datejoin = "";
                else
                    datejoin = Convert.ToDateTime(Convert.ToString(rdr.GetSqlValue(3))).ToString("dd-MMM-yyyy",System.Globalization.DateTimeFormatInfo.InvariantInfo);

                div = Convert.ToString(rdr.GetSqlValue(4));

                if (Convert.ToString(rdr.GetSqlValue(5)) == "Null" || Convert.ToString(rdr.GetSqlValue(5)) == "NULL")
                    birthdate = "";
                else
                    birthdate = Convert.ToDateTime(Convert.ToString(rdr.GetSqlValue(5))).ToString("dd-MMM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                license = Convert.ToString(rdr.GetSqlValue(6));

                if (Convert.ToString(rdr.GetSqlValue(7)) == "Null" || Convert.ToString(rdr.GetSqlValue(7)) == "NULL")
                    licenseexpiry = "";
                else
                    licenseexpiry = Convert.ToDateTime(Convert.ToString(rdr.GetSqlValue(7))).ToString("dd-MMM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);


            }
        }


        dt.Columns.Add("Class Name");
        dt.Columns.Add("Course Ref");
        dt.Columns.Add("Training Date");
        dt.Columns.Add("Training Method");
        dt.Columns.Add("Duation");
        dt.Columns.Add("Location");
        dt.Columns.Add("Training Organization");
        string SQL_Training_History = " select A.Class_Name,A.Course_Ref,(DATENAME(dd,A.Training_Date)+'-'+SUBSTRING(DATENAME(mm,A.Training_Date),0,4)+'-'+DATENAME(yyyy,A.Training_Date) ),A.Training_type1,A.Training_Time,A.Location,A.Training_Organization"
            + " from MSAS_Class_Historyl_VW A where 1=1 and A.StaffID='" + staffno + "' order by A.Training_Date desc";

        using (SqlDataReader rdr_his = SqlHelper.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_Training_History))
        {
            while (rdr_his.Read())
            {
                DataRow newrow = dt.NewRow();
                newrow["Class Name"] = Convert.ToString(rdr_his.GetSqlValue(0));
                newrow["Course Ref"] = Convert.ToString(rdr_his.GetSqlValue(1));
                //newrow["Training Date"] = Convert.ToDateTime(Convert.ToString(rdr_his.GetSqlValue(2))).ToString("yyyy-MM-dd");
                newrow["Training Date"] = Convert.ToString(rdr_his.GetSqlValue(2));
                newrow["Training Method"] = Convert.ToString(rdr_his.GetSqlValue(3));
                newrow["Duation"] = Convert.ToString(rdr_his.GetSqlValue(4)) + "Hrs";
                newrow["Location"] = Convert.ToString(rdr_his.GetSqlValue(5));
                newrow["Training Organization"] = Convert.ToString(rdr_his.GetSqlValue(6));
                dt.Rows.Add(newrow);
            }
        }



        total = dt.Rows.Count;

        remainder = total % pagesize;
        if (remainder == 0)
        {
            count = total / pagesize;
        }
        else
        {

            count = total / pagesize + 1;
        }




    }
}