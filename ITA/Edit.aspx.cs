using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Globalization;//日期格式化
using System.Text.RegularExpressions;//分割符号
public partial class _Default : System.Web.UI.Page
{

    string sqlstr = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


 
  

    protected void savedata_Click(object sender, EventArgs e)
    {

        string savetext = Request.Form["savetxt"];
        string[] sArray = savetext.Split('|');
       
        foreach (string i in sArray)
        {
            if (i != "")            
            {
                string[] iArray = i.Split('~');

                using (SqlConnection sqlcnn = new SqlConnection(sqlstr))
                {
                    using (SqlCommand sqlcmm = sqlcnn.CreateCommand())
                    {

                        sqlcmm.CommandText = "INSERT INTO  ITA_Ag_List values(@id,@desc,@agd) ";
                        sqlcmm.Parameters.AddWithValue("@id", iArray[0]);
                        sqlcmm.Parameters.AddWithValue("@desc", iArray[1]);
                        sqlcmm.Parameters.AddWithValue("@agd", iArray[2]);
                        sqlcnn.Open();
                        int d = sqlcmm.ExecuteNonQuery();
                        if (d > 0)
                            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert success');</script>");
                        else
                            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Error01 , please contact the administrator');</script>");

                    }
                }  
            }
        
        

        }


    }



}