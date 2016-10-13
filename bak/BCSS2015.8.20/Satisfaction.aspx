<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Satisfaction.aspx.cs" Inherits="Satisfaction" %>

<%@ Register src="Airmacau.ascx" tagname="Airmacau1" tagprefix="uc1" %>

<%@ Register assembly="Chartlet" namespace="FanG" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="zh-CN" /> 
<meta name="author" content="Airmacau/ITD" /> 
<meta name="Copyright" content="Airmacau" /> 
<meta name="description" content="Airmacau" />
<meta name="keywords" content="Airmacau"  />
 <!--css-->
<link href="css/style.css" rel="stylesheet" type="text/css" />


 <!--js-->

       <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
  <script type="text/javascript">
      function getdata() {
          var flag = true;
          var str1 = document.getElementById("from").value;
          if (!str1) {
              alert("from is required");
              flag = false

          }
          var str = document.getElementById("to").value;
          if (!str) {
              alert("to is required");
              flag = false

          }
          if (flag) {
              document.getElementById("Button1").click();
          }
      }

      </script>
    <title>Home</title>
    

</head>

<body>

    <form id="form1" runat="server">

<div id="backpanel">
<uc1:Airmacau1 ID="Airmacau1" runat="server"/>

<div id="pagebody">


<div id="Contentpanel">
<div id="linkweb" style=" float:left; width:500px; height:25px;font-size:14px;">
</div>
<script>    setInterval("linkweb.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());", 1000);
</script>
    
<div id="welcome" style="width:500px; height:25px;text-align:right; font-size:14px; float:left;">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</div>

<div id="updatelog" style="width: 950px; margin-left:50px">
<h1>&nbsp;</h1>
    <div >  
        <hr/>  
        
        &nbsp;
        <asp:TextBox ID="TextBox1" runat="server" onClick="WdatePicker({maxDate:'%y-%M-%d'})"></asp:TextBox>  
        <img onclick="WdatePicker({maxDate:'%y-%M-%d',el:$dp.$('TextBox1')})" 
src="My97DatePicker/skin/datePicker.gif" mce_src="My97DatePicker/skin/datePicker.gif" width="16" height="22" 
align="absmiddle">  &nbsp;
           <asp:TextBox ID="TextBox2" runat="server" onClick="WdatePicker()"></asp:TextBox>  
        <img onclick="WdatePicker({el:$dp.$('TextBox2')})" src="My97DatePicker/skin/datePicker.gif" 
mce_src="My97DatePicker/skin/datePicker.gif" width="16" height="22" 
align="absmiddle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
    <asp:Button ID="Button2" runat="server" Text="Search" OnClick="select"/>
    &nbsp;&nbsp;&nbsp;

        </div> 
    
   </div>
   </br>
   </br>
    <div id="gridview">

                        <asp:GridView ID="GridView1" runat="server" Width="100%"
            EnableModelValidation="True" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:GridView>

        </div>
    <div id="chart"style="margin-left:200px">
        <cc1:Chartlet Width="700px" ID="Chartlet1" runat="server" ChartType="HBar" />

        </div>
    <label id="lblMsg" runat="server"></label>
</div>
</div>
<div id="copyright">
Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
</div>
</div>

    </form>
</body>
</html>
