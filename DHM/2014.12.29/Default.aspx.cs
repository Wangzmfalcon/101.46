﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using SMS.DBUtility;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Data.OleDb;
using System.Diagnostics;
using System.Runtime.InteropServices;

public partial class _Default : System.Web.UI.Page
{   //杀EXCEL
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
   
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
    //检查

    StringBuilder[] stringBuilders = new StringBuilder[16];

    



    //name
    StringBuilder excelsheetname = new StringBuilder(255);
    StringBuilder excelfilename = new StringBuilder(255);


    int errorcode = 0;
    //读取配置文件
    private void readconfig()
    {
        string path = Server.MapPath(Request.ApplicationPath) + "/config.ini";
        try
        {
            for (int i = 0; i < 16; i++) 
            {
                stringBuilders[i] = new StringBuilder();
                GetPrivateProfileString("Excelhead", (i+1).ToString(), "", stringBuilders[i], 255, path);
            }
           

            GetPrivateProfileString("Excelname", "sheetname", "", excelsheetname, 255, path);
            GetPrivateProfileString("Excelname", "filename", "", excelfilename, 255, path);


        }
        catch(Exception e)
        {
           // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('无法获取配置文件，请联系管理员');</script>");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        { }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        
        //上传
        string savePath = null;
        bool fileflag = false;
        string filepath = "Files/";//存储路径
        string filename = Server.HtmlEncode(FileUpload1.FileName);//名字
        string extension = System.IO.Path.GetExtension(filename);//扩展名字
        if (FileUpload1.HasFile)//如果有选择文件
        {


            if (extension == ".xlsx" || extension == ".xls")
            {
                savePath = filepath + filename;//存储相对路径
                FileUpload1.SaveAs(Server.MapPath(savePath));//存到服务器
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('上传成功.');</script>");
                fileflag = true;
            }
            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Wrong file ，please select the right file.');</script>");
                errorcode = 1;//文件格式错误
            }
        }
        else
        {
            errorcode = 5;
        }
        
        if(fileflag)
        {
            
            //格式检查
            readconfig();//获得配置文件
            //DataSet ds = LoadDataFromExcel(Server.MapPath(savePath), extension, excelsheetname.ToString());//存储数据 
            //DataSet ds1 = ToDataTable(Server.MapPath(savePath));
            DataSet ds = new DataSet();  
            //读取文件
            DataTable dt = ImpExcel(Server.MapPath(savePath));     
            ds.Tables.Add(dt);



            if(errorcode!=2)
            {

                 for (int i = 0; i < 16; i++)
                 {
                    string columnname = null;
                    try
                    {
                        columnname = ds.Tables[excelsheetname.ToString()].Columns[i].ColumnName;
                    }
                    catch (Exception ex)
                    {
                        errorcode = 4;//表格格式错误
                    }
                    if (stringBuilders[i].ToString() != columnname)
                    {
                        errorcode = 4;
                    }
                }



                 if (errorcode != 3 && errorcode != 4)
                 {
                     //转换
                     DataSet dstemp = LoadTemplateFromExcel(Server.MapPath("Template/Template.xls"), extension, excelsheetname.ToString());//存储数据 
                     newexcel(ds, dstemp);
                     addavg(dstemp);
                     //添加 AVG

                     //保存                     
                     saveExcel(Server.MapPath("Template/"+excelfilename.ToString()+".xls"),dstemp);
                     File.Delete(Server.MapPath(savePath));
                     //killexcel
                     //KillProcess();
                     //下载
                     FileTo();
                    


                 }




              

            }

           
           
           
            //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('删除成功.');</script>");
        }
        //删除上传文件
        if(errorcode!=1&&errorcode!=0)
        {
            File.Delete(Server.MapPath(savePath));
        }
       
        //错误提示
        string errorstring = null;
        switch (errorcode)
        {
            case 0:
                errorstring = "Convert successful";
                break;
            case 1:
                errorstring = "Wrong Format ,please select the correct excel file";
                break;
            case 2:
                errorstring = "Wrong sheet ,please select the correct file";
                break;
            case 3:
                errorstring = "Can not find the Template file ,please contact administrator";
                break;
            case 4:
                errorstring = "Wrong file ,please select the correct file";
                break;
            case 5:
                errorstring = "No file ,please select  file";
                break;
            default:
                //errorstring = "Convert successful";
                break;
        }

        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + errorstring + "');</script>");
            
    }


    private void addavg(DataSet dstemp)
    {
        for (int i = 0; i < dstemp.Tables.Count; i++)
        {
            string dtempname = dstemp.Tables[i].TableName;
            float avg = 0;
            DataRow rowtemp = dstemp.Tables[dtempname].NewRow();
            if (dtempname == "主管碰头会议决议事项督办清单")
            {
                
                for (int j = 1; j < dstemp.Tables[dtempname].Rows.Count - 1; j++)
                {
                   
                    DataRow rowds = dstemp.Tables[dtempname].Rows[j];
                    string rowjj = rowds[7].ToString();
                    float f = float.Parse(rowjj.Substring(0,rowjj.Length - 1));
                    f /= 100;
                    avg += f;
                }
                avg = avg * (float)100 / (float)(dstemp.Tables[dtempname].Rows.Count - 2);
                rowtemp[0] = "平均进度";
                rowtemp[7] = avg.ToString()+"%";
            }
            else
            {
                for (int j = 1; j < dstemp.Tables[dtempname].Rows.Count ; j++)
                {

                    DataRow rowds = dstemp.Tables[dtempname].Rows[j];
                    string rowjj = rowds[6].ToString();
                    float f = float.Parse(rowjj.Substring(0, rowjj.Length - 1));
                    f /= 100;
                    avg += f;
                }
                avg = avg * (float)100 / (float)(dstemp.Tables[dtempname].Rows.Count - 1);
                rowtemp[0] = "平均进度";
                rowtemp[6] = avg.ToString() + "%";
            
            }
            dstemp.Tables[i].Rows.Add(rowtemp);
        }
    }

    //杀EXCEL
    private void KillProcess()
    {
        //获得进程对象，以用来操作
        System.Diagnostics.Process myproc = new System.Diagnostics.Process();
        //得到所有打开的进程
        try
        {
            Process[] pros = Process.GetProcesses();
            //获得需要杀死的进程名
            foreach (Process thisproc in pros)
            {
                if (thisproc.ProcessName == "EXCEL")
                    //立即杀死进程
                    thisproc.Kill();
            }
        }
        catch (Exception Exc)
        {
            throw new Exception("", Exc);
        }
    } 

    //kill
    
    public void Kill(Microsoft.Office.Interop.Excel.Application excel)
    {
        excel.Quit();
        IntPtr t = new IntPtr(excel.Hwnd);
        int k = 0;
        GetWindowThreadProcessId(t, out k);
        System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
        p.Kill();
    }  
    //测试读文件

    /// <summary>
        /// 读取Excel文件到DataSet中
        /// </summary>
        /// <param name=”filePath”>文件路径</param>
        /// <returns></returns>
        public static DataSet ToDataTable(string filePath)
        {
            string connStr = "";
            string fileType = System.IO.Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileType)) return null;
            if (fileType == ".xls")
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath+ ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            else
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath+ ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            string sql_F = "Select * FROM [{0}]";
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;
            DataTable dtSheetName= null;
            DataSet ds = new DataSet();
            try
            {
                // 初始化连接，并打开
                conn = new OleDbConnection(connStr);
                conn.Open();
                // 获取数据源的表定义元数据
                string SheetName = "";
                dtSheetName= conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                // 初始化适配器
                da = new OleDbDataAdapter();
                for (int i = 0; i < dtSheetName.Rows.Count; i++)
                {
                    SheetName = (string)dtSheetName.Rows[i]["TABLE_NAME"];
                    if (SheetName .Contains("$") && !SheetName .Replace("‘", "").EndsWith("$"))
                    {
                        continue;
                    }
                    da.SelectCommand = new OleDbCommand(String.Format(sql_F, SheetName ), conn);
                    DataSet dsItem = new DataSet();
                    da.Fill(dsItem, SheetName);
                    ds.Tables.Add(dsItem.Tables[0].Copy());
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // 关闭连接
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    da.Dispose();
                    conn.Dispose();
                }
            }
            return ds;
        }


    // 完全读取 excel
        /// <summary>
        /// 解析Excel，返回DataTable
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public  System.Data.DataTable ImpExcel(string fileName)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.TableName = excelsheetname.ToString();
            try
            {
               //Microsoft.Office.Interop.Excel.Application app;
               //Microsoft.Office.Interop.Excel.Workbook wbs;
               // Microsoft.Office.Interop.Excel.Worksheet ws;

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application(); //新建文件

                // 多数使用缺省值 (除了 read-only我们设置它为 true)
                Microsoft.Office.Interop.Excel.Workbook wbs = app.Workbooks.Open(fileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, null, null);
                // 取得工作簿（workbook）中表单的集合（sheets）
                Microsoft.Office.Interop.Excel.Sheets wss = wbs.Worksheets;
                // 取得表单集合中唯一的一个表（worksheet）
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wss.get_Item(1);
              

                //app = new Microsoft.Office.Interop.Excel.Application();
                //wbs = app.Workbooks.Open(fileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, null, null);
               
                //ws = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
                //int a = ws.Rows.Count;
                int a = ws.UsedRange.Cells.Rows.Count+2;
                //int b = ws.Columns.Count;
                int b = 20;
                string name = ws.Name;


                for (int i = 1; i < a; i++)
                {
                    if (i == 1)
                    {
                        for (int j = 1; j <= b; j++)
                        {
                            Microsoft.Office.Interop.Excel.Range range = ws.get_Range(app.Cells[i, j], app.Cells[i, j]);
                            range.Select();
                            string columnnames = app.ActiveCell.Text.ToString();
                            dt.Columns.Add(columnnames, typeof(string));
                        }
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 1; j <= b; j++)
                        {
                            Microsoft.Office.Interop.Excel.Range range = ws.get_Range(app.Cells[i, j], app.Cells[i, j]);
                            range.Select();
                            int rowco = j - 1;
                            string cellc = app.ActiveCell.Text.ToString(); ;
                            dr[rowco] = cellc;
                        }
                        dt.Rows.Add(dr);
                    }
                
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);
                ws = null;

                System.Runtime.InteropServices.Marshal.ReleaseComObject(wss);
                wss = null;

                wbs.Close(true, Type.Missing, Type.Missing);
                //(Microsoft.Office.Interop.Excel.Worksheet)wbs.Close(true, Type.Missing, Type.Missing);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wbs);
                wbs = null;
                
                app.Application.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                int generation = System.GC.GetGeneration(app);
                Kill(app);
                app = null;
                System.GC.Collect(generation); 
                return dt;
            }
            catch (Exception ex)
            {
               // MessageBox.Show("数据绑定Excel失败! 失败原因：Excel格式不正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dt;
            }
            finally
            {
                
                GC.Collect();//垃圾回收
                GC.WaitForPendingFinalizers();
            }
        }
    //下载
    public void FileTo()   //file文件名称
    {


        string path = Server.MapPath("Template/" + excelfilename.ToString() + ".xls");

            System.IO.FileInfo file = new System.IO.FileInfo(path);

            if (file.Exists)
            {

                Response.Clear();

                Response.ContentType = "application/vnd.ms-excel";

                Response.AddHeader("Content-Disposition", "attachment; filename=" +Server.UrlEncode(excelfilename.ToString()) + ".xls");

                Response.AddHeader("Content-Length", file.Length.ToString());

                Response.ContentType = "application/octet-stream";

                Response.Filter.Close();

                Response.WriteFile(file.FullName);

                Response.End();


        }
    }
    //写EXCEL
    public void saveExcel(string savepath,DataSet dstemp)
    {

        string filepath = Server.MapPath("Template/Template.xls");

        Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application(); //新建文件

        // 多数使用缺省值 (除了 read-only我们设置它为 true)
        Microsoft.Office.Interop.Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(filepath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, null, null);
        // 取得工作簿（workbook）中表单的集合（sheets）
        Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
        // 取得表单集合中唯一的一个表（worksheet）

        if (ExcelObj == null)
        {
            //MessageBox.Show("无法启动Excel，可能您的电脑未安装Excel");
            return;
        }
        try
        {

           
            for (int i = 0; i < dstemp.Tables.Count; i++)
            { 
                string dtempname= dstemp.Tables[i].TableName;
                
            
            
                int rowIndex = 1;
                int colIndex = 0;

                int sizeofsheet = sheets.Count;


                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(dtempname);
                    string a = worksheet.Name;
                    int countrow = dstemp.Tables[dtempname].Rows.Count;
                    
                int countcolumn=0;
                if (dtempname == "主管碰头会议决议事项督办清单")
                    countcolumn = 9;
                else
                    countcolumn = 8;
                    var RowAll = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[countrow + 1, countcolumn]);
                    RowAll.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    System.Data.DataTable table = dstemp.Tables[dtempname];
                    foreach (DataColumn col in table.Columns)
                    {
                        colIndex++;
                        worksheet.Cells[2, colIndex] = col.ColumnName;
                    }

                    foreach (DataRow row in table.Rows)
                    {
                        rowIndex++;
                        colIndex = 0;
                        foreach (DataColumn col in table.Columns)
                        {
                            colIndex++;
                            worksheet.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();

                        }
                    }
                    rowIndex = 1;
                    colIndex = 0;

            }
            ExcelObj.DisplayAlerts = false;
            ExcelObj.ActiveWorkbook.SaveAs(savepath);

            //MessageBox.Show("数据导出成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ExcelObj.Visible = false;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets); 
            sheets = null;


            theWorkbook.Close(true, Type.Missing, Type.Missing);                     
            System.Runtime.InteropServices.Marshal.ReleaseComObject(theWorkbook); 
            theWorkbook = null;

            ExcelObj.Application.Workbooks.Close();
            ExcelObj.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelObj);
            Kill(ExcelObj);
            int generation = System.GC.GetGeneration(ExcelObj);
            ExcelObj = null;
            System.GC.Collect(generation); 
            
            
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.ToString());
        }
        finally
        {
            GC.Collect();//垃圾回收
            GC.WaitForPendingFinalizers();
        }

    } 


    //格式转换
    public void newexcel(DataSet ds, DataSet dstemp)
    {
        for (int i = 0; i < ds.Tables[excelsheetname.ToString()].Rows.Count - 1; i++)
        {
            DataRow rowtemp = dstemp.Tables[excelsheetname.ToString()].NewRow();
            DataRow rowds = ds.Tables[excelsheetname.ToString()].Rows[i];
            rowtemp[0] = rowds[1];
            rowtemp[1] = rowds[2];
            //rowtemp[2]    //VPS
            //string []vps =new string[];
            List<string> vps=new List<string>();
            
            for (int j = 8; j < 16; j++)
            {
                string check=rowds[j].ToString();
                if (check == "1")
                {
                    vps.Add(ds.Tables[excelsheetname.ToString()].Columns[j].ColumnName);
                    string vptable = ds.Tables[excelsheetname.ToString()].Columns[j].ColumnName;
                    DataRow vprow = dstemp.Tables[ds.Tables[excelsheetname.ToString()].Columns[j].ColumnName].NewRow();
                    vprow[0] = rowds[1];
                    vprow[1] = rowds[2];
                    vprow[2] = rowds[0];
                    vprow[3] = rowds[3];
                    vprow[4] = rowds[4];
                    vprow[5] = rowds[5];
                    vprow[6] = rowds[6];
                    vprow[7] = rowds[7];
                    dstemp.Tables[ds.Tables[excelsheetname.ToString()].Columns[j].ColumnName].Rows.Add(vprow);

                }
            }
           int onlyone=1;
           
           foreach (string s in vps)
           {
               if (onlyone == 1)
               {
                   rowtemp[2] += s;
               }
               else
               {
                   rowtemp[2] += "\n"+s;
               }
               onlyone++;
           }
        
            rowtemp[3] = rowds[0];            
            rowtemp[4] = rowds[3];
            rowtemp[5] = rowds[4];
            rowtemp[6] = rowds[5];
            rowtemp[7] = rowds[6];
            rowtemp[8] = rowds[7];


            dstemp.Tables[excelsheetname.ToString()].Rows.Add(rowtemp);
        }

    
    }

    //读取上传数据
    public  DataSet LoadDataFromExcel(string filePath, string Exceltype, string sheetname)
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
        try
        {
            String sql = "SELECT * FROM  [" + sheetname + "$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);//读出数据

            OleDaExcel.Fill(OleDsExcle, sheetname);//DS的表名字

            
        }
        catch (Exception e)
        {
           // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + e.Message + ".');</script>");
            errorcode = 2;//文件sheet不存在
           
        }
        OleConn.Close();//链接断开
        return OleDsExcle;

    }


    //读取Template数据
    public DataSet LoadTemplateFromExcel(string filePath, string Exceltype, string sheetname)
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
        try
        {
            String sql = "SELECT * FROM  [" + sheetname + "$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);//读出数据
            OleDaExcel.Fill(OleDsExcle, sheetname);//DS的表名字

            String sql1 = "SELECT * FROM  [VPCM$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel1 = new OleDbDataAdapter(sql1, OleConn);//读出数据
            OleDaExcel1.Fill(OleDsExcle, "VPCM");//DS的表名字


            String sql2 = "SELECT * FROM  [VPCS$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel2 = new OleDbDataAdapter(sql2, OleConn);//读出数据
            OleDaExcel2.Fill(OleDsExcle, "VPCS");//DS的表名字


            String sql3 = "SELECT * FROM  [VPFO$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel3 = new OleDbDataAdapter(sql3, OleConn);//读出数据
            OleDaExcel3.Fill(OleDsExcle, "VPFO");//DS的表名字

            String sql4 = "SELECT * FROM  [VPFN$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel4 = new OleDbDataAdapter(sql4, OleConn);//读出数据
            OleDaExcel4.Fill(OleDsExcle, "VPFN");//DS的表名字


            String sql5 = "SELECT * FROM  [VPGA$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel5 = new OleDbDataAdapter(sql5, OleConn);//读出数据
            OleDaExcel5.Fill(OleDsExcle, "VPGA");//DS的表名字

            String sql6 = "SELECT * FROM  [VPEM$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel6 = new OleDbDataAdapter(sql6, OleConn);//读出数据
            OleDaExcel6.Fill(OleDsExcle, "VPEM");//DS的表名字

            String sql7 = "SELECT * FROM  [GMCQ$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel7 = new OleDbDataAdapter(sql7, OleConn);//读出数据
            OleDaExcel7.Fill(OleDsExcle, "GMCQ");//DS的表名字

            String sql8 = "SELECT * FROM  [GMAS$]";//可是更改Sheet名称，比如sheet2，等等    
            //String sql = "SELECT * FROM  [9$A3:Z99]";
            OleDbDataAdapter OleDaExcel8 = new OleDbDataAdapter(sql8, OleConn);//读出数据
            OleDaExcel8.Fill(OleDsExcle, "GMAS");//DS的表名字




        }
        catch (Exception e)
        {
            // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + e.Message + ".');</script>");
            errorcode = 3;//temp文件sheet不存在
        }
        finally
        {
            GC.Collect();//垃圾回收
            OleConn.Close();//链接断开
        }
       
        return OleDsExcle;

    }
}