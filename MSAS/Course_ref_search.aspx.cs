using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Drawing;
using System.IO;


public partial class Course_ref_search : System.Web.UI.Page
{
    GridView gv = new GridView();
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
                Label1.Text = "Welcome " + Session["staffname"].ToString();
            }

        }


    }
    private void GetData()
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select ID,Course_Ref,Course,Training_Type from MSAS_Course_Reference WHERE 1=1 ";



                sqlcnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                //   GetData();
                Lab_PageCount.Text = "Current " + (GridView1.PageIndex + 1).ToString() + " Page";
                //用LblPageCount来显示当前数据的总页数。   
                Lab_CurrentPage.Text = "Total " + GridView1.PageCount.ToString() + " Page";
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");

    }
    protected void btn_search(object sender, EventArgs e)
    {
        GetData1();
    }

    private void GetData1()
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select ID,Course_Ref,Course,Training_Type from MSAS_Course_Reference where Course_Ref like @Course_Ref and Course like @Course";
                sqlcmm.Parameters.AddWithValue("@Course_Ref", "%" + this.Class_Type.Text + "%");
                sqlcmm.Parameters.AddWithValue("@Course", "%" + this.Course_Type.Text + "%");

                sqlcnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                //   GetData();
                Lab_PageCount.Text = "Current " + (GridView1.PageIndex + 1).ToString() + " Page";
                //用LblPageCount来显示当前数据的总页数。   
                Lab_CurrentPage.Text = "Total " + GridView1.PageCount.ToString() + " Page";
            }
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;//获取当前行的索引
        string Class_id = (this.GridView1.Rows[index].FindControl("Course_Ref_id") as Label).Text;
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                string status = "0";
                sqlcmm.CommandText = "delete MSAS_Course_Reference where ID=@id";
                sqlcmm.Parameters.AddWithValue("@id", Class_id);
                sqlcmm.Parameters.AddWithValue("@Status", status);
                sqlcnn.Open();
                int i = sqlcmm.ExecuteNonQuery();
                //sqlcnn.Close();
                //sqlcnn.Open();

                sqlcmm.CommandText = "Delete MSAS_Course_Ref_Range where ID=@id";
          
                int j = sqlcmm.ExecuteNonQuery();
                sqlcnn.Close();
                if (i > 0&&j>0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");
                    GetData1();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                }

            }
        }



 

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //GridView1.EditIndex = e.NewEditIndex;
        //string useri1 = ((LinkButton)GridView1.Rows[e.NewEditIndex].Cells[1].FindControl("Label2")).Text; ;
        //Session["userNo"] = useri1;
        //Response.Redirect("Authorizationprint.aspx");
        GridView1.EditIndex = e.NewEditIndex;

        GetData1();

    }//处于编辑状态


    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GetData1();
    }//取消编辑
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (GridView1.PageIndex != GridView1.PageCount)
        {
            GridView1.PageIndex = GridView1.PageIndex + 1;
        }
        GetData1();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        GetData1();
        //GridView1.DataBind(); 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (GridView1.PageIndex != 0)
        {
            GridView1.PageIndex = GridView1.PageIndex - 1;
            GetData1();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (GridView1.PageCount > 0)
        {
            GridView1.PageIndex = GridView1.PageCount - 1;
            GetData1();
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
            GetData1();
        }
    }
    public object IsNull(object item)
    {
        if (Equals(Convert.ToString(item), ""))
        {
            return DBNull.Value;
        }
        else
        {
            return Convert.ToString(item);
        }
    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Course_Ref_id = ((Label)GridView1.SelectedRow.Cells[0].FindControl("Course_Ref_id")).Text;
        //  (LinkButton)GridView1.SelectedRow.Cells[1].Attributes.Add("onclick", "this.form.target='_blank'"); 
        Session["Course_Ref"] = Course_Ref_id;
       // ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Class.aspx','_blank')</script>");
        Response.Redirect("Course_ref.aspx");
        //Response.Redirect("Authorizationprint.aspx?staffno=" + useri1);
        //     Response.Write("<script>window.open('Authorizationprint.aspx?staffno=" + useri1 + "','_blank')</script>");
    }
    protected void add_class(object sender, EventArgs e)
    {
        Session["Course_Ref"] = "";
       // ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Class.aspx','_blank')</script>");
        Response.Redirect("Course_ref.aspx");
    }
}