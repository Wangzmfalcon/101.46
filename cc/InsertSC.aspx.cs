using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SMS.DBUtility;
using System.Data;
using System.Data.OleDb;
using System.IO;

public partial class InsertSC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["User_ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
            Label1.Text = "Welcome " + Session["User_Name"].ToString();


        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>document.getElementById('from1').value='" + DateTime.Now.ToShortDateString() + "';document.getElementById('to11').value='" + DateTime.Now.AddYears(100).ToShortDateString() + "';</script>");
        if (!Page.IsPostBack)
        {
            ListItem item = new ListItem("");//"13"为item3项的关联值  
            ListItem item0 = new ListItem("SCH");//"13"为item3项的关联值  
            ListItem item1 = new ListItem("CHA");//"11"为item1项的关联值  
          

            this.DropDownList1.Items.Add(item);//添加到DropDownList1  
            this.DropDownList1.Items.Add(item0);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item1);//添加到DropDownList1   



            string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info where Crew_Info.Rcd_Status ='NEW'"
                  + " order by Crew_Info.Staff_Name";


            DataTable dt = new DataTable();
            dt.Columns.Add("StaffName(StaffNo)", typeof(string));
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Staff))
            {
                while (rdr.Read())
                {
                    DataRow row = dt.NewRow();
                    row["StaffName(StaffNo)"] = Convert.ToString(rdr.GetSqlValue(1)) + "(" + Convert.ToString(rdr.GetSqlValue(0)) + ")";


                    dt.Rows.Add(row);
                }

                this.DropDownList2.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DropDownList2.Items.Add(new ListItem(dt.Rows[i]["StaffName(StaffNo)"].ToString()));
                }
            }
          
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }


    public List<string[]> getstafflist(string type)//获得对应的list
    {
        List<string[]> stafflist = new List<string[]>();

        string SQL_getstaff = " select Staff_No,Staff_Name from Crew_Info "
        + "where Crew_Info.Rcd_Status='NEW'   AND Title='" + type + "'";



        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_getstaff))
        {
            while (rdr.Read())
            {

                string[] staffno = new string[2];
                staffno[0] = rdr[0].ToString().Trim();
                staffno[1] = rdr[1].ToString().Trim();
                stafflist.Add(staffno);

            }

        }
        return stafflist;
    }

    public void insertsc(string stn_code, string stn_name, string ft, string sN, string sNa,string Fr,string To)//插入
    {


        string SQL_Insert = "INSERT INTO Station_Crew_Pair"
             + " (Station_Code,Station_Name,Flight_Type,Allow_Staff_No,Allow_Staff_Name,No_From,No_To)"
                      + " VALUES(@stn_code,@stn_name,@ft,@sN,@sNa,@Fr,@To)";
        SqlParameter[] parm = new SqlParameter[]{
                    new SqlParameter("@stn_code", SqlDbType.VarChar, 6),
                    new SqlParameter("@stn_name", SqlDbType.VarChar, 100),
                    new SqlParameter("@ft", SqlDbType.VarChar, 20),
                     new SqlParameter("@sN", SqlDbType.VarChar, 10),
                     new SqlParameter("@sNa", SqlDbType.VarChar, 100),
                    new SqlParameter("@Fr", SqlDbType.Date),
                    new SqlParameter("@To", SqlDbType.Date)
                     };
        parm[0].Value = stn_code.Trim();
        parm[1].Value = stn_name.Trim();
        parm[2].Value = ft.Trim();
        parm[3].Value = sN.Trim();
        parm[4].Value = sNa.Trim();
        parm[5].Value = Convert.ToDateTime(Fr);
        parm[6].Value = Convert.ToDateTime(To);

        try
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Insert, parm);
            }
            //Response.Write("<script>alert('The operation was successful')</script>");
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('The operation was successful');</script>");


        }
        catch
        {
            //Response.Write("<script>alert('Record already exists')</script>");
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Record already exists');</script>");

        }
        //写LOG

        string SQL_Log = "INSERT INTO Crew_Check_Log"
    + " (Staff_No,Details_Origin,Details_After_Action,Actions,Rcd_By,Edit_Table)"
    + " VALUES(@sN,@DO,@DA,@AC,@RB,@ET)";


        SqlParameter[] parmlog = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@DO", SqlDbType.VarChar, 200),
                new SqlParameter("@DA", SqlDbType.VarChar, 200),
                new SqlParameter("@AC", SqlDbType.VarChar, 50),
                new SqlParameter("@RB", SqlDbType.VarChar, 50),
                new SqlParameter("@ET", SqlDbType.VarChar, 10)
                 };
        parmlog[0].Value = "Station_Crew_Pair";
        parmlog[1].Value = "";
        parmlog[2].Value = stn_code.Trim() + "/" + stn_name.Trim() + "/" + ft.Trim() + "/" + sN.Trim() + "/" + sNa.Trim() + "/" + Fr + "/" + To;
        parmlog[3].Value = "CREATE";
        parmlog[4].Value = Session["User_ID"].ToString().Trim();
        parmlog[5].Value = "SC";
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Log, parmlog);
        }

    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string stn_code = TextBox1.Text.ToUpper();
        string stn_name = TextBox2.Text.ToUpper();
        string ft = DropDownList1.Text;
        string ss = DropDownList2.Text;
        string Fr = Request.Form["cc_from"];
        string To = Request.Form["cc_to"];
        List<string[]> stafflist = new List<string[]>();
        if (stn_code!=""&&ft!=""&&ss!=""&&Fr!=""&&To!="")
        {
            string sNa = ss.Split('(')[0];
            string sN = ss.Split('(')[1].Split(')')[0];

            if (stn_name == "")
                stn_name = "Null";

            if (sN == "00000000")//ALL CREW
            {
                stafflist = getstafflist("CREW");

                foreach (string[] staff in stafflist)
                {
                    insertsc(stn_code, stn_name, ft, staff[0], staff[1], Fr, To);
                }
            }
            else if (sN == "00000001")//ALL FO
            {
                stafflist = getstafflist("FO");
                foreach (string[] staff in stafflist)
                {
                    insertsc(stn_code, stn_name, ft, staff[0], staff[1], Fr, To);
                }
            }
            else if (sN == "00000002")//ALL CPT
            {
                stafflist = getstafflist("CPT");
                foreach (string[] staff in stafflist)
                {
                    insertsc(stn_code, stn_name, ft, staff[0], staff[1], Fr, To);
                }
            }
            else if (sN == "00000003")//ALL INSTRUCTOR
            {
                stafflist = getstafflist("INSTRUCTOR");
                foreach (string[] staff in stafflist)
                {
                    insertsc(stn_code, stn_name, ft, staff[0], staff[1], Fr, To);
                }
            }
            else
            {


                insertsc(stn_code, stn_name, ft, sN, sNa, Fr, To);


            }
          

        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please insert the information');</script>");
        }
    }
}