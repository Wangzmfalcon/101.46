<%@ Page Language="C#" Debug="false" AutoEventWireup="true" CodeFile="query.aspx.cs" Inherits="query" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            text-align: center;
        }
    </style>
</head>
<body style="text-align: left">
    <form id="form1" runat="server">
    <div class="style1">
    <div style="height: 150px; width: 923px;text-align: center;">
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/airmacau.png" />
        <br />
        <asp:Label ID="Label1" runat="server" style="font-size: 30px; font-weight: 700; color: #FF0000;" 
            Text="Airmacau Flight Time Calculate System "></asp:Label>
        
    
    </div>
        <div class="style2">
        
    <asp:Label ID="Label2" runat="server" style="text-align: left" Text="StaffNO"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" style="text-align: left" Text="LastDate"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" style="text-align: left" Text="Period"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" DataMember="asd ">
    </asp:DropDownList>

    <asp:Button ID="Button1" runat="server" Text="Query" onclick="Button1_Click" />
            <br />
            <br />
            <br />
            <br />
            <div>
                Total Flight time:<asp:Label ID="Label7" runat="server" Text="0"></asp:Label>
            </div>
            <br />
        </div>
       
        <br />
        <br />
        Detail Flight imformation:<br />
        <asp:GridView ID="GridView2" runat="server" BackColor="#339966">
            <HeaderStyle BackColor="#0099CC" BorderColor="Black" />
        </asp:GridView>
        
    <br />
    <br />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">home</asp:HyperLink>
    <br />
&nbsp;&nbsp;
    </div>
    </form>
</body>
</html>
