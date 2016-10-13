<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HomePage</title>
    <style type="text/css">
        .style1
        {
            height: 37px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center"  >
    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/airmacau.png" 
            onclick="ImageButton1_Click" title ="Home page"  />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Log out</asp:HyperLink>
    
    </div>
    <div>
    <table width="705" border="0" align="center">
<tr>
<td colspan="2" style="background-color:#99bbbb;" class="style1">
<h1 style="text-align: center">Crew_Check System</h1>
</td>
</tr>

<tr valign="top">
<td style="background-color:#ffff99;width:100px;text-align:top;">
<b>Menu</b>
<br /><br />
<a href="changepassword.aspx">Change your password</a><br /><br />
<a href="crew.aspx">Crew information</a><br /><br />
<a href="crewcheck.aspx">Crew_Check information</a>
</td>
<td style="background-color:#EEEEEE;height:600px;width:400px;text-align:left;">
<div style="width:605; text-align: right;">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</div>
<div id="linkweb">
</div>
<script>    setInterval("linkweb.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());", 1000);
</script>

</td>
</tr>

<tr>
<td colspan="2" style="background-color:#99bbbb;text-align:center;">
Copyright www.airmacau.com.mo</td>
</tr>
</table>


    </div>
    </form>
</body>



</html>
