<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Station_Setting.aspx.cs" Inherits="Station_Setting" %>

<%@ Register Src="~/NAV.ascx" TagName="NAV" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible' />
    <link rel="icon" href="images/airmacau.ico" />
    <title>Station Setting</title>


    <%-- css --%>

    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/Style.css" rel="stylesheet" />
    <%-- js --%>


    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:NAV ID="NAV" runat="server" />
        </div>
        <div class="mainbody">
            <div class="bodydiv">

                <div style="padding-top: 20px; padding-bottom: 20px; font-family: Cambria, Helvetica, sans-serif;">
                    <p class="pagetitle">Station Setting</p>

                    <asp:TextBox ID="ID" Style="display: none" runat="server"></asp:TextBox>
                    Station:<asp:TextBox ID="STATION_ID" runat="server" Width="150px"></asp:TextBox>
                    Station Code:<asp:TextBox ID="STATION_CODE" runat="server" Width="150px"></asp:TextBox>
                    Station Name:
            <asp:TextBox ID="STATION_NAME" runat="server" Width="150px"></asp:TextBox>
                    <asp:LinkButton class="gridbutton" ID="Add" runat="server" Text="Add" OnClick="save_Click" />

                    <asp:LinkButton class="gridbutton" ID="Delete" runat="server" Text="Delete" OnClick="delete_Click" />

                </div>

                <div>

                    <asp:Repeater ID="Station" runat="server">

                        <HeaderTemplate>
                            <table class="grid grid-striped grid-hover">
                                <tr>
                                    <th>Station</th>
                                    <th>Station Code </th>
                                    <th>Station Name</th>
                                    <%-- <th>Delete</th>--%>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><a href="#" onclick="deleteitem('<%#Eval("id") %>','<%#Eval("STATION")%>','<%#Eval("STATION_CODE")%>','<%#Eval("STATION_NAME")%>')"><%#Eval("STATION")%></a></td>

                                <td><font> <%#Eval("STATION_CODE")%></font></td>
                                <td><font> <%#Eval("STATION_NAME")%></font></td>
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





                <div class="pagebreak">
                    <div class="col-md-3">
                        <asp:Label ID="lblCurrentPage" runat="server"
                            Text="Label"></asp:Label>&nbsp;
                Total :<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>
                    </div>

                    <div class="col-md-3" style="float: right">
                        <div class="col-md-3">
                            <asp:HyperLink ID="first" runat="server"><i class="fa fa-angle-double-left" aria-hidden="true"></i></asp:HyperLink>

                            <asp:HyperLink ID="up" runat="server"><i class="fa fa-angle-left" aria-hidden="true"></i></asp:HyperLink>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <asp:HyperLink ID="next" runat="server"><i class="fa fa-angle-right" aria-hidden="true"></i></asp:HyperLink>

                            <asp:HyperLink ID="last" runat="server"><i class="fa fa-angle-double-right" aria-hidden="true"></i></asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>



        function deleteitem(i, a, b, c) {
            $("#ID").val(i);
            $("#STATION_ID").val(a);
            $("#STATION_NAME").val(b);
            $("#STATION_CODE").val(c);
        }
    </script>
</body>
</html>
