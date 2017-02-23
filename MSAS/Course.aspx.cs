using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;


public partial class Course : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {



        if (Session["staffno"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Label1.Text = "Welcome " + Session["staffname"].ToString();

            SqlConnection conn = new SqlConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("select id,Course  from MSAS_Course   order by id", SqlHelper1.Conn);
            sda.Fill(ds, "Course");
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables["Course"].DefaultView;
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
            Position_table.DataSource = pds;
            Position_table.DataBind();
        }
      

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
        
    }

    protected void save_Click(object sender, EventArgs e)
    {
        string flag = "Y";
        try
        {
            int Order_int = Convert.ToInt32(Course_id.Text);


            //检查是否存在
            string SQL_insert = "  INSERT INTO  MSAS_Course (id,Course) values (@id,@Position)";

            SqlParameter[] parms = new SqlParameter[]{
                     new SqlParameter("@id",  SqlDbType.Int),
                     new SqlParameter("@Position", SqlDbType.VarChar, 50)
      
               };
            parms[0].Value = Course_id.Text;
            parms[1].Value = Course_name.Text;
            using (SqlConnection conn = new SqlConnection(SqlHelper1.Conn))
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
        catch
        {

            flag = "N";
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Id should be number.');</script>");
        }
      
    }
    protected void delete_Click(object sender, EventArgs e)
    {
        string SQL_delete = " delete MSAS_Course where id='" + Course_id.Text + "'  ";
        using (SqlConnection conn = new SqlConnection(SqlHelper1.Conn))
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