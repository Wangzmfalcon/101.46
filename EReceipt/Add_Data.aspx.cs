using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
public partial class Add_Data : System.Web.UI.Page
{

    public string strpagetitle = "";
    string id = "";
    string offs = "";
    public string balance_Text = "0";
    protected void Page_Load(object sender, EventArgs e)
    {    //获得id  如果id=null 就是新建

        id = Request["id"];
        if (id == null)//新建
        {
            strpagetitle = "Add Data";
        }
        else
        {
            strpagetitle = "Edit Data";
        }



        if (Session["Manage_Level"] == null || Session["UserID"] == null || Session["Receipt"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else if (!IsPostBack)
        {
            //添加下拉选项


            //权限管理
            if (Session["Station"] == null || Session["Station"].ToString() == "")
            {

                Response.Write("<script>alert('You have no authorization to view this page , please contact the administrator')</script>");
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('You have no authorization to view this page , please contact the administrator');</script>");
                Server.Transfer("Home.aspx");
            }

            string stationsession = Session["Station"].ToString();
            string SQL_query0 = "";
            if (stationsession == "ALL")
            {

              
                 SQL_query0 = "select STATION from ERS_STATION ";
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query0))
                {
                    while (rdr.Read())
                    {
                        Station.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                    }

                }
            }
            else 
            {

                string SQL_Station = "Select Station from ERS_Range where  User_Id ='" + Session["UserID"] .ToString()+ "'";

                using (SqlDataReader rdr_station = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_Station))
                {
                    while (rdr_station.Read())
                    {
                        Station.Items.Add(Convert.ToString(rdr_station.GetSqlValue(0)));
                    }
                }


            }
            //Deposit.Items.Add("");
            // SQL_query0 = "select Trans_Value from ERS_Trans where Trans_Type='Deposit'  order by Trans_Order ";
            //using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query0))
            //{
            //    while (rdr.Read())
            //    {
            //        Deposit.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
            //    }

            //}


            //Sales.Items.Add("");
            //SQL_query0 = "select Trans_Value from ERS_Trans where Trans_Type='Sales'  order by Trans_Order ";
            //using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query0))
            //{
            //    while (rdr.Read())
            //    {
            //        Sales.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
            //    }

            //}
            string selectstation = Station.SelectedItem.Value;
            string wherestation = "";
            if (selectstation != "")
                wherestation = " and Trans_Station='" + selectstation + "'";

            Sales.Items.Clear();

            Sales.Items.Add("");
            string SQL_query = "select Trans_Value from ERS_Trans where Trans_Type='Sales'" + wherestation + "  order by Trans_Order";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
            {
                while (rdr.Read())
                {
                    Sales.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                }

            }


            Deposit.Items.Clear();
            Deposit.Items.Add("");
            string SQL_query1 = "select Trans_Value from ERS_Trans where Trans_Type='Deposit' " + wherestation + "  order by Trans_Order";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query1))
            {
                while (rdr.Read())
                {
                    Deposit.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                }

            }




            Currency.Items.Clear();
            SQL_query1 = "select Trans_Value from ERS_Trans where Trans_Type='Currency'  " + wherestation + "    order by Trans_Order";
            using (SqlDataReader rdr1 = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query1))
            {
                while (rdr1.Read())
                {
                    Currency.Items.Add(Convert.ToString(rdr1.GetSqlValue(0)));
                }

            }
            //权限管理
            //string stationsession = Session["Station"].ToString();
            //if (stationsession != "ALL")
            //{
            //    Station.SelectedValue = stationsession;
            //    Station.Enabled = false;
            //    Station.BackColor = ColorTranslator.FromHtml("#f9f9f9");
            //}


            //Num.Attributes["ReadOnly"] = "false";
            //Num.Enabled = false;
            Num.BackColor = ColorTranslator.FromHtml("#f9f9f9");



        

            if (id == null)//新建
            {




                //if (stationsession != "ALL")
                //{
                    string SQL_query_num = "select max(Num) from ERS_Receipt where Station='" + Station.Text + "'";
                    using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query_num))
                    {
                        if (rdr.Read())
                        {

                            if (Convert.ToString(rdr.GetSqlValue(0)) == "NULL" || Convert.ToString(rdr.GetSqlValue(0)) == "Null")
                                Num.Text = "1";
                            else
                            {
                                int R_num = Convert.ToInt16(Convert.ToString(rdr.GetSqlValue(0)));
                                R_num = R_num + 1;
                                Num.Text = R_num.ToString();
                            }
                        }

                    }
                //}



                Issue.Text = DateTime.Now.ToShortDateString();
                Issue.Enabled = false;
                Issue.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                Print.Visible = false;

            }
            else
            {
                //非新建

                Reset.Visible = false;

                string SQL_query_all = "SELECT id,Station,Num,Deposit,Sales,username,Issue_Date,Received,RTNG,PNR,TTL,Remark,currency,cash,cheque,cheque_drawn,card,bank,Total_amt,Balance,finalize,void,offs  FROM ERS_Receipt  where id='" + id + "'";

                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query_all))
                {
                    if (rdr.Read())
                    {


                        Station.SelectedValue = Convert.ToString(rdr.GetSqlValue(1)).Trim();

                        //如果是修改，要重新查询下拉框
                        Sales.Items.Clear();
                        Sales.Items.Add("");
                        SQL_query = "select Trans_Value from ERS_Trans where Trans_Type='Sales' and Trans_Station='" + Convert.ToString(rdr.GetSqlValue(1)).Trim() + "'  order by Trans_Order";
                        using (SqlDataReader rdr1 = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
                        {
                            while (rdr1.Read())
                            {
                                Sales.Items.Add(Convert.ToString(rdr1.GetSqlValue(0)));
                            }

                        }

                        Deposit.Items.Clear();
                        Deposit.Items.Add("");
                        SQL_query1 = "select Trans_Value from ERS_Trans where Trans_Type='Deposit' and Trans_Station='" + Convert.ToString(rdr.GetSqlValue(1)).Trim() + "'  order by Trans_Order";
                        using (SqlDataReader rdr1 = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query1))
                        {
                            while (rdr1.Read())
                            {
                                Deposit.Items.Add(Convert.ToString(rdr1.GetSqlValue(0)));
                            }

                        }
                        

                        Currency.Items.Clear();
                        SQL_query1 = "select Trans_Value from ERS_Trans where Trans_Type='Currency' and Trans_Station='" + Convert.ToString(rdr.GetSqlValue(1)).Trim() + "'  order by Trans_Order";
                        using (SqlDataReader rdr1 = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query1))
                        {
                            while (rdr1.Read())
                            {
                                Currency.Items.Add(Convert.ToString(rdr1.GetSqlValue(0)));
                            }

                        }

                        Station.Enabled = false;
                        Station.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                        Num.Text = Convert.ToString(rdr.GetSqlValue(2));
                        string a = Convert.ToString(rdr.GetSqlValue(3));
                        Deposit.SelectedValue = Convert.ToString(rdr.GetSqlValue(3)).Trim();
                        Sales.SelectedValue = Convert.ToString(rdr.GetSqlValue(4)).Trim();
                        Issue.Text = Convert.ToDateTime(rdr.GetSqlValue(6)).ToShortDateString();
                        Issue.Enabled = false;
                        Issue.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                        Received.Text = Convert.ToString(rdr.GetSqlValue(7));
                        RTNG.Text = Convert.ToString(rdr.GetSqlValue(8));
                        PNR.Text = Convert.ToString(rdr.GetSqlValue(9));
                        TTL.Text = Convert.ToString(rdr.GetSqlValue(10));
                        Remark.Text = Convert.ToString(rdr.GetSqlValue(11));
                        Currency.SelectedValue = Convert.ToString(rdr.GetSqlValue(12)).Trim();
                        cash.Text = Convert.ToString(rdr.GetSqlValue(13));
                        Cheque.Text = Convert.ToString(rdr.GetSqlValue(14));
                        Drawn.Text = Convert.ToString(rdr.GetSqlValue(15));
                        card.Text = Convert.ToString(rdr.GetSqlValue(16));
                        bank.Text = Convert.ToString(rdr.GetSqlValue(17));
                        Amount.Text = Convert.ToString(rdr.GetSqlValue(18));
                        Balance.Text = Convert.ToString(rdr.GetSqlValue(19));
                        //Balance1.Text = Convert.ToString(rdr.GetSqlValue(19));
                        balance_Text = Convert.ToString(rdr.GetSqlValue(19));


                        string finalize = Convert.ToString(rdr.GetSqlValue(20));
                        string voidflag = Convert.ToString(rdr.GetSqlValue(21));
                        offs = Convert.ToString(rdr.GetSqlValue(22));
                        if (finalize == "True" || voidflag == "True")
                        {
                            //已经打印或者 void的 不允许修改

                            if (finalize == "True")
                                strpagetitle = "Finalized";
                            else strpagetitle = "Void";


                            Station.Enabled = false;
                            Station.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            Deposit.Enabled = false;
                            Deposit.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            Sales.Enabled = false;
                            Sales.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            Received.Enabled = false;
                            Received.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            RTNG.Enabled = false;
                            RTNG.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            PNR.Enabled = false;
                            PNR.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            TTL.Enabled = false;
                            TTL.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            Remark.Enabled = false;
                            Remark.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            Currency.Enabled = false;
                            Currency.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            cash.Enabled = false;
                            cash.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            Cheque.Enabled = false;
                            Cheque.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            Drawn.Enabled = false;
                            Drawn.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            card.Enabled = false;
                            card.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            bank.Enabled = false;
                            bank.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            Amount.Enabled = false;
                            Amount.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            //Balance.Enabled = false;
                            Balance.BackColor = ColorTranslator.FromHtml("#f9f9f9");



                            OR1.Enabled = false;
                            OR1.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            OR2.Enabled = false;
                            OR2.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            OR3.Enabled = false;
                            OR3.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            OR4.Enabled = false;
                            OR4.BackColor = ColorTranslator.FromHtml("#f9f9f9");
                            OR5.Enabled = false;
                            OR5.BackColor = ColorTranslator.FromHtml("#f9f9f9");



                            Save.Visible = false;

                        }


                    }
                }


                string SQL_query_OR = " select Station,Num,Num1 from ERS_OR" +
                    " where 1=1 and Station='" + Station.SelectedValue + "'" +
                    " AND Num='" + Num.Text + "'" +
                    " order by order_id";

                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query_OR))
                {
                    int ornum = 1;
                    while (rdr.Read())
                    {
                        switch (ornum)
                        {
                            case 1:
                                OR1.Text = Convert.ToString(rdr.GetSqlValue(2));
             
                                amt1.Text = getorbalance(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));
                                cur1.Text = getorcurrency(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));
                                break;
                            case 2:
                                OR2.Text = Convert.ToString(rdr.GetSqlValue(2));
                                amt2.Text = getorbalance(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));
                                cur2.Text = getorcurrency(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));

                                break;
                            case 3:
                                OR3.Text = Convert.ToString(rdr.GetSqlValue(2));
                                amt3.Text = getorbalance(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));
                                cur3.Text = getorcurrency(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));
                                break;
                            case 4:
                                OR4.Text = Convert.ToString(rdr.GetSqlValue(2));
                                amt4.Text = getorbalance(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));
                                cur4.Text = getorcurrency(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));
                                break;
                            case 5:
                                OR5.Text = Convert.ToString(rdr.GetSqlValue(2));
                                amt5.Text = getorbalance(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));
                                cur5.Text = getorcurrency(Station.SelectedValue, Convert.ToString(rdr.GetSqlValue(2)));
                                break;


                        }

                        ornum++;
                    }
                }


            }


        }
       
        Save.Attributes.Add("onclick", "return savecheck()");
    }




    public string getorbalance(string station, string Num)
    {
        string balance = "";

        string Sql_balance = "select Balance from ERS_Receipt where Station ='" + station + "'  and  Num='" + Num + "' ";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, Sql_balance))
        {

            if (rdr.Read())
            {
                balance = Convert.ToString(rdr.GetSqlValue(0));
            }
        }
        return balance;
    }



    public string getorcurrency(string station, string Num)
    {
        string balance = "";

        string Sql_balance = "select currency from ERS_Receipt where Station ='" + station + "'  and  Num='" + Num + "' ";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, Sql_balance))
        {

            if (rdr.Read())
            {
                balance = Convert.ToString(rdr.GetSqlValue(0));
            }
        }
        return balance;
    }
    protected void Station_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            string selectstation = Station.SelectedItem.Value;
            string wherestation = "";
            if (selectstation != "")
                wherestation = " and Trans_Station='" + selectstation + "'";

            Sales.Items.Clear();

            Sales.Items.Add("");
            string SQL_query = "select Trans_Value from ERS_Trans where Trans_Type='Sales'" + wherestation + "  order by Trans_Order";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query))
            {
                while (rdr.Read())
                {
                    Sales.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                }

            }


            Deposit.Items.Clear();
            Deposit.Items.Add("");
            string SQL_query1 = "select Trans_Value from ERS_Trans where Trans_Type='Deposit' " + wherestation + "  order by Trans_Order";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query1))
            {
                while (rdr.Read())
                {
                    Deposit.Items.Add(Convert.ToString(rdr.GetSqlValue(0)));
                }

            }



              Currency.Items.Clear();
            SQL_query1 = "select Trans_Value from ERS_Trans where Trans_Type='Currency'  " + wherestation + "    order by Trans_Order";
            using (SqlDataReader rdr1 = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query1))
            {
                while (rdr1.Read())
                {
                    Currency.Items.Add(Convert.ToString(rdr1.GetSqlValue(0)));
                }

            }


            string SQL_query_num = "select max(Num) from ERS_Receipt where Station='" + selectstation + "'";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query_num))
            {
                if (rdr.Read())
                {

                    if (Convert.ToString(rdr.GetSqlValue(0)) == "NULL" || Convert.ToString(rdr.GetSqlValue(0)) == "Null")
                        Num.Text = "1";
                    else
                    {
                        int R_num = Convert.ToInt16(Convert.ToString(rdr.GetSqlValue(0)));
                        R_num = R_num + 1;
                        Num.Text = R_num.ToString();
                    }
                }

            }

      

    }
    protected void Save_Click(object sender, EventArgs e)
    {

        if (id == null)//新建
        {

            string stationsession_text = Station.Text;
            string number_text = Num.Text;
            //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Add');</script>");
            //删除
            string SQL_delete = " delete from  ERS_Receipt where  Station='"+stationsession_text+"' and Num='"+number_text+"'";
            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_delete);
                if (actionrows > 0)
                {
                    //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data success');</script>");

                }
                else
                {
                    //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Delete data faild');</script>");
                }
            }

            //添加 recipt
            string sql_insert = " INSERT INTO ERS_Receipt" +
                " (Station,Num,Deposit,Sales,username,Issue_Date,Received,RTNG,PNR,TTL,Remark,currency,cash,cheque,cheque_drawn,card,bank,Total_amt,Balance,finalize,void,offs)"
                + " Values(";
            sql_insert += "'" + Station.Text + " '";
            sql_insert += ",'" + Num.Text + " '";
            sql_insert += ",'" + Deposit.SelectedValue + " '";
            sql_insert += ",'" + Sales.SelectedValue + " '";
            sql_insert += ",'" + Session["ERS_User"].ToString() + " '";
            sql_insert += ",'" + Issue.Text + " '";
            sql_insert += ",N'" + Received.Text + " '";
            sql_insert += ",'" + RTNG.Text + " '";
            sql_insert += ",'" + PNR.Text + " '";
            sql_insert += ",'" + TTL.Text + " '";
            sql_insert += ",N'" + Remark.Text + " '";
            sql_insert += ",'" + Currency.SelectedValue + " '";
            if (cash.Text == "")
            { sql_insert += ",0 "; }
            else
            { sql_insert += ",'" + cash.Text + "' "; }
            sql_insert += ",'" + Cheque.Text + " '";
            sql_insert += ",'" + Drawn.Text + " '";
            sql_insert += ",'" + card.Text + " '";
            sql_insert += ",'" + bank.Text + " '";
            if (Amount.Text == "")
            { sql_insert += ",0 "; }
            else
            { sql_insert += ",'" + Amount.Text + "' "; }
            if (Balance.Text == "")
            { sql_insert += ",0 "; }
            else
            { sql_insert += ",'" + Balance.Text + "' "; }


            sql_insert += ",0,0,0)";

            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_insert);
                if (actionrows > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data success');</script>");

                    writelog("New Receipt,Station:" + Station.Text + ",Num:" + Num.Text);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Insert data faild');</script>");
                }
            }
     
            //添加引用
            if (OR1.Text.Trim() != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR1.Text + "',1)";

                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }

                string sql_update = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR1.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }

            }
            if (OR2.Text.Trim() != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR2.Text + "',2)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }

                string sql_update = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR2.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }


            }
            if (OR3.Text.Trim() != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR3.Text + "',3)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }
                string sql_update = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR3.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }

            }
            if (OR4.Text.Trim() != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR4.Text + "',4)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }
                string sql_update = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR4.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }

            }
            if (OR5.Text.Trim() != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR5.Text + "',5)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }
                string sql_update = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR5.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }

            }

            string SQL_query_all = "SELECT id,Station,Num,Deposit,Sales,username,Issue_Date,Received,RTNG,PNR,TTL,Remark,currency,cash,cheque,cheque_drawn,card,bank,Total_amt,Balance,finalize,void,offs  FROM ERS_Receipt  where Station='"+stationsession_text+"'  and Num='"+number_text+"'";
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query_all))
            {
                if (rdr.Read())
                {
                    balance_Text = Convert.ToString(rdr.GetSqlValue(19));


                }
            }

        }
        else
        {
            //修改

            string sql_update = " UPDATE ERS_Receipt";
            sql_update += " set  Station='" + Station.Text + "'";
            sql_update += ",Num='" + Num.Text + "'";
            sql_update += ",Deposit='" + Deposit.SelectedValue + "'";

            sql_update += ",Sales='" + Sales.SelectedValue + "'";
            sql_update += ",username='" + Session["ERS_User"].ToString() + "'";
            sql_update += ",Issue_Date='" + Issue.Text + "'";
            sql_update += ",Received=N'" + Received.Text + "'";
            sql_update += ",RTNG='" + RTNG.Text + "'";
            sql_update += ",PNR='" + PNR.Text + "'";
            sql_update += ",TTL='" + TTL.Text + "'";
            sql_update += ",Remark=N'" + Remark.Text + "'";
            sql_update += ",currency='" + Currency.SelectedValue + "'";
            if (cash.Text == "")
            { sql_update += ",cash=0"; }
            else
            { sql_update += ",cash='" + cash.Text + "'"; }

            sql_update += ",cheque='" + Cheque.Text + "'";
            sql_update += ",cheque_drawn='" + Drawn.Text + "'";
            sql_update += ",card='" + card.Text + "'";
            sql_update += ",bank='" + bank.Text + "'";
            if (Amount.Text == "")
            { sql_update += ",Total_amt=0"; }
            else
            { sql_update += ",Total_amt='" + Amount.Text + "'"; }
            if (Balance.Text == "")
            { sql_update += ",Balance=0"; }
            else
            { sql_update += ",Balance='" + Balance.Text + "'"; }



            sql_update += " ,finalize=0,void=0,offs='" + offs + "'";
            sql_update += " where id='" + id + "'";


            using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
            {
                int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                if (actionrows > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Update data success');</script>");
                    writelog("Update,Station:" + Station.Text + ",Num:" + Num.Text);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Update data faild');</script>");
                }
            }
          


            //update OR
            string sql_del_or = " delete ERS_OR where Station ='" + Station.Text + "'  and Num='" + Num.Text + "'";
                  using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_del_or);
                }

            if (OR1.Text != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR1.Text + "',1)";

                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }

                string sql_update_or = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR1.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }

            }
            if (OR2.Text != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR2.Text + "',2)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }

                string sql_update_or = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR2.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }


            }
            if (OR3.Text != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR3.Text + "',3)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }
                string sql_update_or = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR3.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }

            }
            if (OR4.Text != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR4.Text + "',4)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }
                string sql_update_or = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR4.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }

            }
            if (OR5.Text != "")
            {
                string sql_or = " insert into ERS_OR (Station,Num,Num1,order_id)";
                sql_or += " values('" + Station.Text + "','" + Num.Text + "','" + OR5.Text + "',5)";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_or);
                }
                string sql_update_or = "update ERS_Receipt set offs=1 where Station ='" + Station.Text + "'  and Num='" + OR5.Text + "'";
                using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
                {
                    int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql_update);
                }

            }
           

        }

     
        string SQL_query_all_1 = "SELECT id,Station,Num,Deposit,Sales,username,Issue_Date,Received,RTNG,PNR,TTL,Remark,currency,cash,cheque,cheque_drawn,card,bank,Total_amt,Balance,finalize,void,offs  FROM ERS_Receipt  where id='" + id + "'";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query_all_1))
        {
            if (rdr.Read())
            {
                balance_Text = Convert.ToString(rdr.GetSqlValue(19));

            
            }
        }


    }
    protected void Print_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "message", "<script>window.open('Ereceipt_print.aspx?Print_id=" + id+"','_blank')</script>");
    }





    public void writelog(string logtext) {
        string SQL_insert = "INSERT INTO ERS_Log (User_Id,Log_Time,Log_IP,Sys_Log) values(@User_Id,@Log_Time,@Log_IP,@Sys_Log)";
        SqlParameter[] parms = new SqlParameter[]{
                    new SqlParameter("@User_Id", SqlDbType.VarChar, 50),
                    new SqlParameter("@Log_Time", SqlDbType.DateTime),
                    new SqlParameter("@Log_IP", SqlDbType.VarChar, 50),
                    new SqlParameter("@Sys_Log", SqlDbType.VarChar, 100),
   
                 };
        parms[0].Value = Session["UserID"].ToString();
        parms[1].Value = DateTime.Now;
        parms[2].Value = Session["IP"].ToString();
        parms[3].Value = logtext;
        using (SqlConnection conn = new SqlConnection(SqlHelper.Conn))
        {
            int actionrows = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_insert, parms);
            if (actionrows > 0)
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