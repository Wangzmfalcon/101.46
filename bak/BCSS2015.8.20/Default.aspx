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


 <!--js-->


 



    <title>Business class service survey</title>
    

</head>

<body>

    <form id="form1" runat="server">

<div id="backpanel">
<uc1:Airmacau1 ID="Airmacau1" runat="server"/>
<div style=" width:1000px; height:700px;   ">
<table border="0" cellspacing="0" cellpadding="0" height="250" 
     style="width: 492px" align="center" >
  <tr>
    <td colspan="2" 
          style=" padding:0 20px;text-align:left; height:120px" >
        </td>
    </tr>
  <tr>
    <td width="108" style="padding:0 5px;height:30px" ><strong>Staff No.:</strong></td>
    <td width="392" style="padding:0 5px;" >
        <asp:TextBox ID="lgnm" runat="server" Width="335px" 
            style="padding-top:2px;padding-bottom:2px;line-height:30px;" Height="30px"
             Text="eg:00001. The same as E-service account." OnFocus="javascript:if(this.value=='eg:00001. The same as E-service account.') {this.value='';this.style.color='1F215B'}" OnBlur="javascript:if(this.value==''){this.value='eg:00001. The same as E-service account.'}"                 ForeColor="Silver" ></asp:TextBox>
            </td>
  </tr>
  <tr>
    <td style="padding:0 5px;" class="style1"><strong>Password:</strong></td>
    <td style="padding:0 5px;text-align:left;" class="style1">
        <asp:TextBox ID="pwd" runat="server" Height="30px" 
            style="padding-top:2px;padding-bottom:2px;line-height:30px;" Width="335px" 

            TextMode="Password" ></asp:TextBox>
            </td>
  </tr>
  <tr>
    <td colspan="2" style="padding:0 5px;text-align:center;height:35px;" >
        <asp:Button ID="login" runat="server" Text="Login" onclick="login_Click" />
        
        <br />
        <asp:Label ID="MessageBox" runat="server" ForeColor="#D80425"></asp:Label>
        
      </td>
    </tr>
 <%-- <tr>
    <td colspan="2" style="padding:0 20px;text-align:center;"><a href="changepwd.aspx" target="mainFrame">Change Password</a></td>
    </tr>--%>
</table>
</div>
<div id="copyright">
Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
</div>
</div>

    </form>
</body>
</html>
