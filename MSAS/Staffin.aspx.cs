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
using SMS.DBUtility;
using Aspose.Cells;//excel

public partial class Staffin : System.Web.UI.Page
{
    GridView gv = new GridView();
    DataTable dt = new DataTable();
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
                //DataTable dt = new DataTable();
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
                sqlcmm.CommandText = "select Seq,StaffID,StaffName,Station,Department,Division,Title,License,(DATENAME(dd,DateOfJoin)+'-'+SUBSTRING(DATENAME(mm,DateOfJoin),0,4)+'-'+DATENAME(yyyy,DateOfJoin) )AS DateofJoin,(DATENAME(dd,LicenseExpired)+'-'+SUBSTRING(DATENAME(mm,LicenseExpired),0,4)+'-'+DATENAME(yyyy,LicenseExpired) )AS LicenseExpired,HRstatus,category,notJMM,(DATENAME(dd,DateOfLeft)+'-'+SUBSTRING(DATENAME(mm,DateOfLeft),0,4)+'-'+DATENAME(yyyy,DateOfLeft) )AS DateOfLeft,(DATENAME(dd,Birthdate)+'-'+SUBSTRING(DATENAME(mm,Birthdate),0,4)+'-'+DATENAME(yyyy,Birthdate)) AS Birthdate from MSAS_HRInfo order by StaffID";
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
                string uid = stano.Text;
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
                    SqlCommand insertCmd = new SqlCommand("insert into MSAS_HRInfo  (StaffID,StaffName,Department,Division,Station,Title,DateOfJoin,License,Category,notJMM,LicenseExpired,DateOfLeft,HRstatus,Birthdate)values(@StaffID,@StaffName,@Department,@Division,@Station,@Title,@DateOfJoin,@License,@Category,@notJMM,@LicenseExpired,@DateOfLeft,@HRstatus,@Birthdate)", cn);
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
                    insertCmd.Parameters.Add("@Birthdate", SqlDbType.DateTime);

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
                    insertCmd.Parameters["@Birthdate"].Value = IsNull(Birthdate.Text);
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


        //插入Position

        string SQL_insert = "  INSERT INTO  MSAS_Position_S (StaffID,Position) values (@StaffID,@Position)";

        SqlParameter[] parms = new SqlParameter[]{
                     new SqlParameter("@StaffID",  SqlDbType.VarChar, 50),
                     new SqlParameter("@Position", SqlDbType.VarChar, 50)
      
               };
        parms[0].Value = stano.Text;
        parms[1].Value = "Other ENM Staff";
        using (SqlConnection conn = new SqlConnection(SqlHelper1.Conn))
        {
            int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert, parms);
            if (actionrows > 0)
            {
                // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data success');</script>");


            }
            else
            {
                // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data faild');</script>");
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
                    GetData1();
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
        string DateOfBirth = (GridView1.Rows[e.RowIndex].FindControl("TextBirthdate") as TextBox).Text;
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "update MSAS_HRInfo set StaffID=@StaffID,StaffName=@StaffName,Department=@Department,Division=@Division,Station=@Station,Title=@Title,DateOfJoin=@DateOfJoin,License=@License,LicenseExpired=@LicenseExpired,HRStatus=@HRStatus ,category=@category,notJMM=@notJMM,DateOfLeft=@DateOfLeft,Birthdate=@Birthdate  where Seq=@id";
                sqlcmm.Parameters.AddWithValue("@StaffID", staffno);
                sqlcmm.Parameters.AddWithValue("@id", Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("Label1") as Label).Text));
                sqlcmm.Parameters.AddWithValue("@StaffName", staffname);
                sqlcmm.Parameters.AddWithValue("@Department", department);
                sqlcmm.Parameters.AddWithValue("@Station", station1);
                sqlcmm.Parameters.AddWithValue("@Division", division);
                sqlcmm.Parameters.AddWithValue("@Title", title);
                sqlcmm.Parameters.AddWithValue("@DateOfJoin", IsNull(jointime));
                sqlcmm.Parameters.AddWithValue("@License", license);
                sqlcmm.Parameters.AddWithValue("@LicenseExpired", IsNull(licenseEx));
                sqlcmm.Parameters.AddWithValue("@HRStatus", HRs);
                sqlcmm.Parameters.AddWithValue("@category", category);
                sqlcmm.Parameters.AddWithValue("@notJMM", JMM);
                sqlcmm.Parameters.AddWithValue("@DateOfLeft", IsNull(DateOfLeft));
                sqlcmm.Parameters.AddWithValue("@Birthdate", IsNull(DateOfBirth));
                sqlcnn.Open();
                int i = sqlcmm.ExecuteNonQuery();
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('success');</script>");
                    GridView1.EditIndex = -1;
                    GetData1();
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
        if (Equals(Convert.ToString(item), ""))
        {
            return DBNull.Value;
        }
        else
        {
            return Convert.ToString(item);
        }
    }

    private void GetData1()
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select Seq,StaffID,StaffName,category,Department,Division,Station,Title,License,(DATENAME(dd,DateOfJoin)+'-'+SUBSTRING(DATENAME(mm,DateOfJoin),0,4)+'-'+DATENAME(yyyy,DateOfJoin) )AS DateofJoin,(DATENAME(dd,LicenseExpired)+'-'+SUBSTRING(DATENAME(mm,LicenseExpired),0,4)+'-'+DATENAME(yyyy,LicenseExpired) )AS LicenseExpired,HRstatus,notJMM,(DATENAME(dd,DateOfLeft)+'-'+SUBSTRING(DATENAME(mm,DateOfLeft),0,4)+'-'+DATENAME(yyyy,DateOfLeft) )AS DateOfLeft,(DATENAME(dd,Birthdate)+'-'+SUBSTRING(DATENAME(mm,Birthdate),0,4)+'-'+DATENAME(yyyy,Birthdate)) AS Birthdate from MSAS_HRInfo where StaffID like @StaffID and StaffName like @StaffName and Department like @Department and Division =(case when @Division=''then Division else @Division end) and Title =(case when @Title=''then Title else @Title end) and License like @License and Station =(case when @Station=''then Station else @Station end) and category =(case when @category=''then category else @category end) and (notJMM = @notJMM or notJMM = @notJMM1) and (HRstatus=@HRstatus or HRstatus=@HRstatus1)  order by StaffID";
                sqlcmm.Parameters.AddWithValue("@StaffID", "%" + this.txtName.Text + "%");
                sqlcmm.Parameters.AddWithValue("@StaffName", "%" + this.tname.Text + "%");
                sqlcmm.Parameters.AddWithValue("@Department", "%" + this.tdepart.SelectedValue + "%");
                sqlcmm.Parameters.AddWithValue("@Division", this.tdivi.SelectedValue);
                sqlcmm.Parameters.AddWithValue("@Station", this.station.SelectedValue);
                sqlcmm.Parameters.AddWithValue("@Title", this.ttitle.SelectedValue);
                sqlcmm.Parameters.AddWithValue("@category", this.tcate.SelectedValue);
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
                //DataTable dt = new DataTable();
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
    protected void Button6_Click(object sender, EventArgs e)
    {
        GetData1();
    }
    //protected void downloadlink(object sender, EventArgs e)
    //{

    //    //Response.Charset = "GB2312";
    //    //Response.ContentEncoding = System.Text.Encoding.UTF8;
    //    //Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("Employee.xls", Encoding.UTF8).ToString());
    //    //Response.ContentType = "application/ms-excel";
    //    //this.EnableViewState = false;
    //    //StringWriter tw = new StringWriter();
    //    //HtmlTextWriter hw = new HtmlTextWriter(tw);
    //    //GridView1.RenderControl(hw);
    //    //Response.Write(tw.ToString());
    //    //Response.End();

    //    GridView1.AllowPaging = false;
    //    GetData1();

    //    string strStyle = "<style>td{mso-number-format:\"\\@\";}</style>";
    //    Response.Charset = "GB2312";
    //    Response.ContentEncoding = System.Text.Encoding.UTF8;
    //    Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("Employee.xls", Encoding.UTF8).ToString());
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
    protected void downloadlink(object sender, EventArgs e)
    {

        GetData1();


        //设置EXCEL列宽
        int[] ColumnWidth = { 10, 30, 20, 20, 20, 50, 30, 30, 30, 20, 20, 30, 30, 30};
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
        cell[1, 3].PutValue("Dept.");
        cell[1, 3].SetStyle(style2);
        cell[1, 4].PutValue("Div.");
        cell[1, 4].SetStyle(style2);
        cell[1, 5].PutValue("Title");
        cell[1, 5].SetStyle(style2);
        cell[1, 6].PutValue("Date of Join");
        cell[1, 6].SetStyle(style2);
        cell[1, 7].PutValue("License");
        cell[1, 7].SetStyle(style2);
        cell[1, 8].PutValue("Category");
        cell[1, 8].SetStyle(style2);
        cell[1, 9].PutValue("Not JMM");
        cell[1, 9].SetStyle(style2);
        cell[1, 10].PutValue("Lic. Exp.");
        cell[1, 10].SetStyle(style2);
        cell[1, 11].PutValue("Date of Left");
        cell[1, 11].SetStyle(style2);
        cell[1, 12].PutValue("Date of Birth");
        cell[1, 12].SetStyle(style2);
        cell[1, 13].PutValue("Left");
        cell[1, 13].SetStyle(style2);

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
            cell[row + posStart, 2].PutValue(Drow[6].ToString());
            cell[row + posStart, 2].SetStyle(style2);
            cell[row + posStart, 3].PutValue(Drow[4].ToString());
            cell[row + posStart, 3].SetStyle(style2);
            cell[row + posStart, 4].PutValue(Drow[5].ToString());
            cell[row + posStart, 4].SetStyle(style2);
            cell[row + posStart, 5].PutValue(Drow[7].ToString());
            cell[row + posStart, 5].SetStyle(style2);
            cell[row + posStart, 6].PutValue(Drow[9].ToString());
            cell[row + posStart, 6].SetStyle(style2);
            cell[row + posStart, 7].PutValue(Drow[8].ToString());
            cell[row + posStart, 7].SetStyle(style2);
            cell[row + posStart, 8].PutValue(Drow[3].ToString());
            cell[row + posStart, 8].SetStyle(style2);
            cell[row + posStart, 9].PutValue(Drow[12].ToString());
            cell[row + posStart, 9].SetStyle(style2);
            cell[row + posStart, 10].PutValue(Drow[10].ToString());
            cell[row + posStart, 10].SetStyle(style2);
            cell[row + posStart, 11].PutValue(Drow[13].ToString());
            cell[row + posStart, 11].SetStyle(style2);
            cell[row + posStart, 12].PutValue(Drow[14].ToString());
            cell[row + posStart, 12].SetStyle(style2);
            cell[row + posStart, 13].PutValue(Drow[11].ToString());
            cell[row + posStart, 13].SetStyle(style2);

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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string useri1 = ((LinkButton)GridView1.SelectedRow.Cells[1].FindControl("Label2")).Text;
        //  (LinkButton)GridView1.SelectedRow.Cells[1].Attributes.Add("onclick", "this.form.target='_blank'"); 
        // Session["userNo"] = useri1;
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Position_setting.aspx?user=" + useri1 + "','_blank')</script>");
        //Response.Redirect("Authorizationprint.aspx?staffno=" + useri1);
        //     Response.Write("<script>window.open('Authorizationprint.aspx?staffno=" + useri1 + "','_blank')</script>");
    }



}
