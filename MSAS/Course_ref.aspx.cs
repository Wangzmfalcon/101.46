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


public partial class Course_ref : System.Web.UI.Page
{
    public string id = "";
    public string Course_Ref_str = "";
    public string Course_str = "";
    public string Training_Type_str = "";
    public string Duation_str = "";
    public string Traning_Unit_str = "";

    DataTable dtranglist = new DataTable();
    string sqlstr = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["staffno"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
            Label1.Text = "Welcome " + Session["staffname"].ToString();



        //下拉框
        string SQL_course_d = "select Course from MSAS_Course order by id";
        using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, SQL_course_d))
        {
            while (rdr.Read())
            {

                Course_d.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));

            }

        }
        Training_Unit.Items.Add("Year");
        Training_Unit.Items.Add("Month");
        Training_Unit.Items.Add("Day");
        Training_Type.Items.Add("General Initial");
        Training_Type.Items.Add("General Recurrent");
        Training_Type.Items.Add("General One Time");
        Training_Type.Items.Add("Position Initial");
        Training_Type.Items.Add("Position Recurrent");
        Training_Type.Items.Add("Position One Time");
        Training_Type.Items.Add("Other");
        //判断是否是review
        id = Session["Course_Ref"].ToString();

        if (id != "" && id != null)
        {

            //基本信息
            string SQL = "select Course_Ref,Course,Training_Type,Duation,Traning_Unit from MSAS_Course_Reference  where  ID='" + id + "'";
            using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, SQL))
            {
                if (rdr.Read())
                {
                    Course_Ref_str = Convert.ToString(rdr.GetSqlValue(0));
                    Course_str = Convert.ToString(rdr.GetSqlValue(1));
                    Training_Type_str = Convert.ToString(rdr.GetSqlValue(2));
                    Duation_str = Convert.ToString(rdr.GetSqlValue(3));
                    Traning_Unit_str = Convert.ToString(rdr.GetSqlValue(4));


                }

            }


            //原来选择的range   
            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "select Position from MSAS_Course_Ref_Range where ID='" + id + "' ";

                    sqlcnn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);

                    adapter.Fill(dtranglist);

                }
            }




        }

        if (!IsPostBack)
        {
            Course_Ref_t.Text = Course_Ref_str;
            Course_d.SelectedValue = Course_str.Trim();
            Training_Type.SelectedValue = Training_Type_str.Trim();
            Duation.Text = Duation_str;
            Training_Unit.SelectedValue = Traning_Unit_str.Trim();




        }




        //range
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                sqlcmm.CommandText = "select id,Position  from MSAS_Position   order by id";



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
        if (findrangelist(Eval("Position").ToString()))
            ret_s = "<div style=\"width:400px\"><input name=\"items\" checked=\"true\" type=\"checkbox\" id=\"CheckBox" + Eval("Position") + "\" />" + Eval("Position") + " </div>";
        else
            ret_s = "<div style=\"width:400px\"><input name=\"items\" type=\"checkbox\" id=\"CheckBox" + Eval("Position") + "\" />" + Eval("Position") + " </div>";


        return ret_s;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");

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

    protected void savedateClick(object sender, EventArgs e)
    {
        //主表

        if (id != "" && id != null)//更新数据 
        {


            //插入新记录
            //基本信息
            SqlConnection cn1 = new SqlConnection(sqlstr);//创建数据库连接对象
            SqlCommand insertCmd = new SqlCommand("update MSAS_Course_Reference set Course_Ref=@Course_Ref,Course=@Course,Training_Type=@Training_Type,Duation=@Duation,Traning_Unit=@Traning_Unit  where id=@ID ", cn1);

            insertCmd.Parameters.Add("@ID", SqlDbType.Int);
            insertCmd.Parameters.Add("@Course_Ref", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Course", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Training_Type", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Duation", SqlDbType.Int);
            insertCmd.Parameters.Add("@Traning_Unit", SqlDbType.VarChar, 50);


            insertCmd.Parameters["@ID"].Value = id;
            insertCmd.Parameters["@Course"].Value = Course_d.SelectedItem.Value.ToString().Trim();
            insertCmd.Parameters["@Course_Ref"].Value = Course_Ref_t.Text;
            insertCmd.Parameters["@Training_Type"].Value = Training_Type.SelectedItem.Value.ToString().Trim();
            insertCmd.Parameters["@Duation"].Value = Duation.Text;
            insertCmd.Parameters["@Traning_Unit"].Value = Training_Unit.SelectedItem.Value.ToString().Trim();


            cn1.Open();
            int flag = insertCmd.ExecuteNonQuery();
            if (flag > 0)
            {
                //  Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg", "<script type=\"text/javascript\">function ShowAlert(){alert('dd');}window.onload=ShowAlert;</script>");
                // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert success');</script>");

            }
            else
                //  ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert fail');</script>");

                cn1.Close();


        }
        else//新增数据
        {

            //生成序号

            int currentid = 0;
            string SQL = "select isnull(max(id),0)  from MSAS_Course_Reference ";
            using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, SQL))
            {
                if (rdr.Read())
                {
                    currentid = Convert.ToInt32(Convert.ToString(rdr.GetSqlValue(0)));


                }

            }
            int newid = currentid + 1;
            id = Convert.ToString(newid);



            //插入新记录
            //基本信息
            SqlConnection cn1 = new SqlConnection(sqlstr);//创建数据库连接对象
            SqlCommand insertCmd = new SqlCommand("insert into MSAS_Course_Reference values(@ID,@Course_Ref,@Course,@Training_Type,@Duation,@Traning_Unit)", cn1);

            insertCmd.Parameters.Add("@ID", SqlDbType.Int);
            insertCmd.Parameters.Add("@Course_Ref", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Course", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Training_Type", SqlDbType.VarChar, 50);
            insertCmd.Parameters.Add("@Duation", SqlDbType.Int);
            insertCmd.Parameters.Add("@Traning_Unit", SqlDbType.VarChar, 50);


            insertCmd.Parameters["@ID"].Value = newid;
            insertCmd.Parameters["@Course"].Value = Course_d.SelectedItem.Value.ToString().Trim();
            insertCmd.Parameters["@Course_Ref"].Value = Course_Ref_t.Text;
            insertCmd.Parameters["@Training_Type"].Value = Training_Type.SelectedItem.Value.ToString().Trim();
            if (Duation.Text == "")
                insertCmd.Parameters["@Duation"].Value = 0;
            else
                insertCmd.Parameters["@Duation"].Value = Duation.Text;
            insertCmd.Parameters["@Traning_Unit"].Value = Training_Unit.SelectedItem.Value.ToString().Trim();


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

        //删除range记录


        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {



                sqlcmm.CommandText = "delete MSAS_Course_Ref_Range  where ID='" + id + "'";

                sqlcnn.Open();
                int j = sqlcmm.ExecuteNonQuery();

                sqlcnn.Close();

                if (j > 0)
                {
                    // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");

                }
                else
                {
                    //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                }

            }


        }

        //插入新的range
        SqlConnection cn2 = new SqlConnection(sqlstr);//创建数据库连接对象
        string rangetext = Request.Form["savetxt"];
        int flag1;
        string[] sArray = rangetext.Split('|');
        for (int i = 0; i < sArray.Length; i++)
        {

            if (sArray[i] != "")
            {
                string key = sArray[i].Replace("CheckBox", "");


                SqlCommand insertCmd1 = new SqlCommand("insert into MSAS_Course_Ref_Range values(@ID,@Position)", cn2);
                insertCmd1.Parameters.Add("@ID", SqlDbType.Int);
                insertCmd1.Parameters.Add("@Position", SqlDbType.VarChar, 50);


                insertCmd1.Parameters["@ID"].Value = id;
                insertCmd1.Parameters["@Position"].Value = key;

                cn2.Open();
                flag1 = insertCmd1.ExecuteNonQuery();
                if (flag1 > 0)
                {
                    //  Page.ClientScript.RegisterStartupScript(Page.GetType(), "msg", "<script type=\"text/javascript\">function ShowAlert(){alert('dd');}window.onload=ShowAlert;</script>");
                    // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert success');</script>");
                    //  ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Class_setting.aspx','_blank')</script>");

                }
                else
                {
                    // ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New data insert fail');</script>");
                }
                cn2.Close();
            }


        }






        Response.Redirect("Course_ref_search.aspx");
    }
}