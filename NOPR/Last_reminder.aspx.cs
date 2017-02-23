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
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;
public partial class Last_reminder : System.Web.UI.Page
{
    public int failcount = 0;
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    StringBuilder cctext = new StringBuilder(255);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin_Level"] == null || Session["NOPRUserID"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else
        {
            getdata();
            Send.Attributes.Add("onclick", "return check()");
        }
    }


    public void getdata()
    {

        //读取数据
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter("select * from NOPR_Data where 1=1", SqlHelper.Conn);
        sda.Fill(ds, "Email_table");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables["Email_table"].DefaultView;
        datacount.Text = ds.Tables["Email_table"].Rows.Count.ToString();
        pds.AllowPaging = true;//允许分页
        pds.PageSize = 5;//单页显示项数
        int CurPage;
        if (Request.QueryString["Page"] != null)
            CurPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurPage = 1;
        pds.CurrentPageIndex = CurPage - 1;
        int Count = pds.PageCount;
        lblCurrentPage.Text = "Current Page：" + CurPage.ToString();
        labPage.Text = Count.ToString();
        if (Count > 1)
        {
            this.first.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=1";
            this.last.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(Count);
        }
        if (!pds.IsFirstPage)
        {

            up.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1);
        }

        if (!pds.IsLastPage)
        {

            next.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage + 1);
        }


        //Repeater
        Email_table.DataSource = pds;
        Email_table.DataBind();
    }
    protected void Send_Click(object sender, EventArgs e)
    {


        string SQL_query = " SELECT distinct staffid,Name,Email,GM_Email,Other_Email  from NOPR_Data";

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {
            while (rdr.Read())
            {
                sendemail(Convert.ToString(rdr.GetSqlValue(0)), Convert.ToString(rdr.GetSqlValue(1)), Convert.ToString(rdr.GetSqlValue(2)), Convert.ToString(rdr.GetSqlValue(3)), Convert.ToString(rdr.GetSqlValue(4)));
            }

        }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Mail sent successfully.');</script>");

    }



    public void sendemail(string staffid, string name, string mail, string gmmail, string othermail)
    {

        //发件人是HR固定账号
        string UserName = "";

        string Password = "@@@@@@@";
        string MailServer = "192.168.101.100";
        int smtpPort = 25;
        System.Net.Mail.SmtpClient sc = new SmtpClient(MailServer, smtpPort);
        NetworkCredential nc = new NetworkCredential(UserName, Password);
        sc.Credentials = nc;

        MailMessage MyEmailMessage = new MailMessage();

        //获取收件人
        getmailadd();
        //添加收件人       
        MyEmailMessage.To.Add(new MailAddress(mail));
        //CC GM
        if (gmmail != "")
            MyEmailMessage.CC.Add(new MailAddress(gmmail));
        if (othermail != "")
            MyEmailMessage.CC.Add(new MailAddress(othermail));
        //CC HR经理
        addcc(MyEmailMessage);
        //CC 发件人
        string SQL_query = " select Email from NOPR_User where NOPR_UserName='" + Session["NOPRUserID"].ToString() + "'";

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {
            if (rdr.Read())
            {
                MyEmailMessage.CC.Add(new MailAddress(Convert.ToString(rdr.GetSqlValue(0))));
                MyEmailMessage.From = new MailAddress(Convert.ToString(rdr.GetSqlValue(0)));
            }

        }



        MyEmailMessage.IsBodyHtml = true;
        MyEmailMessage.BodyEncoding = Encoding.GetEncoding(936);
        MyEmailMessage.Subject = "Last reminder for your no punch notification（" + staffid + ")";
        //获得邮件内容


        string txbody = "<P style=\"font-family:times;font-size:18px\">Dear " + name + " (" + staffid + "),</p>";
        txbody = txbody + " <span style=\"color:red;font-family:times;font-size:18px\"><p><b><i>THIS SERVE AS THE LAST REMINDER FOR YOU!</i></b></p></span>";
        txbody = txbody + "<div style=\"float:left;font-family:times;font-size:18px;display:block\">Kindly note that you had</div>";
        string SQL_mailbody = " select Result,Punch_Date,Punch_Time from NOPR_Data where StaffID='" + staffid + "' and Name='" + name + "'  and Email='" + mail + "'   and GM_Email='" + gmmail + "' and Other_Email='" + othermail + "'  order by Punch_Date,Punch_Time";

        txbody = txbody + "<table style=\"font-family:times;font-size:18px;\">";

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_mailbody))
        {
            while (rdr.Read())
            {
                txbody = txbody + "<tr>";
                txbody = txbody + "<td style=\"background-color:yellow;\">" + Convert.ToString(rdr.GetSqlValue(0)) + " (" + Convert.ToString(rdr.GetSqlValue(2)) + " ) </td>";
                txbody = txbody + "<td>on</td>";
                txbody = txbody + "<td style=\"background-color:yellow;\">" + Convert.ToDateTime(Convert.ToString(rdr.GetSqlValue(1))).ToString("dd-MM-yyyy") + "</td>";
                txbody = txbody + "</tr>";


                // txbody = txbody + "<tr><td>" + Convert.ToString(rdr.GetSqlValue(0)) + "</td><td>" + Convert.ToString(rdr.GetSqlValue(1)) + "</td><td>" + Convert.ToString(rdr.GetSqlValue(2)) + "</td></tr>";
            }

        }
        txbody = txbody + "</table>";
        txbody = txbody + "</div>";
        txbody = txbody + " </br>";
        txbody = txbody + " <span style=\"font-family:times;font-size:18px\">The attendance discrepancies are not clear <span style=\"color:red\"><i><b>within 3 days</b></i></span> from this notification will be considered as absence without leave and warning letter will be issued.</span>";
        txbody = txbody + " <p style=\"font-family:times;font-size:18px\">If the staff forgot to punch in/out, please submit your application through E-HR system for your superior’s approval:</p>";
        txbody = txbody + "  <a href=\"http://ehr.airmacau.com.mo\" style=\" font-family:times;font-size:18px\">http://ehr.airmacau.com.mo </a><span style=\" font-family:times;font-size:18px\"><i>(NX Self Service → Punch Data Application → Apply Punch Data → Filling Up → Submit)</i><span>";
        txbody = txbody + "  <p><i><u>Please refer our employee handbook section21.1.5 regarding the Absence without Leave:</u></i></p>";
        txbody = txbody + "<img src=\"cid:last\">";
        //txbody = txbody + "  </br>";
        //txbody = txbody + " <span style=\"background-color:yellow;font-family:times;font-size:18px\">Noted:</span>";
        //txbody = txbody + "<P style=\"font-family:times;font-size:18px\">One who fails to punch data will be treated as <span style=\"background-color:yellow;\">Absence without leave</span>. The following action will be taken against an employee who is absent without leave for the day (including staff who are unable to provide a medical certificate to justify his absence): </p>";
        //txbody = txbody + "<P style=\"font-family:times;font-size:18px\">(1) First offence - Letter of warning and one day of annual leave or salary deducted.</p>";
        //txbody = txbody + "<P style=\"font-family:times;font-size:18px\">(2) Second offence - Letter of warning;</p>";
        //txbody = txbody + "<P style=\"font-family:times;font-size:18px;margin-left:140px\">- Deduct one day's salary;</p>";
        //txbody = txbody + "<P style=\"font-family:times;font-size:18px;margin-left:140px\">- Staff cease to be eligible for travel benefit for the next 12 months.</p>";
        //txbody = txbody + "<P style=\"font-family:times;font-size:18px\">(3) Third offence - Disciplinary Inquiry with a view to dismissal.</p>";
        txbody = txbody + "</br>";
        txbody = txbody + "</br>";
        txbody = txbody + "<P style=\"font-family:times;font-size:18px\">Thank you for your attention.</p>";
        txbody = txbody + "<P style=\"font-family:times;font-size:18px\">Human Resources Division</p>";


        //html 格式
        AlternateView htmlBody = AlternateView.CreateAlternateViewFromString(txbody, null, "text/html");

        //图片添加
        LinkedResource lrImage = new LinkedResource(Server.MapPath(Request.ApplicationPath) + "/images/2.jpg", "image/gif");
        lrImage.ContentId = "last";
        htmlBody.LinkedResources.Add(lrImage);


        MyEmailMessage.AlternateViews.Add(htmlBody);
        //MyEmailMessage.Body = txbody;

        MyEmailMessage.Priority = MailPriority.High;
        try
        {
            sc.Send(MyEmailMessage);//发送电子邮件
        }
        catch (Exception er)
        {
            failcount++;
            // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Email Send Error.');</script>");
        }



    }


    //添加CC
    public void addcc(MailMessage MyEmailMessage)
    {
        string[] cclist = cctext.ToString().Split(';');
        int cclistlen = cclist.Length;
        for (int i = 0; i < cclist.Length; i++)
        {
            if (cclist[i] == "")
                continue;
            else
                MyEmailMessage.CC.Add(new MailAddress(cclist[i]));
        }

    }


    //初始化接收人地址
    public bool getmailadd()
    {
        bool flag = false; //false是正常
        string path = Server.MapPath(Request.ApplicationPath) + "/mail.ini";
        try
        {


            int i1 = GetPrivateProfileString("mail", "cc", "", cctext, 255, path);
        }
        catch
        {

            flag = true;
        }
        return flag;

    }


    //上传到数据库
    protected void Upload_Click(object sender, EventArgs e)
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




                //插入数据 

                DataTable dt = new DataTable();
                InsertToDataBase(ds);




            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('File Type error, please select the correct file.');</script>");
            }
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Upload success.');</script>");
            getdata();
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please select Upload file.');</script>");
        }


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


        String sql = "SELECT [Employee ID],[Employee Name],[Verified Result] ,[Roster Punch Date],[Roster Punch Time], [Email],[GM's Email],[Other's Email]FROM  [Sheet1$A1:GG20000]";//可是更改Sheet名称，比如sheet2，等等   
        OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);//读出数据
        OleDaExcel.Fill(OleDsExcle, "dt");//DS的表名字

        OleConn.Close();//链接断开


        return OleDsExcle;

    }

    //插入数据
    public bool InsertToDataBase(DataSet ds)
    {
        bool flag = false;//用来return

        //删除历史数据
        string SQL_Delete = " delete NOPR_Data where 1=1";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Delete);
            if (actionrows > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");

            }
            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
            }
        }

        //插入新数据

        string SQL_insert = " INSERT INTO  NOPR_Data (StaffID,Name,Result,Punch_Date,Punch_Time,Email,GM_Email,Other_Email)"
            + " values (@StaffID,@Name,@Result,@Punch_Date,@Punch_Time,@Email,@GM_Email,@Other_Email)";
        SqlParameter[] parms = new SqlParameter[]{
            new SqlParameter("@StaffID", SqlDbType.VarChar, 10),
            new SqlParameter("@name", SqlDbType.VarChar, 50),
            new SqlParameter("@Result", SqlDbType.VarChar, 50),
            new SqlParameter("@Punch_Date", SqlDbType.Date),
            new SqlParameter("@Punch_Time", SqlDbType.VarChar, 10),
            new SqlParameter("@Email", SqlDbType.VarChar, 50),
             new SqlParameter("@GM_Email", SqlDbType.VarChar, 50),
               new SqlParameter("@Other_Email", SqlDbType.VarChar, 50)
         };

        for (int i = 0; i < ds.Tables["dt"].Rows.Count; i++)
        {
            DataRow row = ds.Tables["dt"].Rows[i];
            parms[0].Value = row[0].ToString();
            parms[1].Value = row[1].ToString();
            parms[2].Value = row[2].ToString();
            parms[3].Value = Convert.ToDateTime(row[3].ToString().Trim()).ToShortDateString();
            try
            {

                parms[4].Value = Convert.ToDateTime(row[4].ToString().Trim()).ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                parms[4].Value = row[4].ToString();
            }
            parms[5].Value = row[5].ToString();
            parms[6].Value = row[6].ToString();
            parms[7].Value = row[7].ToString();
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert, parms);
            }
        }
        return flag;
    }
}