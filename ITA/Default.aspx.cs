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
using System.Xml.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Globalization;//日期格式化
public partial class _Default : System.Web.UI.Page
{

    string sqlstr = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Search(object sender, EventArgs e)
    {
        reflash();

    }


    public void reflash()
    {
        using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
        {
            using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
            {
                string SQL = "select Seq,Ag_id,Description,CONVERT(varchar(100), Ag_Expire_date, 105) Ag_Expire_date from ITA_Ag_List where 1=1 ";
                if (Ag_id.Value.ToString().Trim() != "")
                    SQL += "and Ag_id like'%" + Ag_id.Value.ToString().Trim() + "%'";
                if (Desr.Value.ToString().Trim() != "")
                    SQL += "and Description like'%" + Desr.Value.ToString().Trim() + "%'";
                if (datepicker1.Value.ToString().Trim() != "")
                    SQL += "and Ag_Expire_date='" + datepicker1.Value.ToString().Trim() + "'";

                sqlcmm.CommandText = SQL;
                sqlcnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                this.Ag_table.DataSource = dt;
                this.Ag_table.DataBind();

            }
        }
    
    }




    protected void cmd(object sender, EventArgs e)
    {
        if (EC.Text == "edit")
        {
            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "update ITA_Ag_List set Ag_id=@id,Description=@desc,Ag_Expire_date=@agd where Seq=@seq";
                    sqlcmm.Parameters.AddWithValue("@id", EID.Text.ToString());
                    sqlcmm.Parameters.AddWithValue("@desc", ED.Text.ToString());
                    sqlcmm.Parameters.AddWithValue("@agd", EED.Text);
                    sqlcmm.Parameters.AddWithValue("@seq", ES.Text.ToString());
            
               
                sqlcnn.Open();
                int i = sqlcmm.ExecuteNonQuery();
                if (i > 0)
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Update success');</script>");
                else
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Error01 , please contact the administrator');</script>");

                }
            }
            reflash();

        }      
        else if (EC.Text == "del")
        {


            using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
            {
                using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                {
                    sqlcmm.CommandText = "delete ITA_Ag_List where Seq=@seq";
                    sqlcmm.Parameters.AddWithValue("@seq", ES.Text.ToString());


                    sqlcnn.Open();
                    int i = sqlcmm.ExecuteNonQuery();
                    if (i > 0)
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete success');</script>");

                    else
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Error02 , please contact the administrator');</script>");

                }
            }
            reflash();

         
        
        }
        else
        {
        
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Error , please contact the administrator');</script>");

        }


    }
    public string trstyle(int i)
    {
        string ret_s ="";

        DateTime today = DateTime.Now;
        string expired = Eval("Ag_Expire_date").ToString();
        DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo(); //设置日期转换格式
        dtFormat.ShortDatePattern = "dd-MM-yyyy";
        if (Convert.ToDateTime(expired, dtFormat) < today)
        {
            ret_s = "<tr class=\"warning\">" +
                         "<td id=\"agseq" +i + "\" style=\"display:none\" >" + Eval("Seq") + "</td>" +
                         "<td id=\"agid" + i + "\">" + Eval("Ag_id") + "</td>" +
                         "<td id=\"agdesc" +i + "\">" + Eval("Description") + "</td>" +
                         "<td id=\"aged" + i + "\">" + Eval("Ag_Expire_date") + "</td>";
         

        }
        else
        {
            ret_s = "<tr>" +
                       "<td id=\"agseq" + i + "\"   style=\"display:none\">" + Eval("Seq") + "</td>" +
                       "<td id=\"agid" + i + "\">" + Eval("Ag_id") + "</td>" +
                       "<td id=\"agdesc" + i + "\">" + Eval("Description") + "</td>" +
                       "<td id=\"aged" + i + "\">" + Eval("Ag_Expire_date") + "</td>";
                 
        }

        

        return ret_s;
    }

    public string tdstyle(object ob)
    {
        string ret_s = "";
        if (ob == DBNull.Value)
        {
            return "--";
        }
        else
        {
            ret_s = "<td class=\"success\">"+ob.ToString() +"</td>";
            return ret_s;
        }

    }

    //protected void Del(object sender, EventArgs e)
    //{
    //    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + Eval("Ag_id") + "');</script>");

    //}
}