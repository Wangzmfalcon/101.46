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

public partial class WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userid = Session["User_ID"].ToString();

        string SQL =
            "select * from BCSS_REPORT where USERID =@userid COLLATE  Chinese_PRC_CS_AS  and  REPORTID=@reportid ";
        SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@userid", SqlDbType.VarChar, 50),
                new SqlParameter("@reportid", SqlDbType.VarChar, 50)
            };
            //删除页面  DEL权限
        parm[0].Value = userid;
        parm[1].Value = "DEL";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL, parm))
        {
            if (rdr.Read())
            {
            }
            else
            {
                delete.Visible = false;
            }
        }



        //下载页面DOWN权限
        parm[0].Value = userid;
        parm[1].Value = "DOWN";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL, parm))
        {
            if (rdr.Read())
            {
            }
            else
            {
                download.Visible = false;
            }
        }


        //Report权限
        for (int i = 1; i <= 13; i++)
        {
            if (getright(Session["User_ID"].ToString(), i.ToString().Trim()) == false)
            {
                LinkButton lib = (LinkButton)FindControl("LinkButton"+i.ToString().Trim());
                lib.Visible = false;
            }
       
        }

    }

    public bool getright(string userid, string reportid)
    {
        bool permission = false;
        string SQL = "select 'X' from BCSS_REPORT WHERE USERID='" + userid + "'  AND REPORTID='" + reportid + "'";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL))
        {
            if (rdr.Read())
            {
                permission = true;
            }
            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Unauthorized user. Please contact administrator.');</script>");
            }
        }
        return permission;

    }

}