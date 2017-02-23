using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;//日期格式化
using Aspose.Cells;//excel
using System.Drawing;

public partial class Training_Alert_Search : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {



        if (Session["staffno"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Label1.Text = "Welcome " + Session["staffname"].ToString();
            if (!IsPostBack)
            {
                //第一次打开设置下拉框
                Station.Items.Clear();
                Station.Items.Add("");
                string SQL_Station = "select a.Station as Station2 from MSAS_Station a order by a.Station ";
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_Station))
                {
                    while (rdr.Read())
                    {
                        Station.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                    }

                }



                Department.Items.Clear();
                Department.Items.Add("");
                string SQL_Department = "select a.Department as Department2 from MSAS_Department a order by a.Department ";
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_Department))
                {
                    while (rdr.Read())
                    {
                        Department.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                    }

                }
                Training_Type.Items.Add("");
                Training_Type.Items.Add("General Initial");
                Training_Type.Items.Add("General Recurrent");
                Training_Type.Items.Add("General One Time");
                Training_Type.Items.Add("Position Initial");
                Training_Type.Items.Add("Position Recurrent");
                Training_Type.Items.Add("Position One Time");
                Training_Type.Items.Add("Other");


                Alert.Items.Add("");
                Alert.Items.Add("Need Initial");
                Alert.Items.Add("Need Recurrent");

                Division.Items.Clear();
                Division.Items.Add("");
                string SQL_Div = "select a.Division as Division1 from MSAS_Division a order by  a.Division ";
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_Div))
                {
                    while (rdr.Read())
                    {
                        Division.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                    }

                }


                Course.Items.Clear();
                Course.Items.Add("");
                string SQL_course_d = "select Course from MSAS_Course order by id";
                using (SqlDataReader rdr = SqlHelper1.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_course_d))
                {
                    while (rdr.Read())
                    {

                        Course.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));

                    }

                }

                Course_re.Items.Clear();
                Course_re.Items.Add("");
                string SQL_course_re = "select Course_Ref  from MSAS_Course_Reference  order by id ";
                using (SqlDataReader rdr = SqlHelper1.ExecuteReader(SqlHelper1.Conn, CommandType.Text, SQL_course_re))
                {
                    while (rdr.Read())
                    {

                        Course_re.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));

                    }

                }


            }
            else
            {
                GetData();
            }

            if (Request.QueryString["Page"] != null)
            {
                if (Request.QueryString["Staffid"].ToString() != "")
                    Staff_Id.Text = Request.QueryString["Staffid"].ToString();

                if (Request.QueryString["Station"].ToString() != "")
                    Station.SelectedValue = Request.QueryString["Station"].ToString();


                if (Request.QueryString["Dept"].ToString() != "")
                    Department.SelectedValue = Request.QueryString["Dept"].ToString();


                if (Request.QueryString["Div"].ToString() != "")
                    Division.SelectedValue = Request.QueryString["Div"].ToString();


                if (Request.QueryString["From"].ToString() != "")
                    From.Text = Request.QueryString["From"].ToString();

                if (Request.QueryString["To"].ToString() != "")
                    To.Text = Request.QueryString["To"].ToString();


                if (Request.QueryString["Course"].ToString() != "")
                    Course.SelectedValue = Request.QueryString["Course"].ToString();


                if (Request.QueryString["Course_ref"].ToString() != "")
                    Course_re.SelectedValue = Request.QueryString["Course_ref"].ToString();



                if (Request.QueryString["Course_Type"].ToString() != "")
                    Training_Type.SelectedValue = Request.QueryString["Course_Type"].ToString();



                if (Request.QueryString["Class"].ToString() != "")
                    Class.Text = Request.QueryString["Class"].ToString();


                if (Request.QueryString["alert"].ToString() != "")
                    Alert.SelectedValue = Request.QueryString["alert"].ToString();

                GetData();
            }


        }



    }

    public void GetData()
    {


        //读取数据
        string SQL = "";

        switch (Alert.SelectedItem.Value)
        {

            case "Need Initial":
                SQL = "select distinct * from MSAS_Course_Initial_VW where 1=1";
                break;
            case "Need Recurrent":
                SQL = "select distinct * from MSAS_Course_Recurrent_VW where 1=1";
                break;
            default:
                SQL = "select distinct * from MSAS_Course_I_R_VW where 1=1";
                if (From.Text.Trim() == "" || To.Text.Trim() == "")
                {
                    SQL = SQL + "and Alert<>'OK'";
                }
                break;


        }





      
        if (Staff_Id.Text.Trim() != "")
        {
            SQL = SQL + "and StaffID ='" + Staff_Id.Text + "' ";

        }


      
        if (Station.SelectedItem.Value != "")
        {
            SQL = SQL + "and Station ='" + Station.SelectedItem.Value + "' ";

        }



        if (Department.SelectedItem.Value != "")
        {
            SQL = SQL + "and Department ='" + Department.SelectedItem.Value + "' ";

        }



        if (Division.SelectedItem.Value != "")
        {
            SQL = SQL + "and Division ='" + Division.SelectedItem.Value + "' ";

        }


        if (From.Text.Trim() != "" && To.Text.Trim() != "")
        {
            SQL = SQL + "and (Training_Required_Date between '" + From.Text + "'  and '" + To.Text + "')";

        }



        if (Course.SelectedItem.Value != "")
        {
            SQL = SQL + "and Course ='" + Course.SelectedItem.Value + "' ";

        }



        if (Course_re.SelectedItem.Value != "")
        {
            SQL = SQL + "and Course_Ref ='" + Course_re.SelectedItem.Value + "' ";

        }




        if (Training_Type.SelectedItem.Value != "")
        {
            SQL = SQL + "and Training_Type ='" + Training_Type.SelectedItem.Value + "' ";

        }


        if (Alert.SelectedItem.Value != "")
        {
            SQL = SQL + "and Alert ='" + Alert.SelectedItem.Value + "' ";

        }

        if (Class.Text.Trim() != "")
        {
            SQL = SQL + "and Class_Name like'%" + Class.Text + "%' ";

        }





        SqlDataAdapter sda = new SqlDataAdapter(SQL, SqlHelper1.Conn);
        ds = new DataSet();
        sda.Fill(ds, "Report");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables["Report"].DefaultView;
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
        this.first.NavigateUrl = null;
        this.last.NavigateUrl = null;
        up.NavigateUrl = null;
        next.NavigateUrl = null;
        if (Count > 1)
        {
            this.first.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=1&Staffid=" + Staff_Id.Text + "&Station=" + Station.SelectedItem.Value + "&Dept=" + Department.SelectedItem.Value + "&Div=" + Division.SelectedItem.Value + "&From=" + From.Text + "&To=" + To.Text + "&Course=" + Course.SelectedItem.Value + "&Course_ref=" + Course_re.SelectedItem.Value + "&Course_Type=" + Training_Type.SelectedItem.Value + "&Class=" + Class.Text + "&alert=" + Alert.SelectedItem.Value;
            this.last.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(Count) + "&Staffid=" + Staff_Id.Text + "&Station=" + Station.SelectedItem.Value + "&Dept=" + Department.SelectedItem.Value + "&Div=" + Division.SelectedItem.Value + "&From=" + From.Text + "&To=" + To.Text + "&Course=" + Course.SelectedItem.Value + "&Course_ref=" + Course_re.SelectedItem.Value + "&Course_Type=" + Training_Type.SelectedItem.Value + "&Class=" + Class.Text + "&alert=" + Alert.SelectedItem.Value;
        }

        if (!pds.IsFirstPage)
        {

            up.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1) + "&Staffid=" + Staff_Id.Text + "&Station=" + Station.SelectedItem.Value + "&Dept=" + Department.SelectedItem.Value + "&Div=" + Division.SelectedItem.Value + "&From=" + From.Text + "&To=" + To.Text + "&Course=" + Course.SelectedItem.Value + "&Course_ref=" + Course_re.SelectedItem.Value + "&Course_Type=" + Training_Type.SelectedItem.Value + "&Class=" + Class.Text + "&alert=" + Alert.SelectedItem.Value;
        }

        if (!pds.IsLastPage)
        {

            next.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage + 1) + "&Staffid=" + Staff_Id.Text + "&Station=" + Station.SelectedItem.Value + "&Dept=" + Department.SelectedItem.Value + "&Div=" + Division.SelectedItem.Value + "&From=" + From.Text + "&To=" + To.Text + "&Course=" + Course.SelectedItem.Value + "&Course_ref=" + Course_re.SelectedItem.Value + "&Course_Type=" + Training_Type.SelectedItem.Value + "&Class=" + Class.Text + "&alert=" + Alert.SelectedItem.Value;
        }


        //Repeater
        Report.DataSource = pds;
        Report.DataBind();

    }

    public void GetData1()
    {


        //读取数据
        string SQL = "";

        switch (Alert.SelectedItem.Value)
        {

            case "Need Initial":
                SQL = "select distinct * from MSAS_Course_Initial_VW where 1=1";
                break;
            case "Need Recurrent":
                SQL = "select distinct * from MSAS_Course_Recurrent_VW where 1=1";
                break;
            default:
                SQL = "select distinct * from MSAS_Course_I_R_VW where 1=1 ";
                if (From.Text.Trim() == "" || To.Text.Trim() == "")
                {
                    SQL = SQL + "and Alert<>'OK'";
                }
                break;


        }





      
        if (Staff_Id.Text.Trim() != "")
        {
            SQL = SQL + "and StaffID ='" + Staff_Id.Text + "' ";

        }

        if (Station.SelectedItem.Value != "")
        {
            SQL = SQL + "and Station ='" + Station.SelectedItem.Value + "' ";

        }



        if (Department.SelectedItem.Value != "")
        {
            SQL = SQL + "and Department ='" + Department.SelectedItem.Value + "' ";

        }



        if (Division.SelectedItem.Value != "")
        {
            SQL = SQL + "and Division ='" + Division.SelectedItem.Value + "' ";

        }


        if (From.Text.Trim() != "" && To.Text.Trim() != "")
        {
            SQL = SQL + "and (Training_Required_Date between '" + From.Text + "'  and '" + To.Text + "')";

        }



        if (Course.SelectedItem.Value != "")
        {
            SQL = SQL + "and Course ='" + Course.SelectedItem.Value + "' ";

        }



        if (Course_re.SelectedItem.Value != "")
        {
            SQL = SQL + "and Course_Ref ='" + Course_re.SelectedItem.Value + "' ";

        }




        if (Training_Type.SelectedItem.Value != "")
        {
            SQL = SQL + "and Training_Type ='" + Training_Type.SelectedItem.Value + "' ";

        }


        if (Alert.SelectedItem.Value != "")
        {
            SQL = SQL + "and Alert ='" + Alert.SelectedItem.Value + "' ";

        }

        if (Class.Text.Trim() != "")
        {
            SQL = SQL + "and Class_Name like'%" + Class.Text + "%' ";

        }





        SqlDataAdapter sda = new SqlDataAdapter(SQL, SqlHelper1.Conn);
        ds = new DataSet();
        sda.Fill(ds, "Report");

        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables["Report"].DefaultView;
        pds.AllowPaging = true;//允许分页
        pds.PageSize = 10;//单页显示项数
        int CurPage;
        //if (Request.QueryString["Page"] != null)
        //    CurPage = Convert.ToInt32(Request.QueryString["Page"]);
        //else
        CurPage = 1;
        pds.CurrentPageIndex = CurPage - 1;
        int Count = pds.PageCount;
        lblCurrentPage.Text = "Current Page：" + CurPage.ToString();
        labPage.Text = Count.ToString();

        this.first.NavigateUrl = null;
        this.last.NavigateUrl = null;
        up.NavigateUrl = null;
        next.NavigateUrl = null;
        if (Count > 1)
        {
            this.first.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=1&Staffid=" + Staff_Id.Text + "&Station=" + Station.SelectedItem.Value + "&Dept=" + Department.SelectedItem.Value + "&Div=" + Division.SelectedItem.Value + "&From=" + From.Text + "&To=" + To.Text + "&Course=" + Course.SelectedItem.Value + "&Course_ref=" + Course_re.SelectedItem.Value + "&Course_Type=" + Training_Type.SelectedItem.Value + "&Class=" + Class.Text + "&alert=" + Alert.SelectedItem.Value;
            this.last.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(Count) + "&Staffid=" + Staff_Id.Text + "&Station=" + Station.SelectedItem.Value + "&Dept=" + Department.SelectedItem.Value + "&Div=" + Division.SelectedItem.Value + "&From=" + From.Text + "&To=" + To.Text + "&Course=" + Course.SelectedItem.Value + "&Course_ref=" + Course_re.SelectedItem.Value + "&Course_Type=" + Training_Type.SelectedItem.Value + "&Class=" + Class.Text + "&alert=" + Alert.SelectedItem.Value;
        }

        if (!pds.IsFirstPage)
        {

            up.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1) + "&Staffid=" + Staff_Id.Text + "&Station=" + Station.SelectedItem.Value + "&Dept=" + Department.SelectedItem.Value + "&Div=" + Division.SelectedItem.Value + "&From=" + From.Text + "&To=" + To.Text + "&Course=" + Course.SelectedItem.Value + "&Course_ref=" + Course_re.SelectedItem.Value + "&Course_Type=" + Training_Type.SelectedItem.Value + "&Class=" + Class.Text + "&alert=" + Alert.SelectedItem.Value;
        }

        if (!pds.IsLastPage)
        {

            next.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage + 1) + "&Staffid=" + Staff_Id.Text + "&Station=" + Station.SelectedItem.Value + "&Dept=" + Department.SelectedItem.Value + "&Div=" + Division.SelectedItem.Value + "&From=" + From.Text + "&To=" + To.Text + "&Course=" + Course.SelectedItem.Value + "&Course_ref=" + Course_re.SelectedItem.Value + "&Course_Type=" + Training_Type.SelectedItem.Value + "&Class=" + Class.Text + "&alert=" + Alert.SelectedItem.Value;
        }


        //Repeater
        Report.DataSource = pds;
        Report.DataBind();

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");

    }
    protected void Search_Click(object sender, EventArgs e)
    {
        GetData1();

        //Response.Write("<script>window.open('Training_Records_Print.aspx?staffno=00200','_blank')</script>");

        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Training_Records_Print.aspx','_blank')</script>");
        //Response.Redirect("Training_Records_Print.aspx");
    }
    protected void Download_Click(object sender, EventArgs e)
    {

        string[] title = { "Staff ID", "Staff Name", "Station", "Divion", "Class","Batch", "Course", "Course Refence", "Last Training Date", "Next Due" };
        int[] ColumnWidth = { 20, 50, 20, 20, 50, 20, 100, 50, 30, 30 };
        downloadexcel(ds.Tables["Report"], title, ColumnWidth, "Training_Alert");
    }


    public void downloadexcel(DataTable dt, string[] title, int[] ColumnWidth, string ReportTitleName)
    {
        GetData();
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

        //表头格式
        Aspose.Cells.Style style3 = wb.Styles[wb.Styles.Add()];
        style3.HorizontalAlignment = TextAlignmentType.Center;
        style3.Font.IsBold = true;//设置粗体
        style3.Font.Size = 10;//设置字体大小


        //sheet1
        Worksheet ws = wb.Worksheets[0];
        Cells cell = ws.Cells;
        ws.Name = "Telephone";
        //合并第一行单元格
        Aspose.Cells.Range range = cell.CreateRange(0, 0, 1, ColumnWidth.Length);
        range.Merge();
        cell["A1"].PutValue(ReportTitleName); //标题
        //给单元格关联样式
        cell["A1"].SetStyle(style1); //报表名字 样式
        //设置Execl列名  可以采用单独传值
        for (int i = 0; i < title.Length; i++)
        {
            cell[1, i].PutValue(title[i]);
            cell[1, i].SetStyle(style3);

        }

        //设置单元格内容
        int posStart = 2;
        int row = 0;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow Drow = dt.Rows[i];
            cell[row + posStart, 0].PutValue(Drow["StaffID"].ToString());
            cell[row + posStart, 0].SetStyle(style2);
            cell[row + posStart, 1].PutValue(Drow["StaffName"].ToString());
            cell[row + posStart, 1].SetStyle(style2);
            cell[row + posStart, 2].PutValue(Drow["Station"].ToString());
            cell[row + posStart, 2].SetStyle(style2);
            cell[row + posStart, 3].PutValue(Drow["Division"].ToString());
            cell[row + posStart, 3].SetStyle(style2);
            cell[row + posStart, 4].PutValue(Drow["Class_Name"].ToString());
            cell[row + posStart, 4].SetStyle(style2);
            cell[row + posStart, 5].PutValue(Drow["Batch"].ToString());
            cell[row + posStart, 5].SetStyle(style2);
            cell[row + posStart, 6].PutValue(Drow["Course"].ToString());
            cell[row + posStart, 6].SetStyle(style2);
            cell[row + posStart, 7].PutValue(Drow["Course_Ref"].ToString());
            cell[row + posStart, 7].SetStyle(style2);
            cell[row + posStart, 8].PutValue(Convert.ToDateTime(Drow["Training_Date"]).ToString("yyyy-MM-dd"));
            cell[row + posStart, 8].SetStyle(style2);
            cell[row + posStart, 9].PutValue(Convert.ToDateTime(Drow["Training_Required_Date"]).ToString("yyyy-MM-dd"));
            cell[row + posStart, 9].SetStyle(style2);


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
}