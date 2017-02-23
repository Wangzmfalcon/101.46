using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Globalization;//日期格式化
using SMS.DBUtility;


public partial class Class : System.Web.UI.Page
{
    DataTable dtranglist = new DataTable();
    string sqlstr = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    public string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["staffno"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
            Label1.Text = "Welcome " + Session["staffname"].ToString();




        if (!IsPostBack)
        {

            //Class Type

            string SQL = "select id,Course_Ref  from MSAS_Course_Reference  order by id ";
            using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, SQL))
            {
                while (rdr.Read())
                {
                    Course_Ref.Items.Add(Convert.ToString(rdr.GetSqlValue(1)));


                }

            }
            //Training Type
            Training_Type.Items.Clear();
            Training_Type.Items.Add("Classroom");
            Training_Type.Items.Add("Self Study");
            Training_Type.Items.Add("OJT");
            Training_Type.Items.Add("LEC");
            Training_Type.Items.Add("RS");
            Training_Type.Items.Add("Other");






            id = Session["Class_ID"].ToString();

            if (id != "" && id != null)
            {
                //基本信息
                string SQL1 = "select Class_Name,Course_Ref,Batch,Instructor,CONVERT(varchar(16), Training_Date, 20),Training_Time,Training_type,Location,Training_Organization  from MSAS_Class  where 1=1 and ID='" + id + "'";
                using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, SQL1))
                {
                    if (rdr.Read())
                    {
                        Class_Name.Text = Convert.ToString(rdr.GetSqlValue(0));
                        Course_Ref.SelectedValue = Convert.ToString(rdr.GetSqlValue(1)).Trim();
                        Batch.Text = Convert.ToString(rdr.GetSqlValue(2));
                        Instructor.Text = Convert.ToString(rdr.GetSqlValue(3));
                        Training_Date.Text = Convert.ToString(rdr.GetSqlValue(4));
                        if (rdr.IsDBNull(5))
                        {
                            Training_Time.Text = "";
                        }
                        else
                            Training_Time.Text = Convert.ToString(rdr.GetSqlValue(5));

                        Training_Type.SelectedValue = Convert.ToString(rdr.GetSqlValue(6)).Trim();
                        Location.Text = Convert.ToString(rdr.GetSqlValue(7));
                        Training_Organization.Text = Convert.ToString(rdr.GetSqlValue(8));


                    }

                }

            }









            //attend 
            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select Staff from MSAS_Class_Range where 1=1 and ID='" + id + "' ";

                    sqlcnn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.Fill(dtranglist);

                }
            }


        }



        //查询range
        //range  
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {

                 string classid = Course_Ref.SelectedItem.Value;
                string Course_Type = "";
                string sql_Course_big = "SELECT Training_Type from MSAS_Course_Reference   where Course_Ref='" + classid + "'";

                using (SqlDataReader rdr = SqlHelper.ExecuteReader(sqlstr, CommandType.Text, sql_Course_big))
                {
                    if (rdr.Read())
                    {
                        Course_Type = Convert.ToString(rdr.GetSqlValue(0));
                    }

                }
               
                sqlcmm.CommandText = "select C.StaffID,C.StaffName                                                  "
                                    + "from MSAS_HRInfo C ";
                if (Course_Type != "Other" && Course_Type != "Position Initial" && Course_Type != "Position One Time" && Course_Type != "General One Time")
                {
                    sqlcmm.CommandText += "join   "
                                        + "(select distinct(S.StaffID)      "
                                        + "from MSAS_Course_Reference A,MSAS_Course_Ref_Range B,MSAS_Position_S S                "
                                        + "where A.ID=B.ID                                           ";

                    if (classid != "" && classid != null)
                    {
                        sqlcmm.CommandText += "and A.Course_Ref='" + classid + "'";
                    }
                    sqlcmm.CommandText += "and S.Position=B.Position) D on                                              "
                                        + "C.StaffID=D.StaffID                                           ";


                }
                sqlcmm.CommandText += "where  1=1                                          ";
                if (id == "")
                    sqlcmm.CommandText += "and C.HRstatus=0                                       ";



                sqlcmm.CommandText += "order by C.StaffID";




                sqlcnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                this.titlelist.DataSource = dt;
                this.titlelist.DataBind();

            }
        }


    }



    public string trstyle(int i)
    {

        string ret_s = "";
        if (findrangelist(Eval("StaffID").ToString()))
            //ret_s = "<div style=\"width:200px;float:left\"><input name=\"items\" checked=\"true\" type=\"checkbox\" id=\"CheckBox" + Eval("Title") + "\" />" + Eval("Title") + " </div>";
            ret_s = "<div style=\"width:250px;float:left\"><input name=\"items\" type=\"checkbox\"  checked=\"true\" id=\"CheckBox" + Eval("StaffID") + "\" />" + Eval("StaffID") + " " + Eval("Staffname") + " </div>";
        else
            ret_s = "<div style=\"width:250px;float:left\"><input name=\"items\" type=\"checkbox\" id=\"CheckBox" + Eval("StaffID") + "\" />" + Eval("StaffID") + " " + Eval("Staffname") + " </div>";


        return ret_s;
    }



    public bool findrangelist(string title)
    {
        bool result = false;

        for (int i = 0; i < dtranglist.Rows.Count; i++)
        {
            if (title == dtranglist.Rows[i][0].ToString())
            {
                result = true;
            }

        }

        return result;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");

    }
    protected void savedateClick(object sender, EventArgs e)
    {
        id = Session["Class_ID"].ToString();

        if (id != "" && id != null)//修改
        {

            //更新记录
            //基本信息
            SqlConnection cn1 = new SqlConnection(sqlstr);//创建数据库连接对象
            SqlCommand insertCmd = new SqlCommand("update MSAS_Class set Class_Name=@Class_Name,Course_Ref=@Course_Ref,Batch=@Batch,Instructor=@Instructor,Training_Date=@Training_Date,Training_Time=@Training_Time,Training_type=@Training_type,Location=@Location,Training_Organization=@Training_Organization where  ID=@ID", cn1);
            insertCmd.Parameters.Add("@ID", SqlDbType.Int);
            insertCmd.Parameters.Add("@Class_Name", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Course_Ref", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Batch", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Instructor", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Training_Date", SqlDbType.Date);
            insertCmd.Parameters.Add("@Training_Time", SqlDbType.Int);
            insertCmd.Parameters.Add("@Training_type", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Location", SqlDbType.VarChar, 100);
            insertCmd.Parameters.Add("@Training_Organization", SqlDbType.VarChar, 100);



            insertCmd.Parameters["@ID"].Value = id;
            insertCmd.Parameters["@Class_Name"].Value = Class_Name.Text;
            insertCmd.Parameters["@Course_Ref"].Value = Course_Ref.Text;
            insertCmd.Parameters["@Batch"].Value = Batch.Text;
            insertCmd.Parameters["@Instructor"].Value = Instructor.Text;
            if (Training_Date.Text == "")
                insertCmd.Parameters["@Training_Date"].Value = "2000.1.1";
            else
                insertCmd.Parameters["@Training_Date"].Value = Training_Date.Text;
            if (Training_Time.Text == "")
                insertCmd.Parameters["@Training_Time"].Value = DBNull.Value;
            else
                insertCmd.Parameters["@Training_Time"].Value = Training_Time.Text;
            insertCmd.Parameters["@Training_type"].Value = Training_Type.SelectedItem.Value.ToString().Trim();
            insertCmd.Parameters["@Location"].Value = Location.Text;
            insertCmd.Parameters["@Training_Organization"].Value = Training_Organization.Text;

            cn1.Open();
            int flag = insertCmd.ExecuteNonQuery();
            if (flag > 0)
            {
                //  Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg", "<script type=\"text/javascript\">function ShowAlert(){alert('dd');}window.onload=ShowAlert;</script>");
                // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert success');</script>");

            }
            else
            {
            }
            //  ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert fail');</script>");

            cn1.Close();


            //删除历史记录
            using (SqlConnection sqlcnn1 = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm1 = sqlcnn1.CreateCommand())
                {



                    sqlcmm1.CommandText = "Delete MSAS_Class_Range where ID='" + id + "'";
                    sqlcnn1.Open();
                    int j = sqlcmm1.ExecuteNonQuery();
                    sqlcnn1.Close();
                    if (j > 0)
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");

                    }
                    else
                    {
                        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                    }

                }
            }

        }
        else//新增
        {

            //生成新id

            int currentid = 0;
            string SQL = "select isnull(max(id),0)  from MSAS_Class ";
            using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, SQL))
            {
                if (rdr.Read())
                {
                    currentid = Convert.ToInt32(Convert.ToString(rdr.GetSqlValue(0)));


                }

            }
            int newid = currentid + 1;
            id = newid.ToString();
            //插入新记录
            //基本信息
            SqlConnection cn1 = new SqlConnection(sqlstr);//创建数据库连接对象
            SqlCommand insertCmd = new SqlCommand("insert into MSAS_Class values(@ID,@Class_Name,@Course_Ref,@Batch,@Instructor,@Training_Date,@Training_Time,@Training_type,@Location,@Training_Organization)", cn1);
            insertCmd.Parameters.Add("@ID", SqlDbType.Int);
            insertCmd.Parameters.Add("@Class_Name", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Course_Ref", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Batch", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Instructor", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Training_Date", SqlDbType.Date);
            insertCmd.Parameters.Add("@Training_Time", SqlDbType.Int);
            insertCmd.Parameters.Add("@Training_type", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Location", SqlDbType.VarChar, 100);
            insertCmd.Parameters.Add("@Training_Organization", SqlDbType.VarChar, 100);



            insertCmd.Parameters["@ID"].Value = newid;
            insertCmd.Parameters["@Class_Name"].Value = Class_Name.Text;
            insertCmd.Parameters["@Course_Ref"].Value = Course_Ref.Text;
            insertCmd.Parameters["@Batch"].Value = Batch.Text;
            insertCmd.Parameters["@Instructor"].Value = Instructor.Text;
            if (Training_Date.Text == "")
                insertCmd.Parameters["@Training_Date"].Value = "2000.1.1";
            else
                insertCmd.Parameters["@Training_Date"].Value = Training_Date.Text;
            if (Training_Time.Text == "")
                insertCmd.Parameters["@Training_Time"].Value = DBNull.Value;
            else
                insertCmd.Parameters["@Training_Time"].Value = Training_Time.Text;
            insertCmd.Parameters["@Training_type"].Value = Training_Type.SelectedItem.Value.ToString().Trim();
            insertCmd.Parameters["@Location"].Value = Location.Text;
            insertCmd.Parameters["@Training_Organization"].Value = Training_Organization.Text;

            cn1.Open();
            int flag = insertCmd.ExecuteNonQuery();
            if (flag > 0)
            {
                //  Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg", "<script type=\"text/javascript\">function ShowAlert(){alert('dd');}window.onload=ShowAlert;</script>");
                // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert success');</script>");

            }
            else
            {
            }
            //  ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert fail');</script>");

            cn1.Close();




        }




        SqlConnection cn2 = new SqlConnection(sqlstr);//创建数据库连接对象
        string rangetext = Request.Form["savetxt"];
        int flag1;
        string[] sArray = rangetext.Split('|');
        for (int i = 0; i < sArray.Length; i++)
        {

            if (sArray[i] != "")
            {
                string key = sArray[i].Replace("CheckBox", "");


                SqlCommand insertCmd1 = new SqlCommand("insert into MSAS_Class_Range values(@ID,@staff)", cn2);
                insertCmd1.Parameters.Add("@ID", SqlDbType.Int);
                insertCmd1.Parameters.Add("@staff", SqlDbType.VarChar, 50);


                insertCmd1.Parameters["@ID"].Value = id;
                insertCmd1.Parameters["@staff"].Value = key;

                cn2.Open();
                flag1 = insertCmd1.ExecuteNonQuery();
                if (flag1 > 0)
                {
                    //  Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg", "<script type=\"text/javascript\">function ShowAlert(){alert('dd');}window.onload=ShowAlert;</script>");
                    // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert success');</script>");
                    //ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Course_Setting.aspx','_blank')</script>");

                }
                else
                { }
                // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert fail');</script>");

                cn2.Close();
            }


        }
        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.history.back(-2);</script>");
        //Response.Redirect("Class_search.aspx");
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>if(confirm('Data saved , press \"OK\" to close this page?')){window.close(); }else{ window.close();}</script>");
        //Response.Write("<script>window.close();</script>");
    }
    protected void Course_Ref_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
}