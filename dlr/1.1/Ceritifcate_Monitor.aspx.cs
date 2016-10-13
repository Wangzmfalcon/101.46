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

        if (Session["Registration"] == null)
            Session["Registration"] = "";
        if (Session["ks"] == null)
            Session["ks"] = "0";

      
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
          
           
            String sql = "SELECT * FROM  [Sheet1$A2:J200]";//可是更改Sheet名称，比如sheet2，等等   
            OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);//读出数据
            OleDaExcel.Fill(OleDsExcle, "dt");//DS的表名字

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


                  //回写状态
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
            string SQL_query = " select * from DLR_Ceritifcate_Monitor "
                + " where Registration = '" + row["Registration"].ToString().Trim() + "'";
            
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
            {
                if (rdr.Read())
                {
                    if (rdr["C_of_A"].ToString().Trim() == row["C_of_A"].ToString().Trim())//AU检测
                    {
                        string SQL_UP = " UPDATE DLR_Ceritifcate_Monitor  "
                        + " SET C_of_A_S  ='" + row["C_of_A_S"].ToString().Trim() + "',C_of_A_P ='" + row["C_of_A_P"].ToString().Trim() + "'"
                        + " where Registration = '" + row["Registration"].ToString().Trim() + "'";                        
                          using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                          {
                              SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
                          }                        
                    }


                    if (rdr["Station_Licence"].ToString().Trim() == row["Station_Licence"].ToString().Trim())//AU检测
                    {
                        string SQL_UP = " UPDATE DLR_Ceritifcate_Monitor  "
                        + " SET Station_Licence_S  ='" + row["Station_Licence_S"].ToString().Trim() + "',Station_Licence_P ='" + row["Station_Licence_P"].ToString().Trim() + "'"
                        + " where Registration = '" + row["Registration"].ToString().Trim() + "'";
                        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                        {
                            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
                        }
                    }



                    if (rdr["CAAC"].ToString().Trim() == row["CAAC"].ToString().Trim())//AU检测
                    {
                        string SQL_UP = " UPDATE DLR_Ceritifcate_Monitor  "
                        + " SET CAAC_S  ='" + row["CAAC_S"].ToString().Trim() + "',CAAC_P ='" + row["CAAC_P"].ToString().Trim() + "'"
                        + " where Registration = '" + row["Registration"].ToString().Trim() + "'";
                        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                        {
                            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
                        }
                    }


                    if (rdr["Radio_Licence"].ToString().Trim() == row["Radio_Licence"].ToString().Trim())//AU检测
                    {
                        string SQL_UP = " UPDATE DLR_Ceritifcate_Monitor  "
                        + " SET Radio_Licence_S  ='" + row["Radio_Licence_S"].ToString().Trim() + "',Radio_Licence_P ='" + row["Radio_Licence_P"].ToString().Trim() + "'"
                        + " where Registration = '" + row["Registration"].ToString().Trim() + "'";
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
        string SQL_query = " select * from DLR_Ceritifcate_Monitor ";


        dt.Columns.Add("Registration", typeof(string));
        dt.Columns.Add("C_of_A", typeof(string));
        dt.Columns.Add("C_of_A_P", typeof(string));
        dt.Columns.Add("C_of_A_S", typeof(string));
        dt.Columns.Add("Station_Licence", typeof(string));
        dt.Columns.Add("Station_Licence_P", typeof(string));
        dt.Columns.Add("Station_Licence_S", typeof(string));
        dt.Columns.Add("Radio_Licence", typeof(string));
        dt.Columns.Add("Radio_Licence_P", typeof(string));
        dt.Columns.Add("Radio_Licence_S", typeof(string));
        dt.Columns.Add("CAAC", typeof(string));
        dt.Columns.Add("CAAC_P", typeof(string));
        dt.Columns.Add("CAAC_S", typeof(string));

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {

            while (rdr.Read())
            {

                DataRow row = dt.NewRow();
                row["Registration"] = Convert.ToString(rdr.GetSqlValue(0));
                row["C_of_A"] = Convert.ToString(rdr.GetSqlValue(1));
                row["C_of_A_P"] = Convert.ToString(rdr.GetSqlValue(2));
                row["C_of_A_S"] = Convert.ToString(rdr.GetSqlValue(3));
                row["Station_Licence"] = Convert.ToString(rdr.GetSqlValue(4));
                row["Station_Licence_P"] = Convert.ToString(rdr.GetSqlValue(5));
                row["Station_Licence_S"] = Convert.ToString(rdr.GetSqlValue(6));
                row["Radio_Licence"] = Convert.ToString(rdr.GetSqlValue(7));
                row["Radio_Licence_P"] = Convert.ToString(rdr.GetSqlValue(8));
                row["Radio_Licence_S"] = Convert.ToString(rdr.GetSqlValue(9));
                row["CAAC"] = Convert.ToString(rdr.GetSqlValue(10));
                row["CAAC_P"] = Convert.ToString(rdr.GetSqlValue(11));
                row["CAAC_S"] = Convert.ToString(rdr.GetSqlValue(12));
                dt.Rows.Add(row);
            }
        }
        //删除
        string SQL_Delete = " DELETE from DLR_Ceritifcate_Monitor where 1=1 ";
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Delete);
        }



        string SQL_Insert =//插入
           "INSERT INTO DLR_Ceritifcate_Monitor (Registration,C_of_A,Station_Licence,Radio_Licence,CAAC) " +
           "VALUES(@Rg,@CA,@SL,@RL,@In)";

        SqlParameter[] parms = new SqlParameter[]{
            new SqlParameter("@Rg", SqlDbType.VarChar, 10),            
            new SqlParameter("@CA", SqlDbType.Date),
            new SqlParameter("@SL", SqlDbType.Date),
            new SqlParameter("@RL", SqlDbType.Date),
            new SqlParameter("@In", SqlDbType.Date)
         };


         for (int i = 0; i < ds.Tables["dt"].Rows.Count; i++)
         {
             DataRow row = ds.Tables["dt"].Rows[i];
             if (row[0].ToString() == ""||row[1].ToString() == "")
                 continue;
             parms[0].Value = row[0].ToString();
             if (row[1].ToString().Trim() == "")
                 parms[1].Value = Convert.ToDateTime("2099-12-31");
             else
                 parms[1].Value = Convert.ToDateTime(Convert.ToDateTime(row[1].ToString().Trim()).ToShortDateString());

             if (row[2].ToString().Trim() == "")
                 parms[2].Value = Convert.ToDateTime("2099-12-31");
             else
                 parms[2].Value = Convert.ToDateTime(Convert.ToDateTime(row[2].ToString().Trim()).ToShortDateString());
             
             if (row[3].ToString().Trim() == "")
                 parms[3].Value = Convert.ToDateTime("2099-12-31");
             else
                 parms[3].Value = Convert.ToDateTime(Convert.ToDateTime(row[3].ToString().Trim()).ToShortDateString());

             if (row[4].ToString().Trim() == "" || row[4].ToString().Trim() == "-")
                 parms[4].Value = Convert.ToDateTime("2099-12-31");
             else
                 parms[4].Value = Convert.ToDateTime(Convert.ToDateTime(row[4].ToString().Trim()).ToShortDateString());
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
        Session["Registration"] = TextBox1.Text;

        Session["ks"] = "0";
        Bind();
        
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["Registration"] = TextBox1.Text;

        Session["ks"] = "8";
        Bind();
    }
    //数据绑定
    protected void Bind()
    {
        
        string re = "";
        int k = Convert.ToInt32(Session["ks"].ToString()); 

        if (Session["Registration"].ToString() != "")
        {
            re = " and (Registration like '%" + Session["Registration"].ToString().Trim() + "%')";
        }


        string SQL_query = " select * from DLR_Ceritifcate_Monitor "
            + " where 1=1  " + re;
      
        DataTable dt = new DataTable();

        dt.Columns.Add("Registration", typeof(string));
        dt.Columns.Add("C_of_A", typeof(string));
        dt.Columns.Add("C_of_A_P", typeof(string));
        dt.Columns.Add("C_of_A_S", typeof(string));
        dt.Columns.Add("Station_Licence", typeof(string));
        dt.Columns.Add("Station_P", typeof(string));
        dt.Columns.Add("Station_S", typeof(string));
        dt.Columns.Add("Radio_Licence", typeof(string));
        dt.Columns.Add("Radio_P", typeof(string));
        dt.Columns.Add("Radio_S", typeof(string));
        dt.Columns.Add("CAAC", typeof(string));
        dt.Columns.Add("CAAC_P", typeof(string));
        dt.Columns.Add("CAAC_S", typeof(string));

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {

            while (rdr.Read())
            {

                DataRow row = dt.NewRow();
                row["Registration"] = Convert.ToString(rdr.GetSqlValue(0));
                row["C_of_A"] = Convert.ToString(rdr.GetSqlValue(1));
                row["C_of_A_P"] = Convert.ToString(rdr.GetSqlValue(2));
                row["C_of_A_S"] = Convert.ToString(rdr.GetSqlValue(3));
                row["Station_Licence"] = Convert.ToString(rdr.GetSqlValue(4));
                row["Station_P"] = Convert.ToString(rdr.GetSqlValue(5));
                row["Station_S"] = Convert.ToString(rdr.GetSqlValue(6));
                row["Radio_Licence"] = Convert.ToString(rdr.GetSqlValue(7));
                row["Radio_P"] = Convert.ToString(rdr.GetSqlValue(8));
                row["Radio_S"] = Convert.ToString(rdr.GetSqlValue(9));
                row["CAAC"] = Convert.ToString(rdr.GetSqlValue(10));
                row["CAAC_P"] = Convert.ToString(rdr.GetSqlValue(11));
                row["CAAC_S"] = Convert.ToString(rdr.GetSqlValue(12));
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
            


             if (k == 0)
             {


                 AddGridViewColumn(dt.Columns[0].ColumnName, 0, null, 10);//
                 AddGridViewColumn(dt.Columns[1].ColumnName, 0, null, 10); //
                 AddGridViewColumn(dt.Columns[2].ColumnName, 0, null, 10); //  
                 AddGridViewColumn(dt.Columns[3].ColumnName, 0, null, 10); //
                 AddGridViewColumn("确认", 4, "Button1", 10);
                 AddGridViewColumn(dt.Columns[4].ColumnName, 0, null, 10); //  
                 AddGridViewColumn(dt.Columns[5].ColumnName, 0, null, 10); //  
                 AddGridViewColumn(dt.Columns[6].ColumnName, 0, null, 10); //  
                 AddGridViewColumn("确认", 4, "Button2", 10);
                 //AddGridViewColumn(dt.Columns[7].ColumnName, 0, null, 10); //  
                 //AddGridViewColumn(dt.Columns[8].ColumnName, 0, null, 10); //  
                 //AddGridViewColumn(dt.Columns[9].ColumnName, 0, null, 10); //  
                 //AddGridViewColumn("确认", 4, "Button3", 10);
                 //AddGridViewColumn(dt.Columns[10].ColumnName, 0, null, 10); //  
                 //AddGridViewColumn(dt.Columns[11].ColumnName, 0, null, 10); //  
                 //AddGridViewColumn(dt.Columns[12].ColumnName, 0, null, 10); //  
                 //AddGridViewColumn("确认", 4, "Button4", 10);
                 GridView1.DataSource = dt;
                 GridView1.DataBind();


                 for (int j = GridView1.PageIndex * GridView1.PageSize, i = 0; i < GridView1.PageSize && j < dt.Rows.Count; i++, j++)
                 {

                     GridView1.Rows[i].Cells[0].Text = dt.Rows[j]["Registration"].ToString();
                     GridView1.Rows[i].Cells[1].Text = Convert.ToDateTime(dt.Rows[j]["C_of_A"]).ToShortDateString();
                     GridView1.Rows[i].Cells[2].Text = dt.Rows[j]["C_of_A_P"].ToString();
                     GridView1.Rows[i].Cells[3].Text = getstatus(dt.Rows[j]["C_of_A_S"].ToString());
                     ((Button)GridView1.Rows[i].Cells[4].FindControl("Button1")).Text = "确认";
                     ((Button)GridView1.Rows[i].Cells[4].FindControl("Button1")).CommandName = "CA";
                     ((Button)GridView1.Rows[i].Cells[4].FindControl("Button1")).OnClientClick = "return confirm('是否确认')";
                     if (dt.Rows[j]["C_of_A_S"].ToString().Trim() != "1")
                     {
                         ((Button)GridView1.Rows[i].Cells[4].FindControl("Button1")).Enabled = false;

                     }

                     if (dt.Rows[j]["C_of_A_S"].ToString().Trim() == "2")
                     {
                         GridView1.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Black;
                     }
                     if (dt.Rows[j]["C_of_A_S"].ToString().Trim() == "4")
                     {
                         GridView1.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Red;
                     }




                     GridView1.Rows[i].Cells[5].Text = Convert.ToDateTime(dt.Rows[j]["Station_Licence"]).ToShortDateString();
                     GridView1.Rows[i].Cells[6].Text = dt.Rows[j]["Station_P"].ToString();
                     GridView1.Rows[i].Cells[7].Text = getstatus(dt.Rows[j]["Station_S"].ToString());
                     ((Button)GridView1.Rows[i].Cells[8].FindControl("Button2")).Text = "确认";
                     ((Button)GridView1.Rows[i].Cells[8].FindControl("Button2")).CommandName = "SL";
                     ((Button)GridView1.Rows[i].Cells[8].FindControl("Button2")).OnClientClick = "return confirm('是否确认')";
                     if (dt.Rows[j]["Station_S"].ToString().Trim() != "1")
                     {
                         ((Button)GridView1.Rows[i].Cells[8].FindControl("Button2")).Enabled = false;

                     }

                     if (dt.Rows[j]["Station_S"].ToString().Trim() == "2")
                     {
                         GridView1.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Black;
                     }
                     if (dt.Rows[j]["Station_S"].ToString().Trim() == "4")
                     {
                         GridView1.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                     }



                     //GridView1.Rows[i].Cells[9].Text = Convert.ToDateTime(dt.Rows[j]["Radio_Licence"]).ToShortDateString();
                     //GridView1.Rows[i].Cells[10].Text = dt.Rows[j]["Radio_Licence_P"].ToString();
                     //GridView1.Rows[i].Cells[11].Text = getstatus(dt.Rows[j]["Radio_Licence_S"].ToString());
                     //((Button)GridView1.Rows[i].Cells[12].FindControl("Button3")).Text = "确认";
                     //((Button)GridView1.Rows[i].Cells[12].FindControl("Button3")).CommandName = "am";
                     //((Button)GridView1.Rows[i].Cells[12].FindControl("Button3")).OnClientClick = "return confirm('是否确认')";
                     //if (dt.Rows[j]["Radio_Licence_S"].ToString().Trim() != "1")
                     //{
                     //    ((Button)GridView1.Rows[i].Cells[12].FindControl("Button3")).Enabled = false;

                     //}
                     //if (dt.Rows[j]["Radio_Licence_S"].ToString().Trim() == "2")
                     //{
                     //    GridView1.Rows[i].Cells[11].ForeColor = System.Drawing.Color.Black;
                     //}
                     //if (dt.Rows[j]["Radio_Licence_S"].ToString().Trim() == "4")
                     //{
                     //    GridView1.Rows[i].Cells[11].ForeColor = System.Drawing.Color.Red;
                     //}



                     //GridView1.Rows[i].Cells[13].Text = Convert.ToDateTime(dt.Rows[j]["CAAC"]).ToShortDateString();
                     //GridView1.Rows[i].Cells[14].Text = dt.Rows[j]["CAAC_P"].ToString();
                     //GridView1.Rows[i].Cells[15].Text = getstatus(dt.Rows[j]["CAAC_S"].ToString());
                     //((Button)GridView1.Rows[i].Cells[16].FindControl("Button4")).Text = "确认";
                     //((Button)GridView1.Rows[i].Cells[16].FindControl("Button4")).CommandName = "am";
                     //((Button)GridView1.Rows[i].Cells[16].FindControl("Button4")).OnClientClick = "return confirm('是否确认')";
                     //if (dt.Rows[j]["CAAC_S"].ToString().Trim() != "1")
                     //{
                     //    ((Button)GridView1.Rows[i].Cells[16].FindControl("Button2")).Enabled = false;

                     //}
                     //if (dt.Rows[j]["CAAC_S"].ToString().Trim() == "2")
                     //{
                     //    GridView1.Rows[i].Cells[15].ForeColor = System.Drawing.Color.Black;
                     //}
                     //if (dt.Rows[j]["CAAC_S"].ToString().Trim() == "4")
                     //{
                     //    GridView1.Rows[i].Cells[15].ForeColor = System.Drawing.Color.Red;
                     //}



                 }
             }
             if (k == 8)
             {

                 AddGridViewColumn(dt.Columns[0].ColumnName, 0, null, 10);//               
                 AddGridViewColumn(dt.Columns[7].ColumnName, 0, null, 10); //  
                 AddGridViewColumn(dt.Columns[8].ColumnName, 0, null, 10); //  
                 AddGridViewColumn(dt.Columns[9].ColumnName, 0, null, 10); //  
                 AddGridViewColumn("确认", 4, "Button3", 1);
                 AddGridViewColumn(dt.Columns[10].ColumnName, 0, null, 10); //  
                 AddGridViewColumn(dt.Columns[11].ColumnName, 0, null, 10); //  
                 AddGridViewColumn(dt.Columns[12].ColumnName, 0, null, 10); //  
                 AddGridViewColumn("确认", 4, "Button4", 10);
                 GridView1.DataSource = dt;
                 GridView1.DataBind();


                 for (int j = GridView1.PageIndex * GridView1.PageSize, i = 0; i < GridView1.PageSize && j < dt.Rows.Count; i++, j++)
                 {
                     GridView1.Rows[i].Cells[0].Text = dt.Rows[j]["Registration"].ToString();

                     GridView1.Rows[i].Cells[1].Text = Convert.ToDateTime(dt.Rows[j]["Radio_Licence"]).ToShortDateString();
                     GridView1.Rows[i].Cells[2].Text = dt.Rows[j]["Radio_P"].ToString();
                     GridView1.Rows[i].Cells[3].Text = getstatus(dt.Rows[j]["Radio_S"].ToString());
                     ((Button)GridView1.Rows[i].Cells[4].FindControl("Button3")).Text = "确认";
                     ((Button)GridView1.Rows[i].Cells[4].FindControl("Button3")).CommandName = "RL";
                     ((Button)GridView1.Rows[i].Cells[4].FindControl("Button3")).OnClientClick = "return confirm('是否确认')";
                     if (dt.Rows[j]["Radio_S"].ToString().Trim() != "1")
                     {
                         ((Button)GridView1.Rows[i].Cells[4].FindControl("Button3")).Enabled = false;

                     }
                     if (dt.Rows[j]["Radio_S"].ToString().Trim() == "2")
                     {
                         GridView1.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Black;
                     }
                     if (dt.Rows[j]["Radio_S"].ToString().Trim() == "4")
                     {
                         GridView1.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Red;
                     }



                     GridView1.Rows[i].Cells[5].Text = Convert.ToDateTime(dt.Rows[j]["CAAC"]).ToShortDateString();
                     GridView1.Rows[i].Cells[6].Text = dt.Rows[j]["CAAC_P"].ToString();
                     GridView1.Rows[i].Cells[7].Text = getstatus(dt.Rows[j]["CAAC_S"].ToString());
                     ((Button)GridView1.Rows[i].Cells[8].FindControl("Button4")).Text = "确认";
                     ((Button)GridView1.Rows[i].Cells[8].FindControl("Button4")).CommandName = "IN";
                     ((Button)GridView1.Rows[i].Cells[8].FindControl("Button4")).OnClientClick = "return confirm('是否确认')";
                     if (dt.Rows[j]["CAAC_S"].ToString().Trim() != "1")
                     {
                         ((Button)GridView1.Rows[i].Cells[8].FindControl("Button4")).Enabled = false;

                     }
                     if (dt.Rows[j]["CAAC_S"].ToString().Trim() == "2")
                     {
                         GridView1.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Black;
                     }
                     if (dt.Rows[j]["CAAC_S"].ToString().Trim() == "4")
                     {
                         GridView1.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
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
        
        if (e.CommandName == "CA")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;


            string SQL_UP = " UPDATE DLR_Ceritifcate_Monitor  "
                + " SET C_of_A_S  ='2'"
                + " where Registration ='" + gvr.Cells[0].Text.ToString().Trim() + "' and C_of_A ='" + gvr.Cells[1].Text.ToString().Trim()+"'";
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
            }

            
        }

        if (e.CommandName == "SL")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;


            string SQL_UP = " UPDATE DLR_Ceritifcate_Monitor  "
                + " SET Station_Licence_S  ='2'"
                + " where Registration ='" + gvr.Cells[0].Text.ToString().Trim() + "' and Station_Licence ='" + gvr.Cells[5].Text.ToString().Trim() + "'";
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
            }


        }
        if (e.CommandName == "RL")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;


            string SQL_UP = " UPDATE DLR_Ceritifcate_Monitor  "
                + " SET Radio_Licence_S  ='2'"
                + " where Registration ='" + gvr.Cells[0].Text.ToString().Trim() + "' and Radio_Licence ='" + gvr.Cells[1].Text.ToString().Trim() + "'";
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UP);
            }


        }
        if (e.CommandName == "IN")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;


            string SQL_UP = " UPDATE DLR_Ceritifcate_Monitor  "
                + " SET CAAC_S  ='2'"
                + " where Registration ='" + gvr.Cells[0].Text.ToString().Trim() +"' and CAAC ='" + gvr.Cells[5].Text.ToString().Trim() + "'";
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

 
