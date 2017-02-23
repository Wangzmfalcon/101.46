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

public partial class Staffin : System.Web.UI.Page
{
    string sqlstr = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();
        }

    }
    private void GetData()
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select Seq,StaffID,StaffName,Department,Division,Title,License,Convert(varchar(10),DateOfJoin,120) AS DateOfJoin,Convert(varchar(10),LicenseExpired,120) AS LicenseExpired,HRstatus from MSAS_HRInfo";
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
        string sl = "<script language='javascript' type='text/javascript'>  showFloat()</script>";
        Page.RegisterStartupScript("mya", sl);

        stano.Text = "";
        nam.Text = "";
        datejo.Text = "";
        LisenceEx1.Text = "";
        Lisen.Text = "";
        Depart.Items.Clear();
        Divis.Items.Clear();
        Titl.Items.Clear();
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Department from MSAS_Department a";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Depart.Items.Add(new ListItem(dt.Rows[i]["Department"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Division from MSAS_Division a";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Divis.Items.Add(new ListItem(dt.Rows[i]["Division"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Title from MSAS_Title a";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Titl.Items.Add(new ListItem(dt.Rows[i]["Title"].ToString()));
                }
            }
        }
    }//向数据库添加数据
    public void finish(object sender, EventArgs e)
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                string uid=stano.Text;
                sqlcmm.CommandText = "select * from MSAS_HRInfo where StaffID ='" + uid + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                adapter.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('staffNo exist');</script>");
                    GetData();
                }
                else
                {
                    DataSet ds = new DataSet();//实例化内存数据库ds 
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);//创建数据库连接对象
                    SqlCommand insertCmd = new SqlCommand("insert into MSAS_HRInfo values(@StaffID,@StaffName,@Department,@Division,@Title,@DateOfJoin,@License,@LicenseExpired,@HRstatus)", cn);
                    insertCmd.Parameters.Add("@DateOfJoin", SqlDbType.DateTime);
                    insertCmd.Parameters.Add("@LicenseExpired", SqlDbType.DateTime);
                    insertCmd.Parameters.Add("@StaffID", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@StaffName", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Department", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Division", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Title", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@License", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@HRstatus", SqlDbType.Bit);

                    insertCmd.Parameters["@StaffID"].Value = stano.Text;
                    insertCmd.Parameters["@StaffName"].Value = nam.Text;
                    insertCmd.Parameters["@DateOfJoin"].Value = datejo.Text;
                    insertCmd.Parameters["@LicenseExpired"].Value = LisenceEx1.Text;
                    insertCmd.Parameters["@License"].Value = Lisen.Text;
                    insertCmd.Parameters["@Department"].Value = Depart.Text;
                    insertCmd.Parameters["@Division"].Value = Divis.Text;
                    insertCmd.Parameters["@Title"].Value = Titl.Text;
                    insertCmd.Parameters["@HRStatus"].Value = false;
                    try
                    {
                        cn.Open();
                        int flag = insertCmd.ExecuteNonQuery();
                        if (flag > 0)
                        {
                            //  Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg", "<script type=\"text/javascript\">function ShowAlert(){alert('dd');}window.onload=ShowAlert;</script>");
                            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('success');</script>");
                            GetData();
                        }
                        else


                            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('fail');</script>");


                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
                    }

                    finally
                    {
                        cn.Close();
                    }
                }
            }
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int index = e.RowIndex;//获取当前行的索引
        int id = Convert.ToInt32((this.GridView1.Rows[index].FindControl("Label1") as Label).Text);
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "delete from MSAS_HRInfo where Seq=@Title";
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
        
        if (((DropDownList)e.Row.FindControl("Department")) != null)
        {
            DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("Department");
            DropDownList1.Items.Clear();
            

            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select a.Department as Department2 from MSAS_Department a";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.SelectCommand.CommandType = CommandType.Text;
                    DataSet Ds = new DataSet();
                    adapter.Fill(Ds, "MSAS_HRInfo");
                    dt = Ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList1.Items.Add(new ListItem(dt.Rows[i]["Department2"].ToString()));
                    }
                    //DropDownList1.SelectedValue = dt.Rows[0]["Department2"].ToString();

                    if (e.Row.RowType == DataControlRowType.DataRow) //判断是否数据行;
                    {

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string haveimg = drv["Department"].ToString();
                        DropDownList1.SelectedValue = haveimg;
                    }
                      //  string a = lb.Text;

                    
                }
            }

        }
        if (((DropDownList)e.Row.FindControl("Division")) != null)
        {
            DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("Division");
            DropDownList2.Items.Clear();
            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select a.Division as Division1 from MSAS_Division a";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.SelectCommand.CommandType = CommandType.Text;
                    DataSet Ds = new DataSet();
                    adapter.Fill(Ds, "MSAS_HRInfo");
                    dt = Ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList2.Items.Add(new ListItem(dt.Rows[i]["Division1"].ToString()));
                    }
                    if (e.Row.RowType == DataControlRowType.DataRow) //判断是否数据行;
                    {

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string haveimg1 = drv["Division"].ToString();
                        DropDownList2.SelectedValue = haveimg1;
                    }
                }
            }
        }
        if (((DropDownList)e.Row.FindControl("Title")) != null)
        {
            DropDownList DropDownList3 = (DropDownList)e.Row.FindControl("Title");
            DropDownList3.Items.Clear();
            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select a.Title as Title1 from MSAS_Title a";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.SelectCommand.CommandType = CommandType.Text;
                    DataSet Ds = new DataSet();
                    adapter.Fill(Ds, "MSAS_HRInfo");
                    dt = Ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList3.Items.Add(new ListItem(dt.Rows[i]["Title1"].ToString()));
                    }
                    if (e.Row.RowType == DataControlRowType.DataRow) //判断是否数据行;
                    {

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string haveimg2 = drv["Title"].ToString();
                        DropDownList3.SelectedValue = haveimg2;
                    }
                }
            }
        }
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
        string staffno = (GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text;
        string staffname = (GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox).Text;
        string department = (GridView1.Rows[e.RowIndex].FindControl("Department") as DropDownList).Text;
        string division = (GridView1.Rows[e.RowIndex].FindControl("Division") as DropDownList).Text;
        string title = (GridView1.Rows[e.RowIndex].FindControl("Title") as DropDownList).Text;
        string jointime = (GridView1.Rows[e.RowIndex].FindControl("TextBox6") as TextBox).Text;
        string license = (GridView1.Rows[e.RowIndex].FindControl("TextBox5") as TextBox).Text;
        string licenseEx = (GridView1.Rows[e.RowIndex].FindControl("TextBox9") as TextBox).Text;
        bool HRs = (GridView1.Rows[e.RowIndex].FindControl("CheckBox12") as CheckBox).Checked;

        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "update MSAS_HRInfo set StaffID=@StaffID,StaffName=@StaffName,Department=@Department,Division=@Division,Title=@Title,DateOfJoin=@DateOfJoin,License=@License,LicenseExpired=@LicenseExpired,HRStatus=@HRStatus where Seq=@id";
                sqlcmm.Parameters.AddWithValue("@StaffID", staffno);
                sqlcmm.Parameters.AddWithValue("@id", Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text));
                sqlcmm.Parameters.AddWithValue("@StaffName", staffname);
                sqlcmm.Parameters.AddWithValue("@Department", department);
                sqlcmm.Parameters.AddWithValue("@Division", division);
                sqlcmm.Parameters.AddWithValue("@Title", title);
                sqlcmm.Parameters.AddWithValue("@DateOfJoin", jointime);
                sqlcmm.Parameters.AddWithValue("@License", license);
                sqlcmm.Parameters.AddWithValue("@LicenseExpired", licenseEx);
                sqlcmm.Parameters.AddWithValue("@HRStatus", HRs);
                
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        // base.VerifyRenderingInServerForm(control); 

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select Seq,StaffID,StaffName,Department,Division,Title,License,Convert(varchar(10),DateOfJoin,120) AS DateOfJoin,Convert(varchar(10),LicenseExpired,120) AS LicenseExpired,HRstatus from MSAS_HRInfo where StaffID like @StaffID";
                sqlcmm.Parameters.AddWithValue("@StaffID", "%" + this.txtName.Text + "%");
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
}
