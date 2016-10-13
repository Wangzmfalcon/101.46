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

public partial class crew : System.Web.UI.Page
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

            ListItem item = new ListItem("");//"13"为item3项的关联值  
            ListItem item0 = new ListItem("CREW");//"13"为item3项的关联值  
            ListItem item1 = new ListItem("INSTRUCTOR");//"11"为item1项的关联值  
            ListItem item2 = new ListItem("CPT");//"13"为item3项的关联值  
            ListItem item3 = new ListItem("FO");//"12"为item2项的关联值 



            this.Title.Items.Add(item);//添加到DropDownList1  
            this.Title.Items.Add(item0);//添加到DropDownList1   
            this.Title.Items.Add(item1);//添加到DropDownList1   
            this.Title.Items.Add(item2);//添加到DropDownList1   
            this.Title.Items.Add(item3);//添加到DropDownList1   


        }
    }

  


    //主页
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }

    

    //插入
    protected void Button2_Click1(object sender, EventArgs e)
    {
        string sN = StaffNo.Text;
        string sNa = StaffName.Text;
        string Ti = Title.Text;
        if(sN!=""&&sNa!=""&&Ti!="")
        {
            string SQL_Insert = "INSERT INTO Crew_Info"
               + " (Staff_No,Staff_Name,Title,Rcd_Status,Rcd_By)"
               + " VALUES(@sN,@sNa,@Ti,@RS,@RB)";
            SqlParameter[] parm = new SqlParameter[]{
                    new SqlParameter("@sN", SqlDbType.VarChar, 10),
                    new SqlParameter("@sNa", SqlDbType.VarChar, 100),
                    new SqlParameter("@Ti", SqlDbType.VarChar, 50),
                    new SqlParameter("@RS", SqlDbType.VarChar, 10),
                    new SqlParameter("@RB", SqlDbType.VarChar, 50)
                     };
            parm[0].Value = sN;
            parm[1].Value = sNa;
            parm[2].Value = Ti;
            parm[3].Value = "NEW";
            parm[4].Value = Session["User_ID"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Insert, parm);
                }
                Response.Write("<script>alert('The operation was successful')</script>");
               

                //LOG

                    string SQL_Log = "INSERT INTO Crew_Check_Log"
                + " (Staff_No,Details_Origin,Details_After_Action,Actions,Rcd_By)"
                + " VALUES(@sN,@DO,@DA,@AC,@RB)";


                SqlParameter[] parmlog = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@DO", SqlDbType.VarChar, 200),
                new SqlParameter("@DA", SqlDbType.VarChar, 200),
                new SqlParameter("@AC", SqlDbType.VarChar, 50),
                new SqlParameter("@RB", SqlDbType.VarChar, 50)
                 };
                parmlog[0].Value = sN;
                parmlog[1].Value = "";
                parmlog[2].Value = sN+"/"+sNa+"/"+Ti;
                parmlog[3].Value = "CREATE";
                parmlog[4].Value = Session["User_ID"].ToString();

                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Log, parmlog);
                }


                //Response.Redirect("Home.aspx");
                Response.Write("<script language='javascript'>window.location='Home.aspx'</script>");

            }
            catch 
            {
                Response.Write("<script>alert('Record already exists')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Please insert the information')</script>");
        }
    
    }

   
}