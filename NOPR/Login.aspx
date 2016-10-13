<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<!--[if lt IE 7 ]> <html lang="en" class="ie6 ielt8"> <![endif]-->
<!--[if IE 7 ]>    <html lang="en" class="ie7 ielt8"> <![endif]-->
<!--[if IE 8 ]>    <html lang="en" class="ie8"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!-->
<link href="/css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<!--<![endif]-->
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible' />
    <link rel="icon" href="images/airmacau.ico" />
    <title>Login</title>

    <%-- css --%>
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginhead">

            <div style="width: 960px; margin: auto;">
                <img src="./images/nxlogo170_48.png" height="40" style="margin-left: 35px; margin-top: 25px; float: left" />

                <div style="color: white; font-family: AkzidenzGrotesk,Perpetua,Cambria; margin: auto; width: 350px; height: 50px; padding-top: 20px">No Punch Reminder</div>
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
                    <img src="images/punch.jpg" style="margin-left: 35px; margin-top: 35px" />
                </div>
                <div class="loginbox">
                    <div style="background: url(./images/login_punch.png)0 10px no-repeat; margin-top: 25px; height: 465px; width: 270px;">

                        <div>
                            <p style="padding-top: 100px; padding-left: 85px; font-family: Perpetua,AkzidenzGrotesk,Cambria; font-size: 25px; color: #808080"><b>LOGIN</b></p>
                            <div>
                                <input type="text" placeholder="Username" required="required" id="username" runat="server" style="width: 160px; height: 30px; margin-top: 4px; margin-left: 40px" />
                            </div>
                            <div>
                                <input type="password" placeholder="Password" required="required" id="password" runat="server" style="width: 160px; height: 30px; margin-top: 25px; margin-left: 40px" />
                            </div>


                            <div style="margin-left: 100px; margin-top: 15px;">
                                <asp:ImageButton ID="LoginButton" runat="server" Text="" OnClick="LoginButton_Click" Width="50px" Height="50px" ImageUrl="~/images/key_login.png" />
                                <%-- <asp:Button ID="LoginButton" runat="server"  OnClick="LoginButton_Click"/>--%>
                                <%--     <i class="fa fa-sign-in fa-2x" aria-hidden="true"></i>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="foot">
                    Copyright © 2016 - All Rights Reserved Air Macau Company IT Division

                </div>
            </div>
            <%--    <div class="loginfoot clear">
       <%--         <div class="ui-state-highlight ui-corner-all" style="margin-top: 15px; line-height: 18px; padding-top: 5px; padding: 5px;">
                    <p style="line-height: 20px;">
                        <strong>Information:</strong><br>
                        1. Recommended Browsers: Chrome, IE-8 or above.<br>
                        2. If you any login issue, please contact IT.
                    </p>
                </div>--%>


            <%--  </div>--%>
        </div>

    </form>
</body>
</html>
