<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Download.aspx.cs"  EnableEventValidation="false"  Inherits="Home" %>
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

    <div id="first"style="width: 950px; margin-left:50px">
        1.   From:
        <input class="Wdate" type="text" style="width:100px;height:20px"   onClick="WdatePicker()  " name="deptdate" id= "from"  runat="server"/>
        to:
        <input class="Wdate" type="text" style="width:100px;height:20px"   onClick="WdatePicker()  " name="deptdate" id= "to" runat="server" />
        <asp:Button ID="download1" runat="server" Text="Donwload" OnClick="download1_Click" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
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
