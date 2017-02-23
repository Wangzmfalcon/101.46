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

public partial class Authorization : System.Web.UI.Page
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
        tdepart.Items.Clear();
        tdep.Items.Clear();
        tdiv.Items.Clear();
        tsta.Items.Clear();
        tdivi.Items.Clear();
        ttitle.Items.Clear();
        tvaild.Items.Clear();
        tvaild.Items.Add("All");
        tvaild.Items.Add("Yes");
        tvaild.Items.Add("No");
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Station as Station from MSAS_Station a order by a.Station ";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                tsta.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tsta.Items.Add(new ListItem(dt.Rows[i]["Station"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Department as Department from MSAS_Department a order by  a.Department";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                tdep.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tdep.Items.Add(new ListItem(dt.Rows[i]["Department"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Division as Division from MSAS_Division a order by  a.Division";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                tdiv.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tdiv.Items.Add(new ListItem(dt.Rows[i]["Division"].ToString()));
                }
            }
        }

        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Range as Range from MSAS_Range a order by a.Range  ";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_AuthorizationList");
                dt = Ds.Tables[0];
                tdivi.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tdivi.Items.Add(new ListItem(dt.Rows[i]["Range"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Project as Project from MSAS_Project a order by a.Project ";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_AuthorizationList");
                dt = Ds.Tables[0];
                tdepart.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tdepart.Items.Add(new ListItem(dt.Rows[i]["Project"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Level as Level from MSAS_Level a order by a.Level";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_AuthorizationList");
                dt = Ds.Tables[0];
                ttitle.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ttitle.Items.Add(new ListItem(dt.Rows[i]["Level"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select b.StaffID,b.HRstatus, a.Seq,a.StaffID,a.Project,a.Range,a.Level,(DATENAME(dd,a.ExpireDate)+'-'+SUBSTRING(DATENAME(mm,a.ExpireDate),0,4)+'-'+DATENAME(yyyy,a.ExpireDate) )AS ExpireDate,a.Vaild,a.Remarks,a.stamp from MSAS_AuthorizationList a,MSAS_HRInfo b where a.Status!=2 and a.StaffID=b.StaffID and b.HRstatus=0";
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
        datejo.Text = "";
        Lisen.Text = "";
        Depart.Items.Clear();
        Divis.Items.Clear();
        Titl.Items.Clear();
        TextStamp.Text = "";
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Project from MSAS_Project a";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_AuthorizationList");
                dt = Ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Depart.Items.Add(new ListItem(dt.Rows[i]["Project"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Range from MSAS_Range a";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_AuthorizationList");
                dt = Ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Divis.Items.Add(new ListItem(dt.Rows[i]["Range"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Level from MSAS_Level a";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_AuthorizationList");
                dt = Ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Titl.Items.Add(new ListItem(dt.Rows[i]["Level"].ToString()));
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
                string uid = stano.Text;
                sqlcmm.CommandText = "select * from MSAS_HRInfo where StaffID ='" + uid + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('staffNo not exist');</script>");
                    GetData();
                }
                else
                {
                    DataSet ds = new DataSet();//实例化内存数据库ds 
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);//创建数据库连接对象
                    SqlCommand insertCmd = new SqlCommand("insert into MSAS_AuthorizationList values(@StaffID,@Project,@Range,@Level,@stamp,@ExpireDate,@Vaild,@Remarks,@Status)", cn);
                    insertCmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime);
                    insertCmd.Parameters.Add("@StaffID", SqlDbType.VarChar, 10);
                    insertCmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Range", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Level", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Vaild", SqlDbType.Bit);
                    insertCmd.Parameters.Add("@Status", SqlDbType.VarChar, 10);
                    insertCmd.Parameters.Add("@stamp", SqlDbType.VarChar, 50);
                    insertCmd.Parameters["@StaffID"].Value = stano.Text;
                    if (datejo.Text != "")
                    {

                        insertCmd.Parameters["@ExpireDate"].Value = datejo.Text;
                    }
                    else
                    {
                        insertCmd.Parameters["@ExpireDate"].Value = "2999-12-31";
                    }
                    //   insertCmd.Parameters["@LicenseExpired"].Value = LisenceEx1.Text;
                    insertCmd.Parameters["@Remarks"].Value = Lisen.Text;
                    insertCmd.Parameters["@Project"].Value = Depart.Text;
                    insertCmd.Parameters["@Range"].Value = Divis.Text;
                    insertCmd.Parameters["@Level"].Value = Titl.Text;
                    insertCmd.Parameters["@stamp"].Value = TextStamp.Text;
                    insertCmd.Parameters["@Vaild"].Value = true;
                    insertCmd.Parameters["@Status"].Value = "0";
                    try
                    {
                        cn.Open();
                        int flag = insertCmd.ExecuteNonQuery();
                        if (flag > 0)
                        {
                            //  Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg", "<script type=\"text/javascript\">function ShowAlert(){alert('dd');}window.onload=ShowAlert;</script>");
                            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert success');</script>");
                            GetData();
                        }
                        else


                            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert fail');</script>");


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
                string status = "2";
                sqlcmm.CommandText = "update MSAS_AuthorizationList set Status=@Status where Seq=@id";
                sqlcmm.Parameters.AddWithValue("@id", id);
                sqlcmm.Parameters.AddWithValue("@Status", status);
                sqlcnn.Open();
                int i = sqlcmm.ExecuteNonQuery();
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");
                    GetData();
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

        if (((DropDownList)e.Row.FindControl("Project")) != null)
        {
            DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("Project");
            DropDownList1.Items.Clear();


            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select a.Project as Project from MSAS_Project a";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.SelectCommand.CommandType = CommandType.Text;
                    DataSet Ds = new DataSet();
                    adapter.Fill(Ds, "MSAS_AuthorizationList");
                    dt = Ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList1.Items.Add(new ListItem(dt.Rows[i]["Project"].ToString()));
                    }
                    //DropDownList1.SelectedValue = dt.Rows[0]["Department2"].ToString();

                    if (e.Row.RowType == DataControlRowType.DataRow) //判断是否数据行;
                    {

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string haveimg = drv["Project"].ToString();
                        DropDownList1.SelectedValue = haveimg;
                    }
                    //  string a = lb.Text;


                }
            }

        }
        if (((DropDownList)e.Row.FindControl("Range")) != null)
        {
            DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("Range");
            DropDownList2.Items.Clear();
            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select a.Range as Range from MSAS_Range a";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.SelectCommand.CommandType = CommandType.Text;
                    DataSet Ds = new DataSet();
                    adapter.Fill(Ds, "MSAS_AuthorizationList");
                    dt = Ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList2.Items.Add(new ListItem(dt.Rows[i]["Range"].ToString()));
                    }
                    if (e.Row.RowType == DataControlRowType.DataRow) //判断是否数据行;
                    {

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string haveimg1 = drv["Range"].ToString();
                        DropDownList2.SelectedValue = haveimg1;
                    }
                }
            }
        }
        if (((DropDownList)e.Row.FindControl("Level")) != null)
        {
            DropDownList DropDownList3 = (DropDownList)e.Row.FindControl("Level");
            DropDownList3.Items.Clear();
            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select a.Level as Level from MSAS_Level a";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.SelectCommand.CommandType = CommandType.Text;
                    DataSet Ds = new DataSet();
                    adapter.Fill(Ds, "MSAS_AuthorizationList");
                    dt = Ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList3.Items.Add(new ListItem(dt.Rows[i]["Level"].ToString()));
                    }
                    if (e.Row.RowType == DataControlRowType.DataRow) //判断是否数据行;
                    {

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string haveimg2 = drv["Level"].ToString();
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
        //GridView1.EditIndex = e.NewEditIndex;
        //string useri1 = ((LinkButton)GridView1.Rows[e.NewEditIndex].Cells[1].FindControl("Label2")).Text; ;
        //Session["userNo"] = useri1;
        //Response.Redirect("Authorizationprint.aspx");
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
        string remarks = (GridView1.Rows[e.RowIndex].FindControl("Remarks") as TextBox).Text;
        string project = (GridView1.Rows[e.RowIndex].FindControl("Project") as DropDownList).Text;
        string range = (GridView1.Rows[e.RowIndex].FindControl("Range") as DropDownList).Text;
        string level = (GridView1.Rows[e.RowIndex].FindControl("Level") as DropDownList).Text;
        string stamp = (GridView1.Rows[e.RowIndex].FindControl("stamp") as TextBox).Text;
        string expireDate = (GridView1.Rows[e.RowIndex].FindControl("ExpireDate") as TextBox).Text;
        bool Vail = (GridView1.Rows[e.RowIndex].FindControl("CheckBox12") as CheckBox).Checked;
        string status = "1";
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "update MSAS_AuthorizationList set StaffID=@StaffID,Project=@Project,Range=@Range,Level=@Level,ExpireDate=@ExpireDate,Remarks=@Remarks,Vaild=@Vaild,Status=@Status,stamp=@stamp where Seq=@id";
                sqlcmm.Parameters.AddWithValue("@StaffID", staffno);
                sqlcmm.Parameters.AddWithValue("@id", Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text));
                sqlcmm.Parameters.AddWithValue("@Remarks", remarks);
                sqlcmm.Parameters.AddWithValue("@Project", project);
                sqlcmm.Parameters.AddWithValue("@Range", range);
                sqlcmm.Parameters.AddWithValue("@Level", level);
                sqlcmm.Parameters.AddWithValue("@ExpireDate", expireDate);
                sqlcmm.Parameters.AddWithValue("@Vaild", Vail);
                sqlcmm.Parameters.AddWithValue("@Status", status);
                sqlcmm.Parameters.AddWithValue("@stamp", stamp);
                sqlcnn.Open();
                int i = sqlcmm.ExecuteNonQuery();
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Update success');</script>");
                    GridView1.EditIndex = -1;
                    GetData();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Update faild');</script>");
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
                sqlcmm.CommandText = "select a.Seq,a.StaffID,a.Project,a.Range,a.Level,(DATENAME(dd,a.ExpireDate)+'-'+SUBSTRING(DATENAME(mm,a.ExpireDate),0,4)+'-'+DATENAME(yyyy,a.ExpireDate) )AS ExpireDate,a.Vaild,a.Remarks,a.stamp,b.StaffID,b.HRstatus,b.Department,b.Division,b.Station from MSAS_AuthorizationList a,MSAS_HRInfo b where a.Status!=2 and a.StaffID like @StaffID and a.Project like @Project and  a.Range like @Range and a.Level like @Level and a.stamp like @stamp and b.Department like @Department and b.Division like @Division and b.Station like @Station and a.StaffID=b.StaffID and b.HRstatus=0 and (Vaild = @Vaild or Vaild = @Vaild1) ";
                sqlcmm.Parameters.AddWithValue("@StaffID", "%" + this.txtName.Text + "%");
                sqlcmm.Parameters.AddWithValue("@stamp", "%" + this.tstamp.Text + "%");
                sqlcmm.Parameters.AddWithValue("@Project", "%" + this.tdepart.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@Range", "%" + this.tdivi.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@Level", "%" + this.ttitle.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@Department", "%" + this.tdep.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@Division", "%" + this.tdiv.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@Station", "%" + this.tsta.SelectedValue + "%");
                if (tvaild.SelectedValue == "Yes")
                {
                    sqlcmm.Parameters.AddWithValue("@Vaild", true);
                    sqlcmm.Parameters.AddWithValue("@Vaild1", DBNull.Value);
                }
                else if (tvaild.SelectedValue == "No")
                {
                    sqlcmm.Parameters.AddWithValue("@Vaild", false);
                    sqlcmm.Parameters.AddWithValue("@Vaild1", DBNull.Value);
                }
                else
                {
                    sqlcmm.Parameters.AddWithValue("@Vaild", false);
                    sqlcmm.Parameters.AddWithValue("@Vaild1", true);
                }
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

    protected void downloadlink(object sender, EventArgs e)
    {

        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("Authorization.xls", Encoding.UTF8).ToString());
        Response.ContentType = "application/ms-excel";
        this.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        GridView1.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string useri1 = ((LinkButton)GridView1.SelectedRow.Cells[1].FindControl("Label2")).Text;
        Session["userNo"] = useri1;
        Response.Redirect("Authorizationprint.aspx");
    }
}
