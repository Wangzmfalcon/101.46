using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using SMS.DBUtility;
using System.Text.RegularExpressions;

public partial class uploadRoster : System.Web.UI.Page
{
    int count = 0;
    int con = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Date", typeof(string));
        dt.Columns.Add("StaffNO", typeof(string));
        dt.Columns.Add("Flight", typeof(string));
        dt.Columns.Add("DHC/O", typeof(string));
        dt.Rows.Add(dt.NewRow());
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }




    //读取数据
    public static DataSet LoadDataFromExcel(string filePath, string Exceltype)
    {
        try
        {
            string strConn;//连接EXCEL语句

            switch (Exceltype)//EXCEL各版本的链接语句
            {
                case ".xls"://2003
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1;'";
                    break;
                case ".xlsx"://2007
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=NO;IMEX=1;'";
                    break;
                default:
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1;'";
                    break;
            }

            OleDbConnection OleConn = new OleDbConnection(strConn);//建立链接
            OleConn.Open();//打开EXCEL
            String sql = "SELECT * FROM  [Roster$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);//读出数据
            DataSet OleDsExcle = new DataSet();//建立DS
            OleDaExcel.Fill(OleDsExcle, "DS");//DS的表名字
            OleConn.Close();//链接断开
            return OleDsExcle;
        }
        catch (Exception er)
        {
            return null;
        }
    }
    public bool Islegalflight(string fl)
    {
        bool islegal = false;
        System.Text.RegularExpressions.Regex regNX = new System.Text.RegularExpressions.Regex("^NX.*");
        System.Text.RegularExpressions.Regex regCA = new System.Text.RegularExpressions.Regex("^CA.*");
        System.Text.RegularExpressions.Regex regNum = new Regex("^[0-9]");
        if (regNX.IsMatch(fl))
        {
            //Response.Write("<script>alert('is NX')</script>");
            islegal = true;
        }
        else if(regCA.IsMatch(fl))
        {
            //Response.Write("<script>alert('is CA')</script>");
            islegal = true;
        }
        else if (regNum.IsMatch(fl))
        {
            //Response.Write("<script>alert('is 数字')</script>");
            islegal = true;
        }
        return islegal;
    }



    public DataTable readdata(DataSet ds)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Date", typeof(string));
        dt.Columns.Add("StaffNO", typeof(string));
        dt.Columns.Add("Flight", typeof(string));
        dt.Columns.Add("DHC/O", typeof(string));

        
        
        int excelwide=0;
        System.Text.RegularExpressions.Regex regNum = new Regex("^[0-9]");
        for (int i = 36; i <= 40;i++ )
        {
            if (!regNum.IsMatch(ds.Tables["DS"].Rows[1][i].ToString().Trim()))
            {
                
                excelwide = i;
                //Response.Write("<script>alert('" + excelwide + "')</script>");
                break;
            }
        }
        //Response.Write("<script>alert('" + excelwide + "')</script>");
        int month = Convert.ToDateTime(ds.Tables["DS"].Rows[0][3].ToString().Trim()).Month;
        int year = Convert.ToDateTime(ds.Tables["DS"].Rows[0][3].ToString().Trim()).Year;
        int days =DateTime.DaysInMonth(year,month);
        DateTime ld = Convert.ToDateTime(ds.Tables["DS"].Rows[0][3].ToString().Trim()).AddDays(days);
        DateTime fd = Convert.ToDateTime(ds.Tables["DS"].Rows[0][3].ToString().Trim());
        //DateTime ldd= DateTime.Now;
        //DateTime fdd = DateTime.Now;
        //ldd = Convert.ToDateTime(ld);
        //fdd = Convert.ToDateTime(fd);


        //插入前删除以往数据
        string SQL_Delet_Card = "Delete From Roster " +
       "Where Roster.Date <@ld and Roster.Date >= @fd";
        string connectStr = "server=192.168.101.114;User Id = falcon;Password = airmacau;; database = FLT";//连接SQL语句
        
            SqlParameter[] parms1 = new SqlParameter[]{
                        new SqlParameter("@ld", SqlDbType.DateTime),
                        new SqlParameter("@fd", SqlDbType.DateTime)
                        
                     };
            parms1[0].Value = Convert.ToDateTime(ld.ToString().Trim());
            parms1[1].Value = Convert.ToDateTime(fd.ToString().Trim());
           
        try
        {
            using (SqlConnection conn = new SqlConnection(connectStr))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Delet_Card, parms1);
            }
        }
        catch (Exception e)
        {
        }
        for (int i = 2; i < ds.Tables["DS"].Rows.Count; i++)
        {
            
            string Staff = ds.Tables["DS"].Rows[i][2].ToString().TrimStart('0').Trim();
            for (int j = 9; j < excelwide; j++)
            {
                count++;
                int date = 0;
                try { date = Convert.ToInt32(ds.Tables["DS"].Rows[1][j].ToString().Trim()); }
                catch (Exception edate)
                {
                    break;
                }
                
                string Fl = ds.Tables["DS"].Rows[i][j].ToString().Trim();
                string cday = year + "/" + month + "/" + date;
                DateTime day = DateTime.Now;
                try
                {
                    day = Convert.ToDateTime(cday);
                }
                catch (Exception eday)
                {
                    break;
                }
                string[] F = Fl.Replace("\n", "@").Split('@');

                for (int k = 0; k < F.Length; k++)
                {
                    string[] s = F[k].Split(' ');
                    string fll = s[0];
                    string flag = "";
                    if (s.Length == 2)
                        flag = s[1];
                    string dhc = "0";
                    if (!Islegalflight(fll))
                    {
                        continue;
                    }
                    if (flag == "DHC" || flag == "O")
                    {

                        dhc = "1";
                    }
                    else
                    {

                        dhc = "0";
                    }

                    DataRow row = dt.NewRow();
                    row["Date"] = Convert.ToString(day.ToShortDateString());
                    row["StaffNO"] = Convert.ToString(Staff);
                    row["Flight"] = Convert.ToString(fll);
                    row["DHC/O"] = Convert.ToString(dhc);
                    dt.Rows.Add(row);//dt 添加行
                    

                  


                    //插入数据库
                    string SQL_insert_Card =//插入
                      "INSERT INTO Roster (Roster.Date,Roster.Staffno,Roster.Fltno,Roster.DHC) " +
                      "VALUES(@Date,@StaffNO,@Fltno,@DHC)";
                    //string connectStr1 = "server=192.168.3.1;User Id = falcon;Password = airmacau; database = FLT";//连接SQL语句
                    SqlParameter[] parms = new SqlParameter[]{
                        new SqlParameter("@Date", SqlDbType.Date),
                        new SqlParameter("@StaffNO", SqlDbType.VarChar, 10),
                        new SqlParameter("@Fltno", SqlDbType.VarChar, 10),
                        new SqlParameter("@DHC", SqlDbType.VarChar, 10)
                     };
                    parms[0].Value = day;
                    parms[1].Value = Staff;
                    parms[2].Value = fll;
                    parms[3].Value = dhc;

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                        {

                            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert_Card, parms);
                            con++;

                        }
                    }
                    catch (Exception e)
                    {
                        Response.Write(e.ToString());
                         continue;

                    }
                }
                
            }

          

        }


        return dt;
    }




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


             
                //读取数据
                DataSet ds = LoadDataFromExcel(Server.MapPath(savePath), extension);//存储数据 
                    
                   
                //GridView1.DataSource = ds;
                //GridView1.DataBind();
                DataTable dt = readdata(ds);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    string s1 = dt.Rows[i][3].ToString();
                    
                    
                    if (s1 == "是")
                    {
                        GridView1.Rows[i].ForeColor = System.Drawing.Color.Red;
                    }

                }

                //插入相同数据
                Response.Write("<script>alert('"+con+" succeed')</script>");

              
            }
            else
            {
                Response.Write("<script>alert('wrong file')</script>");
            }
            //FileInfo info = new FileInfo(Server.MapPath(savePath));//删除上传文件               
            //if (info.Exists)
            //{
            //    info.Delete();
            //}
        }
    }
}