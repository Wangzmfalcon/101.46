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

            this.DropDownList1.Items.Add(item);//添加到DropDownList1  
            this.DropDownList1.Items.Add(item0);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item1);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item2);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item3);//添加到DropDownList1  

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx"); 
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gvw = (GridView)sender;
        GridView1.PageIndex = e.NewPageIndex;

        //if (e.NewPageIndex < 0) 
        //{ TextBox pageNum = (TextBox)gvw.BottomPagerRow.FindControl("tbPage"); 
        //    int Pa = int.Parse(pageNum.Text); 
        //    if (Pa <= 0)
        //        gvw.PageIndex = 0; 
        //    else                   
        //        gvw.PageIndex = Pa - 1; } 
        //else { gvw.PageIndex = e.NewPageIndex; }
        getSQLandparm(Convert.ToInt32(Session["CI_flag"].ToString()));

       
    }
    protected void GridView1DataBind(string SQL_query,SqlParameter[] parm)
    { 
        DataTable dt = new DataTable();
        dt.Columns.Add("StaffNo", typeof(string));
        dt.Columns.Add("StaffName", typeof(string));
        dt.Columns.Add("TiTle", typeof(string));
         using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query, parm))
        {
            while (rdr.Read())
            {
                DataRow row = dt.NewRow();
                row["StaffNo"] = Convert.ToString(rdr.GetSqlValue(0));
                row["StaffName"] = Convert.ToString(rdr.GetSqlValue(1));
                row["TiTle"] = Convert.ToString(rdr.GetSqlValue(2));
                dt.Rows.Add(row);
            }
           
        }
         GridView1.DataSource = dt;//绑定数据显示 
         GridView1.DataKeyNames = new String[] { "StaffNo" };
         GridView1.DataBind();
         for (int j = GridView1.PageIndex * GridView1.PageSize, i = 0; i < GridView1.PageSize && j < dt.Rows.Count; i++, j++)
         {
             GridView1.Rows[i].Cells[0].Text = dt.Rows[j]["StaffNo"].ToString();
             GridView1.Rows[i].Cells[1].Text = dt.Rows[j]["StaffName"].ToString();
             GridView1.Rows[i].Cells[2].Text = dt.Rows[j]["TiTle"].ToString();
         }
         Panel1.Visible = true;
         Panel2.Visible = false;
         Panel3.Visible = false;

    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        getSQLandparm(Convert.ToInt32(Session["CI_flag"].ToString()));
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string id = GridView1.Rows[e.RowIndex].Cells[0].Text.ToString();
        string id1 = GridView1.Rows[e.RowIndex].Cells[1].Text.ToString();
        string id2 = GridView1.Rows[e.RowIndex].Cells[2].Text.ToString();
        string sN =((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
        string sNa = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string Ti = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text; ;
        if (sN != "" && sNa != "" && Ti != "")
        {
            if (Ti.ToUpper() == "CREW" || Ti.ToUpper() == "INSTRUCTOR" || Ti.ToUpper() == "CPT" || Ti.ToUpper() == "FO")
            {
                string SQL_update = "update Crew_Info  "
                    + "set Crew_Info.Staff_No = @sN , Crew_Info.Staff_Name = @sNa ,Crew_Info.Title =@Ti"
                    + " where Staff_No =@id and Staff_Name=@id1  and Title =@id2 ";
                SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@sNa", SqlDbType.VarChar, 100),
                new SqlParameter("@Ti", SqlDbType.VarChar, 50),
                new SqlParameter("@id", SqlDbType.VarChar, 10),
                new SqlParameter("@id1", SqlDbType.VarChar, 100),
                new SqlParameter("@id2", SqlDbType.VarChar, 50)
                 };
                parm[0].Value = sN;
                parm[1].Value = sNa;
                parm[2].Value = Ti;
                parm[3].Value = id;
                parm[4].Value = id1;
                parm[5].Value = id2;
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update,parm);
                }
               
                //log
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
                parmlog[1].Value = id+ "/" +id1 + "/" + id2;
                parmlog[2].Value = sN + "/" + sNa + "/" + Ti;
                parmlog[3].Value = "UPDATE";
                parmlog[4].Value = Session["User_ID"].ToString();

                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Log, parmlog);
                }


            }
            else
            { Response.Write("<script>alert('Title should be CREW/INSTRUCTOR/CPT/FO')</script>"); }

            getSQLandparm(Convert.ToInt32(Session["CI_flag"].ToString()));
        }

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        getSQLandparm(Convert.ToInt32(Session["CI_flag"].ToString()));
    }


    protected void GridView1_RowDelete(object sender, GridViewDeleteEventArgs e)
    {
        Label2.Text = GridView1.Rows[e.RowIndex].Cells[0].Text;
        Label3.Text = GridView1.Rows[e.RowIndex].Cells[1].Text;
        Label4.Text = GridView1.Rows[e.RowIndex].Cells[2].Text;
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
       
        //Response.Write("<script>alert('" + e.RowIndex + "')</script>");
    }
    protected void getSQLandparm(int flag)
    {
        string sN = Session["CI_StaffNo"].ToString();
        string sNa = Session["CI_StaffName"].ToString();
        string Ti = Session["CI_Title"].ToString();
        SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@sNa", SqlDbType.VarChar, 100),
                new SqlParameter("@Ti", SqlDbType.VarChar, 50)
                 };
        parm[0].Value = sN;
        parm[1].Value = sNa;
        parm[2].Value = Ti;

        switch (flag)
        {
            case 0:
                string SQL_query0 = "select * from Crew_Info "
                    + "where Crew_Info.Staff_No =@sN and Crew_Info.Staff_Name =@sNa and Crew_Info.Title =@Ti and Crew_Info. Rcd_Status = 'NEW'"
                    + "order by Crew_Info.Staff_No";
            
                GridView1DataBind(SQL_query0, parm);
                break;
            case 1:
                 string SQL_query1 = "select * from Crew_Info "
                    + "where Crew_Info.Staff_No =@sN and Crew_Info.Staff_Name =@sNa and Crew_Info. Rcd_Status = 'NEW'"
                    + "order by Crew_Info.Staff_No";
            
                GridView1DataBind(SQL_query1, parm);
                break;
            case 2:
                  string SQL_query2 = "select * from Crew_Info "
                    + "where Crew_Info.Staff_No =@sN and Crew_Info.Title =@Ti and Crew_Info. Rcd_Status = 'NEW'"
                    + "order by Crew_Info.Staff_No";
            
                GridView1DataBind(SQL_query2, parm);
                break;
            case 3:
                string SQL_query3 = "select * from Crew_Info "
                    + "where Crew_Info.Staff_No =@sN  and Crew_Info. Rcd_Status = 'NEW'"
                    + "order by Crew_Info.Staff_No";
            
                GridView1DataBind(SQL_query3, parm);
                break;
            case 4:
                string SQL_query4 = "select * from Crew_Info "
                    + "where Crew_Info.Staff_Name =@sNa and Crew_Info.Title =@Ti and Crew_Info. Rcd_Status = 'NEW'"
                    + "order by Crew_Info.Staff_No";
            
            
                GridView1DataBind(SQL_query4, parm);
                break;
            case 5:
                string SQL_query5 = "select * from Crew_Info "
                    + "where  Crew_Info.Staff_Name =@sNa and Crew_Info. Rcd_Status = 'NEW'"
                    + "order by Crew_Info.Staff_No";
            
                GridView1DataBind(SQL_query5, parm);
                break;
            case 6:
                string SQL_query6 = "select * from Crew_Info "
                    + "where  Crew_Info.Title =@Ti and Crew_Info. Rcd_Status = 'NEW'"
                    + "order by Crew_Info.Staff_No";
             
                GridView1DataBind(SQL_query6, parm);

                break;
            case 7:
                string SQL_query7 = "select * from Crew_Info "
                    + "where  Crew_Info. Rcd_Status = 'NEW'"
                    + "order by Crew_Info.Staff_No";
          
                GridView1DataBind(SQL_query7, parm);

                break;
                
        }
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int flag=0;
        Session["CI_StaffNo"] = StaffNo.Text;
        Session["CI_StaffName"] = StaffName.Text;
        Session["CI_Title"] = Title.Text;
        if (StaffNo.Text == "" )
        {
            flag = flag + 4;
        }
        if (StaffName.Text == "")
        {
            flag = flag + 2;
        }
        if (Title.Text == "")
        {
            flag = flag + 1;
        }
        //Response.Write("<script>alert('"+flag+"')</script>");
        Session["CI_flag"] = flag;
        string flag1 = Session["CI_flag"].ToString();
        getSQLandparm(flag);
       
        

    }
    
    protected void DeleteCrewInfo_Click(object sender, EventArgs e)
    {
        string SQL_Del = "UPDATE Crew_Info "
                    + " SET Crew_Info.Rcd_Status ='DEL'"                
                    +" where Crew_Info.Staff_No =@sN and Crew_Info.Staff_Name =@sNa and Crew_Info.Title =@Ti";
        SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@sNa", SqlDbType.VarChar, 100),
                new SqlParameter("@Ti", SqlDbType.VarChar, 50)
                 };
        parm[0].Value = Label2.Text;
        parm[1].Value = Label3.Text;
        parm[2].Value = Label4.Text;
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Del, parm);
        }
        getSQLandparm(Convert.ToInt32(Session["CI_flag"].ToString()));
        //写日志
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
        parmlog[0].Value = Label2.Text;
        parmlog[1].Value = Label2.Text.Trim() + "/" + Label3.Text.Trim() + "/" + Label4.Text.Trim();
        parmlog[2].Value = "";
        parmlog[3].Value = "DEL";
        parmlog[4].Value = Session["User_ID"].ToString();

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Log, parmlog);
        }

        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;

        
    }
    protected void CancelCrewInfo_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
    }

   
    protected void Button2_Click1(object sender, EventArgs e)
    {
       

        TextBox1.Text = StaffNo.Text;
        TextBox2.Text = StaffName.Text;
        DropDownList1.Text = Title.Text;
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
    }
    protected void insert_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "" && DropDownList1.Text != "")
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
            parm[0].Value = TextBox1.Text;
            parm[1].Value = TextBox2.Text;
            parm[2].Value = DropDownList1.Text;
            parm[3].Value = "NEW";
            parm[4].Value = Session["User_ID"].ToString();


            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Insert, parm);
            }
            Response.Write("<script>alert('The operation was successful')</script>");
        }
        else
        {
            Response.Write("<script>alert('Please insert the information')</script>");
        }

        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
        
    }
    protected void Edit_Click(object sender, EventArgs e)
    {

    }
}