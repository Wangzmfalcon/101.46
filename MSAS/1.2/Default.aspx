<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="note/FormStyle.css" rel="stylesheet" type="text/css" />
    <link href="note/Style.css" rel="stylesheet" type="text/css" />
    <link href="note/menu.css" rel="stylesheet" type="text/css" />
    <title>MASA Login</title>
    <style type="text/css">
        #f {
            position: absolute;
            display: none;
        }
    </style>
    <script type="text/javascript">



        function shows() {
            var f = document.getElementById("f");
            f.style.display = 'block';
        }
        function closed() {
            var f = document.getElementById("f");

            f.style.display = 'none';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="layout">
            <div id="systitle">
                <div class="logo">
                    <img src="pic/logo.gif" width="152" height="40" />
                </div>
                <div class="toptitle">Maintenance Staff Authorization System<span style="font-size: xx-small; font-weight: normal; padding: 5px"></span></div>
                <div id="logoutbt">
                </div>
            </div>
            <div style="border-bottom: 4px solid #382649;"></div>
            <div style="border-bottom: 8px solid #D80425;"></div>

            <div class="menu">
                <ul>
                </ul>
            </div>
            <div id="login2">
                <table border="0" cellspacing="0" cellpadding="0" height="250"
                    style="width: 492px">
                    <tr>
                        <td height="38" colspan="2" style="background-color: #F1F1F1; padding: 0 20px; text-align: left; border-bottom: #CCC solid 1px; font-size: 16px;">Login
                        </td>
                    </tr>
                    <tr>
                        <td width="108" style="padding: 0 5px; height: 30px"><strong>Staff No.:</strong></td>
                        <td width="392" style="padding: 0 5px;">
                            <asp:TextBox ID="lgnm" runat="server" Width="335px"
                                Style="padding-top: 2px; padding-bottom: 2px; line-height: 30px;" Height="30px"
                                Text="Your Staff ID.eg:00001." OnFocus="javascript:if(this.value=='Your Staff ID.eg:00001.') {this.value='';this.style.color='1F215B'}" OnBlur="javascript:if(this.value==''){this.value='Your Staff ID.eg:00001.'}" ForeColor="black"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0 5px; height: 30px;"><strong>Password:</strong></td>
                        <td style="padding: 0 5px; text-align: left;">
                            <asp:TextBox ID="pwd" runat="server" Height="30px"
                                Style="padding-top: 2px; padding-bottom: 2px; line-height: 30px;" Width="335px"
                                TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >

                        <td colspan="2" style="padding: 0 5px; text-align: center;" height="15px">
                            <div style=" text-align: center">
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Forget Password"
                                    onmouseover="shows()" onmouseout="closed()" Visible="false"></asp:LinkButton>
                                <div id="f" style="background-color: azure; text-align: center; margin-right:auto">
                                    <div>You should </div>
                               

                                </div>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" style="padding: 0 5px; text-align: center; height: 35px;">
                            <asp:Button ID="Submit"
                                Text="Login" class="pagebutton" onmouseover="currentcolor=this.style.backgroundColor;this.style.backgroundColor='#3A7FED'" onmouseout="this.style.backgroundColor=currentcolor" runat="server" OnClick="Submit_Click" />

                            <br />
                            <asp:Label ID="MessageBox" runat="server" ForeColor="#D80425"></asp:Label>

                        </td>
                    </tr>
                    <%-- <tr>
    <td colspan="2" style="padding:0 20px;text-align:center;"><a href="changepwd.aspx" target="mainFrame">Change Password</a></td>
    </tr>--%>
                </table>
            </div>
        </div>
    </form>
    <div id="bottomnav">
        <div class="footer"></div>

    </div>


</body>
</html>
