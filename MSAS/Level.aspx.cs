using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Level : System.Web.UI.Page
{
    string sqlstr = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["staffno"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

    }
    private void GetData()
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select * from MSAS_Level";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                adapter.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                Lab_PageCount.Text = "Current " + (GridView1.PageIndex + 1).ToString() + " Page";
                //用LblPageCount来显示当前数据的总页数。   
                Lab_CurrentPage.Text = "Total " + GridView1.PageCount.ToString() + " Page";
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlcnn1 = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm1 = sqlcnn1.CreateCommand())
            {
                sqlcmm1.CommandText = "select Level from MSAS_Level where Level='" + txtName.Text + "'";
                DataTable dt1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlcmm1);
                adapter1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                }
                else
                {
                    string max = "";
                    using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
                    {
                        using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                        {
                            sqlcmm.CommandText = "select max(ID) as ID1 from MSAS_Level";
                            sqlcmm.Parameters.AddWithValue("@MSAS_Title", this.txtName.Text);
                            sqlcnn.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows[0][0].ToString() != "")
                            {
                                max = dt.Rows[0][0].ToString();
                            }
                            else
                            {
                                max = DateTime.Now.Year + "0000";
                            }

                        }
                    }

                    int startNum = Convert.ToInt32(max.Substring(4, 4)) + 1;
                    string startString = null;
                    if (startNum < 10)
                    {
                        startString = "000" + startNum;
                    }
                    else if (startNum >= 10 && startNum < 100)
                    {
                        startString = "00" + startNum;
                    }
                    else
                    {
                        startString = startNum.ToString();
                    }
                    string endString = DateTime.Now.Year + startString;
                    int num = Convert.ToInt32(endString);
                    using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
                    {
                        using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                        {
                            sqlcmm.CommandText = "insert into MSAS_Level(Level,ID)values(@title,@ID)";
                            sqlcmm.Parameters.AddWithValue("@title", this.txtName.Text);
                            sqlcmm.Parameters.AddWithValue("@ID", num);
                            sqlcnn.Open();
                            int i = sqlcmm.ExecuteNonQuery();
                            if (i > 0)
                            {
                                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('success');</script>");
                                txtName.Text = "";
                                GetData();
                            }
                            else
                            {

                                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('faild');</script>");
                            }
                        }
                    }
                }
            }
        }
    }//向数据库添加数据

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int index = e.RowIndex;//获取当前行的索引
        int id = Convert.ToInt32((this.GridView1.Rows[index].FindControl("Label1") as Label).Text);
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "delete from MSAS_Level where ID=@Title";
                sqlcmm.Parameters.AddWithValue("@Title", id);
                sqlcnn.Open();
                int i = sqlcmm.ExecuteNonQuery();
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('success');</script>");
                    GetData();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('faild');</script>");
                }

            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lb = e.Row.FindControl("LinkButton2") as LinkButton;
            if (lb.Text == "delete")
            {
                lb.Attributes.Add("onclick", "return confirm('Delete？')");
            }

        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GetData();
    }//处于编辑状态
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GetData();
    }//取消编辑
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (GridView1.PageIndex != GridView1.PageCount)
        {
            GridView1.PageIndex = GridView1.PageIndex + 1;
        }
        GetData();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        GetData();
        //GridView1.DataBind(); 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (GridView1.PageIndex != 0)
        {
            GridView1.PageIndex = GridView1.PageIndex - 1;
            GetData();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (GridView1.PageCount > 0)
        {
            GridView1.PageIndex = GridView1.PageCount - 1;
            GetData();
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        int toPage;
        try
        {
            toPage = int.Parse(TextBox1.Text);
            if (toPage > 0)
            {
                GridView1.PageIndex = toPage - 1;
            }
            else if (toPage > GridView1.PageCount)
            {
                GridView1.PageIndex = GridView1.PageCount - 1;
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please Input A PageNumber You want Turn to');</script>");
            //  Response.Write("<script language='javascript'>alert('Please Input A PageNumber You want Turn');</script>");
        }
        finally
        {
            GetData();
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string username = (GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text;

        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "update MSAS_Level set Level=@Title where ID=@id";
                sqlcmm.Parameters.AddWithValue("@Title", username);
                sqlcmm.Parameters.AddWithValue("@id", Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text));
                sqlcnn.Open();
                int i = sqlcmm.ExecuteNonQuery();
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('success');</script>");
                    GridView1.EditIndex = -1;
                    GetData();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('faild');</script>");
                }
            }
        }

    }//更新操作
}