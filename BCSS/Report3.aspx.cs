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
        Chartlet1.MaxValueY = 3.5;
        Chartlet1.MinValueY = 1;
        

        if (Session["User_ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }       
        else

            Chartlet1.Visible = false;
            
            Label1.Text = "Welcome " + Session["User_Name"].ToString();

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Home.aspx");
    }

    public DataTable rowtocolumn(DataTable dt)
    {
        DataTable dtNew = new DataTable();
       
        //报表头 为第一行
        DataColumn dc1 = dt.Columns[0];
        dtNew.Columns.Add(dc1.ColumnName, typeof(string));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            string colname = dr[0].ToString();
            dtNew.Columns.Add(colname, typeof(string));
        }


        //其他列为 第二行
        int j = 0;
        foreach (DataColumn dc in dt.Columns)
        {
            if (j!=0)
            { 
                DataRow drNew = dtNew.NewRow();
                drNew[0] = dc.ColumnName.ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                
                    drNew[i+1 ] = dt.Rows[i][dc].ToString();
                }
                dtNew.Rows.Add(drNew);
            }
            j++;
        }
        return dtNew;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    
        string from = Request.Form["from"];     
        string to = Request.Form["to"];
        bool flag = true;
        if (from == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('From is request.');</script>");
            flag = false;
            GridView1.Visible = false;
            Chartlet1.Visible = false;
        }

        if (to == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('To is request.');</script>");
            flag = false;
            GridView1.Visible = false;
            Chartlet1.Visible = false;
        }

        if(flag)
        {

            string SQL_select =
             "select station as Station, SUM(BD.VAL_03),COUNT(BD.VAL_03), Convert(decimal(18,2),SUM(BD.VAL_03)*1.0/COUNT(BD.VAL_03)) Avg"
             + " from BCSS_DATE BD"
             + " where STATUS='NEW'"
             + " and BD.VAL_01<>0"
             + " and (CAST(DEP_DT AS date) between @from and @to)"
             + " group by station"
             + " order by station";
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@from", SqlDbType.Date),
                  new SqlParameter("@to", SqlDbType.Date)
            };
            parm[0].Value = from;
            parm[1].Value = to;
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("Station", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("Point", Type.GetType("System.String"));
            //DataColumn dc3 = new DataColumn("Point2", Type.GetType("System.String"));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            //dt.Columns.Add(dc3);
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL_select, parm))
            {
                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["Station"] = rdr["Station"].ToString();
                    dr["Point"] = rdr["Avg"].ToString();
                    // dr["point2"] = rdr["avg2"].ToString();
                    dt.Rows.Add(dr);
                }
            }


            if (dt.Rows.Count > 0)
            {
                DataTable dt1 = new DataTable();
                dt1 = rowtocolumn(dt);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                GridView1.Visible = true;
                Chartlet1.BindChartData(dt);
                Chartlet1.Visible = true;
               // Chartlet1.MaxValueY = 100;
               // Chartlet1.Shadow.Radius = 3;
                Chartlet1.ChartTitle.Text = "Avg Satisfaction for Question3";
                Chartlet1.YLabels.UnitText = "point";

            }
            else
            {
                GridView1.Visible = false;
                Chartlet1.Visible = false;
            }



        }

    }
 
}