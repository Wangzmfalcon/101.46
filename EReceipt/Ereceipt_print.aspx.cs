using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


public partial class Ereceipt_print : System.Web.UI.Page
{
    public string Print_id = "";
    public string Station = "";
    public string Num = "";
    public string Deposit = "";
    public string Sales = "";
    public string username = "";
    public string Issue_Date = "";
    public string Received = "";
    public string RTNG = "";
    public string PNR = "";
    public string TTL = "";
    public string Remark = "";
    public string currency = "";
    public string cash = "";
    public string cheque = "";
    public string cheque_drawn = "";
    public string card = "";
    public string bank = "";
    public string Total_amt = "";
    public string Balance = "";
    public string English_tatal = "";
    public string cash_html_text = "";
    public string or_html_text = "";
    public string background_text = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Print_id = Request.QueryString["Print_id"];

        //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('" + Print_id + "');</script>");

        string SQL_query_all = "SELECT Station,Num,Deposit,Sales,username,Issue_Date,Received,RTNG,PNR,TTL,Remark,currency, convert(varchar, convert(money, isnull(cash,0)), 1),cheque,cheque_drawn,card,convert(varchar, convert(money, isnull(bank,0)), 1),convert(varchar, convert(money,isnull(Total_amt,0) ), 1),convert(varchar, convert(money,isnull(Balance,0) ), 1),finalize,void,offs  FROM ERS_Receipt  where id='" + Print_id + "' ";

        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query_all))
        {
            if (rdr.Read())
            {
                Station = Convert.ToString(rdr.GetSqlValue(0));
                Num =  string.Format("{0:d6}",Convert.ToInt32( Convert.ToString(rdr.GetSqlValue(1))));
                Deposit = Convert.ToString(rdr.GetSqlValue(2));
                Sales = Convert.ToString(rdr.GetSqlValue(3));
                username = Convert.ToString(rdr.GetSqlValue(4));
                Issue_Date = Convert.ToDateTime(Convert.ToString(rdr.GetSqlValue(5)).Trim()).ToString("yyyy/MM/dd");
                Received = Convert.ToString(rdr.GetSqlValue(6));
                RTNG = Convert.ToString(rdr.GetSqlValue(7));
                PNR = Convert.ToString(rdr.GetSqlValue(8));
                TTL = Convert.ToString(rdr.GetSqlValue(9));
                Remark = Convert.ToString(rdr.GetSqlValue(10));
                currency = Convert.ToString(rdr.GetSqlValue(11));
                cash = Convert.ToString(rdr.GetSqlValue(12));
                cheque = Convert.ToString(rdr.GetSqlValue(13));
                cheque_drawn = Convert.ToString(rdr.GetSqlValue(14));
                card = Convert.ToString(rdr.GetSqlValue(15));
                bank = Convert.ToString(rdr.GetSqlValue(16));
                Total_amt = Convert.ToString(rdr.GetSqlValue(17));
                Balance = Convert.ToString(rdr.GetSqlValue(18));
                string void_flag=Convert.ToString(rdr.GetSqlValue(20));
                if (void_flag == "True")
                {

                    background_text = "style=\"background: url(./images/VOID.jpg)0 10px no-repeat\"";
                
                }

            }
        }


        English_tatal = NumberToEnglishString(Convert.ToInt32(Math.Round(Convert.ToDecimal(Total_amt),0)))+" ONLY";

        Cash_html();
        OR_html();
    }



    public void Cash_html()
    {

        if (cash != "0.00" || card != " " || bank != "0.00")
        {
            cash_html_text = cash_html_text + " <div class=\"printline\"> ";
            if (cash != "0.00")
                cash_html_text = cash_html_text + "             <div class=\"col-md-4\">By cash &nbsp<u>" + currency + " " + cash + "</u></div>";
            if (card != " ")
                cash_html_text = cash_html_text + "            <div class=\"col-md-4\">By Credit card&nbsp<u>" + card + "</u></div>";
            if (bank != "0.00")
                cash_html_text = cash_html_text + "            <div class=\"col-md-4\">By Bank Transfer &nbsp<u>" + currency + " " + bank + "</u></div>";
            cash_html_text = cash_html_text + "        </div>";


        }

        if (cheque != " ")
        {
            cash_html_text = cash_html_text + " <div class=\"printline\">";
            cash_html_text = cash_html_text + "         <div class=\"col-md-5\">By cheque No.  &nbsp<u>" + cheque + "</u></div>";
            cash_html_text = cash_html_text + "       <div class=\"col-md-5\">Drawn on&nbsp<u>" + cheque_drawn + "</u></div>";
            cash_html_text = cash_html_text + "   </div>";
        }

    }

    public void OR_html()
    {

        string SQL_query_or = "   select A.Num1,convert(varchar, convert(money, B.Balance), 1) from ERS_OR A, ERS_Receipt B "
            + "   where A.Station='" + Station + "'"
            + "   and A.Num='" + Num + "'"
            + "   and A.Num1=B.Num"
            + "   and A.Station=B.Station"
            + "   order by A.order_id";
        string or_text = "";
        using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.Conn, CommandType.Text, SQL_query_or))
        {
            while (rdr.Read())
            {
                or_text = or_text + "<div class=\"col-md-4\">OR No.<u>" + string.Format("{0:d6}", Convert.ToInt32(Convert.ToString(rdr.GetSqlValue(0)))) + "</u>:&nbsp " + currency + "<u>" + Convert.ToString(rdr.GetSqlValue(1)) + "</u></div>";

            }
        }



        if (or_text != "")
        {
            or_html_text = or_html_text + "<div class=\"printline\" style=\"height: 10%\">";
            or_html_text = or_html_text + "<div class=\"OR\">";
            or_html_text = or_html_text + or_text;
            or_html_text = or_html_text + "</div>";
            or_html_text = or_html_text + "</div>";
            or_html_text = or_html_text + "<div class=\"printline\">";
            or_html_text = or_html_text + "<div>Balance:"+currency+" <u><b>"+Balance+"</b></u></div>";
            or_html_text = or_html_text + "</div>";

        }

    }

    static string NumberToEnglishString(int number)
    {
        if (number < 0) //暂不考虑负数
        {
            return "";
        }
        if (number < 20) //0到19
        {
            switch (number)
            {
                case 0:
                    return "ZERO";
                case 1:
                    return "ONE";
                case 2:
                    return "TWO";
                case 3:
                    return "THREE";
                case 4:
                    return "FOUR";
                case 5:
                    return "FIVE";
                case 6:
                    return "SIX";
                case 7:
                    return "SEVEN";
                case 8:
                    return "EIGHT";
                case 9:
                    return "NINE";
                case 10:
                    return "TEN";
                case 11:
                    return "ELEVEN";
                case 12:
                    return "TWELVE";
                case 13:
                    return "THIRTEEN";
                case 14:
                    return "FOURTEEN";
                case 15:
                    return "FIFTEEN";
                case 16:
                    return "SIXTEEN";
                case 17:
                    return "SEVENTEEN";
                case 18:
                    return "EIGHTEEN";
                case 19:
                    return "NINETEEN";
                default:
                    return "";
            }
        }
        if (number < 100) //20到99
        {
            if (number % 10 == 0) //20,30,40,...90的输出
            {
                switch (number)
                {
                    case 20:
                        return "TWENTY";
                    case 30:
                        return "THIRTY";
                    case 40:
                        return "FORTY";
                    case 50:
                        return "FIFTY";
                    case 60:
                        return "SIXTY";
                    case 70:
                        return "SEVENTY";
                    case 80:
                        return "EIGHTY";
                    case 90:
                        return "NINETY";
                    default:
                        return "";
                }
            }
            else //21.22,....99 思路：26=20+6
            {
                return string.Format("{0} {1}", NumberToEnglishString(10 * (number / 10)),
                    NumberToEnglishString(number % 10));
            }
        }
        if (number < 1000) //100到999  百级
        {
            if (number % 100 == 0)
            {
                return string.Format("{0} HUNDRED", NumberToEnglishString(number / 100));
            }
            else
            {
                return string.Format("{0} HUNDRED AND {1}", NumberToEnglishString(number / 100),
                    NumberToEnglishString(number % 100));
            }
        }
        if (number < 1000000) //1000到999999 千级
        {
            if (number % 1000 == 0)
            {
                return string.Format("{0} THOUSAND", NumberToEnglishString(number / 1000));
            }
            else
            {
                return string.Format("{0} THOUSAND AND {1}", NumberToEnglishString(number / 1000),
                    NumberToEnglishString(number % 1000));
            }
        }
        if (number < 1000000000) //1000 000到999 999 999 百万级
        {
            if (number % 1000 == 0)
            {
                return string.Format("{0} MILLION", NumberToEnglishString(number / 1000000));
            }
            else
            {
                return string.Format("{0} MILLION AND {1}", NumberToEnglishString(number / 1000000),
                    NumberToEnglishString(number % 1000000));
            }
        }
        if (number <= int.MaxValue) //十亿 级
        {
            if (number % 1000000000 == 0)
            {
                return string.Format("{0} BILLION", NumberToEnglishString(number / 1000000000));
            }
            else
            {
                return string.Format("{0} BILLION AND {1}", NumberToEnglishString(number / 1000000000),
                    NumberToEnglishString(number % 1000000000));
            }
        }
        return "";
    }

}