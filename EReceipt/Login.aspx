<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

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
    <title>E-Receipt Login </title>

    <%-- css --%>

    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="loginhead">

            <div style="width: 960px; margin: auto;">
                <img src="./images/nxlogo170_48.png" height="40" style="margin-left: 35px; margin-top: 25px; float: left" />

                <div style="color: white; font-family: AkzidenzGrotesk,Perpetua,Cambria; margin: auto; width: 350px; height: 50px; padding-top: 20px">E-Receipt</div>
            </div>

        </div>
        <div class="containers">

            <div class="loginbody">
                <div class="loginad">
                    <img src="images/Ereceipt.jpg" style="margin-left: 35px; margin-top: 35px" />
                </div>
                <div class="loginbox">
                    <div style="background: url(./images/login.png)0 10px no-repeat; margin-top: 25px; height: 465px; width: 270px;">

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
        </div>
    </form>
</body>
</html>
