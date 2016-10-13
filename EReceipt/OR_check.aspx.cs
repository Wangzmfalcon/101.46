using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class OR_check : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
        string OR_num = Request.Form["OR"].ToString();
        string Station = Request.Form["Station"].ToString();
        string reply="";
        string type = "";
        string offs = "";
        string currency = "";
        string SQL_balance = "select A.Balance,A.offs,A.Total_amt,A.currency from ERS_Receipt A where A.Station='" + Station + "'and A.Num='" + OR_num + "'  and void=0 ";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_balance))
        {
            if (rdr.Read())
            {
                type = "0";//有该OR
                reply = Convert.ToString(rdr.GetSqlValue(2));
                offs = Convert.ToString(rdr.GetSqlValue(1));
                currency = Convert.ToString(rdr.GetSqlValue(3));
            }
            else
            {
                type = "1";//查不到OR
                reply = "can not found";
                currency = "0";
            }
            
        }

        if (offs == "True" || offs == "1")
        {
            type = "2";//被使用过
           
        }

        reply = type + "|" + currency + "|" + reply;
        Response.Write(reply);
    }
}