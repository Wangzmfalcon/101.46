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
        
        
        if (Session["User_ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
            Label1.Text = "Welcome " + Session["User_Name"].ToString();
        
            if(Session["AStaffNo"]==null)
                Session["AStaffNo"]="";
            if(Session["Deadline"]==null)
                Session["Deadline"]="";
            if(Session["ADAYS"]==null)
                Session["ADAYS"] = "";
            Bind();
            GridView1.Visible = false;
            Label4.Text = "Total: 0 items";
        
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
        
    }

    protected void Bind()
    {

        string asf = Session["AStaffNo"].ToString();
        string adl = Session["Deadline"].ToString();
        string ads = Session["ADAYS"].ToString();


        string SQL_query = " select * from DLR_TEST ";
      
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


         GridView1.Columns.Clear();
         if (dt == null)
         {
             GridView1.Visible = false;
         }
         else
         {
             
            // AddGridViewColumn(dt.Columns[0].ColumnName, 0, null, 15);//
             AddGridViewColumn(dt.Columns[1].ColumnName, 0, null, 20); //
             AddGridViewColumn(dt.Columns[2].ColumnName, 0, null, 20); //  
             AddGridViewColumn(dt.Columns[3].ColumnName, 0, null, 20); //  
             AddGridViewColumn(dt.Columns[4].ColumnName, 0, null, 20); //               
             AddGridViewColumn("修改", 2, "LinkButton1", 10);
             AddGridViewColumn("删除", 2, "LinkButton2", 10);
             AddGridViewColumn("确认", 4, "Button3", 10);
             
             GridView1.DataSource = dt;
             GridView1.DataBind();



             for (int j = GridView1.PageIndex * GridView1.PageSize, i = 0; i < GridView1.PageSize && j < dt.Rows.Count; i++, j++)
             {
                 //GridView1.Rows[i].Cells[0].Text = dt.Rows[j]["所属课程编号"].ToString();
                 GridView1.Rows[i].Cells[0].Text = dt.Rows[j]["Staff_No"].ToString();
                 GridView1.Rows[i].Cells[1].Text = dt.Rows[j]["Time"].ToString();
                 GridView1.Rows[i].Cells[2].Text = dt.Rows[j]["ProTime"].ToString();
                 GridView1.Rows[i].Cells[3].Text = getstatus(dt.Rows[j]["Status"].ToString());
                 //GridView1.Rows[i].Cells[5].Text = "第" + dt.Rows[j]["分组情况"].ToString() + "组";
                 //((HyperLink)GridView1.Rows[i].Cells[6].FindControl("HyperLink1")).Text = "录入";
                 //((HyperLink)GridView1.Rows[i].Cells[6].FindControl("HyperLink1")).NavigateUrl
                 //    = HTML_exper + "experId=" + dt.Rows[j]["实验编号"].ToString()
                 //    + "&courseId=" + dt.Rows[j]["所属课程编号"].ToString() + "&teamName=" + dt.Rows[j]["分组情况"].ToString();

                 ((LinkButton)GridView1.Rows[i].Cells[4].FindControl("LinkButton1")).Text = "修改";
                 ((LinkButton)GridView1.Rows[i].Cells[4].FindControl("LinkButton1")).CommandName = "upd";
                 ((LinkButton)GridView1.Rows[i].Cells[4].FindControl("LinkButton1")).OnClientClick = "return confirm('您确实要修改吗？')";

                 ((LinkButton)GridView1.Rows[i].Cells[5].FindControl("LinkButton2")).Text = "删除";
                 ((LinkButton)GridView1.Rows[i].Cells[5].FindControl("LinkButton2")).CommandName = "del";
                 ((LinkButton)GridView1.Rows[i].Cells[5].FindControl("LinkButton2")).OnClientClick = "return confirm('您确实要删除吗？删除后成绩将不能恢复！')";


                 ((Button)GridView1.Rows[i].Cells[6].FindControl("Button3")).Text = "确认";
                 ((Button)GridView1.Rows[i].Cells[6].FindControl("Button3")).CommandName = "conf";
                 ((Button)GridView1.Rows[i].Cells[6].FindControl("Button3")).OnClientClick = "return confirm('是否确认')";
                 if (dt.Rows[j]["Status"].ToString() != "1")
                 {
                     ((Button)GridView1.Rows[i].Cells[6].FindControl("Button3")).Enabled = false;

                 }
             }

             GridView1.Visible = true;
             Label4.Text = "Total: " + dt.Rows.Count + " items";

         }
      
    }


    //状态判断
    private string getstatus(string intt)
    { 
        string state="";
        switch (Convert.ToInt32(intt))
        {
            case 0:
                state = "提醒时间未到";
                break;
            case 1:
                state = "已经发送了提醒邮件";
                break;
            case 2:
                state = "已确认";
                break;
            case 3:
                state = "已过期";
                break;                
            case 4:
                state = "已过期";
                break;
        }
        return state;

    }

    private void AddGridViewColumn(string ColumnName, int type, string linkButtonName, int width)
    {
        GridViewTemplate temp = new GridViewTemplate(DataControlRowType.DataRow, ColumnName, type, linkButtonName);
        TemplateField field = new TemplateField();
        field.HeaderText = ColumnName;
        field.ItemTemplate = temp;
        field.ItemStyle.Width = Unit.Percentage(width);
        GridView1.Columns.Add(field);
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        GridView gvw = (GridView)sender;
        if (e.NewPageIndex < 0)
        {
            TextBox pageNum = (TextBox)gvw.BottomPagerRow.FindControl("tbPage");
            int Pa = int.Parse(pageNum.Text);
            if (Pa <= 0)
                gvw.PageIndex = 0;
            else
                gvw.PageIndex = Pa - 1;
        }
        else
        {
            gvw.PageIndex = e.NewPageIndex;
        }
        Bind();
    }




  
 
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "upd")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
          
        }
        if (e.CommandName == "del")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
         
        }
        if (e.CommandName == "conf")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
           
        }


        Bind();
    }






    #region 自定义GridView类
    public class GridViewTemplate : ITemplate
    {
        private DataControlRowType templateType;
        private string columnName;
        private int style;
        private string uName;
        public GridViewTemplate(DataControlRowType type, string colname, int str, string usercontrolName)
        {
            templateType = type;
            columnName = colname;
            style = str;
            uName = usercontrolName;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            if (templateType == DataControlRowType.DataRow)
            {
                switch (style)
                {
                    case 0:
                        LiteralControl label = new LiteralControl();
                        label.DataBinding += new EventHandler(tb_DataBinding);
                        container.Controls.Add(label);
                        break;
                    case 1:
                        HyperLink link = new HyperLink();
                        link.ID = uName;
                        container.Controls.Add(link);
                        break;
                    case 2:
                        LinkButton lbtn = new LinkButton();
                        lbtn.ID = uName;
                        container.Controls.Add(lbtn);
                        break;
                    case 3:
                        TextBox tb = new TextBox();
                        tb.ID = uName;
                        container.Controls.Add(tb);
                        break;

                    case 4:
                        Button bt = new Button();
                        bt.ID = uName;
                        container.Controls.Add(bt);                      
                        break;
                }

            }
        }
        private void tb_DataBinding(object sender, EventArgs e)
        {
            LiteralControl lb = (LiteralControl)sender;
            GridViewRow container = (GridViewRow)lb.NamingContainer;
            string str = ((DataRowView)container.DataItem)[columnName].ToString();
            lb.Text = "";
        }
    }
    #endregion


}

 
