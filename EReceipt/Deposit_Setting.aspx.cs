using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;

public partial class Deposit_Setting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Manage_Level"] == null || Session["UserID"] == null || Session["Receipt"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else if (!IsPostBack)
        {
            string stationsession = Session["Station"].ToString();
            if (stationsession == "ALL")
            {
                string SQL_query0 = "select STATION from ERS_STATION ";
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

                string SQL_query0 = "select Station from ERS_Range where User_Id='" + Session["UserID"].ToString() + "'";
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query0))
                {
                    while (rdr.Read())
                    {
                        Station.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                    }

                }

            }


            if (Session["SELECTSTATION"] == null)
                getdate(Station.SelectedValue);
            else
            {
                Station.SelectedValue = Session["SELECTSTATION"].ToString();
                getdate(Session["SELECTSTATION"].ToString());
            }

        }
    }


    public void getdate(string Station)
    {


        //读取数据
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter("select Trans_Value,Trans_Order from ERS_Trans where Trans_Type='Deposit' and Trans_Station='" + Station + "'  order by Trans_Order", SqlHelper.Conn);
        sda.Fill(ds, "Deposit");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables["Deposit"].DefaultView;
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
        Deposit_table.DataSource = pds;
        Deposit_table.DataBind();
    }
    protected void save_Click(object sender, EventArgs e)
    {

        string Deposit_Type = Deposit.Text;


        //检查order是否是数字
        string flag = "Y";
        try
        {
            int Order_int = Convert.ToInt32(Order.Text);
        }
        catch
        {

            flag = "N";
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Order should be number.');</script>");
        }

        //检查是否存在
        string SQL_query = " select * from ERS_Trans where Trans_Value='" + Deposit_Type + "' and Trans_Station='" + Station.SelectedValue + "' and Trans_Type='Deposit'";

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {
            if (rdr.Read())
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Deposit_Type already exists.');</script>");
            }
            else if(flag=="Y")
            {
                //没有就插入
                string SQL_insert = " INSERT INTO ERS_Trans  (Trans_Type,Trans_Value,Trans_Order,Trans_Station) values (@Trans_Type,@Trans_Value,@Trans_Order,@Trans_Station)";
                SqlParameter[] parms = new SqlParameter[]{
                     new SqlParameter("@Trans_Type", SqlDbType.VarChar, 50),
                     new SqlParameter("@Trans_Value", SqlDbType.VarChar, 50),
                    new SqlParameter("@Trans_Order", SqlDbType.Int),
        new SqlParameter("@Trans_Station", SqlDbType.VarChar, 50)
               };
                parms[0].Value = "Deposit";
                parms[1].Value = Deposit_Type;
                parms[2].Value = Convert.ToInt16(Order.Text);
                parms[3].Value = Station.SelectedValue;
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert, parms);
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

        string Deposit_Type = Deposit.Text;
        string stationselect = Station.SelectedValue;

        string SQL_delete = " delete ERS_Trans where Trans_Value='" + Deposit_Type + "'and Trans_Station='" + stationselect + "'  and Trans_Type='Deposit' ";
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

    protected void Station_SelectedIndexChanged(object sender, EventArgs e)
    {

        Session["SELECTSTATION"] = Station.SelectedValue;
        getdate(Station.SelectedValue);
    }
}