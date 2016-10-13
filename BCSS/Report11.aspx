<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report11.aspx.cs" Inherits="Home"debug="true" %>
<%@ Register src="Airmacau.ascx" tagname="Airmacau1" tagprefix="uc1" %>

<%@ Register assembly="Chartlet" namespace="FanG" tagprefix="cc1" %>

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


 <!--js-->

       <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
 
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
<div id="maintable">
    <div style=" height:60px"></div>

    <div id="search" align="center"  >
        From&nbsp;<input class="Wdate" type="text" style="width:100px;height:20px"   onClick="WdatePicker()  " name="from" id= "from" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To&nbsp;<input class="Wdate" type="text" style="width:100px;height:20px"   onClick="WdatePicker()  " name="to" id= "to" />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    <div id="grid" align="center">
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="800px" >
                  <AlternatingRowStyle BackColor="White" />
                  <EditRowStyle BackColor="#2461BF" />
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
                  <RowStyle BackColor="#EFF3FB" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </div>

    <div id="chartlet" align="center"><cc1:Chartlet ID="Chartlet1" runat="server" />
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
