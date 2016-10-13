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

public partial class upload : System.Web.UI.Page
{
 
    int count = 0;
    int count1 = 0;
    

    protected void Page_Load(object sender, EventArgs e)
    {
       
        DataTable dt = new DataTable();
        dt.Columns.Add("Date", typeof(string));
        dt.Columns.Add("Fltno", typeof(string));
        dt.Rows.Add(dt.NewRow());
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public static string[] GetsheetnameFromExcel(string filePath, string Exceltype)
    {
        string[] strTableNames = new string[40];
        string strConn;//连接EXCEL语句

        switch (Exceltype)//EXCEL各版本的链接语句
        {
            case ".xls"://2003
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=no;IMEX=1;'";
                break;
            case ".xlsx"://2007
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=no;IMEX=1;'";
                break;
            default:
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=no;IMEX=1;'";
                break;
        }
        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
        System.Text.RegularExpressions.Regex regNum = new Regex("^[0-9]*$");
        int i = 0;
        for (int k = 0; k < dtSheetName.Rows.Count; k++)
        {
            string s1 = null;
            s1 = dtSheetName.Rows[k]["TABLE_NAME"].ToString().Replace("$", "").Replace("'", "");
            if (regNum.IsMatch(s1))
            {
                strTableNames[i] = s1;
                i++;
            }
        }


        return strTableNames;
    }
    //读取数据
    public static DataSet LoadDataFromExcel(string filePath, string Exceltype, string[] sheetname)
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
        for (int i = 0; i < sheetname.Length; i++)
        {
            string tablename = sheetname[i];
            if (tablename == null)
                continue;
            String sql = "SELECT * FROM  [" + sheetname[i] + "$A3:Z200]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);//读出数据

            OleDaExcel.Fill(OleDsExcle, sheetname[i]);//DS的表名字
        }
        OleConn.Close();//链接断开
        return OleDsExcle;
   
    }
    //读取日期
    public static DataSet LoadDateFromExcel(string filePath, string Exceltype, string[] sheetname)
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
            DataSet OleDsExcle = new DataSet();//建立DS
            for (int i = 0; i < sheetname.Length; i++)
            {
                string tablename = sheetname[i];
                if (tablename == null)
                    continue;
                String sql = "SELECT * FROM  [" + sheetname[i] + "$D1:D1]";//可是更改Sheet名称，比如sheet2，等等    
                //String sql = "SELECT * FROM  [9$A3:Z99]";
                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);//读出数据

                OleDaExcel.Fill(OleDsExcle, sheetname[i]);//DS的表名字
            }
            OleConn.Close();//链接断开
            return OleDsExcle;

      
    }


    public string IsNull(string row)
    {
        string ro=null;
        if (row == "" || row == null)
            ro = "0";
        
        else
            ro = row;
        return ro;

    }

    //插入数据
    public bool InsertToDataBase(DataSet ds, string[] sheetname, DataTable dt, DataSet date)
    {
        bool flag = false;//用来return
        
        string SQL_insert_Card =//插入
            "INSERT INTO FLT (FLT.Date,FLT.Fltno,FLT.ATD,FLT.ATA,FLT.Org,FLT.Des,FLT.FT,FLT.s1,FLT.s2,FLT.s3,FLT.s4,FLT.s5,FLT.s6,FLT.s7,FLT.s8,FLT.s9,FLT.s10,FLT.s11,FLT.s12,FLT.s13,FLT.s14,FLT.s15,FLT.s16,FLT.s17,FLT.s18,FLT.s19,FLT.s20) " +
            "VALUES(@Date,@Fltno, @ATD,@ATA,@Org,@Des,@FT,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)";
        string connectStr = "server=192.168.101.114;User Id = falcon;Password = airmacau;; database = FLT";//连接SQL语句
        for (int j = 0; j < sheetname.Length; j++)
        {
            string tablename = sheetname[j];
            if (tablename == null)
                continue;
            //DataSet date = LoadDateFromExcel(Server.MapPath(savePath), extension, tablename);
            for (int i = 0; i < ds.Tables[tablename].Rows.Count; i++)
            {
                SqlParameter[] parms = new SqlParameter[]{
            new SqlParameter("@Date", SqlDbType.Date),
            new SqlParameter("@Fltno", SqlDbType.VarChar, 10),
            new SqlParameter("@ATD", SqlDbType.DateTime),
            new SqlParameter("@ATA", SqlDbType.DateTime),
            new SqlParameter("@Org", SqlDbType.VarChar, 10),
            new SqlParameter("@Des", SqlDbType.VarChar, 10),
            new SqlParameter("@FT", SqlDbType.DateTime),
            new SqlParameter("@d1", SqlDbType.VarChar, 10),
            new SqlParameter("@d2", SqlDbType.VarChar, 10),
            new SqlParameter("@d3", SqlDbType.VarChar, 10),
            new SqlParameter("@d4", SqlDbType.VarChar, 10),
            new SqlParameter("@d5", SqlDbType.VarChar, 10),
            new SqlParameter("@d6", SqlDbType.VarChar, 10),
            new SqlParameter("@d7", SqlDbType.VarChar, 10),
            new SqlParameter("@d8", SqlDbType.VarChar, 10),
            new SqlParameter("@d9", SqlDbType.VarChar, 10),
            new SqlParameter("@d10", SqlDbType.VarChar, 10),
            new SqlParameter("@d11", SqlDbType.VarChar, 10),
            new SqlParameter("@d12", SqlDbType.VarChar, 10),
            new SqlParameter("@d13", SqlDbType.VarChar, 10),
            new SqlParameter("@d14", SqlDbType.VarChar, 10),
            new SqlParameter("@d15", SqlDbType.VarChar, 10),
            new SqlParameter("@d16", SqlDbType.VarChar, 10),
            new SqlParameter("@d17", SqlDbType.VarChar, 10),
            new SqlParameter("@d18", SqlDbType.VarChar, 10),
            new SqlParameter("@d19", SqlDbType.VarChar, 10),
            new SqlParameter("@d20", SqlDbType.VarChar, 10)
                };

                DataRow row = ds.Tables[tablename].Rows[i];

                parms[0].Value = Convert.ToDateTime(date.Tables[tablename].Rows[0][0].ToString().Trim());
                int fl = 0;
                try
                {
                    parms[1].Value = row[0].ToString().Trim();
                }
                catch (Exception er1)
                {

                }
                if (parms[1].Value == "")
                    fl = 1;
                if (fl == 0)
                {
                    try
                    {
                        parms[2].Value = Convert.ToDateTime(row[1].ToString().Trim());
                        parms[3].Value = Convert.ToDateTime(row[2].ToString().Trim());
                        parms[4].Value = row[3].ToString().Trim();
                        parms[5].Value = row[4].ToString().Trim();
                        parms[6].Value = Convert.ToDateTime(row[5].ToString().Trim());
                        parms[7].Value = row[6].ToString().Trim();
                        parms[8].Value = row[7].ToString().Trim();
                        parms[9].Value = row[8].ToString().Trim();
                        parms[10].Value = row[9].ToString().Trim();
                        parms[11].Value = row[10].ToString().Trim();
                        parms[12].Value = row[11].ToString().Trim();
                        parms[13].Value = row[12].ToString().Trim();
                        parms[14].Value = row[13].ToString().Trim();
                        parms[15].Value = row[14].ToString().Trim();
                        parms[16].Value = row[15].ToString().Trim();
                        parms[17].Value = row[16].ToString().Trim();
                        parms[18].Value = row[17].ToString().Trim();
                        parms[19].Value = row[18].ToString().Trim();
                        parms[20].Value = row[19].ToString().Trim();
                        parms[21].Value = row[20].ToString().Trim();
                        parms[22].Value = row[21].ToString().Trim();
                        parms[23].Value = row[22].ToString().Trim();
                        parms[24].Value = row[23].ToString().Trim();
                        parms[25].Value = row[24].ToString().Trim();
                        parms[26].Value = row[25].ToString().Trim();


                    }

                    catch (Exception er1)
                    {
                        DataRow row1 = dt.NewRow();
                        //注意get有两点  数据库中第一个属性下表为0，以此排开；get时注意数据库里是什么类型 类型写错了会读不到数据
                        row1["Date"] = Convert.ToString(parms[0].Value);
                        row1["Fltno"] = Convert.ToString(parms[1].Value);
                        dt.Rows.Add(row1);//dt 添加行
                        count1++;
                        continue;
                    }






                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectStr))
                        {

                            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert_Card, parms);
                            count++;

                        }
                    }
                    catch (Exception e)
                    {
                        //Response.Write("<script>alert('" + parms[0].Value + " " + parms[1].Value + " " + "\\r please check the file')</script>");
                        DataRow row1 = dt.NewRow();
                        //注意get有两点  数据库中第一个属性下表为0，以此排开；get时注意数据库里是什么类型 类型写错了会读不到数据
                        row1["Date"] = Convert.ToString(parms[0].Value);
                        row1["Fltno"] = Convert.ToString(parms[1].Value);
                        dt.Rows.Add(row1);//dt 添加行
                        count1++;
                        continue;

                    }

                }


            }
        }
        flag = true;


     

    return flag;
    }
    //删除以往数据
    public void DeleteDataFromSQL(DataSet date, string[] sheetname)
    {
        string SQL_Delet_Card = "Delete From FLT " +
            "Where FLT.Date = @Date ";
        //string connectStr = "server=FALCON-IT\\SQLEXPRESS;User Id = sa;Password = 1234567890w; database = FLT";//连接SQL语句
        try
        {
            for (int j = 0; j < sheetname.Length; j++)
            {
                string tablename = sheetname[j];
                if (tablename == null)
                    continue;
                SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@Date", SqlDbType.Date)
            };
                //Response.Write("<script>alert('" +  Convert.ToDateTime(date.Tables["DS"].Rows[0][0].ToString().Trim()) + "')</script>");


                parm[0].Value = Convert.ToDateTime(date.Tables[tablename].Rows[0][0].ToString().Trim());


                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Delet_Card, parm);
                }
            }
        }
        catch (Exception e)
        {
        }

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
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("Fltno", typeof(string));

              
                string[] sheetname = GetsheetnameFromExcel(Server.MapPath(savePath), extension);
                    //读取数据
                DataSet ds = LoadDataFromExcel(Server.MapPath(savePath), extension, sheetname);//存储数据 
                    //读取日期
                DataSet date = LoadDateFromExcel(Server.MapPath(savePath), extension, sheetname);


                //删除相同数据
                DeleteDataFromSQL(date, sheetname);
                

                //插入相同数据
                InsertToDataBase(ds, sheetname, dt,date);

                

                Response.Write("<script>alert('" + count + " items succeed, " + count1 + " items failed ')</script>");
                
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Label2.Text = count + " items succeed, " + count1 + " items failed ";
                count = 0;
                count1 = 0;
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