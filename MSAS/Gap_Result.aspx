<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gap_Result.aspx.cs" Inherits="Main" %>

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
    <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible' />

    <!--css-->
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <style type="text/css">
        .position {
            width: 800px;
            margin: auto;
            border-collapse: collapse;
            border-spacing: 2px;
            border: 1px solid;
        }

            .position th {
                border: 1px solid;
            }


            .position td {
                border: 1px solid;
            }


        .td20 {
            width: 20%;
        }

        .td10 {
            width: 10%;
        }
    </style>

    <title>Gap Result</title>


</head>

<body>

    <form id="form1" runat="server">

        <div id="backpanel">
            <uc1:Airmacau1 ID="Airmacau1" runat="server" />

            <div id="pagebody">


                <div id="Contentpanel">
                    <div id="linkweb" style="float: left; width: 500px; height: 25px; font-size: 14px;">
                    </div>
                    <script>    setInterval("linkweb.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());", 1000);
                    </script>
                    <div id="welcome" style="width: 500px; height: 25px; text-align: right; font-size: 14px; float: left;">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>

                    <div id="updatelog" style="width: 950px; margin-left: 50px">
                        <h1>Position Gap Analysis Result</h1>
                        Staff No.<a><%=userstring%></a>

                    </div>
                    <div style="height:550px;overflow:scroll">
                        <table class="position">
                            <tr>
                                <th colspan="3">Before Change</th>
                                <th colspan="3">After Change</th>
                            </tr>


                            <tr>
                                <td class="td10">Position</td>
                                <td class="td20">Course Reference</td>
                                <td class="td20">Class</td>
                                <td class="td10">Position</td>
                                <td class="td20">Course Reference</td>
                                <td class="td20">Class</td>

                            </tr>
                            <tr>
                                <asp:Repeater ID="positionlist" runat="server">
                                    <ItemTemplate>
                                        <%# resultsty((Container.ItemIndex+1))%>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tr>
                        </table>
                    </div>

                </div>
            </div>
            <div id="copyright">
                Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
            </div>
        </div>

    </form>
</body>
</html>
