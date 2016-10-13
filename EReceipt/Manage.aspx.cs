using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
public partial class Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Manage_Level"] == null || Session["UserID"] == null || Session["Receipt"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else if(!IsPostBack)
        {
            //权限管理
            string stationsession = Session["Station"].ToString();
            string SQL_query0 = "";
            Station.Items.Add("");
            if (stationsession == "ALL")
            {


                SQL_query0 = "select STATION from ERS_STATION ";
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query0))
                {
                    while (rdr.Read())
                    {
                        Station.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                    }

                }
            }
            else
            {

                string SQL_Station = "Select Station from ERS_Range where  User_Id ='" + Session["UserID"].ToString() + "'";

                using (SqlDataReader rdr_station = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Station))
                {
                    while (rdr_station.Read())
                    {
                        Station.Items.Add(Convert.ToString(rdr_station.GetSqlValue(0)));
                    }
                }


            }
            //权限管理
            //string stationsession = Session["Station"].ToString();
            //if (stationsession != "ALL")
            //{
            //    Station.SelectedValue = stationsession;
            //    Station.Enabled = false;
            //    Station.BackColor = ColorTranslator.FromHtml("#f9f9f9");
            //}


            Sales.Items.Add("");
            string SQL_query = "select Trans_Value from ERS_Trans where Trans_Type='Sales'  order by Trans_Order";         
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
            {
                while (rdr.Read())
                {
                    Sales.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                }

            }

            Deposit.Items.Add("");
            string SQL_query1 = "select Trans_Value from ERS_Trans where Trans_Type='Deposit'  order by Trans_Order";           
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query1))
            {
                while (rdr.Read())
                {
                    Deposit.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                }

            }


            getdata();

        }
    }


    public void getdata()
    {
        //权限管理
        string stationsession = Session["Station"].ToString();
        string sql_query = "select A.*,CONVERT(varchar(100), A.Issue_Date, 103) As Issue  from ERS_Receipt A ";
        sql_query += " where 1=1   ";
        if (Station.Text != "" && Station.Text != null)
        {

            sql_query += " and  Station='" + Station.Text + "'";
        }



        if (Num.Text != "" && Num.Text != null)
        {

            sql_query += " and  Num='" + Num.Text + "'";
        }


        if (Issue_Date.Text != "" && Issue_Date.Text != null)
        {

            sql_query += " and  Issue_Date='" + Issue_Date.Text + "'";
        }


        if (Received.Text != "" && Received.Text != null)
        {

            sql_query += " and  Received='" + Received.Text + "'";
        }

        if (Balance.Text != "" && Balance.Text != null)
        {

            sql_query += " and  Balance='" + Balance.Text + "'";
        }

        if (Sales.Text != "" && Sales.Text != null)
        {

            sql_query += " and  Sales='" + Sales.Text + "'";
        }
        if (Deposit.Text != "" && Deposit.Text != null)
        {

            sql_query += " and  Deposit='" + Deposit.Text + "'";
        }

        sql_query+=" order by id  DESC";
        //读取数据
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(sql_query, SqlHelper.Conn);
        sda.Fill(ds, "Receipt");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables["Receipt"].DefaultView;
        pds.AllowPaging = true;//允许分页
        pds.PageSize = 5;//单页显示项数
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
        Receipt_table.DataSource = pds;
        Receipt_table.DataBind();
    
    }




    protected void Search_Click(object sender, EventArgs e)
    {
        getdata();
    }
}