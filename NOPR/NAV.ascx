<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NAV.ascx.cs" Inherits="NAV" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>nav</title>
    <%-- css --%>

    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/login.css" rel="stylesheet" />
    <link href="css/nav.css" rel="stylesheet" />

    <%-- js --%>

    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>

</head>
<body>
    <div style="background-color: #292059;">
    <div class="pagehead">
        <%--   <div style="float: left">
            <img src="images/am_icon.png" width="50" style="margin-left: 0" />
        </div>
        <div style="text-align: center">
            <a>No Punch Reminder</a>
        </div>--%>

        <div style="width: 960px; margin: auto;">
            <img src="images/nxlogo170_48.png" height="40" style="margin-left: 35px; margin-top: 25px; float: left" />

            <div style="color: white; font-family: Perpetua; margin: auto; width: 350px; height: 50px; padding-top: 20px">No Punch Reminder</div>
        </div>
    </div>
    <span class="clear"></span>
    <div class="navbar">
        <ul>
            <li><a href="Home.aspx">Home</a></li>



            <li id="email" runat="server" class="dropdown">
                <a href="#" class="dropbtn">Send E-Mail</a>
                <div class="dropdown-content">
                    <a href="First_reminder.aspx">First Reminder</a>
                    <a href="Last_reminder.aspx">Last Reminder</a>

                </div>
            </li>


            <li id="admin" runat="server" class="dropdown">
                <a href="#" class="dropbtn">Admin Setting</a>
                <div class="dropdown-content">
                    <a href="User_Setting.aspx">User Setting</a>
                    <a href="CC_setting.aspx">CC Setting</a>

                </div>
            </li>

            <li style="float: right">
                <div style="width:50px">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/icon/logout.png" OnClick="ImageButton1_Click" />
                </div>

                <%--   <a href="Login.aspx" >Log out</a>--%>
            </li>
        </ul>
    </div>

</div>

</body>
</html>
