<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change your password</title>
    <style type="text/css">

        .style2
        {
            height: 38px;
        }
        .style1
        {
            height: 30px;
        }
        .style3
        {
            width: 100px;
        }
        .style4
        {
            height: 30px;
            width: 217px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/airmacau.png" 
            onclick="ImageButton1_Click" title ="Home page" />
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
<td style="background-color:#ffff99;text-align:top;" class="style3">
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
<div style="width: 592px">

    <table border="0" cellspacing="0" cellpadding="0" height="250" 
     style="width: 492px" >
  <tr>
    <td colspan="2" 
          style=" ;padding:0 20px;text-align:left;font-size: 16px;" 
          class="style2">
        </td>
    </tr>
  <tr>
    <td style="padding:0 5px;" class="style4" ><strong>Staff No.:</strong></td>
    <td width="392" style="padding:0 5px;" class="style1" >
        <asp:TextBox ID="lgnm" runat="server" Width="335px" 
            style="padding-top:2px;padding-bottom:2px;line-height:30px;" Height="30px"
             Text="eg:00001. The same as E-service account." OnFocus="javascript:if(this.value=='eg:00001. The same as E-service account.') {this.value='';this.style.color='1F215B'}" OnBlur="javascript:if(this.value==''){this.value='eg:00001. The same as E-service account.'}"                 ForeColor="Silver" ></asp:TextBox>
            </td>
  </tr>
  <tr>
    <td style="padding:0 5px;" class="style4"><strong>Old Password:</strong></td>
    <td style="padding:0 5px;text-align:left;" class="style1">
        <asp:TextBox ID="oldpwd" runat="server" Height="30px" 
            style="padding-top:2px;padding-bottom:2px;line-height:30px;" Width="335px" 

            TextMode="Password" ></asp:TextBox>
            </td>
  </tr>
  <tr>
    <td style="padding:0 5px;" class="style4"><strong>New Password:</strong></td>
    <td style="padding:0 5px;text-align:left;" class="style1">
        <asp:TextBox ID="newpwd" runat="server" Height="30px" 
            style="padding-top:2px;padding-bottom:2px;line-height:30px;" Width="335px" 

            TextMode="Password" ></asp:TextBox>
            </td>
  </tr>
  <tr>
    <td style="padding:0 5px;" class="style4"><strong>New Password Confirm:</strong></td>
    <td style="padding:0 5px;text-align:left;" class="style1">
        <asp:TextBox ID="newpwd2" runat="server" Height="30px" 
            style="padding-top:2px;padding-bottom:2px;line-height:30px;" Width="335px" 

            TextMode="Password" ></asp:TextBox>
            </td>
  </tr>
  <tr>
    <td colspan="2" style="padding:0 5px;text-align:center;height:35px;" >
        <asp:Button ID="login" runat="server" Text="Yes" onclick="login_Click" />
        
        <br />
        
      </td>
    </tr>
 <%-- <tr>
    <td colspan="2" style="padding:0 20px;text-align:center;"><a href="changepwd.aspx" target="mainFrame">Change Password</a></td>
    </tr>--%>
</table>

</div>
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
