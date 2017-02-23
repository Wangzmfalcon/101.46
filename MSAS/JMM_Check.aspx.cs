using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;

public partial class JMM_Check : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string stano = Request.Form["stano"].ToString();
        string reply = "";
        string SQL_JMM = "SELECT notJMM from MSAS_HRInfo where 1=1 and StaffID='"+stano+"'";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_JMM))
        {
            if (rdr.Read())
            {
                string a = Convert.ToString(rdr.GetSqlValue(0));
                if (Convert.ToString(rdr.GetSqlValue(0)) == "true" || Convert.ToString(rdr.GetSqlValue(0)) == "True" || Convert.ToString(rdr.GetSqlValue(0)) == "0")
                {
                    reply = "true";
                }

            }
            else
            {
                reply = "false";
            }
         
        }

        Response.Write(reply);
    }
}