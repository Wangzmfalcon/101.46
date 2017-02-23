<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Authorizationprint.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Authorization Print</title>
    <style>
        .GridView {
            border-top: none;
            border-bottom: none;
            text-align: left;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
        }


        .control {
            text-align: left;
        }
    </style>

    <script>
        function printme() {
            document.body.innerHTML = document.getElementById('div1').innerHTML
            window.print();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">

        <div>
            <div style="width: 649px; margin: 0 auto; text-align: right; font-weight: bolder;"><a href="javascript:printme()" target="_self">Print</a></div>
            <div id="div1">
                LICENSE:<asp:Label ID="Label1" runat="server"></asp:Label>Expiry:<asp:Label ID="Label3" runat="server"></asp:Label>
                <br />
                StaffID：<asp:Label ID="Label4" runat="server"></asp:Label></br>
            NAME:<asp:Label ID="Label2" runat="server"></asp:Label>
                <br />
                </br>

        <asp:GridView ID="GridView1" CssClass="GridView" runat="server" BorderStyle="None"
            CellPadding="0" GridLines="None" AutoGenerateColumns="False">

            <Columns>
                <asp:TemplateField HeaderText="Project" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="left" >
                    <ItemTemplate>
                        <asp:Label ID="Label5" CssClass="control" runat="server" Text='<%# Bind("Project") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Range" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="left" >
                    <ItemTemplate>
                        <asp:Label ID="Label6" CssClass="control" runat="server" Text='<%# Bind("Range") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Level" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="left" >
                    <ItemTemplate>
                        <asp:Label ID="Label7" CssClass="control" runat="server" Text='<%# Bind("Level") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExpireDate" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="left" >
                    <ItemTemplate>
                        <asp:Label ID="Label8" CssClass="control" runat="server" Text='<%# Bind("ExpireDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
          
        </asp:GridView>
            </div>




        </div>
    </form>
</body>
</html>
