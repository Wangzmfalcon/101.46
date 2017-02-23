using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    string filepath = null;
    string savePath = null;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["User_ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else


            if (Session["MOA_Station"] == null)
                Session["MOA_Station"] = "";



        Bind();
        GridView1.Visible = false;


    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }

    //读取excel数据
    public static DataSet LoadDataFromExcel(string filePath, string Exceltype)
    {

        string strConn;//连接EXCEL语句

        switch (Exceltype)//EXCEL各版本的链接语句
        {
            case ".xls"://2003
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=yes;IMEX=1;'";
                break;
            case ".xlsx"://2007
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                break;
            default:
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                break;
        }
        //strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";

        OleDbConnection OleConn = new OleDbConnection(strConn);//建立链接
        OleConn.Open();//打开EXCEL
        DataSet OleDsExcle = new DataSet();//建立DS
        //String sql = "SELECT [Reponsible QA][CAR/CAF No#],[Div/Sta#],[Final-Reply],[CA Target Date],[PA Target Date] FROM  [2014 Control$A1:AW2000]";//可是更改Sheet名称，比如sheet2，等等  
        String sql = "SELECT * FROM  [Sheet1$B6:FF2000]";//可是更改Sheet名称，比如sheet2，等等   
        OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);//读出数据
        OleDaExcel.Fill(OleDsExcle, "dt");//DS的表名字

        OleConn.Close();//链接断开
        return OleDsExcle;

    }



    //上传
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (FileUpload1.HasFile)//如果有选择文件
        {
            filepath = "Files/";//存储路径
            string filename = Server.HtmlEncode(FileUpload1.FileName);//名字
            string extension = System.IO.Path.GetExtension(filename);//扩展名字

            if (extension == ".xlsx" || extension == ".xls")
            {
                savePath = filepath + filename;//存储相对路径
                FileUpload1.SaveAs(Server.MapPath(savePath));//存到服务器





                //从EXCEL读取新数据
                DataSet ds = LoadDataFromExcel(Server.MapPath(savePath), extension);//存储数据 

                //Label5.Text = Server.MapPath(savePath);
                //插入数据  ds是新数据   dt是旧数据用来回写状态
                DataTable dt = new DataTable();
                InsertToDataBase(ds, dt);

                statuschk(dt);

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('文件错误.');</script>");
            }
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('上传成功.');</script>");
        }
        else

            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('请选择上传的文件.');</script>");
    }


    public void statuschk(DataTable dt)
    {

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = dt.Rows[i];
            string SQL_query = " select * from Outstation_MOA_Monitoring  "
                + " where Record_S ='1' and Station ='" + row["Station"].ToString() + "'";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
            {
                if (rdr.Read())
                {
                    if (rdr["Expiry_Date"].ToString().Trim() == row["Expiry_Date"].ToString().Trim())//AU检测
                    {
                        string SQL_UP = " UPDATE Outstation_MOA_Monitoring  "
                        + " SET Expiry_Date_S  ='" + row["Expiry_Date_S"].ToString().Trim() + "',Expiry_Date_P ='" + row["Expiry_Date_P"].ToString().Trim() + "'"
                        + " where Record_S ='1' and  Station='" + row["Station"].ToString() + "'";
                        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                        {
                            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
                        }
                    }

                }

            }


        }

    }
    //插入数据
    public bool InsertToDataBase(DataSet ds, DataTable dt)
    {
        bool flag = false;//用来return
        //读取原纪录
        string SQL_query = " select * from Outstation_MOA_Monitoring where Record_S ='1'";


        dt.Columns.Add("Station", typeof(string));
        dt.Columns.Add("NAA_Certificate", typeof(string));

        dt.Columns.Add("Expiry_Date", typeof(string));
        dt.Columns.Add("Expiry_Date_P", typeof(string));
        dt.Columns.Add("Expiry_Date_S", typeof(string));




        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {

            while (rdr.Read())
            {

                DataRow row = dt.NewRow();
                row["Station"] = Convert.ToString(rdr.GetSqlValue(0));
                row["NAA_Certificate"] = Convert.ToString(rdr.GetSqlValue(1));

                row["Expiry_Date"] = Convert.ToString(rdr.GetSqlValue(2));
                row["Expiry_Date_P"] = Convert.ToString(rdr.GetSqlValue(3));
                row["Expiry_Date_S"] = Convert.ToString(rdr.GetSqlValue(4));

                dt.Rows.Add(row);

            }

        }

        //修改状态
        string SQL_updates = " UPDATE Outstation_MOA_Monitoring SET Record_S = '0' where Record_S = '1' ";
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_updates);
        }



        string SQL_Insert =//插入
           "INSERT INTO Outstation_MOA_Monitoring (Station,NAA_Certificate,Expiry_Date) " +
           "VALUES(@Station,@NAA_Certificate,@Expiry_Date)";

        SqlParameter[] parms = new SqlParameter[]{
            new SqlParameter("@Station", SqlDbType.VarChar, 20),
            new SqlParameter("@NAA_Certificate", SqlDbType.VarChar, 30),
            new SqlParameter("@Expiry_Date",SqlDbType.Date)
                
         };


        for (int i = 0; i < ds.Tables["dt"].Rows.Count; i++)
        {
            DataRow row = ds.Tables["dt"].Rows[i];
            if (row[1].ToString() == "")
                break;
            parms[0].Value = row[1].ToString().Trim();
            parms[1].Value = row[9].ToString().Trim();


            try
            {
                parms[2].Value = Convert.ToDateTime(row[10].ToString());
            }
            catch (Exception e2)
            {
                parms[2].Value = Convert.ToDateTime("2099-12-31");

            }

            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Insert, parms);
            }



        }


        return flag;
    }



    //查询
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["MOA_Station"] = TextBox1.Text;

        Bind();

    }


    //数据绑定
    protected void Bind()
    {

        string can = "";
      

        if (Session["MOA_Station"].ToString() != "")
        {
            can = " and (Station like '%" + Session["MOA_Station"].ToString().Trim() + "%')";
        }





        string SQL_query = " select * from Outstation_MOA_Monitoring "
            + "  where Record_S ='1' " + can;

        DataTable dt = new DataTable();
        dt.Columns.Add("Station", typeof(string));
        dt.Columns.Add("NAA_Certificate", typeof(string));

        dt.Columns.Add("Expiry_Date", typeof(string));
        dt.Columns.Add("Expiry_Date_P", typeof(string));
        dt.Columns.Add("Expiry_Date_S", typeof(string));

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {

            while (rdr.Read())
            {

                DataRow row = dt.NewRow();
                row["Station"] = Convert.ToString(rdr.GetSqlValue(0));
                row["NAA_Certificate"] = Convert.ToString(rdr.GetSqlValue(1));

                row["Expiry_Date"] = Convert.ToString(rdr.GetSqlValue(2));
                row["Expiry_Date_P"] = Convert.ToString(rdr.GetSqlValue(3));
                row["Expiry_Date_S"] = Convert.ToString(rdr.GetSqlValue(4));
                dt.Rows.Add(row);
            }
        }

        GridView1.Columns.Clear();
        if (dt == null)
        {
            GridView1.Visible = false;
        }
        else
        {


            AddGridViewColumn(dt.Columns[0].ColumnName, 0, null, 10);//
            AddGridViewColumn(dt.Columns[1].ColumnName, 0, null, 10); //              
            AddGridViewColumn(dt.Columns[2].ColumnName, 0, null, 10); //  
            AddGridViewColumn(dt.Columns[3].ColumnName, 0, null, 10); //  
            AddGridViewColumn(dt.Columns[4].ColumnName, 0, null, 10); //  

            AddGridViewColumn("确认", 4, "Button1", 10);

            GridView1.DataSource = dt;
            GridView1.DataBind();


            for (int j = GridView1.PageIndex * GridView1.PageSize, i = 0; i < GridView1.PageSize && j < dt.Rows.Count; i++, j++)
            {
                GridView1.Rows[i].Cells[0].Text = dt.Rows[j]["Station"].ToString();
                GridView1.Rows[i].Cells[1].Text = dt.Rows[j]["NAA_Certificate"].ToString();
                GridView1.Rows[i].Cells[2].Text = Convert.ToDateTime(dt.Rows[j]["Expiry_Date"]).ToShortDateString();
                GridView1.Rows[i].Cells[3].Text = dt.Rows[j]["Expiry_Date_P"].ToString();
                GridView1.Rows[i].Cells[4].Text = getstatus(dt.Rows[j]["Expiry_Date_S"].ToString());
                ((Button)GridView1.Rows[i].Cells[5].FindControl("Button1")).Text = "确认";
                ((Button)GridView1.Rows[i].Cells[5].FindControl("Button1")).CommandName = "ATD";
                ((Button)GridView1.Rows[i].Cells[5].FindControl("Button1")).OnClientClick = "return confirm('是否确认')";
                if (dt.Rows[j]["Expiry_Date_S"].ToString().Trim() != "1")
                {
                    ((Button)GridView1.Rows[i].Cells[5].FindControl("Button1")).Enabled = false;

                }

                if (dt.Rows[j]["Expiry_Date_S"].ToString().Trim() == "2")
                {
                    GridView1.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Black;
                }
                if (dt.Rows[j]["Expiry_Date_S"].ToString().Trim() == "4")
                {
                    GridView1.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Red;
                }


            }


            GridView1.Visible = true;
 

        }

    }


    //状态判断
    private string getstatus(string intt)
    {
        string state = "";
        switch (Convert.ToInt32(intt))
        {
            case 0:
                state = "未到时";
                break;
            case 1:
                state = "已提醒";
                break;
            case 2:
                state = "已确认";
                break;
            case 3:
                state = "未知状态1";
                break;
            case 4:
                state = "已过期";
                break;
            default:
                state = "未知状态2";
                break;
        }
        return state;

    }
    //gridview添加行
    private void AddGridViewColumn(string ColumnName, int type, string linkButtonName, int width)
    {
        GridViewTemplate temp = new GridViewTemplate(DataControlRowType.DataRow, ColumnName, type, linkButtonName);
        //ETemplate etemp =new ETemplate(DataControlRowType.DataRow, ColumnName,linkButtonName);       
        TemplateField field = new TemplateField();
        field.HeaderText = ColumnName;
        field.ItemTemplate = temp;
        //field.EditItemTemplate = etemp;
        field.ItemStyle.Width = Unit.Percentage(width);
        GridView1.Columns.Add(field);
    }


    //换页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView gvw = (GridView)sender;
        if (e.NewPageIndex < 0)
        {
            //TextBox pageNum = (TextBox)gvw.BottomPagerRow.FindControl("tbPage");
            //int Pa = int.Parse(pageNum.Text);
            //if (Pa <= 0)
            //    gvw.PageIndex = 0;
            //else
            //    gvw.PageIndex = Pa - 1;
            //gvw.PageIndex = e.NewPageIndex;
        }
        else
        {
            gvw.PageIndex = e.NewPageIndex;
        }
        Bind();
    }


    //编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex; //使GridView控件的第e.NewEditIndex行处于可编辑状态

        Bind();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "ATD")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;


            string SQL_UP = " UPDATE Outstation_MOA_Monitoring  "
                + " SET Expiry_Date_S  ='2'"
                + " where Record_S ='1' and  Station ='" + gvr.Cells[2].Text.ToString().Trim() + "'";
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
            }


        }
       


        Bind();
    }






    #region 自定义GridView类
    public class ETemplate : ITemplate
    {
        private DataControlRowType templateType;
        private string columnName;
        private int style;
        private string uName;
        public ETemplate(DataControlRowType type, string colname, string usercontrolName)
        {
            templateType = type;
            columnName = colname;
            uName = usercontrolName;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            if (templateType == DataControlRowType.DataRow)
            {


                TextBox tb = new TextBox();
                tb.ID = uName;
                container.Controls.Add(tb);



            }
        }
        private void tb_DataBinding(object sender, EventArgs e)
        {
            LiteralControl lb = (LiteralControl)sender;
            GridViewRow container = (GridViewRow)lb.NamingContainer;
            lb.Text = "";
        }
    }
    #endregion

    #region 自定义GridView类
    public class GridViewTemplate : ITemplate
    {
        private DataControlRowType templateType;
        private string columnName;
        private int style;
        private string uName;
        public GridViewTemplate(DataControlRowType type, string colname, int str, string usercontrolName)
        {
            templateType = type;
            columnName = colname;
            style = str;
            uName = usercontrolName;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            if (templateType == DataControlRowType.DataRow)
            {
                switch (style)
                {
                    case 0:
                        LiteralControl label = new LiteralControl();
                        label.DataBinding += new EventHandler(tb_DataBinding);
                        container.Controls.Add(label);
                        break;
                    case 1:
                        HyperLink link = new HyperLink();
                        link.ID = uName;
                        container.Controls.Add(link);
                        break;
                    case 2:
                        LinkButton lbtn = new LinkButton();
                        lbtn.ID = uName;
                        container.Controls.Add(lbtn);
                        break;
                    case 3:
                        TextBox tb = new TextBox();
                        tb.ID = uName;
                        container.Controls.Add(tb);
                        break;

                    case 4:
                        Button bt = new Button();
                        bt.ID = uName;
                        container.Controls.Add(bt);
                        break;
                }

            }
        }
        private void tb_DataBinding(object sender, EventArgs e)
        {
            LiteralControl lb = (LiteralControl)sender;
            GridViewRow container = (GridViewRow)lb.NamingContainer;
            string str = ((DataRowView)container.DataItem)[columnName].ToString();
            lb.Text = "";
        }
    }
    #endregion






}


