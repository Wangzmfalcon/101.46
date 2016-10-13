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
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        if (Session["User_ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
            Label1.Text = "Welcome " + Session["User_Name"].ToString();

            if (Session["CAR_No"] == null)
                Session["CAR_No"] = "";
            if (Session["Audit_Title"] == null)
                Session["Audit_Title"] = "";
            if (Session["Div"] == null)
                Session["Div"] = "";
             if (Session["Fk"] == null)
                 Session["Fk"] = "";

        
            Bind();
            GridView1.Visible = false;
            Label4.Text = "Total: 0 items";
        
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

        OleDbConnection OleConn = new OleDbConnection(strConn);//建立链接
        OleConn.Open();//打开EXCEL
        DataSet OleDsExcle = new DataSet();//建立DS
        String sql = "SELECT * FROM  [Control$A1:AW2000]";//可是更改Sheet名称，比如sheet2，等等   
         OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);//读出数据
         OleDaExcel.Fill(OleDsExcle,"dt");//DS的表名字
        
        OleConn.Close();//链接断开
        return OleDsExcle;
   
    }



    //上传
    protected void Button1_Click(object sender, EventArgs e)
    {
          string savePath = null;
          if (FileUpload1.HasFile)//如果有选择文件
          {
              string filepath = "Files/";//存储路径
              string filename = Server.HtmlEncode(FileUpload1.FileName);//名字
              string extension = System.IO.Path.GetExtension(filename);//扩展名字

              if (extension == ".xlsx" || extension == ".xls")
              {
                  savePath = filepath + filename;//存储相对路径
                  FileUpload1.SaveAs(Server.MapPath(savePath));//存到服务器
                  
            



                  //从EXCEL读取新数据
                  DataSet ds = LoadDataFromExcel(Server.MapPath(savePath), extension);//存储数据 




                  //插入数据  ds是新数据   dt是旧数据用来回写状态
                  DataTable dt = new DataTable();
                  InsertToDataBase(ds,dt);

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

        for (int i = 0; i < dt.Rows.Count;i++ )
        {
            DataRow row = dt.Rows[i];
            string SQL_query = " select * from DLR_Finding_Control "
                + " where CAR_No ='" + row["CAR_No"].ToString() + "'";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
            {
                if (rdr.Read())
                {
                    if (rdr["Final_Issue_Date"].ToString().Trim() == row["Final_Issue_Date"].ToString().Trim())//AU检测
                    {
                        string SQL_UP = " UPDATE DLR_Finding_Control  "
                        + " SET Final_Issue_Date_S  ='" + row["Final_Issue_Date_S"].ToString().Trim() + "',Final_Issue_Date_P ='" + row["Final_Issue_Date_P"].ToString().Trim() + "'"
                        + " where CAR_No='" + row["CAR_No"].ToString() + "'";
                      using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                      {
                          SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
                      }
                    }
                    


                    if (rdr["Final_Due_Date"].ToString().Trim() == row["Final_Due_Date"].ToString().Trim())//AU检测
                    {
                        string SQL_UP = " UPDATE DLR_Finding_Control  "
                        + " SET Final_Due_Date_S  ='" + row["Final_Due_Date_S"].ToString().Trim() + "',Final_Due_Date_P ='" + row["Final_Due_Date_P"].ToString().Trim() + "'"
                        + " where CAR_No='" + row["CAR_No"].ToString() + "'";
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
    public bool InsertToDataBase(DataSet ds,DataTable dt)
    {
        bool flag = false;//用来return
        //读取原纪录
        string SQL_query = " select * from DLR_Finding_Control ";

        dt.Columns.Add("Findings", typeof(string));
        dt.Columns.Add("CAR_No", typeof(string));
        dt.Columns.Add("Audit_Title", typeof(string));
        dt.Columns.Add("Div", typeof(string));
        dt.Columns.Add("Final_Issue_Date", typeof(string));
        dt.Columns.Add("Final_Issue_Date_P", typeof(string));
        dt.Columns.Add("Final_Issue_Date_S", typeof(string));
        dt.Columns.Add("Final_Due_Date", typeof(string));
        dt.Columns.Add("Final_Due_Date_P", typeof(string));
        dt.Columns.Add("Final_Due_Date_S", typeof(string));

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {

            while (rdr.Read())
            {

                DataRow row = dt.NewRow();
                row["Findings"] = Convert.ToString(rdr.GetSqlValue(0));
                row["CAR_No"] = Convert.ToString(rdr.GetSqlValue(1));
                row["Audit_Title"] = Convert.ToString(rdr.GetSqlValue(2));
                row["Div"] = Convert.ToString(rdr.GetSqlValue(3));
                row["Final_Issue_Date"] = Convert.ToString(rdr.GetSqlValue(4));
                row["Final_Issue_Date_P"] = Convert.ToString(rdr.GetSqlValue(5));
                row["Final_Issue_Date_S"] = Convert.ToString(rdr.GetSqlValue(6));
                row["Final_Due_Date"] = Convert.ToString(rdr.GetSqlValue(7));
                row["Final_Due_Date_P"] = Convert.ToString(rdr.GetSqlValue(8));
                row["Final_Due_Date_S"] = Convert.ToString(rdr.GetSqlValue(9));
                dt.Rows.Add(row);
            }
        }
        //删除
        string SQL_Delete = " DELETE from DLR_Finding_Control where 1=1 ";
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Delete);
        }



        string SQL_Insert =//插入
           "INSERT INTO DLR_Finding_Control (Findings,CAR_No,Audit_Title,Div,Final_Issue_Date,Final_Due_Date) " +
           "VALUES(@Fi,@CA,@AT,@DV,@FID,@FDD)";

        SqlParameter[] parms = new SqlParameter[]{
            new SqlParameter("@Fi", SqlDbType.VarChar, 50),
            new SqlParameter("@CA", SqlDbType.VarChar, 50),
            new SqlParameter("@AT", SqlDbType.VarChar, 50),
            new SqlParameter("@DV", SqlDbType.VarChar, 50),
            new SqlParameter("@FID", SqlDbType.Date),
            new SqlParameter("@FDD", SqlDbType.Date)
         };


         for (int i = 0; i < ds.Tables["dt"].Rows.Count; i++)
         {
             DataRow row = ds.Tables["dt"].Rows[i];
             if (row[1].ToString() == "" || row[2].ToString() == "")
                 continue;
             parms[0].Value = row[1].ToString();
             parms[1].Value = row[2].ToString();
             parms[2].Value = row[3].ToString();
             parms[3].Value = row[4].ToString();

             if (row["Final-Issue_Date"].ToString().Trim() == "" || row["Final-Issue_Date"].ToString().Trim() == "N/A")
                 parms[4].Value = Convert.ToDateTime("2099-12-31");
             else
                 parms[4].Value = Convert.ToDateTime(Convert.ToDateTime(row["Final-Issue_Date"].ToString().Trim()).ToShortDateString());

             if (row["Final-Due_Date"].ToString().Trim() == "" || row["Final-Due_Date"].ToString().Trim() == "N/A")
                 parms[5].Value = Convert.ToDateTime("2099-12-31");
             else
                 parms[5].Value = Convert.ToDateTime(Convert.ToDateTime(row["Final-Due_Date"].ToString().Trim()).ToShortDateString());
         
            
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
        Session["CAR_No"] = TextBox1.Text;
        Session["Audit_Title"] = TextBox2.Text;
        Session["Div"] = TextBox3.Text;
        Session["Fk"] = "1";
        Bind();
        
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["CAR_No"] = TextBox1.Text;
        Session["Audit_Title"] = TextBox2.Text;
        Session["Div"] = TextBox3.Text;
        Session["Fk"] = "2";
        Bind();

    }
    //数据绑定
    protected void Bind()
    {

        string can = "";
        string at = "";
        string div = "";

        if (Session["CAR_No"].ToString() != "")
        {
            can = " and (CAR_No like '%" + Session["CAR_No"].ToString().Trim() + "%')";
        }

        if (Session["Audit_Title"].ToString() != "")
        {
            at = " and (Audit_Title like '%" + Session["Audit_Title"].ToString().Trim() + "%')";
        }

        if (Session["Div"].ToString() != "")
        {
            div = " and( Div like '%" + Session["Div"].ToString().Trim() + "%')";
        }


        string SQL_query = " select * from DLR_Finding_Control "
            + " where 1=1  " + can + at + div;
      
        DataTable dt = new DataTable();

        dt.Columns.Add("Findings", typeof(string));
        dt.Columns.Add("CAR_No", typeof(string));
        dt.Columns.Add("Audit_Title", typeof(string));
        dt.Columns.Add("Div", typeof(string));
        dt.Columns.Add("Final_Issue_Date", typeof(string));
        dt.Columns.Add("Final_Issue_P", typeof(string));
        dt.Columns.Add("Final_Issue_S", typeof(string));
        dt.Columns.Add("Final_Due_Date", typeof(string));
        dt.Columns.Add("Final_Due_P", typeof(string));
        dt.Columns.Add("Final_Due_S", typeof(string));

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {

            while (rdr.Read())
            {

                DataRow row = dt.NewRow();
                row["Findings"] = Convert.ToString(rdr.GetSqlValue(0));
                row["CAR_No"] = Convert.ToString(rdr.GetSqlValue(1));
                row["Audit_Title"] = Convert.ToString(rdr.GetSqlValue(2));
                row["Div"] = Convert.ToString(rdr.GetSqlValue(3));
                row["Final_Issue_Date"] = Convert.ToString(rdr.GetSqlValue(4));
                row["Final_Issue_P"] = Convert.ToString(rdr.GetSqlValue(5));
                row["Final_Issue_S"] = Convert.ToString(rdr.GetSqlValue(6));
                row["Final_Due_Date"] = Convert.ToString(rdr.GetSqlValue(7));
                row["Final_Due_P"] = Convert.ToString(rdr.GetSqlValue(8));
                row["Final_Due_S"] = Convert.ToString(rdr.GetSqlValue(9));
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


            
             
      


            if (Session["Fk"].ToString() == "1")
            {


                AddGridViewColumn(dt.Columns[0].ColumnName, 0, null, 10);//
                AddGridViewColumn(dt.Columns[1].ColumnName, 0, null, 20); //
                AddGridViewColumn(dt.Columns[2].ColumnName, 0, null, 20); //  
                AddGridViewColumn(dt.Columns[3].ColumnName, 0, null, 10); //  

                AddGridViewColumn(dt.Columns[4].ColumnName, 0, null, 10); //  
                AddGridViewColumn(dt.Columns[5].ColumnName, 0, null, 10); //  
                AddGridViewColumn(dt.Columns[6].ColumnName, 0, null, 10); //  
                AddGridViewColumn("确认", 4, "Button1", 10);
                //AddGridViewColumn(dt.Columns[7].ColumnName, 0, null, 10); //  
                //AddGridViewColumn(dt.Columns[8].ColumnName, 0, null, 10); //  
                //AddGridViewColumn(dt.Columns[9].ColumnName, 0, null, 10); //  
                //AddGridViewColumn("确认", 4, "Button2", 10);
                GridView1.DataSource = dt;
                GridView1.DataBind();


                 for (int j = GridView1.PageIndex * GridView1.PageSize, i = 0; i < GridView1.PageSize && j < dt.Rows.Count; i++, j++)
                 {

                     GridView1.Rows[i].Cells[0].Text = dt.Rows[j]["Findings"].ToString();
                     GridView1.Rows[i].Cells[1].Text = dt.Rows[j]["CAR_No"].ToString();
                     GridView1.Rows[i].Cells[2].Text = dt.Rows[j]["Audit_Title"].ToString();
                     GridView1.Rows[i].Cells[3].Text = dt.Rows[j]["Div"].ToString();
                     GridView1.Rows[i].Cells[4].Text = Convert.ToDateTime(dt.Rows[j]["Final_Issue_Date"]).ToShortDateString();
                     GridView1.Rows[i].Cells[5].Text = dt.Rows[j]["Final_Issue_P"].ToString();
                     GridView1.Rows[i].Cells[6].Text = getstatus(dt.Rows[j]["Final_Issue_S"].ToString());
                     ((Button)GridView1.Rows[i].Cells[7].FindControl("Button1")).Text = "确认";
                     ((Button)GridView1.Rows[i].Cells[7].FindControl("Button1")).CommandName = "FID";
                     ((Button)GridView1.Rows[i].Cells[7].FindControl("Button1")).OnClientClick = "return confirm('是否确认')";
                     if (dt.Rows[j]["Final_Issue_S"].ToString().Trim() != "1")
                     {
                         ((Button)GridView1.Rows[i].Cells[7].FindControl("Button1")).Enabled = false;
                     
                     }

                     if (dt.Rows[j]["Final_Issue_S"].ToString().Trim() == "2")
                     {
                         GridView1.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Black;
                     }
                     if (dt.Rows[j]["Final_Issue_S"].ToString().Trim() == "4")
                     {
                         GridView1.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Red;
                     }


                     //GridView1.Rows[i].Cells[8].Text = Convert.ToDateTime(dt.Rows[j]["Final_Due_Date"]).ToShortDateString();
                     //GridView1.Rows[i].Cells[9].Text = dt.Rows[j]["Final_Due_Date_P"].ToString();
                     //GridView1.Rows[i].Cells[10].Text = getstatus(dt.Rows[j]["Final_Due_Date_S"].ToString());
                     //((Button)GridView1.Rows[i].Cells[11].FindControl("Button2")).Text = "确认";
                     //((Button)GridView1.Rows[i].Cells[11].FindControl("Button2")).CommandName = "am";
                     //((Button)GridView1.Rows[i].Cells[11].FindControl("Button2")).OnClientClick = "return confirm('是否确认')";
                     //if (dt.Rows[j]["Final_Due_Date_S"].ToString().Trim() != "1")
                     //{
                     //    ((Button)GridView1.Rows[i].Cells[11].FindControl("Button2")).Enabled = false;

                     //}
                     //if (dt.Rows[j]["Final_Due_Date_S"].ToString().Trim() == "2")
                     //{
                     //    GridView1.Rows[i].Cells[10].ForeColor = System.Drawing.Color.Black;
                     //}
                     //if (dt.Rows[j]["Final_Due_Date_S"].ToString().Trim() == "4")
                     //{
                     //    GridView1.Rows[i].Cells[10].ForeColor = System.Drawing.Color.Red;
                     //}
           


                 }
             }
            if (Session["Fk"].ToString() == "2")
            {
                AddGridViewColumn(dt.Columns[0].ColumnName, 0, null, 10);//
                AddGridViewColumn(dt.Columns[1].ColumnName, 0, null, 20); //
                AddGridViewColumn(dt.Columns[2].ColumnName, 0, null, 20); //  
                AddGridViewColumn(dt.Columns[3].ColumnName, 0, null, 10); //  

                AddGridViewColumn(dt.Columns[7].ColumnName, 0, null, 10); //  
                AddGridViewColumn(dt.Columns[8].ColumnName, 0, null, 10); //  
                AddGridViewColumn(dt.Columns[9].ColumnName, 0, null, 10); //  
                AddGridViewColumn("确认", 4, "Button2", 10);
                //AddGridViewColumn(dt.Columns[7].ColumnName, 0, null, 10); //  
                //AddGridViewColumn(dt.Columns[8].ColumnName, 0, null, 10); //  
                //AddGridViewColumn(dt.Columns[9].ColumnName, 0, null, 10); //  
                //AddGridViewColumn("确认", 4, "Button2", 10);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                for (int j = GridView1.PageIndex * GridView1.PageSize, i = 0; i < GridView1.PageSize && j < dt.Rows.Count; i++, j++)
                {

                    GridView1.Rows[i].Cells[0].Text = dt.Rows[j]["Findings"].ToString();
                    GridView1.Rows[i].Cells[1].Text = dt.Rows[j]["CAR_No"].ToString();
                    GridView1.Rows[i].Cells[2].Text = dt.Rows[j]["Audit_Title"].ToString();
                    GridView1.Rows[i].Cells[3].Text = dt.Rows[j]["Div"].ToString();



                    GridView1.Rows[i].Cells[4].Text = Convert.ToDateTime(dt.Rows[j]["Final_Due_Date"]).ToShortDateString();
                    GridView1.Rows[i].Cells[5].Text = dt.Rows[j]["Final_Due_P"].ToString();
                    GridView1.Rows[i].Cells[6].Text = getstatus(dt.Rows[j]["Final_Due_S"].ToString());
                    ((Button)GridView1.Rows[i].Cells[7].FindControl("Button2")).Text = "确认";
                    ((Button)GridView1.Rows[i].Cells[7].FindControl("Button2")).CommandName = "FDD";
                    ((Button)GridView1.Rows[i].Cells[7].FindControl("Button2")).OnClientClick = "return confirm('是否确认')";
                    if (dt.Rows[j]["Final_Due_S"].ToString().Trim() != "1")
                    {
                        ((Button)GridView1.Rows[i].Cells[7].FindControl("Button2")).Enabled = false;

                    }
                    if (dt.Rows[j]["Final_Due_S"].ToString().Trim() == "2")
                    {
                        GridView1.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Black;
                    }
                    if (dt.Rows[j]["Final_Due_S"].ToString().Trim() == "4")
                    {
                        GridView1.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
             GridView1.Visible = true;
             //Label4.Text = "Total: " + dt.Rows.Count + " items";

         }
      
    }


    //状态判断
    private string getstatus(string intt)
    { 
        string state="";
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

        if (e.CommandName == "FID")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;


            string SQL_UP = " UPDATE DLR_Finding_Control  "
                + " SET Final_Issue_Date_S  ='2'"
                + " where CAR_No ='" + gvr.Cells[1].Text.ToString().Trim() + "'";
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
            }

            
        }
        if (e.CommandName == "FDD")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;


            string SQL_UP = " UPDATE DLR_Finding_Control  "
                + " SET Final_Due_Date_S  ='2'"
                + " where CAR_No ='" + gvr.Cells[1].Text.ToString().Trim() + "'";
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

 
