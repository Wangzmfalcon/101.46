using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;

public partial class Station_Setting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Manage_Level"] == null || Session["UserID"] == null || Session["Receipt"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else
        {
            //读取数据
            SqlConnection conn = new SqlConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("select * from ERS_STATION", SqlHelper.Conn);
            sda.Fill(ds, "Station");
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables["Station"].DefaultView;
            pds.AllowPaging = true;//允许分页
            pds.PageSize = 10;//单页显示项数
            int CurPage;
            if (Request.QueryString["Page"] != null)
                CurPage = Convert.ToInt32(Request.QueryString["Page"]);
            else
                CurPage = 1;
            pds.CurrentPageIndex = CurPage - 1;
            int Count = pds.PageCount;
            lblCurrentPage.Text = "Current Page：" + CurPage.ToString();
            labPage.Text = Count.ToString();
            if (Count > 1)
            {
                this.first.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=1";
                this.last.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(Count);
            }
            if (!pds.IsFirstPage)
            {

                up.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1);
            }

            if (!pds.IsLastPage)
            {

                next.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage + 1);
            }


            //Repeater
            Station.DataSource = pds;
            Station.DataBind();
        }
    }
    protected void save_Click(object sender, EventArgs e)
    {

        string station = STATION_ID.Text;
        string station_code = STATION_CODE.Text;
        string station_name = STATION_NAME.Text;

        //检查是否存在
        string SQL_query = " select * from ERS_STATION where STATION='" + station + "'";

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {
            if (rdr.Read())
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Station already exists.');</script>");
            }
            else
            {
                //没有就插入
                string SQL_insert = " INSERT INTO ERS_STATION  (STATION,STATION_CODE,STATION_NAME) values (@STATION , @STATION_CODE ,@STATION_NAME)";
                SqlParameter[] parms = new SqlParameter[]{
                     new SqlParameter("@STATION", SqlDbType.VarChar, 50),
                     new SqlParameter("@STATION_CODE", SqlDbType.VarChar, 50),
                     new SqlParameter("@STATION_NAME", SqlDbType.VarChar, 50),
   
               };
                parms[0].Value = station;
                parms[1].Value = station_code;
                parms[2].Value = station_name;

                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert,parms);
                    if (actionrows > 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data success');</script>");
                        Response.AddHeader("Refresh", "0");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data faild');</script>");
                    }
                }
            }

        }


    }
    protected void delete_Click(object sender, EventArgs e)
    {
        string id = ID.Text;
        string station = STATION_ID.Text;
        string station_code = STATION_CODE.Text;
        string station_name = STATION_NAME.Text;

        string SQL_delete = " delete ERS_STATION where id='" + id + "' ";
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_delete);
            if (actionrows > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");
                Response.AddHeader("Refresh", "0");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
            }
        }

    }
}