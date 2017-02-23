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


public partial class Class_search : System.Web.UI.Page
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
                GetData1();
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
                sqlcmm.CommandText = "select ID,Class_Name,Course_Ref,Batch,(DATENAME(dd,Training_Date)+'-'+SUBSTRING(DATENAME(mm,Training_Date),0,4)+'-'+DATENAME(yyyy,Training_Date) ) as Training_Date1 from MSAS_Class WHERE 1=1 order by Training_Date desc";



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
                string Datesearch = "";

                if (From.Text.Trim() != "" && To.Text.Trim() != "")
                {
                    Datesearch = "and (Training_Date between '" + From.Text + "'  and '" + To.Text + "')";

                }


                sqlcmm.CommandText = "select ID,Class_Name,Course_Ref,Batch,(DATENAME(dd,Training_Date)+'-'+SUBSTRING(DATENAME(mm,Training_Date),0,4)+'-'+DATENAME(yyyy,Training_Date) ) as Training_Date1 from MSAS_Class where 1=1 and  Class_Name like @Class_Name AND Course_Ref like @Course_Ref " + Datesearch + "order by Training_Date desc";
                sqlcmm.Parameters.AddWithValue("@Class_Name", "%" + this.Class_Name.Text + "%");
                sqlcmm.Parameters.AddWithValue("@Course_Ref", "%" + this.Coures_ref_Type.Text + "%");

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
        string Class_id = (this.GridView1.Rows[index].FindControl("Label1") as Label).Text;
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                string status = "0";
                sqlcmm.CommandText = "delete MSAS_Class where ID=@id";
                sqlcmm.Parameters.AddWithValue("@id", Class_id);

                sqlcnn.Open();
                int i = sqlcmm.ExecuteNonQuery();
                //sqlcnn.Close();
                //sqlcnn.Open();

                sqlcmm.CommandText = "Delete MSAS_Class_Range where ID=@id";

                int j = sqlcmm.ExecuteNonQuery();
                sqlcnn.Close();
                if (i > 0 && j > 0)
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
        string Course_ID = ((Label)GridView1.SelectedRow.Cells[1].FindControl("Label1")).Text;
        //  (LinkButton)GridView1.SelectedRow.Cells[1].Attributes.Add("onclick", "this.form.target='_blank'"); 
        Session["Class_ID"] = Course_ID;
        //Response.Redirect("Class.aspx");
        //Server.Transfer("Class.aspx");
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Class.aspx','newwindow','') </script>");
        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Course.aspx')</script>");
        //Response.Redirect("Authorizationprint.aspx?staffno=" + useri1);
        //     Response.Write("<script>window.open('Authorizationprint.aspx?staffno=" + useri1 + "','_blank')</script>");
    }
    protected void add_class(object sender, EventArgs e)
    {
        Session["Class_ID"] = "";
        Response.Redirect("Class.aspx");
        // ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Course.aspx')</script>");

    }
}