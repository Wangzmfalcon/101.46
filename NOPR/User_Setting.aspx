<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Setting.aspx.cs" Inherits="User_Setting" %>

<%@ Register Src="~/NAV.ascx" TagName="NAV" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" href="images/airmacau.ico" />
    <title>User Setting</title>


    <%-- css --%>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:NAV ID="NAV" runat="server" />
        </div>
        <div class="mainbody">
            <div class="bodydiv" style="padding-top: 20px; padding-bottom: 20px; font-family: Cambria, Helvetica, sans-serif;">
                <div class="col-md-1">Login:</div>
                <div class="col-md-5">
                    <asp:TextBox ID="UserID" runat="server"></asp:TextBox></div>
                <div class="col-md-6">
                    Admin Level:<asp:DropDownList ID="Level" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="bodydiv" style="padding-bottom: 20px; padding-top: 20px; font-family: Cambria, Helvetica, sans-serif;">
                <div class="col-md-1">E-Mail:</div>
                <div class="col-md-5">
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox></div>
            <div class="col-md-6">
                <asp:LinkButton class="gridbutton" ID="Add" runat="server" Text="Add" OnClick="save_Click" />
                <asp:LinkButton class="gridbutton" ID="Edit" runat="server" Text="Edit" OnClick="Edit_Click" />
                <asp:LinkButton class="gridbutton" ID="Delete" runat="server" Text="Delete" OnClick="delete_Click" />
            </div>
        </div>
        <div>

            <asp:Repeater ID="User" runat="server">

                <HeaderTemplate>
                    <table class="grid grid-striped grid-hover ">
                        <tr>
                            <th>Login Name</th>

                            <th>Admin Level</th>

                            <th>E-Mail</th>
                            <%-- <th>Delete</th>--%>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><a href="#" onclick="deleteitem('<%#Eval("NOPR_UserName") %>','<%#Eval("NOPR_Admin_Level") %>','<%#Eval("Email") %>')"><%#Eval("NOPR_UserName")%></a></td>


                        <td><font> <%#Eval("NOPR_Admin_Level")%></font></td>
                        <td><font> <%#Eval("Email")%></font></td>

                        <%-- <td>
                            <a class="gridbutton" role="button" onclick="deleteitem('<%#Eval("id") %>','<%#Eval("STATION")%>','<%#Eval("STATION_CODE")%>','<%#Eval("STATION_NAME")%>')">Delete</a>

                        </td>--%>
                    </tr>
                </ItemTemplate>
                <%--   <AlternatingItemTemplate>
                    <tr>
                        <td><a href='Default.aspx?id=<%#"databaselogid" %>'><%#("STATION_NAME")%></a></td>
                    </tr>
                </AlternatingItemTemplate>--%>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>





        <div class="pagebreak bodydiv">

            <div class="col-md-3">
                <asp:Label ID="lblCurrentPage" runat="server"
                    Text="Label"></asp:Label>&nbsp;
                Total :<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="col-md-1">
                <asp:HyperLink ID="first" runat="server"><i class="fa fa-angle-double-left" aria-hidden="true"></i></asp:HyperLink>

                <asp:HyperLink ID="up" runat="server"><i class="fa fa-angle-left" aria-hidden="true"></i></asp:HyperLink>
            </div>
            <div class="col-md-1">
                <asp:HyperLink ID="next" runat="server"><i class="fa fa-angle-right" aria-hidden="true"></i></asp:HyperLink>

                <asp:HyperLink ID="last" runat="server"><i class="fa fa-angle-double-right" aria-hidden="true"></i></asp:HyperLink>
            </div>
        </div>
        </div>
    </form>
    <script>



        function deleteitem(i, a, b) {
            $("#UserID").val(i);
            $("#Level").val(a);
            $("#Email").val(b);

        }
    </script>
</body>

</html>
