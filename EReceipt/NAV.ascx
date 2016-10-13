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


            <div style="width: 960px; margin: auto;">
                <img src="images/nxlogo170_48.png" height="40" style="margin-left: 35px; margin-top: 25px; float: left" />

                <div style="color: white; font-family: Perpetua; margin: auto; width: 350px; height: 50px; padding-top: 20px">E-Receipt</div>
            </div>

        </div>
        <span class="clear"></span>
        <div class="navbar">
            <ul>
                <li><a href="Home.aspx">Home</a></li>
                <li id="add" runat="server"><a href="Add_Data.aspx">Add Data</a></li>
                <li id="manage" runat="server"><a href="Manage.aspx">Manage Data</a></li>
                <li id="setting" runat="server" class="dropdown">
                    <a href="#" class="dropbtn">Settings</a>
                    <div class="dropdown-content">
                        <a href="Station_Setting.aspx">Station Setting</a>
                        <a href="Deposit_Setting.aspx">Deposit Type Setting</a>
                        <a href="Sales_Setting.aspx">Sales Type Setting</a>
                        <a href="Currency_Setting.aspx">Currency Setting</a>
                    </div>
                </li>
                <li id="Li1" runat="server"><a href="Changepassword.aspx">Change Password</a></li>


                <li id="report" runat="server" class="dropdown">
                    <a href="#" class="dropbtn">Report</a>
                    <div class="dropdown-content">
                        <a href="Report1.aspx">Report 1</a>


                    </div>
                </li>
                <li id="admin" runat="server" class="dropdown">
                    <a href="#" class="dropbtn">Admin Settings</a>
                    <div class="dropdown-content">
                        <a href="User_Setting.aspx">User Setting</a>


                    </div>
                </li>

                <li style="float: right">
                    <div style="width: 50px">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/icon/logout.png" OnClick="ImageButton1_Click" />
                    </div>
                </li>
            </ul>
        </div>
    </div>


</body>
</html>
