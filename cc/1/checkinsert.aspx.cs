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
            this.DropDownList4.Items.Add(item);//添加到DropDownList1  
            this.DropDownList4.Items.Add(item0);//添加到DropDownList1   
            this.DropDownList4.Items.Add(item1);//添加到DropDownList1   
            this.DropDownList4.Items.Add(item2);//添加到DropDownList1   



            ListItem ex_item = new ListItem("NONE");//"13"为item3项的关联值  
            ListItem ex_item0 = new ListItem("INSTRUCTOR");//"13"为item3项的关联值  
            this.DropDownList3.Items.Add(ex_item);//添加到DropDownList1  
            this.DropDownList3.Items.Add(ex_item0);
            this.DropDownList6.Items.Add(ex_item);//添加到DropDownList1  
            this.DropDownList6.Items.Add(ex_item0);//添加到DropDownList1  

           }

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        getQuert();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        getQuert();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        string D4text = DropDownList4.SelectedValue;

        switch (D4text)
        {
            case "CREW":
                this.DropDownList5.Items.Clear();
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
                this.DropDownList5.DataSource = dt;
                this.DropDownList5.DataValueField = dt.Columns[0].ColumnName;
                this.DropDownList5.DataBind();

                break;
            case "STATION":
                this.DropDownList5.Items.Clear();
                ListItem item = new ListItem("PEK");//"13"为item3项的关联值  
                ListItem item0 = new ListItem("NRT");//"13"为item3项的关联值  
                ListItem item1 = new ListItem("NKG");//"11"为item1项的关联值  
                this.DropDownList5.Items.Add(item);//添加到DropDownList1  
                this.DropDownList5.Items.Add(item0);//添加到DropDownList1   
                this.DropDownList5.Items.Add(item1);//添加到DropDownList1  
                break;
            case "CARRIER":
                this.DropDownList5.Items.Clear();
                ListItem item2 = new ListItem("CA");//"13"为item3项的关联值  
                ListItem item20 = new ListItem("NX");//"13"为item3项的关联值  
                ListItem item21 = new ListItem("NXCA");//"11"为item1项的关联值  
                this.DropDownList5.Items.Add(item2);//添加到DropDownList1  
                this.DropDownList5.Items.Add(item20);//添加到DropDownList1   
                this.DropDownList5.Items.Add(item21);//添加到DropDownList1  
                break;
            default:
                this.DropDownList5.Items.Clear();
                break;
        }

    }

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
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        Session["CC_StaffNo"] = TextBox1.Text;
        Session["CC_Type"] = DropDownList1.Text;
        
        string[] ss = DropDownList2.Text.Split('(');
        Session["CC_Object"] = ss[0];
        Session["CC_Date"] = Request.Form["cc_date"];
        Session["CC_Except"] = DropDownList3.Text;
    
        getQuert();
    }



    protected void GridView1_RowDelete(object sender, GridViewDeleteEventArgs e)
    {
        Label2.Text = GridView1.Rows[e.RowIndex].Cells[0].Text;
        Label3.Text = GridView1.Rows[e.RowIndex].Cells[1].Text;
        Label4.Text = GridView1.Rows[e.RowIndex].Cells[2].Text;
        Label5.Text = GridView1.Rows[e.RowIndex].Cells[3].Text;
        Label6.Text = GridView1.Rows[e.RowIndex].Cells[4].Text;
        Label7.Text = GridView1.Rows[e.RowIndex].Cells[5].Text;
        Label8.Text = GridView1.Rows[e.RowIndex].Cells[6].Text;
      
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;

        //Response.Write("<script>alert('" + e.RowIndex + "')</script>");
    }
    protected void getQuert()
    {
        string CC_S = Session["CC_StaffNo"].ToString();
        string CC_T = Session["CC_Type"].ToString();
        string CC_O = Session["CC_Object"].ToString();
        string CC_D = Session["CC_Date"].ToString();
        string CC_E = Session["CC_Except"].ToString();

        string ccs = "";
        string cct = "";
        string cco = "";
        string ccd = "";
        string cce = "";

        if (CC_S != "")
        {
            ccs = " and Staff_No = @ccs";
        }
        if (CC_T != "")
        {
            cct = " and No_Type = @cct";
        }
        if (CC_O != "")
        {
            cco = " and No_Object = @cco";
        }
        if (CC_D != "")
        {
            ccd = " and No_From <= @ccd and No_To >=@ccd ";
        }
        else
            CC_D = DateTime.Now.ToString();
        if (CC_E != "")
        {
            cce = " and Except_For = @cce";
        }

        string SQL_Query = "select * from Crew_Check"
            + " where Rcd_Status='NEW' " + ccs + cct + cco + ccd + cce
            + " order by No_From";
        SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@ccs", SqlDbType.VarChar, 10),
                new SqlParameter("@cct", SqlDbType.VarChar, 20),
                new SqlParameter("@cco", SqlDbType.VarChar, 50),
                new SqlParameter("@ccd", SqlDbType.Date),
                new SqlParameter("@cce", SqlDbType.VarChar, 50),
                 };
        parm[0].Value = CC_S;
        parm[1].Value = CC_T;
        parm[2].Value = CC_O;
        parm[3].Value = Convert.ToDateTime(CC_D);
        parm[4].Value = CC_E;
        GridView1DataBind(SQL_Query,parm);
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
        else { gvw.PageIndex = e.NewPageIndex; }
        getQuert();


    }
    protected void GridView1DataBind(string SQL_query, SqlParameter[] parm)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("StaffNo", typeof(string));
        dt.Columns.Add("No_Type", typeof(string));
        dt.Columns.Add("No_Object", typeof(string));
        dt.Columns.Add("No_From", typeof(string));
        dt.Columns.Add("No_To", typeof(string));
        dt.Columns.Add("Except_For", typeof(string));
        dt.Columns.Add("Remark", typeof(string));
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query, parm))
        {
            while (rdr.Read())
            {
                DataRow row = dt.NewRow();
                row["StaffNo"] = Convert.ToString(rdr.GetSqlValue(0));
                row["No_Type"] = Convert.ToString(rdr.GetSqlValue(1));
                row["No_Object"] = Convert.ToString(rdr.GetSqlValue(2));
                row["No_From"] = Convert.ToString(rdr.GetDateTime(3).ToShortDateString());
                row["No_To"] = Convert.ToString(rdr.GetDateTime(4).ToShortDateString());
                row["Except_For"] = Convert.ToString(rdr.GetSqlValue(5));
                row["Remark"] = Convert.ToString(rdr.GetSqlValue(6));
                dt.Rows.Add(row);
            }

        }
        GridView1.DataSource = dt;//绑定数据显示        
        GridView1.DataBind();
        for (int j = GridView1.PageIndex * GridView1.PageSize, i = 0; i < GridView1.PageSize && j < dt.Rows.Count; i++, j++)
        {
            GridView1.Rows[i].Cells[0].Text = dt.Rows[j]["StaffNo"].ToString();
            GridView1.Rows[i].Cells[1].Text = dt.Rows[j]["No_Type"].ToString();
            GridView1.Rows[i].Cells[2].Text = dt.Rows[j]["No_Object"].ToString();
            GridView1.Rows[i].Cells[3].Text = dt.Rows[j]["No_From"].ToString();
            GridView1.Rows[i].Cells[4].Text = dt.Rows[j]["No_To"].ToString();
            GridView1.Rows[i].Cells[5].Text = dt.Rows[j]["Except_For"].ToString();
            GridView1.Rows[i].Cells[6].Text = dt.Rows[j]["Remark"].ToString();
        }
    
        //Panel1.Visible = true;
        //Panel2.Visible = false;
        //Panel3.Visible = false;

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string SQL_Del = "UPDATE Crew_Check "
                    + " SET Crew_Check.Rcd_Status ='DEL'"
                    + " where Crew_Check.Staff_No =@sN and Crew_Check.No_Type =@NT and Crew_Check.No_Object =@NO"
                    + " and  Crew_Check.No_From =@From and Crew_Check.No_To =@To and Crew_Check.Except_For =@EF";
        SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@NT", SqlDbType.VarChar, 20),
                new SqlParameter("@NO", SqlDbType.VarChar, 50),
                new SqlParameter("@From", SqlDbType.Date),
                new SqlParameter("@To", SqlDbType.Date),
                new SqlParameter("@EF", SqlDbType.VarChar, 50),
               
                 };
        parm[0].Value = Label2.Text;
        parm[1].Value = Label3.Text;
        parm[2].Value = Label4.Text;
        parm[3].Value = Convert.ToDateTime(Label5.Text).ToShortDateString();
        parm[4].Value = Convert.ToDateTime(Label6.Text).ToShortDateString();
        parm[5].Value = Label7.Text;
      

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Del, parm);
        }
        getQuert();
        //log

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
        parmlog[1].Value = Label2.Text.Trim() + "/" + Label3.Text.Trim() + "/" + Label4.Text.Trim() + "/" + Label5.Text.Trim() + "/" + Label6.Text.Trim() + "/" + Label7.Text.Trim();
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
    protected void insert_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;

    }
}