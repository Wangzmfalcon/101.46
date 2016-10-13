using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


public partial class void_receipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.Form["id"].ToString();


        string SQL_update = " update ERS_Receipt set void='1' where id='" + id + "'";


        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
            if (actionrows > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");
                Response.Write("Void success");
                writelog("Void,Station:id" + id);
            }
            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                Response.Write("Void faild");
            }
        }

     
    }




    public void writelog(string logtext)
    {
        string SQL_insert = "INSERT INTO ERS_Log (User_Id,Log_Time,Log_IP,Sys_Log) values(@User_Id,@Log_Time,@Log_IP,@Sys_Log)";
        SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@User_Id", SqlDbType.VarChar, 50),
                    new SqlParameter("@Log_Time", SqlDbType.DateTime),
                    new SqlParameter("@Log_IP", SqlDbType.VarChar, 50),
                    new SqlParameter("@Sys_Log", SqlDbType.VarChar, 100),
   
                 };
        parms[0].Value = Session["UserID"].ToString();
        parms[1].Value = DateTime.Now;
        parms[2].Value = Session["IP"].ToString();
        parms[3].Value = logtext;
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert, parms);
            if (actionrows > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");

            }
            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
            }
        }

    }
}