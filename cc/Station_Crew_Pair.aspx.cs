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
public partial class Station_Crew_Pair : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label8.Text = "Total: 0 items";
        if (Session["User_ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
            Label1.Text = "Welcome " + Session["User_Name"].ToString();



        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>document.getElementById('formdate').value='" + DateTime.Now.ToShortDateString() + "';</script>");
        if (!Page.IsPostBack)
        {
            ListItem item = new ListItem("");//"13"为item3项的关联值  
            ListItem item0 = new ListItem("SCH");//"13"为item3项的关联值 
            ListItem item1 = new ListItem("CHA");//"13"为item3项的关联值 
            this.DropDownList1.Items.Add(item);//添加到DropDownList1  
            this.DropDownList1.Items.Add(item0);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item1);//添加到DropDownList1   


            string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info where Crew_Info.Rcd_Status ='NEW' "
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

            }
            //this.DropDownList2.Items.Add("");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //    DropDownList2.Items.Add(new ListItem(dt.Rows[i]["StaffName(StaffNo)"].ToString()));
            //}
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    protected void Delete_Click(object sender, EventArgs e)
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


    //删除
    protected void GridView1_RowDeleting(string keyword)
    {
        //日志

        string SQL_Log = "INSERT INTO Crew_Check_Log"
            + " (Staff_No,Details_Origin,Details_After_Action,Actions,Rcd_By,Edit_Table)"
            + " VALUES(@sN,@DO,@DA,@AC,@RB,@ET)";


        //查旧记录
        string SQL_query = " select * from Station_Crew_Pair"
            + " where Station_Crew_Pair.SC_ID='" + keyword + "'";

        SqlParameter[] parmlog = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@DO", SqlDbType.VarChar, 200),
                new SqlParameter("@DA", SqlDbType.VarChar, 200),
                new SqlParameter("@AC", SqlDbType.VarChar, 50),
                new SqlParameter("@RB", SqlDbType.VarChar, 50),
                new SqlParameter("@ET", SqlDbType.VarChar, 10)
                 };




        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {
            if (rdr.Read())
            {
                parmlog[0].Value = "Stn_Crew pair";
                parmlog[1].Value = rdr[1].ToString().Trim() + "/" + rdr[2].ToString().Trim() + "/" + rdr[3].ToString().Trim() + "/" + rdr[4].ToString().Trim() + "/" + rdr[5].ToString().Trim() + "/" + rdr[6].ToString().Trim() + "/" + rdr[7].ToString().Trim();
                parmlog[2].Value = "";
                parmlog[3].Value = "DEL";
                parmlog[4].Value = Session["User_ID"].ToString().Trim();
                parmlog[5].Value = "SC";
            }

        }
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Log, parmlog);
        }

        //删除

        string SQL_Del = "UPDATE Station_Crew_Pair "
                 + " SET Station_Crew_Pair.Rcd_Status ='DEL'"
                 + " where Station_Crew_Pair.SC_ID='" + keyword + "'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Del);
        }




    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["SC_Code"] = TextBox8.Text.Trim();
        Session["SC_Type"] = DropDownList1.Text.Trim();
        //string[] ss = DropDownList2.Text.Split('(');
        //Session["SC_name"] = ss[0];
        Session["SC_name"] = TextBox3.Text.Trim();
        Session["CC_Date"] = Request.Form["cc_date"];
        
        Bind();
    }


    private void Bind()
    {
        string SC_C = Session["SC_Code"].ToString();
        string SC_T = Session["SC_Type"].ToString();
        string SC_N = Session["SC_name"].ToString();
        //string SC_NO = Session["SC_No"].ToString();
        string SC_D = Session["CC_Date"].ToString();


        string scc = "";
        string sct = "";
        string scn = "";
        string scd = "";

        if (SC_C != "")
        {
            scc = " and Station_Crew_Pair.Station_Code like @scc";
        }
        if (SC_T != "")
        {
            sct = " and Station_Crew_Pair.Flight_Type = @sct";
        }
        if (SC_N != "")
        {
            scn = " and (Station_Crew_Pair.Allow_Staff_Name like @scn or Station_Crew_Pair.Allow_Staff_No like @scn)";
        }
        if (SC_D != "")
        {
            scd = " and Station_Crew_Pair.No_From <= @scd and Station_Crew_Pair.No_To >=@scd ";
        }



        string SQL_Query = "select * from Station_Crew_Pair"
           + " where Station_Crew_Pair.Rcd_Status='NEW' " + scc + sct + scn + scd
           + " order by Station_Crew_Pair.Station_Code ";
        SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@scc", SqlDbType.VarChar, 10),
                new SqlParameter("@sct", SqlDbType.VarChar, 20),
                new SqlParameter("@scn", SqlDbType.VarChar, 50),
                new SqlParameter("@scd", SqlDbType.Date)
                
                 };
        parm[0].Value = "%" + SC_C + "%";
        parm[1].Value = SC_T;
        parm[2].Value = "%" + SC_N + "%";
        parm[3].Value = Convert.ToDateTime(SC_D);



        DataTable dt = new DataTable();
        dt.Columns.Add("SC_ID", typeof(string));
        dt.Columns.Add("Station_Code", typeof(string));
        dt.Columns.Add("Station_Name", typeof(string));
        dt.Columns.Add("Flight_Type", typeof(string));
        dt.Columns.Add("Allow_Staff_No", typeof(string));
        //dt.Columns.Add("Allow_Staff_Name", typeof(string));
        dt.Columns.Add("No_From", typeof(string));
        dt.Columns.Add("No_To", typeof(string)); 


        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Query, parm))
        {
            while (rdr.Read())
            {
                DataRow row = dt.NewRow();
                row["SC_ID"] = Convert.ToString(rdr.GetSqlValue(0));
                row["Station_Code"] = Convert.ToString(rdr.GetSqlValue(1));
                row["Station_Name"] = Convert.ToString(rdr.GetSqlValue(2));
                row["Flight_Type"] = Convert.ToString(rdr.GetSqlValue(3));
                row["Allow_Staff_No"] = Convert.ToString(rdr.GetSqlValue(5)) + "(" + Convert.ToString(rdr.GetSqlValue(4)) + ")";
                //row["Allow_Staff_Name"] = Convert.ToString(rdr.GetSqlValue(5));
                row["No_From"] = Convert.ToString(rdr.GetDateTime(6).ToShortDateString());
                row["No_To"] = Convert.ToString(rdr.GetDateTime(7).ToShortDateString());
                
                
                dt.Rows.Add(row);
            }

        }
        Label8.Text = "Total: " + dt.Rows.Count + " items";
        GridView1.DataSource = dt;//绑定数据显示   
        GridView1.DataKeyNames = new String[] { "SC_ID" };
        GridView1.DataBind();
        Label8.Text = "Total: " + dt.Rows.Count + " items";
        if (dt.Rows.Count == 0)
        { Delete.Visible = false; }
        else
        { Delete.Visible = true; }
        Label8.Text = "Total: " + dt.Rows.Count + " items";

       
    }



    //分页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();


    }

    //取消编辑
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }


    //编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;

        Bind();
    }
     //更新
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //接收
        string keyword = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string sc = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
        string sn = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        string ft = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("Flight_Type")).SelectedItem.Text;
        string asn = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("Allow_Staff_No")).SelectedItem.Text;
        //string asna = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("Allow_Staff_Name")).SelectedItem.Text;
        string Fr = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4")).Text;
        string To = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("No_To")).Text;

        if (sc != "" && ft != "" && asn != "" &&sn != "" && Fr != "" && To != "")//输入不齐
        {
            string sNa =asn.Split('(')[0];
            string sN=asn.Split('(')[1].Split(')')[0];
            //string sNa =asna.Split('(')[0];
            //if(sNa1==sNa)//选的不匹配
            //{
                //读取原有记录

                string SQL_query = " select * from Station_Crew_Pair"
                     + " where Station_Crew_Pair.SC_ID='" + keyword + "'";
                string oldrecord ="";
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
                {
                    if (rdr.Read())
                    {

                        oldrecord = rdr[1].ToString().Trim() + "/" + rdr[2].ToString().Trim() + "/" + rdr[3].ToString().Trim() + "/" + rdr[4].ToString().Trim() + "/" + rdr[5].ToString().Trim() + "/" + rdr[6].ToString().Trim() + "/" + rdr[7].ToString().Trim();
                       
                    }

                }


                string newrecord = sc.Trim() + "/" + sn.Trim() + "/" + ft.Trim() + "/" + sN.Trim() + "/" + sNa.Trim() + "/" + Fr.Trim() + "/" + To.Trim();

                //更新
                string SQL_Update = "UPDATE Station_Crew_Pair "
                    + " SET Station_Code = '" + sc.Trim() + "' , Station_Name = '" + sn.Trim() + "' , Flight_Type = '" + ft + "' , Allow_Staff_No = '" + sN.Trim()
                    + "' , Allow_Staff_Name = '" + sNa.Trim() + "' , No_From = ' " + Fr + "' , No_To = ' " + To + "'"
                    + " where Station_Crew_Pair.SC_ID = '" + keyword + "'";

                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Update);
                }


                //写log
                SqlParameter[] parmlog = new SqlParameter[]{
                        new SqlParameter("@sN", SqlDbType.VarChar, 10),
                        new SqlParameter("@DO", SqlDbType.VarChar, 200),
                        new SqlParameter("@DA", SqlDbType.VarChar, 200),
                        new SqlParameter("@AC", SqlDbType.VarChar, 50),
                        new SqlParameter("@RB", SqlDbType.VarChar, 50),
                        new SqlParameter("@ET", SqlDbType.VarChar, 10)
                            };
                parmlog[0].Value = "Stn_Crew pair";
                parmlog[1].Value = oldrecord;
                parmlog[2].Value = newrecord;
                parmlog[3].Value = "UPDATA";
                parmlog[4].Value = Session["User_ID"].ToString();
                parmlog[5].Value = "SC";

                string SQL_Log = "INSERT INTO Crew_Check_Log"
                          + " (Staff_No,Details_Origin,Details_After_Action,Actions,Rcd_By,Edit_Table)"
                          + " VALUES(@sN,@DO,@DA,@AC,@RB,@ET)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Log, parmlog);
                }

            
            //}
            //else
            //{
            //                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('StaffNo and StaffName do not match');</script>");
            //}

        
        }
        else
        {
            //Response.Write("<script>alert('Please fill in all the information')</script>");
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please fill in all the information');</script>");

        
        }
        GridView1.EditIndex = -1;
        Bind();
    }

     //gridview数据绑定
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (((DropDownList)e.Row.FindControl("Flight_Type")) != null)
        {
            DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("Flight_Type");
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(new ListItem("", "1"));
            DropDownList1.Items.Add(new ListItem("SCH", "2"));
            DropDownList1.Items.Add(new ListItem("CHA", "3"));
        
        }

        if (((DropDownList)e.Row.FindControl("Allow_Staff_No")) != null)
        {
            DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("Allow_Staff_No");
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem(""));
            string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info where Crew_Info.Rcd_Status ='NEW' "
         + " order by Crew_Info.Staff_Name";

            DataTable dt = new DataTable();
            dt.Columns.Add("StaffNo(StaffName)", typeof(string));
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Staff))
            {
                while (rdr.Read())
                {
                    DataRow row = dt.NewRow();
                    row["StaffNo(StaffName)"] = Convert.ToString(rdr.GetSqlValue(1)) + "(" + Convert.ToString(rdr.GetSqlValue(0)) + ")";


                    dt.Rows.Add(row);
                }

            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DropDownList2.Items.Add(new ListItem(dt.Rows[i]["StaffNo(StaffName)"].ToString()));
            }
        }


        if (((DropDownList)e.Row.FindControl("Allow_Staff_Name")) != null)
        {
            DropDownList DropDownList3 = (DropDownList)e.Row.FindControl("Allow_Staff_Name");
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add(new ListItem(""));
            string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info where Crew_Info.Rcd_Status ='NEW' "
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

            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DropDownList3.Items.Add(new ListItem(dt.Rows[i]["StaffName(StaffNo)"].ToString()));
            }
        }

    }
}