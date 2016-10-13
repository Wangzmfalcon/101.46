<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1Default.aspx.cs" Inherits="_Default" %>

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

    <link href="/css/jquery-ui.css" rel="stylesheet" />
    <link href="/css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="containers">
            <div class="loginhead">
                <div style="float:left">
                    <img src="images/am_icon.png" width="50" style="margin-left: 0"/>
                </div>
                <div style="margin:auto;text-align:center">
                    <a>E-Receipt</a>
                </div>
                <div style="border-bottom: 4px solid #382649;"></div>
                <div style="border-bottom: 8px solid #D80425;"></div>
            </div>
            <div class="loginbody">
                <div class="loginad">
                   <img src="images/loginbk.jpg"  style="margin-left: 0"/>
                </div>
                <div class="loginbox">
                    <div class="login-title">
                        Login
                    </div>
                    <div class="login-body">
                        <div>
                            <input type="text" placeholder="Username" required="" id="username" runat="server" />
                        </div>
                        <div>
                            <input type="password" placeholder="Password" required="" id="password"  runat="server" />
                        </div>
                        <div class="tb-login-text-box_rmk">
                            <a href="http://fib/User/Self_ResetPwd.aspx">Reset password</a> | <a href="http://fib/User/ResetStatus.aspx">Unlock account</a>
                        </div>
                        <br>
                        <div>
                            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Submit_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="loginfoot clear">
                <div class="ui-state-highlight ui-corner-all" style="margin-top: 15px; line-height: 18px; padding-top: 5px; padding: 5px;">
                    <p style="line-height: 20px;">
                        <strong>Information:</strong><br>
                        1. <b>Login account is same as FIB, E-Log, T-1 Passenger Revenue Instant Report and Other IT Development System.</b><br>
                        2. Personal information from the EHR system.<br>
                        3. Recommended Browsers: Chrome, IE-8 or above.<br>
                        4. If you any login issue, please contact IT.
                    </p>
                </div>
                <div class="foot">
                    Copyright © 2016 - All Rights Reserved Air Macau Company IT Division

                </div>

            </div>
        </div>
    </form>
</body>
</html>
