<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dome.aspx.cs" Inherits="_Default" %>
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

 



    <title>Airmacau</title>
    

</head>

<body>

    <form id="form1" runat="server">

<div id="backpanel">
<uc1:Airmacau1 ID="Airmacau1" runat="server"/>

<div id="pagebody">
<div id ="leftmenu">
<ul id="nav">
<li><a href="">Home</a></li>
<li><a href="home.aspx">About Us</a></li>
<ul>
 <li><a href="#">Sub Menu 31</a></li>
 <li><a href="#">Sub Menu 32</a>
</ul>
<li><a href="Default.aspx">Contact Us</a>
 <ul>
 <li><a href="#">Sub Menu 31</a></li>
 <li><a href="#">Sub Menu 32</a><ul>
 <li><a href="#">Sub Menu 321</a></li>
 <li><a href="#">Sub Menu 322</a></li>
 <li><a href="#">Sub Menu 323</a></li>
 <li><a href="#">Sub Menu 324</a></li>
 </ul>
 </li>
 <li><a href="#">Sub Menu 33</a></li>
 <li><a href="#">Sub Menu 34</a></li>
 </ul>
</li>
<li><a  href="Default.aspx">Gallery</a>
<ul>
 <li><a href="#">Sub Menu 41</a></li>
 <li><a href="#">Sub Menu 42</a>
 <ul>
 <li><a href="#">Sub Menu 421</a></li>
 <li><a href="#">Sub Menu 422</a></li>
 <li><a href="#">Sub Menu 423</a></li>
 <li><a href="#">Sub Menu 424</a></li>
 </ul>
 </li>
 <li><a href="#">Sub Menu 43</a></li>
 <li><a href="#">Sub Menu 44</a></li>
 </ul>
</li>
<li><a href="#">Contact Me</a></li>
</ul>
</div>

<div id="Contentpanel">
Content goes here</div>

</div>
<div id="copyright">
Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
</div>
</div>

    </form>
</body>
</html>
