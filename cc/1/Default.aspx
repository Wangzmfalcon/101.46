<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
        .style2
        {
            height: 38px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        
        <asp:Image ID="Image1" runat="server" ImageUrl="~/airmacau.png" 
            style="text-align: center" />
        
    </div>
    <div>
    <h1 style="text-align: center">Crew_Check System</h1>
    </div>
    <table border="0" cellspacing="0" cellpadding="0" height="250" 
     style="width: 492px" align="center" >
  <tr>
    <td colspan="2" 
          style=" ;padding:0 20px;text-align:left;;" 
          class="style2">
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
    <div>
    </div>
    <div style="text-align: center">
        Copyright www.airmacau.com.mo</div>
    </form>
</body>
</html>
