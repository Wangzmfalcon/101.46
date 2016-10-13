<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Airmacau.ascx.cs" Inherits="WebUserControl" %>
 <!--css-->
<link href="css/ascx_body.css" rel="stylesheet" media="screen" type="text/css" />
<link href="css/ascx_menu.css" rel="stylesheet" media="screen" type="text/css" />
 <!--js-->
 <script src="js/mainmen_selecet.js" type="text/javascript"></script>
  <script src="js/mainmenu_color.js" type="text/javascript"></script>

<div id="systitle">
<div style="border-top: 4px solid #382649; width:1000px"></div>
<div class="logo">    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/logo.gif"  
            width="152" height="40"
            onclick="ImageButton1_Click" title ="Home page" />
        </div>
<div class="toptitle">XXXX System</div>
</div>

<div style="border-bottom: 4px solid #382649; width:1000px"></div>
<div style=" width:1000px"></div>
<div style=" background:#324143; width:1000px">
<ul id="jsddm">
<li><a href="http://www.airmacau.com.mo/" target="_blank">Home</a></li>
	<li><a href="#">GAD</a>
		<ul>
			<li><a href="#">HR</a></li>
			<li><a href="#">IT</a></li>
			<li><a href="#">Training</a></li>
            <li><a href="#">Admin</a></li>
		</ul>
	</li>
	<li><a href="#">FIN</a>
		<ul>
			<li><a href="#">GA</a></li>
			<li><a href="#">MA</a></li>
			<li><a href="#">RA</a></li>
			<li><a href="#">Treasury</a></li>
			<li><a href="#">CP</a></li>
		</ul>
	</li>
	<li><a href="#">ENM</a>
		<ul>
			<li><a href="#">MR</a></li>
			<li><a href="#">Engineering</a></li>
			<li><a href="#">Quality</a></li>
			<li><a href="#">AM</a></li>
            <li><a href="#">MC</a></li>
		</ul>
	</li>
	<li><a href="#">COM</a>
		<ul>
			<li><a href="#">RM</a></li>
			<li><a href="#">E-Com</a></li>
			<li><a href="#">R&T</a></li>
		</ul>
	</li>
    <li><a href="#">FO</a>
		<ul>
			<li><a href="#">FT</a></li>
			<li><a href="#">FS</a></li>
			<li><a href="#">CT</a></li>
            <li><a href="#">CS</a></li>
		</ul>
	</li>
	<li><a href="http://www.airmacau.com.mo/" target="_blank">Help</a></li>
</ul>
</div>
