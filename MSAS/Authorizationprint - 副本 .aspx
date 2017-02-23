<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Authorizationprint - 副本 .aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Authorization Print</title>
    <script src="./js/jquery-1.11.3.min.js"></script>
    <style>
        /*.GridView {
            border-top: none;
            border-bottom: none;
            text-align: left;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
        }*/
        .h_style {
            border-bottom: 1px solid black;
        }

        .control {
            text-align: left;
        }


        @media all {
            * {
                box-sizing: border-box;
                -moz-box-sizing: border-box; /* Firefox */
                -webkit-box-sizing: border-box;
            }

            html {
                height: 100%;
            }

            body {
                border: 0;
                margin: 0;
                padding: 0;
                height: 100%;
            }

            input {
                border: 0;
            }

            .wrapper {
                width: 900px;
                height: 297mm;
                display: block;
                background-color: #fff;
                margin: 20px auto;
                border-bottom-style: 1px solid black;
                page-break-after: always;
            }

            .wrapper1 {
                width: 900px;
                height: 297mm;
                display: block;
                background-color: #fff;
                margin: 30px auto;
                border-bottom-style: 1px solid black;
                page-break-after: always;
            }

            .titlebar {
                height: 127px;
                position: relative;
                margin: 0px;
                z-index: 100;
                background: transparent;
                background-color: #fff;
                border: 1px solid black;
            }

            #companylogo {
                position: absolute;
                left: 10px;
                top: 43px;
            }

            #AUT {
                position: absolute;
                left: 305px;
                top: 43px;
                font-weight: 900;
            }

            #titleinfo {
                position: absolute;
                right: 10px;
                top: 10px;
                width: 250px;
                height: 100px;
                margin: 5px 5px;
                background-color: #fff;
                display: block;
            }

            #Expriy {
                width: 200px;
                height: 20px;
                background-color: #fff;
                position: relative;
            }

                #Expriy input {
                    position: absolute;
                    margin-top: 2px;
                }

            #titleuser {
                position: absolute;
                bottom: 6px;
                left: 70px;
            }

                #titleuser input {
                    display: block;
                    width: 150px;
                    margin: 3px 0;
                }

            .licensebar {
                background-color: #fff;
                height: 100px;
                width: 900px;
                border: 1px solid black;
            }

            #license {
                display: inline-block;
                width: 200px;
                margin-left: 10px;
                position: absolute;
            }

                #license p {
                    font-weight: 900;
                    margin-left: 10px;
                }

            #category {
                position: relative;
                left: 400px;
                display: inline-block;
            }

                #category p {
                    font-weight: 900;
                }

            .Authorizationspanel {
                height: 800px;
                width: 900px;
                border-left: 1px solid black;
                border-right: 1px solid black;
                border-top: 1px solid black;
            }


            .Remarkpanel {
                height: 1030px;
                width: 900px;
                border-left: 1px solid black;
                border-right: 1px solid black;
                border-top: 1px solid black;
                border-bottom: 1px solid black;
            }

            .signbar {
                display: block;
                position: relative;
                width: 900px;
                height: 130px;
                bottom: 50px;
                top: 0px;
                left: 0px;
                border-left: 1px solid black;
                border-right: 1px solid black;
                border-bottom: 1px solid black;
            }



                .signbar input {
                    border: 0;
                    border-bottom: 2px solid;
                }

                    .signbar input:focus {
                        border: 0;
                        border-bottom: 2px solid;
                    }

                    .signbar input:active {
                        border: 0;
                    }

                .signbar #signname {
                    display: inline-block;
                    width: 100px;
                    position: absolute;
                    left: 50px;
                }

                .signbar #signDate {
                    display: inline-block;
                    width: 100px;
                    position: absolute;
                    right: 150px;
                }
        }
    </style>

    <script>
        function printme() {
            document.body.innerHTML = document.getElementById('div1').innerHTML
            window.print();
        }

        $(document).ready(function () {
            console.log($("html").height());
            console.log($("body").height());
            console.log($(".wrapper").height());
            console.log($(".wrapper").width());
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">

        <div style="font-family: Arial">
            <%--<div style="width: 649px; margin: 0 auto; text-align: right; font-weight: bolder;"><a href="javascript:printme()" target="_self">Print</a></div>--%>
            <div id="div1">
                <div class="wrapper">
                    <div>
                        <div class="titlebar">
                            <div id="companylogo">
                                <img src="./images/logo.gif" style="font-size: 0; display: block; background-repeat: no-repeat;">
                            </div>
                            <div id="AUT">
                                <p>AUTHORIZATION</p>
                            </div>
                            <div id="titleinfo">
                                <div id="Expriy" style="display:none">
                                    <span>Expiry:<asp:Label ID="Label3" runat="server"></asp:Label></span>
                                </div>
                                <div id="titleuser">
                                    <asp:Label ID="Label4" runat="server"></asp:Label></br>
				<asp:Label ID="Label2" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="licensebar">
                            <div id="license">
                                <p>License:</p>
                                <asp:Label ID="Label1" Style="margin-left: 10px" runat="server"></asp:Label>
                            </div>
                            <div id="category">
                                <p>Category:</p>
                                <asp:Label ID="Label9" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="Authorizationspanel">
                            <div class="panelname">
                                <p style="font-weight: 800; font-size: 120%; margin-left: 50px;">Authorizations:</p>
                            </div>
                            <div style="margin-left: 50px; margin-right: 50px">
                                <asp:GridView ID="GridView1" CssClass="GridView" runat="server" BorderStyle="None"
                                    CellPadding="0" GridLines="None" AutoGenerateColumns="False">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Subject" ItemStyle-Width="80px" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" CssClass="control" runat="server" Width="300px" Text='<%# Bind("Project") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                            <ItemStyle Width="80px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rating" ItemStyle-Width="80px" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" CssClass="control" runat="server" Width="200px" Text='<%# Bind("Range") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                            <ItemStyle Width="80px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level" ItemStyle-Width="80px" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" CssClass="control" runat="server" Width="100px" Text='<%# Bind("Level") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                            <ItemStyle Width="80px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Stamp" ItemStyle-Width="80px" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <asp:Label ID="Labelstamp" CssClass="control" runat="server" Width="100px" Text='<%# Bind("stamp") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                            <ItemStyle Width="80px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ExpireDate" ItemStyle-Width="80px" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" CssClass="control" runat="server" Width="100px" Text='<%# Bind("ExpireDate") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                            <ItemStyle Width="80px"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>

                                    <RowStyle Font-Names="Arial" Height="50px" />

                                </asp:GridView>
                            </div>

                        </div>
                        <div class="signbar">
                            <div id="signname">
                                <p style="font-weight: 900">GMQA:</p>
                                <input type="text" name="signname">
                            </div>
                            <div id="signDate">
                                <p style="font-weight: 900">DATE:</p>
                                <input type="text" name="signDdate">
                            </div>
                        </div>
                    </div>

                </div>
                <div style="height: 10px"></div>
                <div class="wrapper">
                    <div class="titlebar">
                        <div id="companylogo">
                            <img src="./images/logo.gif" style=" font-size: 0; display: block; background-repeat: no-repeat;">
                        </div>

                    </div>
                    <div class="Remarkpanel ">
                    </div>
                </div>

            </div>


        </div>

    </form>
</body>
</html>
