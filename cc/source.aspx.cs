using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


public partial class source : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strtemp;

        strtemp = GetURLContent("http://flight.qunar.com/site/oneway_list_inter.htm?searchDepartureAirport=%E6%BE%B3%E9%97%A8&searchArrivalAirport=%E5%8C%97%E4%BA%AC&searchDepartureTime=2013-08-21&searchArrivalTime=2013-08-24&nextNDays=0&startSearch=true&from=qunarindex", "utf-8");
        Response.Write(strtemp);
    }

    string GetURLContent(string url, string EncodingType)
    {
        string PetiResp = "";
        Stream mystream;
        //"http://www.baidu.com"
        //"utf-8"
        System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
        req.AllowAutoRedirect = true;
        System.Net.HttpWebResponse resp = (System.Net.HttpWebResponse)req.GetResponse();
        if (resp.StatusCode == System.Net.HttpStatusCode.OK)
        {
            mystream = resp.GetResponseStream();
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding(EncodingType);
            StreamReader readStream = new StreamReader(mystream, encode);
            char[] cCont = new char[500];
            int count = readStream.Read(cCont, 0, 256);
            while (count > 0)
            {
                // Dumps the 256 characters on a string and displays the string to the console.
                String str = new String(cCont, 0, count);
                PetiResp += str;
                count = readStream.Read(cCont, 0, 256);
            }
            resp.Close();
            return PetiResp;

        }
        resp.Close();
        return null;
    }

}