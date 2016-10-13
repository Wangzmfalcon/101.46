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

public partial class Satisfaction : System.Web.UI.Page
{
    GridView gv = new GridView();
    protected void Page_Load(object sender, EventArgs e)
    {
        Chartlet1.MaxValueY = 100;
        Chartlet1.Shadow.Radius = 3;
        Chartlet1.ChartTitle.Text = "Satisfaction";
        Chartlet1.YLabels.UnitText = "%";
        Chartlet1.Visible = false;

        string SQL = "SELECT CAST(CONVERT(float, (SELECT COUNT(VAL_01) AS VAL_01t  FROM  BCSS_DATE WHERE (VAL_01 = 3))) / CONVERT(float, COUNT(VAL_01)) * 100 AS decimal(38, 2))  AS VAL1,CAST(CONVERT(float, (SELECT COUNT(VAL_02) AS VAL_02t  FROM  BCSS_DATE WHERE (VAL_02 = 3))) / CONVERT(float, COUNT(VAL_02)) * 100 AS decimal(38, 2)) AS VAL2,CAST(CONVERT(float, (SELECT COUNT(VAL_03) AS VAL_03t  FROM  BCSS_DATE WHERE (VAL_03 = 3))) / CONVERT(float, COUNT(VAL_03)) * 100 AS decimal(38, 2)) AS VAL3,CAST(CONVERT(float, (SELECT COUNT(VAL_04) AS VAL_04t  FROM  BCSS_DATE WHERE (VAL_04 = 3))) / CONVERT(float, COUNT(VAL_04)) * 100 AS decimal(38, 2)) AS VAL4,CAST(CONVERT(float, (SELECT COUNT(VAL_05) AS VAL_05t  FROM  BCSS_DATE WHERE (VAL_05 = 3))) / CONVERT(float, COUNT(VAL_05)) * 100 AS decimal(38, 2)) AS VAL5,CAST(CONVERT(float, (SELECT COUNT(VAL_06) AS VAL_06t  FROM  BCSS_DATE WHERE (VAL_06 = 3))) / CONVERT(float, COUNT(VAL_06)) * 100 AS decimal(38, 2)) AS VAL6,CAST(CONVERT(float, (SELECT COUNT(VAL_07) AS VAL_07t  FROM  BCSS_DATE WHERE (VAL_07 = 3))) / CONVERT(float, COUNT(VAL_07)) * 100 AS decimal(38, 2)) AS VAL7,CAST(CONVERT(float, (SELECT COUNT(VAL_08) AS VAL_08t  FROM  BCSS_DATE WHERE (VAL_08 = 3))) / CONVERT(float, COUNT(VAL_08)) * 100 AS decimal(38, 2)) AS VAL8,CAST(CONVERT(float, (SELECT COUNT(VAL_09) AS VAL_09t  FROM  BCSS_DATE WHERE (VAL_09 = 3))) / CONVERT(float, COUNT(VAL_09)) * 100 AS decimal(38, 2)) AS VAL9,CAST(CONVERT(float, (SELECT COUNT(VAL_10) AS VAL_10t  FROM  BCSS_DATE WHERE (VAL_10 = 3))) / CONVERT(float, COUNT(VAL_10)) * 100 AS decimal(38, 2)) AS VAL10,CAST(CONVERT(float, (SELECT COUNT(VAL_11) AS VAL_11t  FROM  BCSS_DATE WHERE (VAL_11 = 3))) / CONVERT(float, COUNT(VAL_11)) * 100 AS decimal(38, 2)) AS VAL11,CAST(CONVERT(float, (SELECT COUNT(VAL_12) AS VAL_12t  FROM  BCSS_DATE WHERE (VAL_12 = 3))) / CONVERT(float, COUNT(VAL_12)) * 100 AS decimal(38, 2)) AS VAL12,CAST(CONVERT(float, (SELECT COUNT(VAL_13) AS VAL_13t  FROM  BCSS_DATE WHERE (VAL_13 = 3))) / CONVERT(float, COUNT(VAL_13)) * 100 AS decimal(38, 2)) AS VAL13 FROM  BCSS_DATE AS BCSS_DATE_1 ";
        using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL))
        {
            while (reader.Read())
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("station", Type.GetType("System.String"));

                DataColumn dc3 = new DataColumn("Proportion", Type.GetType("System.Double"));
                dt.Columns.Add(dc1);

                dt.Columns.Add(dc3);
                for (int i = 0; i <= 12; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["station"] = "MFM";

                    dr["Proportion"] = reader[i];
                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
                Chartlet1.BindChartData(ds);
            }
            reader.Close();
        }   
    }
    protected void select(object sender, EventArgs e)
    {
                if (TextBox1.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.form1, this.GetType(), "click", "alert('please input start time')", true);
        }

        else if (TextBox2.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.form1, this.GetType(), "click", "alert('please input Termination time')", true);
        }
                else if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    //string from = Request.Form["from"];
                    //string to = Request.Form["to"];
                    string SQL =
                     "SELECT CAST(CONVERT(float, (SELECT COUNT(VAL_01) AS VAL_01t  FROM  BCSS_DATE WHERE (VAL_01 = 3)and STATUS='NEW' and (CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_01)) * 100 AS decimal(38, 2))  AS VAL1,CAST(CONVERT(float, (SELECT COUNT(VAL_02) AS VAL_02t  FROM  BCSS_DATE WHERE (VAL_02 = 3)and STATUS='NEW' and (CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_02)) * 100 AS decimal(38, 2)) AS VAL2,CAST(CONVERT(float, (SELECT COUNT(VAL_03) AS VAL_03t  FROM  BCSS_DATE WHERE (VAL_03 = 3)and STATUS='NEW' and (CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_03)) * 100 AS decimal(38, 2)) AS VAL3,CAST(CONVERT(float, (SELECT COUNT(VAL_04) AS VAL_04t  FROM  BCSS_DATE WHERE (VAL_04 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_04)) * 100 AS decimal(38, 2)) AS VAL4,CAST(CONVERT(float, (SELECT COUNT(VAL_05) AS VAL_05t  FROM  BCSS_DATE WHERE (VAL_05 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_05)) * 100 AS decimal(38, 2)) AS VAL5,CAST(CONVERT(float, (SELECT COUNT(VAL_06) AS VAL_06t  FROM  BCSS_DATE WHERE (VAL_06 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_06)) * 100 AS decimal(38, 2)) AS VAL6,CAST(CONVERT(float, (SELECT COUNT(VAL_07) AS VAL_07t  FROM  BCSS_DATE WHERE (VAL_07 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_07)) * 100 AS decimal(38, 2)) AS VAL7,CAST(CONVERT(float, (SELECT COUNT(VAL_08) AS VAL_08t  FROM  BCSS_DATE WHERE (VAL_08 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_08)) * 100 AS decimal(38, 2)) AS VAL8,CAST(CONVERT(float, (SELECT COUNT(VAL_09) AS VAL_09t  FROM  BCSS_DATE WHERE (VAL_09 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_09)) * 100 AS decimal(38, 2)) AS VAL9,CAST(CONVERT(float, (SELECT COUNT(VAL_10) AS VAL_10t  FROM  BCSS_DATE WHERE (VAL_10 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_10)) * 100 AS decimal(38, 2)) AS VAL10,CAST(CONVERT(float, (SELECT COUNT(VAL_11) AS VAL_11t  FROM  BCSS_DATE WHERE (VAL_11 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_11)) * 100 AS decimal(38, 2)) AS VAL11,CAST(CONVERT(float, (SELECT COUNT(VAL_12) AS VAL_12t  FROM  BCSS_DATE WHERE (VAL_12 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_12)) * 100 AS decimal(38, 2)) AS VAL12,CAST(CONVERT(float, (SELECT COUNT(VAL_13) AS VAL_13t  FROM  BCSS_DATE WHERE (VAL_13 = 3)and STATUS='NEW' and(CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'))) / CONVERT(float, COUNT(VAL_13)) * 100 AS decimal(38, 2)) AS VAL13 FROM  BCSS_DATE AS BCSS_DATE_1 where STATUS='NEW' and (CAST(DEP_DT AS date) between '" + TextBox1.Text + "' and '" + TextBox2.Text + "')";
                    //SqlParameter[] parm = new SqlParameter[]{
                    //        new SqlParameter("@from", SqlDbType.Date),
                    //          new SqlParameter("@to", SqlDbType.Date)
                    //    };
                    //parm[0].Value = from;
                    //parm[1].Value = to;
                    DataTable dt = new DataTable();
                    DataColumn dc1 = new DataColumn("station", Type.GetType("System.String"));
                    DataColumn dc2 = new DataColumn("Proportion", Type.GetType("System.Double"));

                    dt.Columns.Add(dc1);
                    dt.Columns.Add(dc2);

                    using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Conn1, CommandType.Text, SQL))
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i <= 12; i++)
                            {
                                DataRow dr = dt.NewRow();
                                dr["station"] = "MFM";

                                dr["Proportion"] = reader[i];
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                    DataTable dt1 = new DataTable();
                    dt1 = rowtocolumn(dt);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    Chartlet1.BindChartData(dt);
                    Chartlet1.Visible = true;

                }

    }
    public DataTable rowtocolumn(DataTable dt)
    {
        DataTable dtNew = new DataTable();
        dtNew.Columns.Add("ColumnName", typeof(string));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dtNew.Columns.Add("Column" + (i + 1).ToString(), typeof(string));
        }
        foreach (DataColumn dc in dt.Columns)
        {
            DataRow drNew = dtNew.NewRow();
            drNew["ColumnName"] = dc.ColumnName;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                drNew[i + 1] = dt.Rows[i][dc].ToString();
            }
            dtNew.Rows.Add(drNew);
        }
        return dtNew;
    }

}
