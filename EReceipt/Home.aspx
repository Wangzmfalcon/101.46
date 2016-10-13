<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register Src="~/NAV.ascx" TagName="NAV" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible' />
    <link rel="icon" href="images/airmacau.ico" />
    <title>Home</title>


    <%-- css --%>
        <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:NAV ID="NAV" runat="server" />
        </div>
        <div class="mainbody">
            <div class="bodydiv">
                  <p style="margin-top: 0; padding-top: 20px; font-family: Perpetua,AkzidenzGrotesk,Cambria; margin-left: 55px;font-size:20px"><b>Version 1.0</b></p>
                <div style="  font-family:Perpetua,AkzidenzGrotesk,Cambria;margin-left: 55px; ">
                    <p>1.User Guideline<a class="fa fa-download" href="temp/E-Receipt User Guideline.xlsx"></a></p>
                  
                </div>


            </div>
        </div>
    </form>
</body>
</html>
