using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;
public partial class User_Setting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin_Level"] == null || Session["NOPRUserID"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else
        {
            //读取数据

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("select * from NOPR_User", SqlHelper.Conn);
            sda.Fill(ds, "User");
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables["User"].DefaultView;
            pds.AllowPaging = true;//允许分页
            pds.PageSize =10;//单页显示项数
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
            User.DataSource = pds;
            User.DataBind();

            if (!IsPostBack)
            {
                Level.Items.Clear();
                Level.Items.Add("Admin");
                Level.Items.Add("User");
            }
        
        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        string id = UserID.Text;


        //检查是否存在
        string SQL_query = " select * from NOPR_User where NOPR_UserName='" + id + "'";

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {
            if (rdr.Read())
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Login Name already exists.');</script>");
            }
            else
            {
                //没有就插入
                string SQL_insert = " INSERT INTO NOPR_User  (NOPR_UserName,NOPR_Admin_Level,Email) values (@NOPR_UserName , @NOPR_Admin_Level ,@Email)";
                SqlParameter[] parms = new SqlParameter[]{
                     new SqlParameter("@NOPR_UserName", SqlDbType.VarChar, 50),
                     new SqlParameter("@NOPR_Admin_Level", SqlDbType.VarChar, 50),
                     new SqlParameter("@Email", SqlDbType.VarChar, 50),
           
               };
                parms[0].Value = id;
                parms[1].Value = Level.Text;
                parms[2].Value = Email.Text;
          

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
    protected void Edit_Click(object sender, EventArgs e)
    {
        //更新
        string SQL_insert = " UPDATE NOPR_User  set NOPR_Admin_Level=@NOPR_Admin_Level,Email=@Email where NOPR_UserName=@NOPR_UserName";
        SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@NOPR_UserName", SqlDbType.VarChar, 50),
                     new SqlParameter("@NOPR_Admin_Level", SqlDbType.VarChar, 50),
                     new SqlParameter("@Email", SqlDbType.VarChar, 50),
               };
        parms[0].Value = UserID.Text;
        parms[1].Value = Level.Text;
        parms[2].Value = Email.Text;

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert, parms);
            if (actionrows > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Update data success');</script>");
                Response.AddHeader("Refresh", "0");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Update data faild');</script>");
            }
        }
    }
    protected void delete_Click(object sender, EventArgs e)
    {
        string id = UserID.Text;


        string SQL_delete = " delete NOPR_User where NOPR_UserName='" + id + "' ";
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