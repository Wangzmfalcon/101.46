<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Authorizationprint.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Authorization Print</title>
    <script src="./js/jquery-1.11.3.min.js"></script>
    <style type="text/css">
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

            .half {
                width: 130mm;
                height: 186mm;
                margin-left: 15mm;
                margin-top: 12mm;
                float: left;
                display: block;
                border: 1px solid black;
            }

            .half1 {
                width: 130mm;
                height: 186mm;
                margin-right: 15mm;
                margin-top: 12mm;
                float: right;
                display: block;
                border: 1px solid black;
            }

            .half p {
                margin-right: 3mm;
                margin-left: 3mm;
            }

            .half1 p {
                margin-right: 3mm;
                margin-left: 3mm;
            }



            .titlebar {
                height: 27mm;
                position: relative;
                margin: 0px;
                z-index: 100;
                background: transparent;
                background-color: #fff;
                border-bottom: 1px solid black;
            }

            .lincensebar {
                height: 17mm;
                position: relative;
                margin: 0px;
                z-index: 100;
                background: transparent;
                background-color: #fff;
                border-bottom: 1px solid black;
                font-family: Arial;
                font-size: small;
            }

            .wrapper {
                width: 317mm;
                height: 210mm;
                display: block;
                background-color: #fff;
                margin-top: 10mm;
                margin-left: auto;
                margin-right: auto;
                page-break-after: always;
            }

            .wrapper1 {
                width: 317mm;
                height: 200mm;
                display: block;
                background-color: #fff;
                margin-top: 10mm;
                margin-bottom: 0mm;
                margin-left: auto;
                margin-right: auto;
                page-break-after: always;
            }


            #companylogo {
                position: absolute;
                left: 4mm;
                top: 5mm;
            }

            #AUT {
                position: absolute;
                left: 49mm;
                top: 5mm;
                font-weight: 900;
                font-family: arial;
            }

            #titleuser {
                position: absolute;
                right: 8mm;
                top: 12mm;
                font-family: arial;
                font-size: small;
            }


            #lincense {
                display: inline-block;
                width: 200px;
                margin-left: 5mm;
                position: absolute;
                font-weight: 200;
                font-family: arial;
            }

                #lincense p {
                    margin-top: 3mm;
                    margin-bottom: 0mm;
                }




            #category {
                position: relative;
                left: 50mm;
                font-family: arial;
                display: inline-block;
            }

            #led {
                position: relative;
                left: 60mm;
                font-family: arial;
                display: inline-block;
            }

            #backmark {
                position: relative;
                left: 60mm;
                font-family: arial;
                margin-top: 10px;
                font-size: 2mm;
            }

            #backmark1 {
                position: absolute;
                left: 60mm;
                font-family: arial;
                top: 134mm;
                font-size: 2mm;
            }

            #verson {
                position: relative;
                left: 3mm;
                font-family: arial;
                margin-top: 200px;
            }

            #verson1 {
                position: absolute;
                left: 3mm;
                font-family: arial;
                top: 132mm;
                font-size: 2mm;
            }

            #signname {
                display: inline;
                top: 110mm;
                position: absolute;
                left: 10mm;
                font-family: arial;
                font-weight: 200;
                font-size: xx-small;
            }


                #signname input {
                    margin-left: 0mm;
                    border: 0;
                    border-bottom: 1px solid;
                    width: 25mm;
                }

                #signname p {
                    margin-left: 0mm;
                }


            #signdate {
                display: inline-block;
                top: 110mm;
                position: absolute;
                right: 10mm;
                font-family: arial;
                font-weight: 200;
                font-size: xx-small;
            }


            #datahead {
                display: inline-block;
                top: 0mm;
                width: 25mm;
                position: absolute;
                left: 5mm;
                font-family: arial;
                font-weight: 200;
                font-size: xx-small;
            }

            #signdate input {
                border: 0;
                border-bottom: 1px solid;
                width: 25mm;
            }

            #datafield {
                height: 135mm;
                position: relative;
                margin: 0px;
                z-index: 100;
                background: transparent;
                background-color: #fff;
            }

            #category p {
                margin-top: 3mm;
                margin-bottom: 0mm;
                font-weight: 200;
            }

            #led p {
                margin-top: 3mm;
                margin-bottom: 0mm;
                font-weight: 200;
            }

            #back_left {
                font-family: arial;
                font-weight: 200;
                font-size: 8pt;
                line-height: 2.7mm;
            }

            #back_right {
                font-family: arial;
                font-weight: 200;
                font-size: 8pt;
                line-height: 2.7mm;
            }

                #back_right p {
                    margin-top: 0mm;
                    margin-bottom: 0mm;
                }

            #back_left p {
                margin-top: 0mm;
                margin-bottom: 0mm;
            }


            #form1 {
                margin-bottom: 0mm;
            }

            .h_style {
                border-bottom: 1px solid black;
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
        <!--  整体 -->
        <div id="front" class="wrapper">
            <!-- 正面 -->
            <div id="front_left" class="half">
                <div class="titlebar">
                    <div id="companylogo">
                        <img src="./images/logo.gif" style="font-size: 0; display: block; background-repeat: no-repeat;">
                    </div>
                    <div id="AUT">
                        <a>AUTHORIZATION</a>
                    </div>
                    <div id="titleuser">
                        <asp:Label ID="staffid" runat="server">staffid</asp:Label></br>
					<asp:Label ID="name" runat="server">name</asp:Label>
                    </div>
                </div>
                <div class="lincensebar">
                    <div id="lincense">
                        <p><b>License:</b></p>
                        &nbsp;&nbsp;&nbsp;
					<asp:Label ID="Label1" runat="server">License</asp:Label>
                    </div>
                    <div id="category">
                        <p><b>Category:</b></p>
                        &nbsp;&nbsp;&nbsp;
					<asp:Label ID="Label9" runat="server">category</asp:Label>
                    </div>
                    <div id="led">
                        <p><b>License Expiry Date:</b></p>
                        &nbsp;&nbsp;&nbsp;
					<asp:Label ID="Label2" runat="server">Expired Date</asp:Label>
                    </div>
                </div>
                <div id="datafield">
                    <div id="datahead">
                        <p style="font-weight: 900">Authorizations:</p>
                    </div>
                    <div style="margin-left: 5mm; margin-top: 10mm; position: absolute; font-family: arial; font-size: x-small;">
                        <asp:GridView ID="GridView1" runat="server" BorderStyle="None"
                            CellPadding="0" GridLines="None" AutoGenerateColumns="False">

                            <Columns>
                                <asp:TemplateField HeaderText="Subject" ItemStyle-Width="25mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" CssClass="control" runat="server" Width="25mm" Height="" Text='<%# Bind("Project") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="25mm"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Rating" ItemStyle-Width="45mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" CssClass="control" runat="server" Width="35mm" Text='<%# Bind("Range") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="45mm"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level" ItemStyle-Width="20mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" CssClass="control" runat="server" Width="20mm" Text='<%# Bind("Level") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="20mm"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Stamp" ItemStyle-Width="20mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Labelstamp" CssClass="control" runat="server" Width="20mm" Text='<%# Bind("stamp") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="20mm"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ExpireDate" ItemStyle-Width="20mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" CssClass="control" runat="server" Width="20mm" Text='<%# Bind("ExpireDate") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="80px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>

                            <RowStyle Font-Names="Arial" Height="20px" />

                        </asp:GridView>
                    </div>
                    <div id="signname">
                        <label style="font-weight: 900">GMQA:</label>
                        <input type="text" name="signname">
                        <p>Print Name:YU Shouhai</p>
                    </div>
                    <div id="signdate">
                        <label style="font-weight: 900">DATE:</label>
                        <input type="text" name="signDdate">
                    </div>
                    <div id="verson1">
                        <p>PM 1.7.1-01-F(22-Jan-2016)</p>
                    </div>
                    <div id="backmark1">
                        <p>FRONT</p>
                    </div>
                </div>

            </div>

            <div id="front_right" class="half1">
                <div class="titlebar">
                    <div id="companylogo">
                        <img src="./images/logo.gif" style="font-size: 0; display: block; background-repeat: no-repeat;">
                    </div>
                    <div id="AUT">
                        <a>AUTHORIZATION</a>
                    </div>
                    <div id="titleuser">
                        <asp:Label ID="staffid1" runat="server">staffid</asp:Label></br>
					<asp:Label ID="name1" runat="server">name</asp:Label>
                    </div>
                </div>
                <div class="lincensebar">
                    <div id="lincense">
                        <p><b>License:</b></p>
                        &nbsp;&nbsp;&nbsp;
					<asp:Label ID="Label4" runat="server">License</asp:Label>
                    </div>
                    <div id="category">
                        <p><b>Category:</b></p>
                        &nbsp;&nbsp;&nbsp;
					<asp:Label ID="Label5" runat="server">category</asp:Label>
                    </div>
                    <div id="led">
                        <p><b>License Expiry Date:</b></p>
                        &nbsp;&nbsp;&nbsp;
					<asp:Label ID="Label3" runat="server">Expired Date</asp:Label>
                    </div>
                </div>
                <div id="datafield">
                    <div id="datahead">
                        <p style="font-weight: 900">Authorizations:</p>
                    </div>
                    <div style="margin-left: 5mm; margin-top: 10mm; position: absolute; font-family: arial; font-size: xx-small;">
                        <asp:GridView ID="GridView2" runat="server" BorderStyle="None"
                            CellPadding="0" GridLines="None" AutoGenerateColumns="False">

                            <Columns>
                                <asp:TemplateField HeaderText="Subject" ItemStyle-Width="25mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" CssClass="control" runat="server" Width="25mm" Text='<%# Bind("Project") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="25mm"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Rating" ItemStyle-Width="40mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" CssClass="control" runat="server" Width="35mm" Text='<%# Bind("Range") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="40mm"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level" ItemStyle-Width="20mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" CssClass="control" runat="server" Width="20mm" Text='<%# Bind("Level") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="20mm"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Stamp" ItemStyle-Width="20mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Labelstamp" CssClass="control" runat="server" Width="20mm" Text='<%# Bind("stamp") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="20mm"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ExpireDate" ItemStyle-Width="20mm" HeaderStyle-CssClass="h_style" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" CssClass="control" runat="server" Width="20mm" Text='<%# Bind("ExpireDate") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                    <ItemStyle Width="80px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>

                            <RowStyle Font-Names="Arial" Height="20px" />

                        </asp:GridView>
                    </div>
                    <div id="signname">
                        <label style="font-weight: 900">GMQA:</label>
                        <input type="text" name="signname">
                        <p>Print Name:YU Shouhai</p>
                    </div>
                    <div id="signdate">
                        <label style="font-weight: 900">DATE:</label>
                        <input type="text" name="signDdate">
                    </div>
                    <div id="verson1">
                        <p>PM 1.7.1-01-F(22-Jan-2016)</p>
                    </div>
                    <div id="backmark1">
                        <p>FRONT</p>
                    </div>
                </div>
            </div>
        </div>
        <div id="back" class="wrapper1">
            <!-- 反面 -->
            <div id="back_left" class="half">
                <%--	<p>&nbsp;</p>
            <p class="auto-style1"><B>Definition:</B></p>
			<p class="auto-style1">AACM: Civil Aviation Authority - Macao, China</p>
			<p class="auto-style1">AMU: Air Macau</p>
			<p class="auto-style1">CRS: Certificate of Release to Service</p>
			<p class="auto-style1">JMM: Joint Maintenance Management</p>
			<p class="auto-style1">MEPM: Maintenance & Engineering Procedure Manual</p>
			<p class="auto-style1">MOA: Maintenance Organization Approval</p>
            <p>&nbsp;</p>
                --%>
                <p>&nbsp;</p>
                <p><b>Remark:</b>&nbsp;</p>
                <p>&nbsp;</p>
                <li>
                    <p>CS-A (+W and/or +A): Aircraft Certifying Staff (+ Weekly Check and/or + A Check CRS)   </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>CS-C: Component Certifying Staff                                                       </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>CS-JMM: JMM Certifying Staff                                                           </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>RII: Required Inspection Items                                                         </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>CMR: Certificate of Maintenance Review                                                 </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>GRI: Goods Receipt Inspection                                                          </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>BSI: Borescope Inspection                                                              </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>NDT: Non Destructive Testing                                                           </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>HP: High Powered Engine Run                                                            </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>LP: Low Powered Engine Run                                                             </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS: Line Maintenance Qualifying Staff                                                  </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS-CM: Cabin Maintenance Qualifying Staff                                              </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS-SM: Sheet Metal Qualifying Staff                                                    </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS-C: Composite Repair Qualifying Staff                                                </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS-P: Painting Qualifying Staff                                                        </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>GRI*:  Good Receipt Inspection (Except Tools, Equipment, Engine & APU, C-duct, Translating Sleeve and Landing Gear Assembly)                                                      </p>
                </li>
                </br>

			<p><b>Note: </b></p>
                <p>&nbsp;</p>
                <p>1.	Refer to MEPM 1.7.1 for the detail privileges, rating & level of the authorization subjects.</p>
                <p>&nbsp;</p>
                <p>2.	The authorizations valid till each Expiry Date inclusive.                                   </p>
                <p>&nbsp;</p>
                <p>3.	A duplicate copy of this authorization letter is retained in QD.                            </p>
                <p>&nbsp;</p>
                <div id="verson">
                    <p>PM 1.7.1-01-F(22-Jan-2016)</p>
                </div>
                <div id="backmark">
                    <p>BACK</p>
                </div>
            </div>
            <div id="back_right" class="half1">
                <%--	<p>&nbsp;</p>
            <p><B>Definition:</B></p>
			<p>AACM: Civil Aviation Authority - Macao, China</p>
			<p>AMU: Air Macau</p>
			<p>CRS: Certificate of Release to Service</p>
			<p>JMM: Joint Maintenance Management</p>
			<p>MEPM: Maintenance & Engineering Procedure Manual</p>
			<p>MOA: Maintenance Organization Approval</p>
            <p>&nbsp;</p>--%>

                <p>&nbsp;</p>
                <p><b>Remark:</b></p>
                <p>&nbsp;</p>
                <li>
                    <p>CS-A (+W and/or +A): Aircraft Certifying Staff (+ Weekly Check and/or + A Check CRS)   </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>CS-C: Component Certifying Staff                                                       </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>CS-JMM: JMM Certifying Staff                                                           </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>RII: Required Inspection Items                                                         </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>CMR: Certificate of Maintenance Review                                                 </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>GRI: Goods Receipt Inspection                                                          </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>BSI: Borescope Inspection                                                              </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>NDT: Non Destructive Testing                                                           </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>HP: High Powered Engine Run                                                            </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>LP: Low Powered Engine Run                                                             </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS: Line Maintenance Qualifying Staff                                                  </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS-CM: Cabin Maintenance Qualifying Staff                                              </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS-SM: Sheet Metal Qualifying Staff                                                    </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS-C: Composite Repair Qualifying Staff                                                </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>QS-P: Painting Qualifying Staff                                                        </p>
                </li>
                <p>&nbsp;</p>
                <li>
                    <p>GRI*:  Good Receipt Inspection (Except Tools, Equipment, Engine & APU, C-duct, Translating Sleeve and Landing Gear Assembly)                                                      </p>
                </li>
                </br>
                <p><b>Note: </b></p>
                <p>&nbsp;</p>
                <p>1.	Refer to MEPM 1.7.1 for the detail privileges, rating & level of the authorization subjects.</p>
                <p>&nbsp;</p>
                <p>2.	The authorizations valid till each Expiry Date inclusive.                                   </p>
                <p>&nbsp;</p>
                <p>3.	A duplicate copy of this authorization letter is retained in QD.                            </p>
                <p>&nbsp;</p>
                <div id="verson">
                    <p>PM 1.7.1-01-F(22-Jan-2016)</p>
                </div>
                <div id="backmark">
                    <p>BACK</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
