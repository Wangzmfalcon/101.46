<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertCrewInfo.aspx.cs" Inherits="crew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head id="Head1" runat="server">
    <title>Insert Crew Information</title>
    <style type="text/css">
        .style1
        {
            height: 37px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/airmacau.png" onclick="ImageButton1_Click" title ="Home page"  />
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
<div style="width:605px; text-align: right;">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</div>
<div style=" height:60px;width:605px; font-weight: 700;" >
    <br />
Please fill in the information:
</div>
<div style="width:605px;" class="style2">

StaffNo:<asp:TextBox ID="StaffNo" runat="server" Width ="100px"></asp:TextBox>
&nbsp;StaffName:<asp:TextBox ID="StaffName" runat="server" Width ="100px"></asp:TextBox>
&nbsp;Title:<asp:DropDownList ID="Title" runat="server">
    </asp:DropDownList>
    
    &nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
        Text="insert" />
    
</div>

</td>
</tr>
        
<tr>
<td colspan="2" style="background-color:#99bbbb;text-align:center;">
Copyright www.airmacau.com.mo</tr>
        
</table>


    </div>
    </form>
</body>
