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

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = "Total: 0 items";
        if (Session["User_ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
            Label1.Text = "Welcome " + Session["User_Name"].ToString();

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string dlday = Request.Form["dlday"];
        string sN = TextBox1.Text;
        string prt = TextBox3.Text;
        if (sN != "" && dlday != "")
        {
            string SQL_Insert = "INSERT INTO DLR_TEST"
                  + " (Staff_No,Time,ProTime)"
                           + " VALUES(@sn,@ti,@pt)";

            SqlParameter[] parm = new SqlParameter[]{
                    new SqlParameter("@sn", SqlDbType.VarChar, 10),
                    new SqlParameter("@ti", SqlDbType.Date),
                    new SqlParameter("@pt", SqlDbType.Int)

             };
            parm[0].Value = sN.Trim();
            parm[1].Value = Convert.ToDateTime(dlday).ToShortDateString();
             if (prt == "")
             {
                 parm[2].Value = 10;
             
             }
             else
             {
                 parm[2].Value = Convert.ToInt32(prt.Trim());
             }
             
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Insert,parm);
            }
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('添加成功');</script>");
        }
        else
        {
          ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('请输入相关信息');</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["AStaffNo"] = TextBox2.Text;
        Session["Deadline"] = Request.Form["dlday2"];
        Session["ADAYS"] = TextBox4.Text;
        Bind();
        
        Button3.Visible = true;
    }

    protected void Bind()
    {

        string asf = Session["AStaffNo"].ToString();
        string adl = Session["Deadline"].ToString();
        string ads = Session["ADAYS"].ToString();


        string SQL_query = " select * from DLR_TEST ";
                  

        //SqlParameter[] parm = new SqlParameter[]{
        //        new SqlParameter("@sN", SqlDbType.Int),
        //        new SqlParameter("@sNa", SqlDbType.VarChar, 10),
        //        new SqlParameter("@Ti", SqlDbType.Date),
        //        new SqlParameter("@Ti", SqlDbType.Int),
        //        new SqlParameter("@Ti", SqlDbType.Int)
        //         };

        //parm[0].Value = "%" + Session["CI_StaffNo"].ToString() + "%";
        //parm[1].Value = "%" + Session["CI_StaffName"].ToString() + "%";
        //parm[2].Value = Session["CI_Title"].ToString();
        DataTable dt = new DataTable();
        dt.Columns.Add("TID", typeof(string));
        dt.Columns.Add("Staff_No", typeof(string));
        dt.Columns.Add("Time", typeof(string));
        dt.Columns.Add("ProTime", typeof(string));
        dt.Columns.Add("Status", typeof(string));
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {

            while (rdr.Read())
            {

                DataRow row = dt.NewRow();
                row["TID"] = Convert.ToString(rdr.GetSqlValue(0));
                row["Staff_No"] = Convert.ToString(rdr.GetSqlValue(1));
                row["Time"] = Convert.ToString(rdr.GetSqlValue(2));
                row["ProTime"] = Convert.ToString(rdr.GetSqlValue(3));
                row["Status"] = Convert.ToString(rdr.GetSqlValue(4));
                dt.Rows.Add(row);
            }
        }
        Label4.Text = "Total: " + dt.Rows.Count + " items";
       
        GridView1.DataSource = dt;//绑定数据显示 
       // GridView1.Rows[5].Visible = false;
     
        GridView1.DataKeyNames = new String[] {"TID"};
        GridView1.DataBind();
        //for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        //{

        //    GridViewRow row = GridView1.Rows[i];
        //    string keyword = GridView1.DataKeys[i].Values[0].ToString();
        //    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + keyword + "');</script>");
        //    //if (GridView1.Rows[i].Cells[2].ToString() == "0")
        //    //{
        //    //    GridView1.Rows[i].Cells[6].Visible = false;
        //    //}
        //}
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    //分页

    //数据绑定
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        
        
        if (((Button)e.Row.FindControl("LinkButton1")) != null)
        {

            if (e.Row.Cells[3].ToString() == "0")
            {
                Button LinkButton1 = (Button)e.Row.FindControl("LinkButton1");
                LinkButton1.Visible = false;
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }

        //取消更新
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex; //使GridView控件的第e.NewEditIndex行处于可编辑状态
        Bind();
    }
      //更新
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string keyword = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + keyword + "');</script>");
    }

    //确认
     protected void GridView1_Deleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string keyword = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + keyword + "');</script>");
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyCommand")
        {
            
            Button button = (Button)e.CommandSource;
            GridViewRow row = (GridViewRow)button.Parent.Parent;
            int ii = row.RowIndex;
            GridViewRow row1 = GridView1.Rows[ii];
            //string id = row1.Cells[0].Text.ToString();
            string keyword = GridView1.DataKeys[ii].Values[0].ToString();
          
            //string a = row.Cells[0].Text.ToString();//获得第一个单元格的值   
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + keyword + "');</script>");
            
            GridView1.EditIndex = -1;
            Bind();
        }
    }

    protected void do2_Click1(object sender, EventArgs e)
    {
        string Tempstr = ((Button)sender).CommandArgument.ToString();
        //Response.Write("<script>alert('"+Tempstr+"');</script>");
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + Tempstr + "');</script>");
        //这里我让Panel显示出来，并把相应的ID给label。知道了ID你就可惟做很多事了
        

    }




}