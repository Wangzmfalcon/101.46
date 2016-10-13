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

public partial class crewcheck : System.Web.UI.Page
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
            ListItem item1 = new ListItem("STATION");//"11"为item1项的关联值  
            ListItem item2 = new ListItem("CARRIER");//"13"为item3项的关联值  
        
            this.DropDownList1.Items.Add(item);//添加到DropDownList1  
            this.DropDownList1.Items.Add(item0);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item1);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item2);//添加到DropDownList1   
           

            ListItem ex_item = new ListItem("NONE");//"13"为item3项的关联值  
            ListItem ex_item0 = new ListItem("INSTRUCTOR");//"13"为item3项的关联值  
            this.DropDownList3.Items.Add(ex_item);//添加到DropDownList1  
            this.DropDownList3.Items.Add(ex_item0);



            string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info "
                  + " order by Crew_Info.Staff_No";


            DataTable dt = new DataTable();
            dt.Columns.Add("StaffNo(StaffName)", typeof(string));
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Staff))
            {
                while (rdr.Read())
                {
                    DataRow row = dt.NewRow();
                    row["StaffNo(StaffName)"] = Convert.ToString(rdr.GetSqlValue(0)) + "(" + Convert.ToString(rdr.GetSqlValue(1)) + ")";


                    dt.Rows.Add(row);
                }

            }
            this.DropDownList4.Items.Add("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DropDownList4.Items.Add(new ListItem(dt.Rows[i]["StaffNo(StaffName)"].ToString()));
            }
           }

    }

 
  
   //活动下拉框
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string D1text = DropDownList1.SelectedValue;

        switch (D1text)
        {
            case "CREW":
                this.DropDownList2.Items.Clear();
                string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info "
                    + " order by Crew_Info.Staff_No";
                
                
                DataTable dt = new DataTable();
                dt.Columns.Add("StaffNo(StaffName)", typeof(string));               
                using(SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Staff))
                {
                    while (rdr.Read())
                    {
                        DataRow row = dt.NewRow();
                        row["StaffNo(StaffName)"] = Convert.ToString(rdr.GetSqlValue(0)) + "(" + Convert.ToString(rdr.GetSqlValue(1))+")";
                        
                        
                        dt.Rows.Add(row);
                    }

                }
                this.DropDownList2.DataSource = dt;
                this.DropDownList2.DataValueField = dt.Columns[0].ColumnName;
                this.DropDownList2.DataBind();
                
                break;
            case "STATION":
                this.DropDownList2.Items.Clear();
                ListItem item = new ListItem("PEK");//"13"为item3项的关联值  
                ListItem item0 = new ListItem("NRT");//"13"为item3项的关联值  
                ListItem item1 = new ListItem("NKG");//"11"为item1项的关联值  
                this.DropDownList2.Items.Add(item);//添加到DropDownList1  
                this.DropDownList2.Items.Add(item0);//添加到DropDownList1   
                this.DropDownList2.Items.Add(item1);//添加到DropDownList1  
                break;
            case "CARRIER":
                this.DropDownList2.Items.Clear();
                ListItem item2 = new ListItem("CA");//"13"为item3项的关联值  
                ListItem item20 = new ListItem("NX");//"13"为item3项的关联值  
                ListItem item21 = new ListItem("NXCA");//"11"为item1项的关联值  
                this.DropDownList2.Items.Add(item2);//添加到DropDownList1  
                this.DropDownList2.Items.Add(item20);//添加到DropDownList1   
                this.DropDownList2.Items.Add(item21);//添加到DropDownList1  
                break;
            default:
                this.DropDownList2.Items.Clear();
                break;
        }

    }
    //
  
   
    //主页
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }










    protected void Button2_Click(object sender, EventArgs e)
    {
        string[] ssa = DropDownList4.Text.Split('(');
        string sN = ssa[0];
        string Ty = DropDownList1.Text;
        string[] ss = DropDownList2.Text.Split('(');
        string Ob = ss[0];
        string Fr = Request.Form["cc_from"];
        string To = Request.Form["cc_to"];
        string Ex = DropDownList3.Text;
        string Re=TextBox1.Text;

        if(sN!=""&&Ty!=""&&Ob!=""&&Fr!=""&&To!="")
        {

        //插入

            string SQL_Insert = "INSERT INTO Crew_Check"
                           + " (Staff_No,No_Type,No_Object,No_From,No_To,Except_For,Remark,Rcd_Status,Rcd_By)"
                           + " VALUES(@sN,@Ty,@Ob,@Fr,@To,@Ex,@Re,@Rs,@Rb)";
            SqlParameter[] parm = new SqlParameter[]{
                    new SqlParameter("@sN", SqlDbType.VarChar, 10),
                    new SqlParameter("@Ty", SqlDbType.VarChar, 20),
                    new SqlParameter("@Ob", SqlDbType.VarChar, 50),
                    new SqlParameter("@Fr", SqlDbType.Date),
                    new SqlParameter("@To", SqlDbType.Date),
                    new SqlParameter("@Ex", SqlDbType.VarChar, 50),
                     new SqlParameter("@Re", SqlDbType.VarChar, 50),
                    new SqlParameter("@Rs", SqlDbType.VarChar, 10),                    
                    new SqlParameter("@Rb", SqlDbType.VarChar, 50)
                     };
            parm[0].Value = sN;
            parm[1].Value = Ty;
            parm[2].Value = Ob;
            parm[3].Value = Convert.ToDateTime(Fr);
            parm[4].Value = Convert.ToDateTime(To);
            parm[5].Value = Ex;
            parm[6].Value = Re;          
            parm[7].Value = "NEW";
            parm[8].Value = Session["User_ID"].ToString();

       
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
                parmlog[2].Value = sN + "/" + Ty + "/" + Ob+ "/" +Fr+ "/" +To+ "/" +Ex+ "/" +Re;
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
            Response.Write("<script>alert('Please insert the information')</script>");
    }
}