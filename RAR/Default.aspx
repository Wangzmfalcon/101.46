<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register src="Airmacau_no menu.ascx" tagname="Airmacau1" tagprefix="uc1" %>

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

 



    <title>RMD  Adhoc Report</title>
    

    <style type="text/css">
        #backpanel {
            text-align: left;
        }
        </style>
    

</head>

<body>

    <form id="form1" runat="server" >

<div id="backpanel">
<uc1:Airmacau1 ID="Airmacau1" runat="server"/>
<div style=" width:1000px; height:700px;   ">
<table border="0" cellspacing="0" cellpadding="0"  
     style="width:800px" align="center" >
 <tr>
    <td colspan="2"; style =" text-align:left; height:20px" height="20px">
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="Convert" OnClick="Button1_Click" />
    </td>
     
</tr>
  <tr>
    <td width="350" style="padding:0 5px;height:30px" >
        &nbsp;</td>
</tr>
<tr>
    <td width="350" style="padding:0 5px;height:30px" >
        
        <strong>
        <br />
        After convert<br />
        </strong>
        
            &nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/images/after.png" Width="936px" />
     </td>
</tr>


    </table>
</div>
<div id="copyright">
Copyright © 2014 - All Rights Reserved Air Macau Company IT Division
div>

    </form>
</body>
</html>
