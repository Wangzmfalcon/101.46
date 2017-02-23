<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Airmacau.ascx.cs" Inherits="WebUserControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="css/ascx_body.css" rel="stylesheet" media="screen" type="text/css" />
<link href="css/ascx_menu.css" rel="stylesheet" media="screen" type="text/css" />
<!--js-->
<script src="js/mainmen_selecet.js" type="text/javascript"></script>
<script src="js/mainmenu_color.js" type="text/javascript"></script>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Main</title>
    <style type="text/css">
        /* common styling */
        /* set up the overall width of the menu div, the font and the margins */
        .menu {
            font-family: arial, sans-serif;
            width: 1000px;
            margin: 0;
        }
            /* remove the bullets and set the margin and padding to zero for the unordered list */
            .menu ul {
                padding: 0;
                margin: 0;
                list-style-type: none;
            }
                /* float the list so that the items are in a line and their position relative so that the drop down list will appear in the right place underneath each list item */
                .menu ul li {
                    float: left;
                    position: relative;
                }
                    /* style the links to be 104px wide by 30px high with a top and right border 1px solid white. Set the background color and the font size. */
                    .menu ul li a, .menu ul li a:visited {
                        display: block;
                        text-align: center;
                        text-decoration: none;
                        width: 104px;
                        height: 30px;
                        color: #000;
                        border: 1px solid #fff;
                        border-width: 1px 1px 0 0;
                        background: #B0B0B0;
                        line-height: 30px;
                        font-size: 12px;
                    }
                    /* make the dropdown ul invisible */
                    .menu ul li ul {
                        display: none;
                    }
                    /* specific to non IE browsers */
                    /* set the background and foreground color of the main menu li on hover */
                    .menu ul li:hover a {
                        color: #fff;
                        background: #b3ab79;
                    }
                    /* make the sub menu ul visible and position it beneath the main menu list item */
                    .menu ul li:hover ul {
                        display: block;
                        position: absolute;
                        top: 31px;
                        left: 0;
                        width: 105px;
                    }
                        /* style the background and foreground color of the submenu links */
                        .menu ul li:hover ul li a {
                            display: block;
                            background: #faeec7;
                            color: #000;
                        }
                            /* style the background and forground colors of the links on hover */
                            .menu ul li:hover ul li a:hover {
                                background: #dfc184;
                                color: #000;
                            }
    </style>
    <!--[if lte IE 6]>
<style type="text/css">
/* styling specific to Internet Explorer IE5.5 and IE6. Yet to see if IE7 handles li:hover */
/* Get rid of any default table style */
table {
border-collapse:collapse;
margin:0; 
padding:0;
}
/* ignore the link used by 'other browsers' */
.menu ul li a.hide, .menu ul li a:visited.hide {
display:none;
}
/* set the background and foreground color of the main menu link on hover */
.menu ul li a:hover {
color:#fff; 
background:#b3ab79;
}
/* make the sub menu ul visible and position it beneath the main menu list item */
.menu ul li a:hover ul {
display:block; 
position:absolute; 
top:32px; 
left:0; 
width:105px;
}
/* style the background and foreground color of the submenu links */
.menu ul li a:hover ul li a {
background:#faeec7; 
color:#000;
}
/* style the background and forground colors of the links on hover */
.menu ul li a:hover ul li a:hover {
background:#dfc184; 
color:#000;
}
</style>
<![endif]-->
</head>
<body>
    <div id="systitle">
        <div style="border-top: 4px solid #382649; width: 1000px"></div>
        <div class="logo">
            <a href="http://www.airmacau.com.mo">
                <img alt="澳门航空" src="images/logo.gif"
                    border="none" /></a>

        </div>
        <div class="toptitle">Maintenance Staff Authorization System</div>
    </div>



    <div class="menu">

        <ul>
            <li><a id="Admin" class="hide" href="Admin.aspx" runat="server">Admin Setting</a>

            </li>
            <li><a id="staffs" class="hide" href="Main.aspx" runat="server">Staff Settings</a>

                <ul>

                    <li><a href="Department.aspx" title="Department Setting">Department Setting</a></li>
                    <li><a href="Position.aspx" title="Division Setting">Division Setting</a></li>
                    <li><a href="Station.aspx" title="Title Setting">Station Setting</a></li>
                    <li><a href="Title.aspx" title="Title Setting">Title Setting</a></li>
					<li><a href="Category.aspx" title="Category Setting">Category Setting</a></li>
                    <li><a href="Staffin.aspx" title="Employee Setting">Employee </a></li>

                </ul>

            </li>

            <li><a id="Authors" style="width: 150px" class="hide" href="Main.aspx" runat="server">Authorization Settings</a>

                <ul>
                    <li><a href="Project.aspx" title="Subject Setting">Subject Setting</a></li>
                    <li><a href="Range.aspx" title="Rating Setting">Rating Setting</a></li>
                    <li><a href="Level.aspx" title="Level Setting">Level Setting</a></li>
     
                </ul>

            </li>
            <li><a id="Author" class="hide" href="Authorization.aspx" runat="server">Authorization</a>

            </li>
            <li><a id="Authorss" style="width: 150px" class="hide" href="AuthorizationSelect.aspx" runat="server">AuthorizationSearch</a>

            </li>
                   <li><a id="Reminder" style="width: 150px" class="hide" href="RS.aspx" runat="server">Reminder Setting</a>
                           <ul>
                    <li><a href="RS.aspx" title="Subject Setting">Reminder Setting</a></li>
                    <li><a href="ML.aspx" title="Rating Setting">Email Setting</a></li>
                  
                </ul>
            </li>
            <li><a id="logout" class="hide" href="Default.aspx" runat="server">Log out</a>

            </li>
        </ul>
        <!-- clear the floats if required -->
        <div class="clear"></div>
    </div>
</body>
</html>
