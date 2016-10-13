<%@ Control Language="C#" AutoEventWireup="true" CodeFile="leftmenu.ascx.cs" Inherits="leftmenu" %>


 <!--css-->
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/leftmenu.css" rel="stylesheet" type="text/css" />

 <!--js-->
 <script src="js/leftmenu.js" type="text/javascript"></script>

 

<ul id="nav">
<li><a href="Home.aspx">Home</a></li>
<li><a href="changpassword.aspx">User service<img  style="position:absolute;right:0;bottom:0; display:block; background-color:F9F9F9" src="images/right.bmp" alt="more" border="none"  /></a>
<ul>
 <li><a href="changpassword.aspx">Change Password</a></li> 
</ul>
</li>
<li><a href="crewcheck.aspx">Crew Check<img  style="position:absolute;right:0;bottom:0 ;display:block; background-color:F9F9F9" src="images/right.bmp" alt="more" border="none"  /></a>
 <ul>
 <li><a href="crewcheck.aspx">Crew Check Search</a></li>
 <li><a href="Station_Crew_Pair.aspx">Stn Check Search</a></li>
 <li><a href="InsertCC.aspx">Add Crew Check</a></li>
 <li><a href="InsertSC.aspx">Add Staion Check</a></li>	
 </ul>
</li>
<li><a  href="crew.aspx">Crew Information<img  style="position:absolute;right:0;bottom:0 ;display:block; background-color:F9F9F9" src="images/right.bmp" alt="more" border="none"  /></a>
<ul>
 <li><a href="crew.aspx">Crew Info Search</a></li>
 <li><a href="InsertCrewInfo.aspx">Add Crew Information</a></li>
 </ul>
</li>
<li><a href="http://www.airmacau.com.mo/"  target="_blank">Go To Airmacau</a></li>
<li><a href="contactus.aspx">Contact Us</a></li>
</ul>