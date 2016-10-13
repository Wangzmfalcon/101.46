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
        string userid = Request.Form["userid"].ToString();
        string cmd = Request.Form["cmd"].ToString();
        string selectstring = Request.Form["select"].ToString();

        switch (cmd)
        {

            case "Add":

                //先删除
                string SQL_Del1 = " delete ERS_Range  where User_Id='" + userid + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Del1);


                    if (actionrows > 0)
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");
                        Response.Write("true");
                        writelog("Delete User:" + userid);
                    }
                    else
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                        Response.Write("false");
                    }


                }




                //再添加
                string[] stationword = selectstring.Split(',');

                for (int i = 0; i <= stationword.Length - 1; i++)
                {
                    string SQL_insert = "INSERT INTO ERS_Range (User_Id,Station) values (@User_Id,@Station) ";

                    SqlParameter[] parms = new SqlParameter[]{
                     new SqlParameter("@User_Id", SqlDbType.VarChar, 50),
                     new SqlParameter("@Station", SqlDbType.VarChar, 50)
                 };
                    parms[0].Value = userid;
                    parms[1].Value = stationword[i];

                    using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                    {
                        int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert, parms);
                        if (actionrows > 0)
                        {
                            //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data success');</script>");
                            //Response.AddHeader("Refresh", "0");
                            Response.Write("true");
                            writelog("Add User:" + userid);
                        }
                        else
                        {
                            Response.Write("false");
                            //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data faild');</script>");
                        }
                    }



                }





                break;

            case "Get":
                string return_text = "";
                string SQL_query0 = "select Station from ERS_Range where User_Id='" + userid + "'";
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query0))
                {
                    while (rdr.Read())
                    {
                        return_text = return_text + Convert.ToString(rdr.GetSqlValue(0)) + "|";
                    }

                }
                if (return_text.Length != 0)
                {
                    return_text = return_text.Remove(return_text.LastIndexOf("|"), 1);
                }

                Response.Write(return_text);


                break;
            case "Del":

                string SQL_Del = " delete ERS_Range  where User_Id='" + userid + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Del);


                    if (actionrows > 0)
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");
                        Response.Write("true");
                        writelog("Delete User:" + userid);
                    }
                    else
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                        Response.Write("false");
                    }


                }
                break;
            default:
                break;



        }


        //string SQL_update = " update ERS_Receipt set void='1' where id='" + id + "'";


        //using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        //{
        //    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update);
        //    if (actionrows > 0)
        //    {
        //        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");
        //        Response.Write("Void success");
        //        writelog("Void,Station:id" + id);
        //    }
        //    else
        //    {
        //        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
        //        Response.Write("Void faild");
        //    }
        //}


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