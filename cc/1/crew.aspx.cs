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
    //分页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }

    //更新
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        //string id = GridView1.Rows[e.RowIndex].Cells[0].Text.ToString();
        string id1 = GridView1.Rows[e.RowIndex].Cells[1].Text.ToString();
        string id2 = GridView1.Rows[e.RowIndex].Cells[2].Text.ToString();
       string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string sN = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
        string sNa = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        string Ti = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedItem.Text;
        if (sN != "" && sNa != "" && Ti != "")
        {
            if (Ti.ToUpper() == "CREW" || Ti.ToUpper() == "INSTRUCTOR" || Ti.ToUpper() == "CPT" || Ti.ToUpper() == "FO")
            {
                string SQL_update = "update Crew_Info  "
                    + "set Crew_Info.Staff_No = @sN , Crew_Info.Staff_Name = @sNa ,Crew_Info.Title =@Ti"
                    + " where Staff_No =@id ";
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
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_update, parm);
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
                parmlog[1].Value = id + "/" + id1 + "/" + id2;
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
        }
        else
        Response.Write("<script>alert('Please fill in all the information')</script>");
            GridView1.EditIndex = -1;
            Bind();
    }
    //删除
    protected void GridView1_RowDeleting(string keyword)
    {
        
       
        //日志
        string SQL_Log = "INSERT INTO Crew_Check_Log"
            + " (Staff_No,Details_Origin,Details_After_Action,Actions,Rcd_By)"
            + " VALUES(@sN,@DO,@DA,@AC,@RB)";

        string find = " select * from Crew_Info "
                   + " where Crew_Info. Rcd_Status = 'NEW' and Crew_Info.Staff_No = '" + keyword + "'";

        SqlParameter[] parmlog = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@DO", SqlDbType.VarChar, 200),
                new SqlParameter("@DA", SqlDbType.VarChar, 200),
                new SqlParameter("@AC", SqlDbType.VarChar, 50),
                new SqlParameter("@RB", SqlDbType.VarChar, 50)
                 };

    


        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, find))
        {
            if (rdr.Read())
            {
                parmlog[0].Value = rdr[0].ToString();
                parmlog[1].Value = rdr[0].ToString() + "/" + rdr[1].ToString() + "/" + rdr[2].ToString();
                parmlog[2].Value = "";
                parmlog[3].Value = "DEL";
                parmlog[4].Value = Session["User_ID"].ToString();

            }

        }


        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Log, parmlog);
        }

      //删除
        string SQL_Del = "UPDATE Crew_Info "
                    + " SET Crew_Info.Rcd_Status ='DEL'"
                    + " where Crew_Info.Staff_No = '" + keyword+ "'";
        
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Del);
        }
      
   
     
        

       



     

    

    }
    //取消更新
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }
    //数据绑定
    protected void  GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     
        


         if (((DropDownList)e.Row.FindControl("DropDownList1")) != null)     
         {  
             DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("DropDownList1");     
             DropDownList1.Items.Clear();
             DropDownList1.Items.Add(new ListItem("CREW", "1"));
             DropDownList1.Items.Add(new ListItem("INSTRUCTOR", "2"));
             DropDownList1.Items.Add(new ListItem("CPT", "3"));
             DropDownList1.Items.Add(new ListItem("FO", "4"));
         }
        
     
    
        
    }
    //主页
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }

    //查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        Session["CI_StaffNo"] = StaffNo.Text;
        Session["CI_StaffName"] = StaffName.Text;
        Session["CI_Title"] = Title.Text;
        Bind();
        Button3.Visible = true;
    }

    //编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex; //使GridView控件的第e.NewEditIndex行处于可编辑状态
        Bind();
    }

    //绑定数据库
    protected void Bind()
    {
        string cs = "";
        string csa = "";
        string cti = "";
        if (Session["CI_StaffNo"] != "")
        {
            cs = " and Crew_Info.Staff_No =@sN";
        }
        if (Session["CI_StaffName"] != "")
        {
            csa = " and Crew_Info.Staff_Name =@sNa";
        }
        if (Session["CI_Title"] != "")
        {
            cti = " and Crew_Info.Title =@Ti";
        }
        string SQL_query = " select * from Crew_Info "
                    + " where Crew_Info. Rcd_Status = 'NEW'"+cs+csa+cti
                    + " order by Crew_Info.Staff_No";
            
        SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@sNa", SqlDbType.VarChar, 100),
                new SqlParameter("@Ti", SqlDbType.VarChar, 50)
                 };
        parm[0].Value = Session["CI_StaffNo"].ToString();
        parm[1].Value = Session["CI_StaffName"].ToString();
        parm[2].Value = Session["CI_Title"].ToString();
        DataTable dt = new DataTable();
        dt.Columns.Add("StaffNo", typeof(string));
        dt.Columns.Add("StaffName", typeof(string));
        dt.Columns.Add("TiTle", typeof(string));
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query,parm))
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
    
    
    }

    //插入
    protected void Button2_Click1(object sender, EventArgs e)
    {

        Response.Redirect("InsertCrewInfo.aspx");
    }

    //删除
    protected void Button3_Click(object sender, EventArgs e)
    {
        int a = GridView1.Rows.Count;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox check = (CheckBox)GridView1.Rows[i].FindControl("deleteRec");

            if (check.Checked)
            {

                
                GridView1_RowDeleting(GridView1.DataKeys[i].Value.ToString());

            }

        }
        Bind();
    }
}