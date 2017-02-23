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
using Aspose.Cells;//excel
public partial class Authorization : System.Web.UI.Page
{
    GridView gv = new GridView();
    DataTable dt = new DataTable();
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
            BttLogin.Attributes.Add("onclick", "return Jmmcheck()");
         

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
                sqlcmm.CommandText = "select b.StaffID,b.HRstatus,b.StaffName,b.Station,b.Division, a.Seq,a.StaffID,a.Project,a.Range,a.Level,(DATENAME(dd,a.ExpireDate)+'-'+SUBSTRING(DATENAME(mm,a.ExpireDate),0,4)+'-'+DATENAME(yyyy,a.ExpireDate) )AS ExpireDate,a.Vaild,a.Remarks,a.stamp from MSAS_AuthorizationList a,MSAS_HRInfo b where a.Status!=2 and a.StaffID=b.StaffID and b.HRstatus=0";
             
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
        using (SqlConnection sqlcnn1 = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm1 = sqlcnn1.CreateCommand())
            {
                string exdate = "";
                if (datejo.Text == "")
                {
                    exdate = "2999-12-31";
                }
                sqlcmm1.CommandText = "select * from MSAS_AuthorizationList where StaffID ='" + stano.Text + "' and Project='" + Depart.Text + "' and Range='" + Divis.Text + "' and Level='" + Titl.Text + "' and stamp='" + TextStamp.Text + "' and ExpireDate='" + exdate + "' and Remarks='" + Lisen.Text + "'";
                DataTable dt1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlcmm1);
                adapter1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                }
                else
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
                                        Session["flag"] = "0";
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

        GetData1();

    }//处于编辑状态
 
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
                    GetData1();
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
    private void GetData1()
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Seq,a.StaffID,b.StaffName,b.Station,b.Division,a.Project,a.Range,a.Level,(DATENAME(dd,a.ExpireDate)+'-'+SUBSTRING(DATENAME(mm,a.ExpireDate),0,4)+'-'+DATENAME(yyyy,a.ExpireDate) )AS ExpireDate,a.Vaild,a.Remarks,a.stamp,b.StaffID,b.HRstatus,b.Department from MSAS_AuthorizationList a,MSAS_HRInfo b where a.Status!=2 and a.StaffID like @StaffID and a.Project =(case when @Project=''then a.Project else @Project end) and  a.Range =(case when @Range=''then a.Range else @Range end) and a.Level =(case when @Level=''then a.Level else @Level end) and a.stamp like @stamp and b.Department like @Department and b.Division like @Division and b.Station like @Station and a.StaffID=b.StaffID and b.HRstatus=0 and (Vaild = @Vaild or Vaild = @Vaild1)  ";
                sqlcmm.Parameters.AddWithValue("@StaffID", "%" + this.txtName.Text + "%");
                sqlcmm.Parameters.AddWithValue("@stamp", "%" + this.tstamp.Text + "%");
                sqlcmm.Parameters.AddWithValue("@Project",  this.tdepart.SelectedValue );
                sqlcmm.Parameters.AddWithValue("@Range",  this.tdivi.SelectedValue );
                sqlcmm.Parameters.AddWithValue("@Level",  this.ttitle.SelectedValue );
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
    protected void Button6_Click(object sender, EventArgs e)
    {
        GetData1();
    }
    protected void downloadlink(object sender, EventArgs e)
    {

        GetData1();


        //设置EXCEL列宽
        int[] ColumnWidth = { 10, 20, 20, 20, 50, 50, 20, 30, 30, 50 ,20};
        //获取用户选择的excel文件名称
        string ReportTitleName = "Authorization_List";
        string savepath = Server.MapPath("Files/" + ReportTitleName.ToString() + ".xls");
        //新建excel
        Workbook wb = new Workbook();

        //设置字体样式

        Aspose.Cells.Style style1 = wb.Styles[wb.Styles.Add()];
        style1.HorizontalAlignment = TextAlignmentType.Center;//文字居中
        style1.Font.Name = "宋体";
        style1.Font.IsBold = true;//设置粗体
        style1.Font.Size = 12;//设置字体大小

        Aspose.Cells.Style style2 = wb.Styles[wb.Styles.Add()];
        style2.HorizontalAlignment = TextAlignmentType.Center;
        style2.Font.Size = 10;


        //sheet1
        Worksheet ws = wb.Worksheets[0];
        Cells cell = ws.Cells;
        ws.Name = "Telephone";
        //合并第一行单元格
        Aspose.Cells.Range range = cell.CreateRange(0, 0, 1, ColumnWidth.Length);
        range.Merge();
        cell["A1"].PutValue("Authorization List"); //标题
        //给单元格关联样式
        cell["A1"].SetStyle(style1); //报表名字 样式
        //设置Execl列名  可以采用单独传值
        cell[1, 0].PutValue("Staff No.");
        cell[1, 0].SetStyle(style2);
        cell[1, 1].PutValue("Staff Name");
        cell[1, 1].SetStyle(style2);
        cell[1, 2].PutValue("Station");
        cell[1, 2].SetStyle(style2);
        cell[1, 3].PutValue("Division");
        cell[1, 3].SetStyle(style2);
        cell[1, 4].PutValue("Subject");
        cell[1, 4].SetStyle(style2);
        cell[1, 5].PutValue("Rating");
        cell[1, 5].SetStyle(style2);
        cell[1, 6].PutValue("Level");
        cell[1, 6].SetStyle(style2);
        cell[1, 7].PutValue("Stamp");
        cell[1, 7].SetStyle(style2);
        cell[1, 8].PutValue("ExpireDate");
        cell[1, 8].SetStyle(style2);
        cell[1, 9].PutValue("Remarks");
        cell[1, 9].SetStyle(style2);
        cell[1, 10].PutValue("Valid");
        cell[1, 10].SetStyle(style2);



        //设置单元格内容
        int posStart = 2;
        int row = 0;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow Drow = dt.Rows[i];
            cell[row + posStart, 0].PutValue(Drow[1].ToString());
            cell[row + posStart, 0].SetStyle(style2);
            cell[row + posStart, 1].PutValue(Drow[2].ToString());
            cell[row + posStart, 1].SetStyle(style2);
            cell[row + posStart, 2].PutValue(Drow[3].ToString());
            cell[row + posStart, 2].SetStyle(style2);
            cell[row + posStart, 3].PutValue(Drow[4].ToString());
            cell[row + posStart, 3].SetStyle(style2);
            cell[row + posStart, 4].PutValue(Drow[5].ToString());
            cell[row + posStart, 4].SetStyle(style2);
            cell[row + posStart, 5].PutValue(Drow[6].ToString());
            cell[row + posStart, 5].SetStyle(style2);
            cell[row + posStart, 6].PutValue(Drow[7].ToString());
            cell[row + posStart, 6].SetStyle(style2);
            cell[row + posStart, 7].PutValue(Drow[11].ToString());
            cell[row + posStart, 7].SetStyle(style2);
            cell[row + posStart, 8].PutValue(Convert.ToDateTime(Drow[8].ToString()).ToString("dd-MMM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            cell[row + posStart, 8].SetStyle(style2);
            cell[row + posStart, 9].PutValue(Drow[10].ToString());
            cell[row + posStart, 9].SetStyle(style2);
            cell[row + posStart, 10].PutValue(Drow[9].ToString());
            cell[row + posStart, 10].SetStyle(style2);

            row++;
        }
        for (int i = 0; i < ColumnWidth.Length; i++)
        {
            cell.SetColumnWidth(i, Convert.ToDouble(ColumnWidth[i].ToString()));
        }


        Workbook wb1 = new Workbook();

        //设置字体样式

        Aspose.Cells.Style style11 = wb1.Styles[wb1.Styles.Add()];
        style11.HorizontalAlignment = TextAlignmentType.Center;//文字居中
        style11.Font.Name = "宋体";
        style11.Font.IsBold = true;//设置粗体
        style11.Font.Size = 12;//设置字体大小

        Aspose.Cells.Style style21 = wb1.Styles[wb1.Styles.Add()];
        style21.HorizontalAlignment = TextAlignmentType.Center;
        style21.Font.Size = 10;



        //保存在服务器
        wb.Combine(wb1);
        wb.Save(savepath);

        FileTo(ReportTitleName);
    }

    //下载
    public void FileTo(string ReportTitleName)   //file文件名称
    {


        string path = Server.MapPath("Files/" + ReportTitleName.ToString() + ".xls");

        System.IO.FileInfo file = new System.IO.FileInfo(path);

        if (file.Exists)
        {

            Response.Clear();

            Response.ContentType = "application/vnd.ms-excel";

            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(ReportTitleName.ToString()) + ".xls");

            Response.AddHeader("Content-Length", file.Length.ToString());

            Response.ContentType = "application/octet-stream";

            Response.Filter.Close();

            Response.WriteFile(file.FullName);

            Response.End();


        }
    }
    //protected void downloadlink(object sender, EventArgs e)
    //{
    //    GridView1.AllowPaging = false;
    //    GetData1();

    //    string strStyle = "<style>td{mso-number-format:\"\\@\";}</style>";
    //    Response.Charset = "GB2312";
    //    Response.ContentEncoding = System.Text.Encoding.UTF8;
    //    Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("Authorization.xls", Encoding.UTF8).ToString());
    //    Response.ContentType = "application/ms-excel";
    //    this.EnableViewState = false;
    //    StringWriter tw = new StringWriter();
    //    HtmlTextWriter hw = new HtmlTextWriter(tw);
    //    gv = this.GridView1;
    //    gv.RenderControl(hw);
    //    Response.Write(strStyle);

    //    Response.Write(tw.ToString());
    //    Response.End();
    //    GridView1.AllowPaging = true;//恢复分页  
    //    //为GridView重新绑定数据源  
    //    GetData1();
    //}

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string useri1 = ((LinkButton)GridView1.SelectedRow.Cells[1].FindControl("Label2")).Text;
      //  (LinkButton)GridView1.SelectedRow.Cells[1].Attributes.Add("onclick", "this.form.target='_blank'"); 
        Session["userNo"] = useri1;
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Authorizationprint.aspx','_blank')</script>");
        //Response.Redirect("Authorizationprint.aspx?staffno=" + useri1);
   //     Response.Write("<script>window.open('Authorizationprint.aspx?staffno=" + useri1 + "','_blank')</script>");
    }
}
