<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertSC.aspx.cs" Inherits="InsertSC" %>
<%@ Register src="Airmacau.ascx" tagname="Airmacau1" tagprefix="uc1" %>
<%@ Register src="leftmenu.ascx" tagname="leftmenu1" tagprefix="uc1" %>
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

 



    <title>Add Station Check</title>
    

    <style type="text/css">
        .style1
        {
            color: #FF0000;
        }
    </style>
    

</head>

<body>

    <form id="form1" runat="server">

<div id="backpanel">
<uc1:Airmacau1 ID="Airmacau1" runat="server"/>

<div id="pagebody">
<div id ="leftmenu">
<uc1:leftmenu1 ID="leftmenu1" runat="server"/>

</div>

<div id="Contentpanel">
<div id="linkweb" style=" float:left; width:400px; height:25px;font-size:14px;">
</div>
<script>    setInterval("linkweb.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());", 1000);
</script>
<div id="welcome" style="width:400px; height:25px;text-align:right; font-size:14px; float:left;">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</div>

<div style=" width:810px; height:100px; font-size:20px; font-weight:bold">
    <br />
    Please fill in the information:</div>
    <div id="input1" style="width:810px;">
     Station_Code<span class="style1">*</span>:
        <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
        Station_Name:
        <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
        Flight_Type<span class="style1">*</span>:
        <asp:DropDownList ID="DropDownList1" runat="server" Width="80px">
        </asp:DropDownList>
        Allow_Staff_Name<span class="style1">*</span>：
        <asp:DropDownList ID="DropDownList2" runat="server" Width="80px">
        </asp:DropDownList>
            <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    From<span class="style1">*</span>:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" style="width:100px;height:22px" name="cc_from" id= "from1">&nbsp;
     To<span class="style1">*</span>:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" 
        style="width:100px;height:22px" name="cc_to" id="to11" value=" ">
&nbsp;<asp:Button ID="Button1" runat="server" Text="insert" onclick="Button1_Click" />
    </div>
</div>
<div id="copyright">
Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
</div>
</div>

    </form>
</body>
</html>
