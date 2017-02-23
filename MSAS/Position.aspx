<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Position.aspx.cs" Inherits="Position" %>

<%@ Register Src="Airmacau.ascx" TagName="Airmacau1" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <meta name="author" content="Airmacau/ITD" />
    <meta name="Copyright" content="Airmacau" />
    <meta name="description" content="Airmacau" />
    <meta name="keywords" content="Airmacau" />
    <!--css-->
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .grid {
    width: 100%;
    max-width: 100%;
    margin-top: 20px;
    font-family: Cambria, Helvetica, sans-serif;
    background-color: transparent;
    border-spacing: 0;
    border-collapse: collapse;
    border-spacing: 2px;
    border-color: grey;
}


        .grid tr {
    display: table-row;
    vertical-align: inherit;
    border-color: inherit;
}


    .grid tr th {
        vertical-align: bottom;
        border-bottom: 2px solid #ddd;
      
        padding: 8px;
        line-height: 1.42857143;
        text-align: left;
        font-weight: bold;
    }

    .grid tr td {
        padding: 8px;
          
        line-height: 1.42857143;
        vertical-align: top;
        border-top: 1px solid #ddd;
    }

    </style>

    <title>Position</title>


</head>

<body>

    <form id="form1" runat="server">

        <div id="backpanel">
            <uc1:Airmacau1 ID="Airmacau1" runat="server" />

            <div id="pagebody">


                <div id="Contentpanel">
                    <div id="linkweb" style="float: left; width: 500px; height: 25px; font-size: 14px;">
                    </div>
                    <script type="text/javascript">    setInterval("linkweb.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());", 1000);
                    </script>
                    <div id="welcome" style="width: 500px; height: 25px; text-align: right; font-size: 14px; float: left;">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                    <div style="height: 30px; text-align: center; color: black; font-size: large">
                        Position Setting
                    </div>
                    <div style="padding-top: 20px; padding-bottom: 20px; font-family: Cambria, Helvetica, sans-serif;">


                        <div style="margin-left: auto; margin-right: auto; margin-top: 30px; width: 600px;">
                            id:<asp:TextBox ID="Position_id" runat="server" required="required"></asp:TextBox>

                            Position:<asp:TextBox ID="Position_name" runat="server" required="required"></asp:TextBox>

                            <asp:LinkButton ID="Add" runat="server" Text="Add" OnClick="save_Click" />
                            <asp:LinkButton ID="Delete" runat="server" Text="Delete" OnClick="delete_Click" />
                        </div>
                    </div>
                    <div  style="margin-left: auto; margin-right: auto; margin-top: 30px; width: 600px;">

                        <asp:Repeater ID="Position_table" runat="server">

                            <HeaderTemplate>
                                <table class="grid" style="width: 50%">
                                    <tr>
                                        <th>Id</th>
                                        <th>Position</th>
                                        <%--    <th>Station Code </th>
                            <th>Station Name</th>--%>
                                        <%-- <th>Delete</th>--%>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><a href="#" onclick="deleteitem('<%#Eval("id")%>')"><%#Eval("id")%></a></td>
                                    <td><font><%#Eval("Position")%></font></td>
                                    <%--                        <td><font> <%#Eval("STATION_CODE")%></font></td>
                        <td><font> <%#Eval("STATION_NAME")%></font></td>--%>
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
                    <div style="margin-left: auto; margin-right: auto; margin-top: 30px; width: 600px;">
                        <div>
                            <asp:Label ID="lblCurrentPage" runat="server"
                                Text="Label"></asp:Label>&nbsp;
                Total :<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div>
                            <asp:HyperLink ID="first" runat="server">First</asp:HyperLink>
                            <asp:HyperLink ID="up" runat="server">previous</asp:HyperLink>
                            <asp:HyperLink ID="next" runat="server">Next</asp:HyperLink>
                            <asp:HyperLink ID="last" runat="server">Last</asp:HyperLink>
                        </div>

                    </div>
                </div>
            </div>
            <div id="copyright">
                Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
            </div>
        </div>
    </form>
        <script type="text/javascript">



            function deleteitem(i) {
                document.getElementById("Position_id").value = i;
                //$("#id").val(i);
            }
    </script>
</body>
</html>
