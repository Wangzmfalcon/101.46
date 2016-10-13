<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login -BK.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<!--[if lt IE 7 ]> <html lang="en" class="ie6 ielt8"> <![endif]-->
<!--[if IE 7 ]>    <html lang="en" class="ie7 ielt8"> <![endif]-->
<!--[if IE 8 ]>    <html lang="en" class="ie8"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!-->

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<!--<![endif]-->
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" href="images/airmacau.ico" />
    <title>Login</title>

    <%-- css --%>
    <style>
        @font-face {
            font-family: AkzidenzGrotesk;
            src: local('font/akzidenz_grotesk_roman.ttf');
        }
    </style>
    <link href="/css/jquery-ui.css" rel="stylesheet" />
    <link href="/css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginhead">
           <%-- <div style="color: white; font-family: AkzidenzGrotesk">AIRMACAU</div>--%>
              <div style="width:960px;margin:auto" >
                <img src="images/nxlogo170_48.png"  height="30" style="margin-left: 35px; margin-top:25px" />
            </div>

            <%--       
            <div style="margin: auto; text-align: center">
                No Punch Reminder
            </div>
            <div style="border-bottom: 4px solid #382649;"></div>
            <div style="border-bottom: 8px solid #D80425;"></div>--%>
        </div>
        <div class="containers">

            <div class="loginbody">
                <div class="loginad">
                    <img src="images/loginbk.jpg" style="margin-left: 0" />
                </div>
                <div class="loginbox">
                    <div class="login-title">
                        Login
                    </div>
                    <br>
                    <div class="login-body">
                        <div>
                            <input type="text" placeholder="Username" required="required" id="username" runat="server" />
                        </div>
                        <div>
                            <input type="password" placeholder="Password" required="required" id="password" runat="server" />
                        </div>
                        <%--<div class="tb-login-text-box_rmk">
                            <a href="http://fib/User/Self_ResetPwd.aspx">Reset password</a> | <a href="http://fib/User/ResetStatus.aspx">Unlock account</a>
                        </div>--%>
                        <br>
                        <div>
                            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
<%--            <div class="loginfoot clear">
                <div class="ui-state-highlight ui-corner-all" style="margin-top: 15px; line-height: 18px; padding-top: 5px; padding: 5px;">
                    <p style="line-height: 20px;">
                        <strong>Information:</strong><br>
                        1. Recommended Browsers: Chrome, IE-8 or above.<br>
                        2. If you any login issue, please contact IT.
                    </p>
                </div>
                <div class="foot">
                    Copyright © 2016 - All Rights Reserved Air Macau Company IT Division

                </div>

            </div>--%>
        </div>
    </form>
</body>
</html>
