﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ML.aspx.cs" Inherits="Home" %>
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

 



    <title>Mail List Setting</title>
    

    <style type="text/css">
        .style2
        {
            font-size: large;
            color: #FF0000;
        }
    </style>
    

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
<p><span class="style2">To</span>Enter remind staff to receive E-mail, separated by 
    semicolons, allowing only add company mailbox that is end of @ airmacau.com.mo</p>
<p>For example:example1@airmacau.com.mo;example2@airmacau.com.mo</p>
 <asp:TextBox ID="TextBox1" runat="server" Height="128px" Width="498px" TextMode=MultiLine></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="OK" />
</div>

<div style="width:1000px; height=150px;font-size:14px; float:left;">
<p><span class="style2"><strong>CC</strong></span> Enter cc staff to receive E-mail, 
    separated by semicolons, allowing only add company mailbox that is end of @ 
    airmacau.com.mo</p>
<p>For example:example1@airmacau.com.mo;example2@airmacau.com.mo</p>
 <asp:TextBox ID="TextBox2" runat="server" Height="128px" Width="498px" TextMode=MultiLine></asp:TextBox>
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="OK" />
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
