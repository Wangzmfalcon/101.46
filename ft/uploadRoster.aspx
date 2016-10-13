<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uploadRoster.aspx.cs" Inherits="uploadRoster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/airmacau.png" />
        <br />
        <asp:Label ID="Label1" runat="server" 
            style="font-size: 30px; font-weight: 700; color: #FF0000;" 
            Text="Airmacau Flight Time Calculate System "></asp:Label>
    
    </div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="upload" />
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">home</asp:HyperLink>
    &nbsp;<br />
    <br />
    <br />
    <br />
    Roster Data<asp:GridView ID="GridView1" runat="server" BackColor="#339966">
        <HeaderStyle BackColor="#0099CC" />
    </asp:GridView>
    &nbsp;&nbsp;&nbsp;
    <div style="margin-left: 360px">
    </div>
    </form>
</body>
</html>
