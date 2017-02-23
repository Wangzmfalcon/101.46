<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Position_Gap.aspx.cs" Inherits="Main" %>

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
            width: 10%;
        }

        .td80 {
            width: 40%;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function ana() {


            var checkedbox = "";
            //check box
            var coll = document.getElementsByName("items")
            for (var i = 0; i < coll.length; i++)
            {
                if (coll[i].checked) {
                    checkedbox += coll[i].id.replace("&","@@@");
                    checkedbox += "|";
                }
                console.log(checkedbox);
            }
                

            var checkedbox1 = "";
            //check box
            var coll = document.getElementsByName("items1")
            for (var i = 0; i < coll.length; i++)
            {
                if (coll[i].checked) {
                    checkedbox1 += coll[i].id.replace("&", "@@@");
                    checkedbox1 += "|";
                }
                console.log(checkedbox1);
            }
               

            window.location.href = "Gap_Result.aspx?staffid=<%=userstring%>&before=" + checkedbox + "&after=" + checkedbox1;
        }
    </script>
    <title>Position Gap Analysis</title>


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
                        <h1>Position Gap Analysis</h1>
                        Staff No.<a><%=userstring%></a>
                       
                    </div>
                     <div><a style="width: 60px; height: 15px; background-color: #fff; display: inline-block; padding: 5px; text-align: center; border-radius: 5px; border: 1px solid #C0C0C0; vertical-align: central; padding-top: 7px; cursor: pointer;margin-left:100px" onclick="ana()">Analysis</a> </div>
                    <div>
                        <table class="position">
                            <tr>
                                <th colspan="2">Before Change</th>
                                <th colspan="2">After Change</th>
                            </tr>
                            <tr>
                                <asp:Repeater ID="positionlist" runat="server">
                                    <ItemTemplate>
                                        <%# positionstyle((Container.ItemIndex+1))%>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tr>
                        </table>
                    </div>
                    <div id="result">
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
