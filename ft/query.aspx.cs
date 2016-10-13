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

public partial class query : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Date", typeof(string));
        dt.Columns.Add("Fltno", typeof(string));
        dt.Columns.Add("ATD", typeof(string));
        dt.Columns.Add("ATA", typeof(string));
        dt.Columns.Add("Org", typeof(string));
        dt.Columns.Add("Des", typeof(string));
        dt.Columns.Add("FT", typeof(string));
        dt.Columns.Add("DHC/O", typeof(string));
        dt.Rows.Add(dt.NewRow());
        GridView2.DataSource = dt;
        GridView2.DataBind();


        if (!Page.IsPostBack)
        {
            ListItem item1 = new ListItem("28");//"13"为item3项的关联值  
            ListItem item2 = new ListItem("14");//"12"为item2项的关联值 
            ListItem item3 = new ListItem("7");//"11"为item1项的关联值   
              
             

              
            this.DropDownList1.Items.Add(item1);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item2);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item3);//添加到DropDownList1   

             }


    }



   

    public DataTable GetDetailBase(int sN,DateTime st, DateTime ls)//读取数据
    {
        DataTable dt = new DataTable();

        string SQL_select =
            "SELECT Roster.Date,Roster.Fltno,FLT.ATD,FLT.ATA,FLT.Org,FLT.Des,FLT.FT,Roster.DHC  " +
            "FROM Roster LEFT JOIN FLT " +
            "ON Roster.Date = FLT.Date and Roster.Fltno =FLT.Fltno " +
            "WHERE Roster.Date >@st and Roster.Date <= @ls and Roster.StaffNO=@sN ";

        string connectStr = "server=192.168.101.114;User Id = falcon;Password = airmacau; database = FLT";//连接SQL语句
      
        SqlParameter[] parms = new SqlParameter[]{
            new SqlParameter("@sN", SqlDbType.VarChar, 10),
            new SqlParameter("@st", SqlDbType.Date),
            new SqlParameter("@ls", SqlDbType.Date)
                                };
        parms[0].Value = sN;
        parms[1].Value = st;
        parms[2].Value = ls;

        dt.Columns.Add("Date", typeof(string));
        dt.Columns.Add("Fltno", typeof(string));
        dt.Columns.Add("ATD", typeof(string));
        dt.Columns.Add("ATA", typeof(string));
        dt.Columns.Add("Org", typeof(string));
        dt.Columns.Add("Des", typeof(string));
        dt.Columns.Add("FT", typeof(string));
        dt.Columns.Add("DHC/O", typeof(string));


 

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(connectStr, CommandType.Text, SQL_select, parms))
        {
            while (rdr.Read())
            {
                DataRow row = dt.NewRow();
                //注意get有两点  数据库中第一个属性下表为0，以此排开；get时注意数据库里是什么类型 类型写错了会读不到数据
                row["Date"] = Convert.ToString(rdr.GetDateTime(0).ToShortDateString());
                row["Fltno"] = Convert.ToString(rdr.GetSqlValue(1));
                row["ATD"] = Convert.ToString(rdr.GetSqlValue(2));
                row["ATA"] = Convert.ToString(rdr.GetSqlValue(3));
                try { row["Org"] = rdr.GetString(4); }
                catch (Exception eory)
                { 
                    row["Org"]="NODATA";
                }
                try { row["Des"] = rdr.GetString(5); }
                catch (Exception eDes)
                {
                    row["Des"] = "NODATA";
                }
                try { row["FT"] = Convert.ToString(rdr.GetSqlValue(6)); }
                catch (Exception eFT)
                {
                    row["FT"] = "NODATA";
                }
                try { row["DHC/O"] = rdr.GetString(7);
                if (rdr.GetString(7) == "1")
                {
                    row["DHC/O"] = "是";
                }
                else
                    row["DHC/O"] = "否";
                }
                catch (Exception edhc)
                {
                    row["DHC"] = "NODATA";
                }
                
                dt.Rows.Add(row);//dt 添加行

            }
            if (dt.Rows.Count == 0)
            {

                dt.Rows.Add(dt.NewRow());

            }
        }
     

        return dt;
    }


    public string GetTotal(DataTable dt)
    {
        string totallab = "0";
        if (dt.Rows.Count > 1)
        {
            
            int thours = 0;
            int tminutes = 0;
            int jin = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][7].ToString() == "是" || dt.Rows[i][6] == "")
                    continue;
                thours = thours + Convert.ToDateTime(dt.Rows[i][6].ToString()).Hour;
                tminutes = tminutes + Convert.ToDateTime(dt.Rows[i][6].ToString()).Minute;
            }
            jin = tminutes / 60;
            tminutes = tminutes % 60;
            thours = thours + jin;
            totallab = thours + ":" + tminutes;
        }
        else
        Response.Write("<script>alert('There is no data')</script>");
        return totallab;
    }



 

    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime lastdate =DateTime.Now;
        DateTime startdate=DateTime.Now;
        int staffNO = 0;
        int flag = 0;
        if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            int period = Convert.ToInt32(DropDownList1.Text);
            try
            {
                lastdate = Convert.ToDateTime(TextBox2.Text);
                staffNO = Convert.ToInt32(TextBox1.Text);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('please input staffno as:\\r0001\\rplease input date as: \\r2013.1.1\\r2013/1/1\\r2013-1-1')</script>");
                flag = 1;
            }
            if (flag == 0)
            {
                startdate = lastdate.AddDays(-period);

               
                DataTable dt = GetDetailBase(staffNO, startdate, lastdate);//查找数据
                //GridView1.DataSource = tt;//绑定数据显示
                GridView2.DataSource = dt;//绑定数据显示
                //GridView1.DataBind();
                GridView2.DataBind();
                for (int i = 0; i <= GridView2.Rows.Count - 1; i++) 
                { 
                    string s1 = dt.Rows[i][6].ToString();
                    string s2 = dt.Rows[i][7].ToString();
                    if (s1 == "")
                    {
                        GridView2.Rows[i].ForeColor = System.Drawing.Color.Red;
                    } 
                    if (s2 == "是") 
                    { 
                        GridView2.Rows[i].ForeColor = System.Drawing.Color.Blue; 
                    } 
                   
                }
               
               Label7.Text = GetTotal(dt);
            }
           
        }
        else
        {
            Response.Write("<script>alert('please input and select information')</script>");
        }
        
    }
 
}