using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SMS.DBUtility;
using System.Data;
using System.Data.OleDb;
using System.IO;
public partial class dropdownlistduoxuan_ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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

            this.lstssdd.DataSource = dt;
            this.lstssdd.DataTextField = "StaffNo(StaffName)";
            this.lstssdd.DataValueField = "StaffNo(StaffName)";
            this.lstssdd.DataBind();
        }
    }
    protected void btnssdd_Click(object sender, EventArgs e)
    {
        string s="";
        //foreach (ListItem li in lstssdd.Items)
        //{
        //    if (li.Selected)    //表示某一项被选中了 
        //    {
        //        s = li.Value + "\n";
        //        //li.Value表示看到的值对应的值.对应上面的lngCatalogID 
        //    }
        //}

        for (int i = 0; i < lstssdd.Items.Count; i++)
        {
            if (lstssdd.Items[i].Selected)
                s += lstssdd.Items[i].Value + "//";

        }

        Label1.Text = s;
       
      
    }
}