<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Airmacau.ascx.cs" Inherits="WebUserControl" %>
<!--css-->
<link href="css/ascx_body.css" rel="stylesheet" media="screen" type="text/css" />
<link href="css/ascx_menu.css" rel="stylesheet" media="screen" type="text/css" />
<!--js-->
<script src="js/mainmen_selecet.js" type="text/javascript"></script>
<script src="js/mainmenu_color.js" type="text/javascript"></script>

<div id="systitle">
    <div style="border-top: 4px solid #382649; width: 1000px"></div>
    <div class="logo">
        <a href="http://www.airmacau.com.mo">
            <img alt="澳门航空" src="images/logo.gif"
                border="none" /></a>

    </div>
    <div class="toptitle">Business Class Service Survey</div>
    <div class="version">V1.0</div>
</div>

<div style="border-bottom: 4px solid #382649; width: 1000px"></div>
<div style="width: 1000px"></div>
<div style="background: #324143; width: 1000px">
    <ul id="jsddm">
        <li><a href="Home.aspx">Home</a></li>
        <li><a href="Datainput.aspx">Data Input</a></li>
        <li><a id="download" runat="server" href="Download.aspx">Download</a></li>
        <li><a id="delete" runat="server" href="Delete.aspx">Delete</a></li>
        <li><a href="#">Reports</a>
            <ul>
                <li>
                    <asp:LinkButton ID="LinkButton1" runat="server" href="Report1.aspx">Report1</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton2" runat="server" href="Report2.aspx">Report2</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton3" runat="server" href="Report3.aspx">Report3</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton4" runat="server" href="Report4.aspx">Report4</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton5" runat="server" href="Report5.aspx">Report5</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton6" runat="server" href="Report6.aspx">Report6</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton7" runat="server" href="Report7.aspx">Report7</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton8" runat="server" href="Report8.aspx">Report8</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton9" runat="server" href="Report9.aspx">Report9</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton10" runat="server" href="Report10.aspx">Report10</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton11" runat="server" href="Report11.aspx">Report11</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton12" runat="server" href="Report12.aspx">Report12</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton13" runat="server" href="Report13.aspx">Report13</asp:LinkButton></li>
                  <li>
                    <asp:LinkButton ID="Satisfaction" runat="server" href="Satisfaction.aspx">Satisfaction</asp:LinkButton></li>
            </ul>
        </li>
        <li><a href="contactus.aspx">Contact Us</a>
            <ul>
                <li><a href="contactus.aspx">Contact Us</a></li>
                <li><a href="#">About Us</a></li>
            </ul>
        </li>
        <li><a href="http://www.airmacau.com.mo/" target="_blank">Airmacau</a></li>
        <li><a href="http://intranet" target="_blank">Intranet</a></li>
        <li><a href="Default.aspx">Log Out</a></li>

    </ul>
</div>
<div style="clear: both"></div>
