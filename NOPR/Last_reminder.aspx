<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Last_reminder.aspx.cs" Inherits="Last_reminder" %>

<%@ Register Src="~/NAV.ascx" TagName="NAV" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible' />
    <link rel="icon" href="images/airmacau.ico" />

    <title>Last reminder</title>


    <%-- css --%>
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:NAV ID="NAV" runat="server" />
        </div>
        <div class="mainbody">
            <p style="margin-top: 0; padding-top: 20px; font-family: Perpetua,AkzidenzGrotesk,Cambria; margin-left: 55px;"><b>Last Reminder</b></p>
            <div style="margin-top: 20px" class="bodydiv">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Upload" runat="server" Text="Upload" OnClick="Upload_Click" />
                <asp:Button ID="Send" runat="server" Text="Send" OnClick="Send_Click" />
            </div>
            <div>
                <asp:Repeater ID="Email_table" runat="server">

                    <HeaderTemplate>
                        <table class="grid grid-striped grid-hover ">
                            <tr>
                                <th>Staff No.</th>
                                <th>Name</th>
                                <th>Verified Result</th>
                                <th>Roster Punch Date</th>
                                <th>Roster Punch Time</th>
                                <th>Email</th>
                                <th>GM's Email</th>
                                <th>Ohter's Email</th>
                                <%-- <th>Delete</th>--%>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><font> <%#Eval("StaffID")%></font></td>
                            <td><font> <%#Eval("Name")%></font></td>
                            <td><font> <%#Eval("Result")%></font></td>
                            <td><font> <%#Eval("Punch_Date")%></font></td>
                            <td><font> <%#Eval("Punch_Time")%></font></td>
                            <td><font> <%#Eval("Email")%></font></td>
                            <td><font> <%#Eval("GM_Email")%></font></td>
                            <td><font> <%#Eval("Other_Email")%></font></td>
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
                    Total Data Count:<asp:Label ID="datacount" runat="server" Text="Label"></asp:Label>

                </div>
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

        <script type="text/javascript">
            function check() {
                if (window.confirm('Confirm to send the E-Mail')) {
                    //alert("确定");
                    return true;
                } else {
                    //alert("取消");
                    return false;
                }
            }
        </script>
    </form>
</body>
</html>
