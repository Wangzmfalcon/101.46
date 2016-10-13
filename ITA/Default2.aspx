<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
      
        <asp:Repeater ID="rptPeople" runat="server">  
            <HeaderTemplate>  
            <table border="1">  
                <tr>  
                    <td>姓名</td>  
                    <td>年龄</td>  
                    <td>性别</td>  
                </tr>  
            </HeaderTemplate>  
            <ItemTemplate>  
                <tr>  
                    <td><%#DataBinder.Eval(Container.DataItem,"Name") %></td>  
                    <td><%#DataBinder.Eval(Container.DataItem,"Age") %></td>  
                    <td><%#DataBinder.Eval(Container.DataItem,"Sex") %></td>  
                </tr>  
            </ItemTemplate>  
            <AlternatingItemTemplate>  
                <tr style="background:gray">  
                    <td><%#DataBinder.Eval(Container.DataItem,"Name") %></td>  
                    <td><%#DataBinder.Eval(Container.DataItem,"Age") %></td>  
                    <td><%#DataBinder.Eval(Container.DataItem,"Sex") %></td>  
                </tr>  
            </AlternatingItemTemplate>  
            <SeparatorTemplate>  
                <tr style="background:red">  
                    <td>123</td>  
                </tr>  
            </SeparatorTemplate>  
            <FooterTemplate>  
            </table>  
            </FooterTemplate>  
        </asp:Repeater>  
      
    </div>  
    </form>  
</body>  
</html> 