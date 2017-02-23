<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RS.aspx.cs" Inherits="Home" %>
<%@ Register src="Airmacau.ascx" tagname="Airmacau1" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="zh-CN" /> 
<meta name="author" content="Airmacau/ITD" /> 
<meta name="Copyright" content="Airmacau" /> 
<meta name="description" content="Airmacau" />
<meta name="keywords" content="Airmacau"  />
 <!--css-->
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/leftmenu.css" rel="stylesheet" type="text/css" />

 <!--js-->
 <script src="js/leftmenu.js" type="text/javascript"></script>

 



    <title>Reminder Setting</title>
    

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
   <div style="width: 900px; margin-left:100px"> 
<div style="width:1000px; height=150px;font-size:14px; float:left;">
<p>In the corresponding form input reminder of days, all records about the table set 
    reminder time N days before the closing date</p>
</div>
<div id="ENM_Staff_Master" style="width:1000px; height=150px;font-size:14px; float:left;">
<ul>ENM_Staff_Master:
<li>AU_EXP<asp:TextBox ID="TextBox1" runat="server">30</asp:TextBox>days
<asp:Button ID="Button1"
    runat="server" Text="modify" onclick="Button1_Click" /></li>
<li>AM_EXP<asp:TextBox ID="TextBox2" runat="server">30</asp:TextBox>days
<asp:Button ID="Button2"
    runat="server" Text="modify" onclick="Button2_Click" style="height: 21px" /></li>
</ul>
</div>
<div id ="Ceritifcate_Monitor" style="width:1000px; height=150px;font-size:14px; float:left;">
<ul>Ceritifcate_Monitor:
<li>C_of_A&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server">30</asp:TextBox>days
<asp:Button ID="Button3"
    runat="server" Text="modify" onclick="Button3_Click" /></li>
<li>ASL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server">30</asp:TextBox>days
<asp:Button ID="Button4"
    runat="server" Text="modify" onclick="Button4_Click" /></li>
<li>DSRT_Radio_Licence&nbsp; <asp:TextBox ID="TextBox7" runat="server">30</asp:TextBox>days
<asp:Button ID="Button7"
    runat="server" Text="modify" onclick="Button7_Click" /></li>
<li>C_of_A_IRL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="TextBox8" runat="server">30</asp:TextBox>days
<asp:Button ID="Button8"
    runat="server" Text="modify" onclick="Button8_Click" style="height: 26px" /></li>
<li>ASL_IRL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox9" runat="server">30</asp:TextBox>days
<asp:Button ID="Button9"
    runat="server" Text="modify" onclick="Button13_Click" /></li>
<li>Declaration&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox10" runat="server">30</asp:TextBox>days
<asp:Button ID="Button10"
    runat="server" Text="modify" onclick="Button14_Click" /></li>
    <li>C_of_R&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox11" runat="server">30</asp:TextBox>days
<asp:Button ID="Button11"
    runat="server" Text="modify" onclick="Button15_Click" /></li>

</ul>
</div>
<div  id="Finding_Control"  style="width:1000px; height=150px;font-size:14px; float:left;">
<ul>Finding Control:
<li>The_Alert_Date&nbsp;&nbsp; <asp:TextBox ID="TextBox5" runat="server">3</asp:TextBox>days
<asp:Button ID="Button5"
    runat="server" Text="modify" onclick="Button5_Click" /></li>
</ul>
</div>
<div  id="Outstation_MOA_Monitoring"  style="width:1000px; height=150px;font-size:14px; float:left;">
<ul>Outstation MOA Monitoring:
<li>Expiry Date&nbsp;&nbsp; <asp:TextBox ID="Expiry_Date" runat="server">30</asp:TextBox>days
<asp:Button ID="Button6"
    runat="server" Text="modify" onclick="Button6_Click" /></li>
</ul>
</div>
</div>
</div>
</div>
<div id="copyright">
Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
</div>
</div>

    </form>
</body>
</html>
