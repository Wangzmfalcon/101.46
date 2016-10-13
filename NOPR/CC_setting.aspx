<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CC_setting.aspx.cs" Inherits="CC_setting" %>

<%@ Register Src="~/NAV.ascx" TagName="NAV" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" href="images/airmacau.ico" />
    <title>CC setting</title>


    <%-- css --%>
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:NAV ID="NAV" runat="server" />
        </div>
        <div class="mainbody ">
            <div class="bodydiv">
                <p style="margin-top: 0; padding-top: 16px;">
                  Enter remind staff to receive E-mail</p><p> Note: separated by 
    semicolons, allowing only add company mailbox that is end of @ airmacau.com.mo
                </p>
                <p>For example:example1@airmacau.com.mo;example2@airmacau.com.mo</p>
                <asp:TextBox ID="TextBox1" runat="server" Height="128px" Width="498px" TextMode="MultiLine"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="OK" />
            </div>
        </div>
    </form>
</body>
</html>
