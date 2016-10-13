<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changpassword.aspx.cs" Inherits="changepassword" %>
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

 



    <title>Change Password</title>
    

    <style type="text/css">
        .auto-style1 {
            height: 35px;
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
<div style=" width:1000px; height:100px;  font-size:20px; font-weight:bold; text-align: center;">
    <br />
    Change password</div>
<div style="width: 750px; margin-left:250px">

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
    <td colspan="2" style="padding:0 5px;text-align:center;" class="auto-style1" >
        <asp:Button ID="login" runat="server" Text="Yes" onclick="login_Click" />
        
        <br />
        
      </td>
    </tr>
 <%-- <tr>
    <td colspan="2" style="padding:0 20px;text-align:center;"><a href="changepwd.aspx" target="mainFrame">Change Password</a></td>
    </tr>--%>
</table>

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
