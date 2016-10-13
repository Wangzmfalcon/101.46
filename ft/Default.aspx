<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="height: 550px; width: 996px">
    
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/airmacau.png" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" style="font-size: xx-large; font-weight: 700; color: #FF0000;" 
            Text="Airmacau Flight Time Calculate System "></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/upload.aspx" 
            style="color: #000000">uploadFT</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HyperLink3" 
            runat="server" NavigateUrl="~/uploadRoster.aspx" style="color: #000000">uploadRoster</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/query.aspx" 
            style="color: #000000">query</asp:HyperLink>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
