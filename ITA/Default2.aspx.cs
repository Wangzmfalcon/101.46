using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)  
        {  
            List<People> peopleList = new List<People>();  
            peopleList.Add(new People("韩兆新",24,Sex.男));  
            peopleList.Add(new People("XXXX", 25, Sex.女));  
            peopleList.Add(new People("YYYY", 20, Sex.男));  
            peopleList.Add(new People("ZZZZ", 23, Sex.男));  
            peopleList.Add(new People("AAAA", 23, Sex.女));  
            peopleList.Add(new People("BBBB", 18, Sex.女));  
  
            rptPeople.DataSource = peopleList;  
            rptPeople.DataBind();  
        }  
  
        protected void rptPeople_ItemDataBound(object sender, RepeaterItemEventArgs e)  
        {  
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)  
            {  
                List<string> literaryList = new List<string>();  
                literaryList.Add("《借我一生》");  
                literaryList.Add("《追风筝的人》");  
                literaryList.Add("《山居笔记》");  
                List<string> scientificList = new List<string>();  
                scientificList.Add("《时间简史》");  
                scientificList.Add("《果壳中的宇宙》");  
                scientificList.Add("《时空的未来》");  
                List<string> philosophicList = new List<string>();  
                philosophicList.Add("《周易正义》");  
                philosophicList.Add("《苏菲的世界》");  
                philosophicList.Add("《理想国》");  
  
                Repeater rptLiterary = e.Item.FindControl("rptLiterary") as Repeater;  
                rptLiterary.DataSource = literaryList;  
                rptLiterary.DataBind();  
                Repeater rptScientific = e.Item.FindControl("rptScientific") as Repeater;  
                rptScientific.DataSource = scientificList;  
                rptScientific.DataBind();  
                Repeater rptPhilosophic = e.Item.FindControl("rptPhilosophic") as Repeater;  
                rptPhilosophic.DataSource = philosophicList;  
                rptPhilosophic.DataBind();  
            }  
  
        }  
    }  
    public enum Sex  
    {   
        男 = 2,  
        女 = 1,  
    };  
    public class People  
    {  
        public People(string name, uint age, Sex sex)  
        {  
            this.Name = name;  
            this.Age = age;  
            this.Sex = sex;  
        }  
          
         
        public string Name  
        {get;set;}  
        public uint Age  
        { get; private set; }  
        public Sex Sex  
        { get; private set; }  
  


}