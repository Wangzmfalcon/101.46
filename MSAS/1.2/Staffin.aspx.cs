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
using System.Data.SqlClient;
using System.Runtime.InteropServices;//外部引用

public partial class Staffin : System.Web.UI.Page
{

    //杀EXCEL
    //[DllImport("User32.dll", CharSet = CharSet.Auto)]
    //public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
    //[DllImport("kernel32")]
    //private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    //[DllImport("kernel32")]
    //private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
   
    DataTable download = new DataTable();
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
        tdivi.Items.Clear();
        ttitle.Items.Clear();
        tcate.Items.Clear();
        tjmm.Items.Clear();
        tleft.Items.Clear();
        station.Items.Clear();


        tjmm.Items.Add("All");
        tjmm.Items.Add("Yes");
        tjmm.Items.Add("No");
        tleft.Items.Add("All");
        tleft.Items.Add("Yes");
        tleft.Items.Add("No");
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Station as Station2 from MSAS_Station a order by a.Station ";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                station.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    station.Items.Add(new ListItem(dt.Rows[i]["Station2"].ToString()));

                }

            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Department as Department2 from MSAS_Department a order by a.Department ";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                tdepart.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tdepart.Items.Add(new ListItem(dt.Rows[i]["Department2"].ToString()));

                }

            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Division as Division1 from MSAS_Division a order by  a.Division ";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                tdivi.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tdivi.Items.Add(new ListItem(dt.Rows[i]["Division1"].ToString()));
                }

            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Title as Title1 from MSAS_Title a order by a.Title";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                ttitle.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ttitle.Items.Add(new ListItem(dt.Rows[i]["Title1"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Category as Category1 from MSAS_Category a";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                tcate.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tcate.Items.Add(new ListItem(dt.Rows[i]["Category1"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select Seq,StaffID,StaffName,Station,Department,Division,Title,License,(DATENAME(dd,DateOfJoin)+'-'+SUBSTRING(DATENAME(mm,DateOfJoin),0,4)+'-'+DATENAME(yyyy,DateOfJoin) )AS DateofJoin,(DATENAME(dd,LicenseExpired)+'-'+SUBSTRING(DATENAME(mm,LicenseExpired),0,4)+'-'+DATENAME(yyyy,LicenseExpired) )AS LicenseExpired,HRstatus,category,notJMM,(DATENAME(dd,DateOfLeft)+'-'+SUBSTRING(DATENAME(mm,DateOfLeft),0,4)+'-'+DATENAME(yyyy,DateOfLeft) )AS DateOfLeft from MSAS_HRInfo";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                adapter.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                //download = dt;
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
        Categoryin.Items.Clear();
        Dropdownlist1.Items.Clear();

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
                sqlcmm.CommandText = "select a.Station from MSAS_Station a";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Dropdownlist1.Items.Add(new ListItem(dt.Rows[i]["Station"].ToString()));
                }
            }
        }
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select a.Category from MSAS_Category a order by a.Category";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                adapter.SelectCommand.CommandType = CommandType.Text;
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MSAS_HRInfo");
                dt = Ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Categoryin.Items.Add(new ListItem(dt.Rows[i]["Category"].ToString()));
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
                    SqlCommand insertCmd = new SqlCommand("insert into MSAS_HRInfo values(@StaffID,@StaffName,@Department,@Division,@Station,@Title,@DateOfJoin,@License,@Category,@notJMM,@LicenseExpired,@DateOfLeft,@HRstatus)", cn);
                    insertCmd.Parameters.Add("@DateOfJoin", SqlDbType.DateTime);
                    insertCmd.Parameters.Add("@LicenseExpired", SqlDbType.DateTime);
                    insertCmd.Parameters.Add("@StaffID", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@StaffName", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Department", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Division", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Station", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@Title", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@License", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@HRstatus", SqlDbType.Bit);
                    insertCmd.Parameters.Add("@Category", SqlDbType.VarChar, 50);
                    insertCmd.Parameters.Add("@DateOfLeft", SqlDbType.DateTime);
                    insertCmd.Parameters.Add("@notJMM", SqlDbType.Bit);

                    insertCmd.Parameters["@StaffID"].Value = stano.Text;
                    insertCmd.Parameters["@StaffName"].Value = nam.Text;
                    insertCmd.Parameters["@DateOfJoin"].Value = IsNull(datejo.Text);
                    insertCmd.Parameters["@LicenseExpired"].Value = IsNull(LisenceEx1.Text);
                    insertCmd.Parameters["@License"].Value = Lisen.Text;
                    insertCmd.Parameters["@Department"].Value = Depart.Text;
                    insertCmd.Parameters["@Station"].Value = Dropdownlist1.Text;
                    insertCmd.Parameters["@Division"].Value = Divis.Text;
                    insertCmd.Parameters["@Title"].Value = Titl.Text;
                    insertCmd.Parameters["@Category"].Value = Categoryin.Text;
                    insertCmd.Parameters["@HRStatus"].Value = false;
                    insertCmd.Parameters["@notJMM"].Value = checknotjmm.Checked;
                    insertCmd.Parameters["@DateOfLeft"].Value = DBNull.Value;

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

        if (((DropDownList)e.Row.FindControl("TextBoxcategory")) != null)
        {
            DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("TextBoxcategory");
            DropDownList2.Items.Clear();
            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select a.Category as Category1 from MSAS_Category a";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.SelectCommand.CommandType = CommandType.Text;
                    DataSet Ds = new DataSet();
                    adapter.Fill(Ds, "MSAS_HRInfo");
                    dt = Ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList2.Items.Add(new ListItem(dt.Rows[i]["Category1"].ToString()));
                    }
                    if (e.Row.RowType == DataControlRowType.DataRow) //判断是否数据行;
                    {

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string haveimg1 = drv["Category"].ToString();
                        DropDownList2.SelectedValue = haveimg1;
                    }
                }
            }
        }
        if (((DropDownList)e.Row.FindControl("Station")) != null)
        {
            DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("Station");
            DropDownList2.Items.Clear();
            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select a.Station as Station1 from MSAS_Station a";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.SelectCommand.CommandType = CommandType.Text;
                    DataSet Ds = new DataSet();
                    adapter.Fill(Ds, "MSAS_HRInfo");
                    dt = Ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList2.Items.Add(new ListItem(dt.Rows[i]["Station1"].ToString()));
                    }
                    if (e.Row.RowType == DataControlRowType.DataRow) //判断是否数据行;
                    {

                        DataRowView drv = (DataRowView)e.Row.DataItem;
                        string haveimg1 = drv["Station"].ToString();
                        DropDownList2.SelectedValue = haveimg1;
                    }
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
        string station1 = (GridView1.Rows[e.RowIndex].FindControl("Station") as DropDownList).Text;
        string category = (GridView1.Rows[e.RowIndex].FindControl("TextBoxcategory") as DropDownList).Text;
        bool JMM = (GridView1.Rows[e.RowIndex].FindControl("CheckBoxnotJMM") as CheckBox).Checked;
        string licenseEx = (GridView1.Rows[e.RowIndex].FindControl("TextBox9") as TextBox).Text;
        string DateOfLeft = (GridView1.Rows[e.RowIndex].FindControl("TextBoxDateOfLeft") as TextBox).Text;
        bool HRs = (GridView1.Rows[e.RowIndex].FindControl("CheckBox12") as CheckBox).Checked;

        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "update MSAS_HRInfo set StaffID=@StaffID,StaffName=@StaffName,Department=@Department,Division=@Division,Station=@Station,Title=@Title,DateOfJoin=@DateOfJoin,License=@License,LicenseExpired=@LicenseExpired,HRStatus=@HRStatus ,category=@category,notJMM=@notJMM,DateOfLeft=@DateOfLeft  where Seq=@id";
                sqlcmm.Parameters.AddWithValue("@StaffID", staffno);
                sqlcmm.Parameters.AddWithValue("@id", Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text));
                sqlcmm.Parameters.AddWithValue("@StaffName", staffname);
                sqlcmm.Parameters.AddWithValue("@Department", department);
                sqlcmm.Parameters.AddWithValue("@Station", station1);
                sqlcmm.Parameters.AddWithValue("@Division", division);
                sqlcmm.Parameters.AddWithValue("@Title", title);
                sqlcmm.Parameters.AddWithValue("@DateOfJoin", jointime);
                sqlcmm.Parameters.AddWithValue("@License", license);
                sqlcmm.Parameters.AddWithValue("@LicenseExpired", licenseEx);
                sqlcmm.Parameters.AddWithValue("@HRStatus", HRs);
                sqlcmm.Parameters.AddWithValue("@category", category);
                sqlcmm.Parameters.AddWithValue("@notJMM", JMM);
                sqlcmm.Parameters.AddWithValue("@DateOfLeft", IsNull(DateOfLeft));
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

    //空值检查
    public object IsNull(object item)
    {
        if (Equals(Convert.ToString(item),""))
        {
            return DBNull.Value;
        }
        else
        {
            return Convert.ToString(item);
        }
    }


   
    protected void Button6_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select Seq,StaffID,StaffName,category,Department,Division,Station,Title,License,(DATENAME(dd,DateOfJoin)+'-'+SUBSTRING(DATENAME(mm,DateOfJoin),0,4)+'-'+DATENAME(yyyy,DateOfJoin) )AS DateofJoin,(DATENAME(dd,LicenseExpired)+'-'+SUBSTRING(DATENAME(mm,LicenseExpired),0,4)+'-'+DATENAME(yyyy,LicenseExpired) )AS LicenseExpired,HRstatus,notJMM,(DATENAME(dd,DateOfLeft)+'-'+SUBSTRING(DATENAME(mm,DateOfLeft),0,4)+'-'+DATENAME(yyyy,DateOfLeft) )AS DateOfLeft from MSAS_HRInfo where StaffID like @StaffID and StaffName like @StaffName and Department like @Department and Division like @Division and Title like @Title and License like @License and Station like @Station and category like @category and (notJMM = @notJMM or notJMM = @notJMM1) and (HRstatus=@HRstatus or HRstatus=@HRstatus1)";
                sqlcmm.Parameters.AddWithValue("@StaffID", "%" + this.txtName.Text + "%");
                sqlcmm.Parameters.AddWithValue("@StaffName", "%" + this.tname.Text + "%");
                sqlcmm.Parameters.AddWithValue("@Department", "%" + this.tdepart.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@Division", "%" + this.tdivi.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@Station", "%" + this.station.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@Title", "%" + this.ttitle.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@category", "%" + this.tcate.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@License", "%" + this.tlicen.Text + "%");
                if (tjmm.SelectedValue == "Yes")
                {
                    sqlcmm.Parameters.AddWithValue("@notJMM", true);
                    sqlcmm.Parameters.AddWithValue("@notJMM1", DBNull.Value);
                }
                else if (tjmm.SelectedValue == "No")
                {
                    sqlcmm.Parameters.AddWithValue("@notJMM", false);
                    sqlcmm.Parameters.AddWithValue("@notJMM1", DBNull.Value);
                }
                else
                {
                    sqlcmm.Parameters.AddWithValue("@notJMM", false);
                    sqlcmm.Parameters.AddWithValue("@notJMM1", true);
                }
                if (tleft.SelectedValue == "Yes")
                {
                    sqlcmm.Parameters.AddWithValue("@HRstatus", true);
                    sqlcmm.Parameters.AddWithValue("@HRstatus1", DBNull.Value);
                }
                else if (tleft.SelectedValue == "No")
                {
                    sqlcmm.Parameters.AddWithValue("@HRstatus", false);
                    sqlcmm.Parameters.AddWithValue("@HRstatus1", DBNull.Value);
                }
                else
                {
                    sqlcmm.Parameters.AddWithValue("@HRstatus", false);
                    sqlcmm.Parameters.AddWithValue("@HRstatus1", true);
                }
                sqlcnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                download = dt;
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
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("Employee.xls", Encoding.UTF8).ToString());
            Response.ContentType = "application/ms-excel";
            this.EnableViewState = false;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            GridView1.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
      
      

    }
   


    



}
