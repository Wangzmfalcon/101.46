<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report1.aspx.cs" Inherits="Home" %>

<%@ Register Src="~/NAV.ascx" TagName="NAV" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible' />
    <link rel="icon" href="images/airmacau.ico" />
    <title>Home</title>



    <%-- css --%>

    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/Style.css" rel="stylesheet" />
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <style type="text/css">
        .grid tr td {
            border-right: 2px solid #ddd;
        }
    </style>
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
                    <%--    <a class="pagetitle clear">Deposit_Setting
            </a>--%>
                    <span class="clear"></span>
                    <div class="col-md-4">
                        Station:
                <asp:DropDownList ID="Station" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        Num:<asp:TextBox ID="Num" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        Issue Date:<asp:TextBox ID="Issue_Date" runat="server"></asp:TextBox>
                    </div>
                    <span class="clear" style="margin-top: 20px"></span>

                    <div class="col-md-4">
                        Received:<asp:TextBox ID="Received" runat="server"></asp:TextBox>
                    </div>


                    <div class="col-md-4">
                        Balance:<asp:TextBox ID="Balance" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-md-4">
                        Sales Type:<asp:DropDownList ID="Sales" runat="server"></asp:DropDownList>
                    </div>
                    <span class="clear" style="margin-top: 20px"></span>
                    <div class="col-md-4">
                        Deposit Type:<asp:DropDownList ID="Deposit" runat="server"></asp:DropDownList>
                    </div>

                    <div class="col-md-4">
                        <asp:LinkButton class="gridbutton" ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
                    </div>
                    <div class="col-md-4">
                        <a class="fa fa-download fa-2x" style="color:#8981b1" onclick="downloadexcel()"></a>
                        <asp:Button ID="downloadexcelbtn" runat="server" Text="Button" OnClick="downloadexcelbtn_Click" Style="display: none" />

                    </div>
                    <%--           Station Code:<asp:TextBox ID="STATION_CODE" runat="server"></asp:TextBox>
            Station Name:<asp:TextBox ID="STATION_NAME" runat="server"></asp:TextBox>--%>
                </div>
                <span class="clear"></span>
                <div>

                    <asp:Repeater ID="Receipt_table" runat="server">

                        <HeaderTemplate>
                            <table class="grid grid-striped grid-hover" style="width: 100%">
                                <tr>
                                    <th>Station</th>
                                    <th>Number</th>
                                    <th>Issue_Date</th>
                                    <th>Received</th>
                                    <th>Net_Amount</th>
                                    <th>Sales</th>
                                    <th>Deposit</th>
                                    <th>RTNG</th>
                                    <th>PNR</th>
                                    <th>TTL</th>


                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><font> <%#Eval("Station")%></font></td>
                                <td><font> <%#Eval("Num")%></font></td>
                                <td><font> <%#Eval("Issue")%></font></td>
                                <td><font> <%#Eval("Received")%></font></td>
                                <td><font> <%#Eval("Balance")%></font></td>
                                <td><font> <%#Eval("Sales")%></font></td>
                                <td><font> <%#Eval("Deposit")%></font></td>
                                <td><font> <%#Eval("RTNG")%></font></td>
                                <td><font> <%#Eval("PNR")%></font></td>
                                <td><font> <%#Eval("TTL")%></font></td>

                                <%--  <td>

                            <a href="#" title="Edit" onclick="action('Edit','<%#Eval("id")%>')" class="fa fa-edit icon_btn"></a>
                            <a href="#" title="Print" onclick="action('Print','<%#Eval("id")%>')" class="fa fa-print icon_btn"></a>
                            <a href="#" title="Void" onclick="action('Void','<%#Eval("id")%>')" class="fa fa-trash icon_btn"></a>
                        </td>--%>



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
        <script>
            function downloadexcel() {
                //console.log("jquery");
                $("#downloadexcelbtn").click();

            }


        </script>
    </form>
</body>
</html>
