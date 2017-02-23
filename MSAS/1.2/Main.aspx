<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>
<%@ Register src="Airmacau.ascx" tagname="Airmacau1" tagprefix="uc1" %>

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



    <title>Home</title>
    

</head>

<body>

    <form id="form1" runat="server">

<div id="backpanel">
<uc1:Airmacau1 ID="Airmacau1" runat="server"/>
<%--<div class="menu">

<ul>
<li><a id="staffs" class="hide" href="Main.aspx" runat="server">Staff Settings</a>

    <ul>
    <li><a href="Department.aspx" title="Department">Department Setting</a></li>
    <li><a href="Position.aspx" title="Wrapping text around images">Division Setting</a></li>
    <li><a href="Title.aspx" title="Wrapping text around images">Title Setting</a></li>
    <li><a href="Staffin.aspx" title="Image Map for detailed information">Employee Setting</a></li>

    </ul>

</li>
<li><a id="Authors" style="width:150px" class="hide" href="Main.aspx" runat="server">Authorization Settings</a>

    <ul>
    <li><a href="Project.aspx" title="Styling forms">Project Setting</a></li>  
    <li><a href="Range.aspx" title="Multi-position drop shadow">Range Setting</a></li>
    <li><a href="Level.aspx" title="Removing active/focus borders">Level Setting</a></li>

    </ul>

</li>
<li><a id="Author" class="hide" href="Authorization.aspx" runat="server" >Authorization</a>

</li>
<li><a id="Authorss" class="hide" href="AuthorizationSelect.aspx" runat="server">AuthorizationSearch</a>

</li>
<li><a class="hide" href="../mozilla/index.html">Test</a>

</li>
</ul>
<!-- clear the floats if required -->
<div class="clear"> </div>
</div>--%>
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
<h1>1.1Updates</h1>
<ul>
<li>Modify the user interface language to English</li>
</ul>
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
