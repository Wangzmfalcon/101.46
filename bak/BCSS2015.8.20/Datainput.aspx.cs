using System;
using System.Collections.Generic;
using SMS.DBUtility;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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

        if (!Page.IsPostBack)
        {
          
            string SQL_FLTNO = "SELECT A.FLIGHT_NO,A.DEP_STA "
                 + " FROM BCSS_FLIGHT_MAP A"
                 + " WHERE A.EFF_DT=(SELECT MAX(EFF_DT) FROM BCSS_FLIGHT_MAP B WHERE A.FLIGHT_NO=B.FLIGHT_NO)"
                 + " ORDER BY A.FLIGHT_NO";


            DataTable dt = new DataTable();
            dt.Columns.Add("FLIGT_NO", typeof(string));
            dt.Columns.Add("STA", typeof(string));
            
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_FLTNO))
            {
               
                while (rdr.Read())
                {
                    DataRow row = dt.NewRow();
                    row["FLIGT_NO"] = Convert.ToString(rdr.GetSqlValue(0)) ;
                    row["STA"] = Convert.ToString(rdr.GetSqlValue(1));
                
                    dt.Rows.Add(row);
                
                }

            }
            //     Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>document.getElementById('from1').value='" + DateTime.Now.ToShortDateString() + "';document.getElementById('to11').value='" + DateTime.Now.AddYears(100).ToShortDateString() + "';</script>");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>document.getElementById('to11').value='" + DateTime.Now.ToShortDateString() + "';</script>");

            
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Q1.Items.Add(new ListItem(dt.Rows[i]["FLIGT_NO"].ToString()));
            }



            this.Q4.Items.Add("Business");
            this.Q4.Items.Add("Leisure");
            this.Q4.Items.Add("Visiting");

            this.Q5.Items.Add("Yes");
            this.Q5.Items.Add("No");


            this.Q7.Items.Add("20 or below");
            this.Q7.Items.Add("21-30");
            this.Q7.Items.Add("31-40");
            this.Q7.Items.Add("41-50");
            this.Q7.Items.Add("51-60");
            this.Q7.Items.Add("60 or above");

            this.Q8.Items.Add("Male");
            this.Q8.Items.Add("Female");
           
        }

    }

    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string savedata = Request.Form["datainput"];
        //List<inputdata> ListOfinputdata = new List<inputdata>();
        string[] sArray = savedata.Split('|');
        string SQL_Insert = " INSERT INTO BCSS_DATE "
            + "  ( USER_ID, FLIGHT_NO, DEP_DT, SEAT_NUM, REASON, MEMBER, NATIONALITY, AGE, GENDER,CITY, VAL_01,VAL_02, VAL_03, VAL_04, VAL_05, VAL_06, VAL_07, VAL_08, VAL_09, VAL_10, VAL_11, VAL_12, VAL_13, LCHAR01, STAFF_NO, STATION, STATUS)"
            + " VALUES( @USER_ID, @FLIGHT_NO, @DEP_DT, @SEAT_NUM, @REASON, @MEMBER, @NATIONALITY, @AGE, @GENDER,@CITY,@VAL_01, @VAL_02, @VAL_03, @VAL_04, @VAL_05, @VAL_06, @VAL_07, @VAL_08, @VAL_09, @VAL_10, @VAL_11, @VAL_12, @VAL_13, @LCHAR01, @STAFF_NO, @STATION, @STATUS) ";
        SqlParameter[] parm = new SqlParameter[]{
                            new SqlParameter("@USER_ID", SqlDbType.VarChar, 10),
                            new SqlParameter("@FLIGHT_NO", SqlDbType.VarChar, 10),
                            new SqlParameter("@DEP_DT", SqlDbType.Date, 10),
                            new SqlParameter("@SEAT_NUM", SqlDbType.VarChar, 10),
                            new SqlParameter("@REASON", SqlDbType.VarChar, 10),
                            new SqlParameter("@MEMBER", SqlDbType.VarChar, 10),
                            new SqlParameter("@NATIONALITY", SqlDbType.VarChar, 10),
                            new SqlParameter("@AGE", SqlDbType.VarChar, 10),
                            new SqlParameter("@GENDER", SqlDbType.VarChar, 10),
                            new SqlParameter("@CITY ", SqlDbType.VarChar, 10),
                            new SqlParameter("@VAL_01", SqlDbType.Int),
                            new SqlParameter("@VAL_02", SqlDbType.Int),
                            new SqlParameter("@VAL_03", SqlDbType.Int),
                            new SqlParameter("@VAL_04", SqlDbType.Int),
                            new SqlParameter("@VAL_05", SqlDbType.Int),
                            new SqlParameter("@VAL_06", SqlDbType.Int),
                            new SqlParameter("@VAL_07", SqlDbType.Int),
                            new SqlParameter("@VAL_08", SqlDbType.Int),
                            new SqlParameter("@VAL_09", SqlDbType.Int),
                            new SqlParameter("@VAL_10", SqlDbType.Int),
                            new SqlParameter("@VAL_11", SqlDbType.Int),
                            new SqlParameter("@VAL_12", SqlDbType.Int),
                            new SqlParameter("@VAL_13", SqlDbType.Int),
                            new SqlParameter("@LCHAR01", SqlDbType.VarChar, 200),
                            new SqlParameter("@STAFF_NO", SqlDbType.VarChar, 10),
                            new SqlParameter("@STATION", SqlDbType.VarChar, 10),
                            new SqlParameter("@STATUS", SqlDbType.VarChar, 10)

                   
                             };
        parm[0].Value = Session["User_ID"].ToString();
        parm[26].Value ="NEW";
        int j = 1;
        foreach (string i in sArray)
        {

            if (i != "")
            {
                string[] iArray = i.Split(':');
                //inputdata ipd = new inputdata(iArray[0],iArray[1]);
               // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('"+i+"');</script>");
                //ListOfinputdata.Add(ipd);
                if (j == 1)//航线得到起飞站点
                {
                    parm[j].Value = iArray[1];
                    string GET_STATION = "SELECT A.DEP_STA "
                       + " FROM BCSS_FLIGHT_MAP A"
                       + " WHERE A.EFF_DT=(SELECT MAX(EFF_DT) FROM BCSS_FLIGHT_MAP B WHERE A.FLIGHT_NO=B.FLIGHT_NO)"
                       + " and A.FLIGHT_NO='" + iArray[1] + "'"
                       + " ORDER BY A.FLIGHT_NO";
                    using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, GET_STATION))
                    {

                        while (rdr.Read())
                        {
                            parm[25].Value = Convert.ToString(rdr.GetSqlValue(0));                 
                        }

                    }
                }else if(j==2)//乘机日期
                {
                    try
                    { parm[j].Value = Convert.ToDateTime(iArray[1]); }

                    catch
                    { parm[j].Value = Convert.ToDateTime("1900.1.1"); }
                      
                 }
                else if (j>=10 &&j<=22)
                {
                    try
                    { parm[j].Value = Convert.ToInt32(iArray[1]); }

                    catch
                    { parm[j].Value = Convert.ToInt32("0"); }
                    
                   
                    }
         
                else
                {

                    try
                    { parm[j].Value = iArray[1]; }

                    catch
                    { parm[j].Value = parm[25].Value = Convert.ToString(""); }
                 }


                j++;



            }
           
        
        }


        //try
        //{
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Insert, parm);
            }
        //}
        // catch
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('save faild');</script>");
        // }
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Input data has been saved');</script>");


    }


    //public class inputdata
    //{
    //    string Qnum;
    //    string Qdata;
    //    public  inputdata (string Qnum,string Qdata)
    //    {
    //        this.Qnum = Qnum;
    //        this.Qdata = Qdata;
    //    }
    //}


}