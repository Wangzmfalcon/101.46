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

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class crewcheck : System.Web.UI.Page
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
            ListItem item0 = new ListItem("CREW");//"13"为item3项的关联值  
            ListItem item1 = new ListItem("STATION");//"11"为item1项的关联值  
            ListItem item2 = new ListItem("CARRIER");//"13"为item3项的关联值  

            this.DropDownList1.Items.Add(item);//添加到DropDownList1  
            this.DropDownList1.Items.Add(item0);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item1);//添加到DropDownList1   
            this.DropDownList1.Items.Add(item2);//添加到DropDownList1   


            ListItem ex_item = new ListItem("NONE");//"13"为item3项的关联值  
            ListItem ex_item0 = new ListItem("INSTRUCTOR");//"13"为item3项的关联值  
            this.DropDownList3.Items.Add(item);
            this.DropDownList3.Items.Add(ex_item);//添加到DropDownList1  
            this.DropDownList3.Items.Add(ex_item0);



            string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info where Crew_Info.Rcd_Status ='NEW'"
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

            lstMultipleValues.Attributes.Add("onclick", "FindSelectedItems(this," + txtSelectedMLValues.ClientID + ");");
            SetMultiValue();
            //formdate.Value = DateTime.Now.ToShortDateString();
          
            //this.DropDownList4.Items.Add("");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //    DropDownList4.Items.Add(new ListItem(dt.Rows[i]["StaffNo(StaffName)"].ToString()));
            //}
        }

    }


    protected void SetMultiValue()
    {
        //DataTable dt = new DataTable("Table1");

        //DataColumn dc1 = new DataColumn("Text");
        //DataColumn dc2 = new DataColumn("Value");
        //dt.Columns.Add(dc1);
        //dt.Columns.Add(dc2);

        ////To get enough data for scroll
        //dt.Rows.Add("Bangalore", 1);
        //dt.Rows.Add("Kolkata", 2);
        //dt.Rows.Add("Pune", 3);
        //dt.Rows.Add("Mumbai", 4);
        //dt.Rows.Add("Noida", 5);
        //dt.Rows.Add("Gurgaon", 6);
        //dt.Rows.Add("Hyderabad", 7);
        //dt.Rows.Add("Chennai", 8);
        //dt.Rows.Add("Jaipur", 8);
        //dt.Rows.Add("Patna", 8);
        //dt.Rows.Add("Ranchi", 8);

        //lstMultipleValues.DataSource = dt;
        //lstMultipleValues.DataTextField = "Text";
        //lstMultipleValues.DataValueField = "Value";
        //lstMultipleValues.DataBind();


        string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info where Crew_Info.Rcd_Status ='NEW' "
      + " order by Crew_Info.Staff_Name";

        DataTable dt = new DataTable();
        dt.Columns.Add("StaffName(StaffNo)", typeof(string));
        DataRow row1 = dt.NewRow();
        row1["StaffName(StaffNo)"] = "";
        dt.Rows.Add(row1);
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Staff))
        {
            while (rdr.Read())
            {
                DataRow row = dt.NewRow();
                row["StaffName(StaffNo)"] = Convert.ToString(rdr.GetSqlValue(1)) + "(" + Convert.ToString(rdr.GetSqlValue(0)) + ")";


                dt.Rows.Add(row);
            }

        }
        this.lstMultipleValues.DataSource = dt;
        this.lstMultipleValues.DataValueField = dt.Columns[0].ColumnName;
        this.lstMultipleValues.DataBind();
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
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string keyword = GridView1.DataKeys[e.RowIndex].Values[0].ToString();

        string[] ss = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("staffNo")).Text.Split('(');
        string[] sN1 = ss[1].Split(')');
        string sN = sN1[0];
        string Ty = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedItem.Text;
        string[] ss2 = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList2")).SelectedItem.Text.Split('(');
        string Ob ;
        if (ss2.Length==1)
        {
            Ob = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList2")).SelectedItem.Text;
        }
        else
        {
        
        string[] ss3 = ss2[1].Split(')');
        Ob = ss3[0];
        }
        string Fr = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4")).Text;
        string To = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox5")).Text;
        string Ex = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList3")).SelectedItem.Text;
        string Re = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox7")).Text;

        if (sN != "" && Ty != "" && Ob != "" && Fr != "" && To != "" && Ex != "" && Re != "")
        {
            bool flag = false;
            if (Ty == "CREW")
            {
                string SQL_Staff = "select Crew_Info.Staff_No from Crew_Info "
                           + " order by Crew_Info.Staff_No";


               // DataTable dt = new DataTable();

                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Staff))
                {
                    while (rdr.Read())
                    {

                        if (Ob == Convert.ToString(rdr.GetSqlValue(0)))
                            flag = true;

                    }

                }

            }
            else if (Ty == "STATION")
            {

                string SQL_Stn = "select * from vStn "
                   + " order by DEP_APT";


                
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL_Stn))
                {
                    while (rdr.Read())
                    {
                        if (Ob == Convert.ToString(rdr.GetSqlValue(0)))
                            flag = true;
                    }

                }

               
            }
            else if (Ty == "CARRIER")
            {
                if (Ob == "CA" || Ob == "NX" || Ob == "NXCA")
                    flag = true;
            }




            if (flag)
            {
                //查旧记录

               
                string SQL_query = " select * from Crew_Check"
            +" where Crew_Check.CC_ID='" + keyword + "'";

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
                        parmlog[0].Value = rdr[1].ToString().Trim();
                        parmlog[1].Value = rdr[1].ToString().Trim() + "/" + rdr[2].ToString().Trim() + "/" + rdr[3].ToString().Trim() + "/" + rdr[4].ToString().Trim() + "/" + rdr[5].ToString().Trim() + "/" + rdr[6].ToString().Trim();
                        parmlog[2].Value = sN.Trim() + "/" + Ty.Trim() + "/" + Ob.Trim() + "/" + Fr.Trim() + "/" + To.Trim() + "/" + Ex.Trim();
                        parmlog[3].Value = "UPDATA";
                        parmlog[4].Value = Session["User_ID"].ToString();
                        parmlog[5].Value = "CC";
                    }

                }


                //写日志
                string SQL_Log = "INSERT INTO Crew_Check_Log"
                           + " (Staff_No,Details_Origin,Details_After_Action,Actions,Rcd_By,Edit_Table)"
                           + " VALUES(@sN,@DO,@DA,@AC,@RB,@ET)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Log, parmlog);
                }


                //更新

                string SQL_Update = "UPDATE Crew_Check "
                + " SET Crew_Check.Staff_No ='" + sN + "' , No_Type ='" + Ty + "'  ,No_Object= '" + Ob + "' ,No_From='" + Fr + "',No_To ='"
                + To + "', Except_For = '" + Ex + "' ,Remark='" + Re + "'"
                 + " where Crew_Check.CC_ID='" + keyword + "'";

                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Update);
                }


            }
            else
            {
                //Response.Write("<script>alert('Type and Object do not match')</script>");
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Type and Object do not match');</script>");
            }
        }
        else
        {
            //Response.Write("<script>alert('Please fill in all the information')</script>");
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please fill in all the information');</script>");
        }



        GridView1.EditIndex = -1;
        Bind();
    }


    //活动下拉框
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    //    string D1text = DropDownList1.SelectedValue;

    //    switch (D1text)
    //    {
    //        case "CREW":
    //            this.DropDownList2.Items.Clear();
    //              string SQL_Staff = "select Crew_Info.Staff_No,Crew_Info.Staff_Name from Crew_Info where Crew_Info.Rcd_Status ='NEW' "
    //            + " order by Crew_Info.Staff_Name";

    //        DataTable dt = new DataTable();
    //        dt.Columns.Add("StaffName(StaffNo)", typeof(string));
    //        DataRow row1 = dt.NewRow();
    //        row1["StaffName(StaffNo)"] = "";
    //        dt.Rows.Add(row1);
    //        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Staff))
    //        {
    //            while (rdr.Read())
    //            {
    //                DataRow row = dt.NewRow();
    //                row["StaffName(StaffNo)"] = Convert.ToString(rdr.GetSqlValue(1)) + "(" + Convert.ToString(rdr.GetSqlValue(0)) + ")";


    //                dt.Rows.Add(row);
    //            }

    //        }
    //            this.DropDownList2.DataSource = dt;
    //            this.DropDownList2.DataValueField = dt.Columns[0].ColumnName;
    //            this.DropDownList2.DataBind();

    //            break;
    //        case "STATION":
    //            this.DropDownList2.Items.Clear();
    //            string SQL_Stn = "select * from vStn "
    //                + " order by DEP_APT";


    //            DataTable dt1 = new DataTable();
    //            dt1.Columns.Add("STATION", typeof(string));
    //            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL_Stn))
    //            {
    //                while (rdr.Read())
    //                {
    //                    DataRow row = dt1.NewRow();
    //                    row["STATION"] = Convert.ToString(rdr.GetSqlValue(0));


    //                    dt1.Rows.Add(row);
    //                }

    //            }
    //            this.DropDownList2.DataSource = dt1;
    //            this.DropDownList2.DataValueField = dt1.Columns[0].ColumnName;
    //            this.DropDownList2.DataBind();

    //            break;
    //        case "CARRIER":
    //            this.DropDownList2.Items.Clear();
    //            ListItem item2 = new ListItem("CA");//"13"为item3项的关联值  
    //            ListItem item20 = new ListItem("NX");//"13"为item3项的关联值  
    //            ListItem item21 = new ListItem("NXCA");//"11"为item1项的关联值  
    //            this.DropDownList2.Items.Add(item2);//添加到DropDownList1  
    //            this.DropDownList2.Items.Add(item20);//添加到DropDownList1   
    //            this.DropDownList2.Items.Add(item21);//添加到DropDownList1  
    //            break;
    //        default:
    //            this.DropDownList2.Items.Clear();
    //            break;
    //    }

    }
    //

    //gridview数据绑定
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {




        if (((DropDownList)e.Row.FindControl("DropDownList1")) != null)
        {
            DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("DropDownList1");
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(new ListItem("", "1"));
            DropDownList1.Items.Add(new ListItem("CREW", "2"));
            DropDownList1.Items.Add(new ListItem("STATION", "3"));
            DropDownList1.Items.Add(new ListItem("CARRIER", "4"));




        }
        if (((DropDownList)e.Row.FindControl("staffNo")) != null)
        {
            DropDownList staffNoDR = (DropDownList)e.Row.FindControl("staffNo");
            staffNoDR.Items.Clear();
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

                staffNoDR.Items.Add(new ListItem(dt.Rows[i]["StaffName(StaffNo)"].ToString()));
            }

        }


        if (((DropDownList)e.Row.FindControl("DropDownList2")) != null)
        {
            DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("DropDownList2");
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem(""));
            DropDownList2.Items.Add(new ListItem("---Station---"));
            //DropDownList2.Items.Add(new ListItem("PEK"));
            //DropDownList2.Items.Add(new ListItem("NRT"));
            //DropDownList2.Items.Add(new ListItem("NKG"));
            string SQL_Stn = "select * from vStn "
                    + " order by DEP_APT";


            DataTable dt1 = new DataTable();
            dt1.Columns.Add("STATION", typeof(string));
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL_Stn))
            {
                while (rdr.Read())
                {
                    DataRow row = dt1.NewRow();
                    row["STATION"] = Convert.ToString(rdr.GetSqlValue(0));


                    dt1.Rows.Add(row);
                }

            }
            //this.DropDownList2.DataSource = dt1;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {

                DropDownList2.Items.Add(new ListItem(dt1.Rows[i]["STATION"].ToString()));
            }

            DropDownList2.Items.Add(new ListItem("---Carrier---"));
            DropDownList2.Items.Add(new ListItem("CA"));
            DropDownList2.Items.Add(new ListItem("NX"));
            DropDownList2.Items.Add(new ListItem("NXCA"));
            DropDownList2.Items.Add(new ListItem("---Staff---"));

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

                DropDownList2.Items.Add(new ListItem(dt.Rows[i]["StaffName(StaffNo)"].ToString()));
            }





        }

        if (((DropDownList)e.Row.FindControl("DropDownList3")) != null)
        {
            DropDownList DropDownList3 = (DropDownList)e.Row.FindControl("DropDownList3");
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add(new ListItem("NONE"));
            DropDownList3.Items.Add(new ListItem("INSTRUCTOR"));


        }

    }
    //主页
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    //查询
    protected void Button1_Click(object sender, EventArgs e)
    {

        //string[] ssa = DropDownList4.Text.Split('(');
        //Session["CC_StaffNo"] = ssa[0];
        Session["CC_StaffNo"] = TextBox1.Text;
        Session["CC_Type"] = DropDownList1.Text;
        //string[] ss = DropDownList2.Text.Split('(');
        //if (DropDownList2.Text != "")
        //{
        //    string[] ssa = DropDownList2.Text.Split('(');
        //    string[] ssn = ssa[1].Split(')');
        //    Session["CC_Object"] = ssn[0];
        //}
        //else
        //    Session["CC_Object"] = "";
        Session["CC_Date"] = Request.Form["cc_date"];
        Session["CC_Except"] = DropDownList3.Text;

        Bind();

    }
    //绑定
    protected void Bind()
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
            ccs = " and( Crew_Check.Staff_No like @ccs or Crew_Info.Staff_Name like @ccs )";
        }
        if (CC_T != "")
        {
            cct = " and Crew_Check.No_Type = @cct";
        }
        if (CC_O != "")
        {
            cco = " and Crew_Check.No_Object = @cco";
        }
        if (CC_D != "")
        {
            ccd = " and Crew_Check.No_From <= @ccd and Crew_Check.No_To >=@ccd ";
        }
        else
            CC_D = DateTime.Now.ToString();
        if (CC_E != "")
        {
            cce = " and Crew_Check.Except_For = @cce";
        }

        string SQL_Query = "select * from Crew_Check,Crew_Info"
            + " where Crew_Check.Rcd_Status='NEW' and Crew_Check.Staff_No = Crew_Info.Staff_No" + ccs + cct + cco + ccd + cce
            + " order by Crew_Check.No_From ";
        SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@ccs", SqlDbType.VarChar, 10),
                new SqlParameter("@cct", SqlDbType.VarChar, 20),
                new SqlParameter("@cco", SqlDbType.VarChar, 50),
                new SqlParameter("@ccd", SqlDbType.Date),
                new SqlParameter("@cce", SqlDbType.VarChar, 50),
                 };
        parm[0].Value = "%"+CC_S+"%";
        parm[1].Value = CC_T;
        parm[2].Value = CC_O;
        parm[3].Value = Convert.ToDateTime(CC_D);
        parm[4].Value = CC_E;

        DataTable dt = new DataTable();
        dt.Columns.Add("CC_ID", typeof(string));
        dt.Columns.Add("StaffNo", typeof(string));
        dt.Columns.Add("No_Type", typeof(string));
        dt.Columns.Add("No_Object", typeof(string));
        dt.Columns.Add("No_From", typeof(string));
        dt.Columns.Add("No_To", typeof(string));
        dt.Columns.Add("Except_For", typeof(string));
        dt.Columns.Add("Remark", typeof(string));
        dt.Columns.Add("Processed_At", typeof(string));


        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Query, parm))
        {
            while (rdr.Read())
            {
                DataRow row = dt.NewRow();
                row["CC_ID"] = Convert.ToString(rdr.GetSqlValue(0));
                row["StaffNo"] = Convert.ToString(rdr.GetSqlValue(1)) + "(" + Convert.ToString(rdr.GetSqlValue(13)) + ")";
                row["No_Type"] = Convert.ToString(rdr.GetSqlValue(2));
                row["No_Object"] = Convert.ToString(rdr.GetSqlValue(3));
                row["No_From"] = Convert.ToString(rdr.GetDateTime(4).ToShortDateString());
                row["No_To"] = Convert.ToString(rdr.GetDateTime(5).ToShortDateString());
                row["Except_For"] = Convert.ToString(rdr.GetSqlValue(6));
                row["Remark"] = Convert.ToString(rdr.GetSqlValue(7));
                row["Processed_At"] = Convert.ToString(rdr.GetSqlValue(8)) ;
                dt.Rows.Add(row);
            }

        }
        Label8.Text = "Total: " + dt.Rows.Count + " items";
        GridView1.DataSource = dt;//绑定数据显示   
        GridView1.DataKeyNames = new String[] { "CC_ID" };
        GridView1.DataBind();
        Label8.Text = "Total: " + dt.Rows.Count + " items";
        if (dt.Rows.Count ==0)
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


    //删除
    protected void GridView1_RowDeleting(string keyword)
    {
        //日志
       
        string SQL_Log = "INSERT INTO Crew_Check_Log"
            + " (Staff_No,Details_Origin,Details_After_Action,Actions,Rcd_By,Edit_Table)"
            + " VALUES(@sN,@DO,@DA,@AC,@RB,@ET)";


        //查旧记录
        string SQL_query = " select * from Crew_Check"
            + " where Crew_Check.CC_ID='" + keyword+"'" ;

        SqlParameter[] parmlog = new SqlParameter[]{
                new SqlParameter("@sN", SqlDbType.VarChar, 10),
                new SqlParameter("@DO", SqlDbType.VarChar, 200),
                new SqlParameter("@DA", SqlDbType.VarChar, 200),
                new SqlParameter("@AC", SqlDbType.VarChar, 50),
                new SqlParameter("@RB", SqlDbType.VarChar, 50),
                new SqlParameter("@ET", SqlDbType.VarChar, 50)
                 };




        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
        {
            if (rdr.Read())
            {
                parmlog[0].Value = rdr[1].ToString().Trim();
                parmlog[1].Value = rdr[1].ToString().Trim() + "/" + rdr[2].ToString().Trim() + "/" + rdr[3].ToString().Trim() + "/" + rdr[4].ToString().Trim() + "/" + rdr[5].ToString().Trim() + "/" + rdr[6].ToString().Trim();
                parmlog[2].Value = "";
                parmlog[3].Value = "DEL";
                parmlog[4].Value = Session["User_ID"].ToString().Trim();
                parmlog[5].Value = "CC";
            }

        }
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Log, parmlog);
        }

        //删除

        string SQL_Del = "UPDATE Crew_Check "
                 + " SET Crew_Check.Rcd_Status ='DEL'"
                 + " where Crew_Check.CC_ID='" + keyword + "'";

        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_Del);
        }



    }

    //删除按钮
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
}