using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Configuration;

public partial class Main : System.Web.UI.Page
{
    public string before = "";
    public string after = "";
    public string userstring = "";

    List<string> beforelist = new List<string>();
    List<string> afterlist = new List<string>();
    List<string> alllist = new List<string>();


    string sqlstr = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        userstring = Request["staffid"];
        before = Request["before"];
        after = Request["after"];

        if (Session["staffno"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Label1.Text = "Welcome " + Session["staffname"].ToString();

            //拆分before
            string[] beforeArray = before.Split('|');

            for (int i = 0; i < beforeArray.Length; i++)
            {
                if (beforeArray[i] != "")
                {
                    beforelist.Add(beforeArray[i].Replace("CheckBox", "").Replace("@@@", "&"));
                }

            }
            //拆分after
            string[] afterArray = after.Split('|');

            for (int i = 0; i < afterArray.Length; i++)
            {
                if (afterArray[i] != "")
                {
                    afterlist.Add(afterArray[i].Replace("CheckBoxx", "").Replace("@@@", "&"));
                }

            }

            //合并

            alllist = beforelist.Union(afterlist).ToList();




            this.positionlist.DataSource = alllist;
            this.positionlist.DataBind();
        }


    }


    public string resultsty(int i)
    {
        string ret_s = "";
        string rowspan = "1";
        string position = alllist[i - 1].ToString();
        //check before
        bool beforeflag = checkposition(beforelist, position);
        string beforeback = "";
        if (beforeflag)
            beforeback = "style=\"background-color:#CAF7B7\"";
        //check after
        bool afterflag = checkposition(afterlist, position);
        string afterback = "";
        if (afterflag)
            afterback = "style=\"background-color:#CAF7B7\"";


        string falses = "<i class=\"fa fa-times\" aria-hidden=\"true\"></i>";
        string truee = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
        string falseback = "style=\"background-color:#EA7171\"";

        ret_s = ret_s + "<tr>";
        string sqlcount = "SELECT count(*)  FROM MSAS_Course_VW where Position='" + position + "'  and  Training_Type <>'Other'";
        using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, sqlcount))
        {
            if (rdr.Read())
            {
                rowspan = Convert.ToString(rdr.GetSqlValue(0));
            }

        }
        string sqldetail = "SELECT Course_Ref FROM MSAS_Course_VW where Position='" + position + "' and  Training_Type <>'Other'";

        ret_s = ret_s + "<td class=\"td10\" rowspan=\"" + rowspan + "\" " + beforeback + ">" + position + "</td>";
        string firstline = "";
        using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, sqldetail))
        {
            if (rdr.Read())
            {
                firstline = Convert.ToString(rdr.GetSqlValue(0));
            }

        }

        ret_s = ret_s + "<td class=\"td20\" " + beforeback + ">" + firstline + "</td>";
        if (beforeflag)
        {
            string result = checkclass(userstring, firstline);
            if (result == "OK")
            {
                ret_s = ret_s + "<td class=\"td20\" " + beforeback + ">" + truee + "</td>";
            }
            else
            {
                ret_s = ret_s + "<td class=\"td20\" " + falseback + ">" + falses + result + "</td>";
            }
            
        }
        else
        {
            ret_s = ret_s + "<td class=\"td20\" " + beforeback + ">" + "</td>";
        }

        ret_s = ret_s + "<td class=\"td10\" rowspan=\"" + rowspan + "\"  " + afterback + ">" + position + "</td>";
        ret_s = ret_s + "<td class=\"td20\"  " + afterback + ">" + firstline + "</td>";
        if (afterflag)
        {

            string result = checkclass(userstring, firstline);
            if (result == "OK")
            {
                ret_s = ret_s + "<td class=\"td20\" " + afterback + ">" + truee + "</td>";
            }
            else
            {
                ret_s = ret_s + "<td class=\"td20\" " + falseback + ">" + falses + result + "</td>";
            }
            

           
        }
        else
        {
            ret_s = ret_s + "<td class=\"td20\"  " + afterback + ">" + "</td>";
        }

        ret_s = ret_s + "</tr>";
        int linecount = 1;
        using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, sqldetail))
        {
            while (rdr.Read())
            {
                if (linecount != 1)
                {
                    ret_s = ret_s + "<tr>";
                    ret_s = ret_s + "<td class=\"td20\" " + beforeback + ">" + Convert.ToString(rdr.GetSqlValue(0)) + "</td>";
                    if (beforeflag)
                    {

                        string result = checkclass(userstring, Convert.ToString(rdr.GetSqlValue(0)));
                        if (result == "OK")
                        {
                            ret_s = ret_s + "<td class=\"td20\" " + beforeback + ">" + truee + "</td>";
                        }
                        else
                        {
                            ret_s = ret_s + "<td class=\"td20\" " + falseback + ">" + falses + result + "</td>";
                        }
            
                    }
                    else
                    {
                        ret_s = ret_s + "<td class=\"td20\" " + beforeback + ">" + "</td>";
                    }
                    ret_s = ret_s + "<td class=\"td10\" " + afterback + ">" + Convert.ToString(rdr.GetSqlValue(0)) + "</td>";
                    if (afterflag)
                    {
                        string result = checkclass(userstring, Convert.ToString(rdr.GetSqlValue(0)));
                        if (result == "OK")
                        {
                            ret_s = ret_s + "<td class=\"td20\" " + afterback + ">" + truee + "</td>";
                        }
                        else
                        {
                            ret_s = ret_s + "<td class=\"td20\" " + falseback + ">" + falses + result + "</td>";
                        }
            
                    }
                    else
                    {
                        ret_s = ret_s + "<td class=\"td20\"  " + afterback + ">" + "</td>";
                    }
                    ret_s = ret_s + "</tr>";
                }
                linecount++;
            }

        }





        return ret_s;
    }


    public string checkclass(string staffid, string course_ref)
    {
        string ret = "";
        //查询reference信息

        string Course = "";
        string Training_Type = "";
        int Duation = 0;
        string Traning_Unit = "";
        string sqlreference = "  select Course,Training_Type,Duation,Traning_Unit from MSAS_Course_Reference where Course_Ref='" + course_ref + "' ";
        using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, sqlreference))
        {
            if (rdr.Read())
            {

                Course = Convert.ToString(rdr.GetSqlValue(0));
                Training_Type = Convert.ToString(rdr.GetSqlValue(1));
                Duation = Convert.ToInt32(Convert.ToString(rdr.GetSqlValue(2)));
                Traning_Unit = Convert.ToString(rdr.GetSqlValue(3));
            }
        }


        if (Training_Type == "Initial")//如果是初训
        {
            string SQL_int = "SELECT* from MSAS_Position_Gap_Class_VW B where B.staff='" + staffid + "' and B.Course='" + Course + "'"
                + " and Training_Date=(select max(A.Training_Date) from MSAS_Position_Gap_Class_VW A where A.Staff=B.Staff and A.Course=B.Course )";
            using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, SQL_int))
            {
                if (rdr.Read())
                {
                    ret = "OK";
                }
                else
                {
                    ret = "No Records";
                }

            }

        }
        else if (Training_Type == "Recurrent")
        {
            string SQL_int = "SELECT B.* from MSAS_Position_Gap_Class_VW B where B.staff='" + staffid + "' and B.Course='" + Course + "'"
                + " and Training_Date=(select max(A.Training_Date) from MSAS_Position_Gap_Class_VW A where A.Staff=B.Staff and A.Course=B.Course )";
            using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, SQL_int))
            {
                if (rdr.Read())
                {
                    DateTime Training_Date = Convert.ToDateTime(rdr.GetSqlValue(5));
                    DateTime Training_Required_Date = DateTime.Now;
                    switch (Traning_Unit)
                    {
                        case "Day":
                            Training_Required_Date=Training_Date.AddDays(Duation);
                            break;
                        case "Month":
                            Training_Required_Date=Training_Date.AddMonths(Duation);
                            break;
                        case "Year":
                            Training_Required_Date=Training_Date.AddYears(Duation);
                            break;
                    }

                    if (Training_Required_Date < DateTime.Now)
                    {

                        ret = Training_Date.ToString("dd-MMM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    }
                    else
                    {
                        ret = "OK";
                    }


                }
                else
                {
                    ret = "No Records";
                }

            }

        }
        else
        {

            string SQL_int = "SELECT* from MSAS_Position_Gap_Class_VW B where B.staff='" + staffid + "' and B.Course_Ref='" + course_ref + "'"
                  + " and Training_Date=(select max(A.Training_Date) from MSAS_Position_Gap_Class_VW A where A.Staff=B.Staff and A.Course_Ref=B.Course_Ref )";
            using (SqlDataReader rdr = SqlHelper1.ExecuteReader(sqlstr, CommandType.Text, SQL_int))
            {
                if (rdr.Read())
                {
                    ret = "OK";
                }
                else
                {
                    ret = "No Records";
                }

            }
        
        
        }


        return ret;

    }

    public bool checkposition(List<string> list, string position)
    {
        bool flag = false;
        foreach (string a in list)
        {
            if (a == position)
            {
                flag = true;
            }
        }
        return flag;

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");

    }
}