<%@ Page Language="C#"Debug="false"   AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <%-- <asp:UpdateProgress runat="server"></asp:UpdateProgress>--%>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            color: #FF0000;
            font-weight: bold;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p class="style1">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/airmacau.png" />
        </p>
    <p class="style1">
        <asp:Label ID="Label1" runat="server" style="font-size: 30px; font-weight: 700; color: #FF0000;" 
            Text="Airmacau Flight Time Calculate System "></asp:Label>
        </p>
    <p style="text-align: center">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" Height="24px" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="Button1" runat="server" Text="upload" Height="24px" 
            onclick="Button1_Click" />
    </p>
    <asp:Label ID="Label2" runat="server" style="color: #FF0000"></asp:Label>

    <br />

    <br />
    <span class="style2">Error Data</span><asp:GridView ID="GridView1" 
        runat="server" BackColor="#339966">
        <HeaderStyle BackColor="#0099CC" />
    </asp:GridView>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" 
        style="text-align: center">home</asp:HyperLink>
    <br />
    </form>
</body>
</html>
