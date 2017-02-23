<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Training_Records_Search.aspx.cs" Inherits="Training_Records_Search" %>

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
    <!--JS-->
    <script language="javascript" type="text/javascript" src="My97Datepicker/WdatePicker.js"></script>


    <title>Training Records Search</title>
    <style type="text/css">
        .searchbox {
            width: 130px;
            height: 20px;
        }

        .col-md-3 {
            width: 25%;
            float: left;
        }


        th {
            color: White;
            background-color: #000084;
            font-weight: bold;
        }

             .datatable td {
            border: 1px solid;
        }
    </style>

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

                    <div style="height: 30px; text-align: center; color: black; font-size: large">
                        Training Records Search
                    </div>

                    <br />
                    <br />
                    <div style="width: 1000px; margin-left: auto; margin-right: auto;">
                        <table style="margin-left: auto; margin-right: auto;">


                            <tr>
                                <td>Staff ID:   </td>
                                <td>
                                    <asp:TextBox ID="Staff_Id" runat="server" CssClass="searchbox"></asp:TextBox>
                                </td>
                                <td>Station: </td>
                                <td>
                                    <asp:DropDownList ID="Station" runat="server" CssClass="searchbox"></asp:DropDownList>

                                </td>
                                <td>Department: </td>
                                <td>
                                    <asp:DropDownList ID="Department" runat="server" CssClass="searchbox"></asp:DropDownList>
                                </td>
                                <td>Division: </td>
                                <td>
                                    <asp:DropDownList ID="Division" runat="server" CssClass="searchbox"></asp:DropDownList>
                                </td>

                            </tr>

                            <tr>
                                <td>From: </td>
                                <td>
                                    <asp:TextBox ID="From" runat="server"
                                        MaxLength="100" Rows="3" Height="20px"
                                        Width="100px" onClick="WdatePicker()"></asp:TextBox>
                                    <img onclick="WdatePicker({el:$dp.$('datejo')})" src="My97DatePicker/skin/datePicker.gif" mce_src="My97DatePicker/skin/datePicker.gif" align="absmiddle">
                                </td>
                                <td>To: </td>
                                <td>
                                    <asp:TextBox ID="To" runat="server"
                                        MaxLength="100" Rows="3" Height="20px"
                                        Width="100px" onClick="WdatePicker()"></asp:TextBox>
                                    <img onclick="WdatePicker({el:$dp.$('datejo')})" src="My97DatePicker/skin/datePicker.gif" mce_src="My97DatePicker/skin/datePicker.gif" align="absmiddle">
                                </td>
                                <td>Course: </td>
                                <td>

                                    <asp:DropDownList ID="Course" runat="server" CssClass="searchbox"></asp:DropDownList>
                                </td>
                                <td>Course Ref: </td>
                                <td>
                                     <asp:DropDownList ID="Course_re" runat="server" CssClass="searchbox"></asp:DropDownList>
                
                                </td>

                            </tr>
                            <tr>
                                <td>Course Type: </td>
                                <td>
                                    <asp:DropDownList ID="Training_Type" runat="server" CssClass="searchbox"></asp:DropDownList>
                                </td>
                                <td>Class: </td>
                                <td>
                                    <asp:TextBox ID="Class" runat="server" CssClass="searchbox"></asp:TextBox>
                                </td>
                                <td>Active Staff Only</td>
                                <td>
                                    <asp:CheckBox ID="Active" runat="server" CssClass="searchbox" Checked="true" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="Search" runat="server" Text="Search" CssClass="fa fa-search" OnClick="Search_Click" /></td>
                                 <td>
                                    <asp:LinkButton ID="Download" runat="server" Text="Download" CssClass="fa fa-download" OnClick="Download_Click" /></td>
                            </tr>

                        </table>
                    </div>
                    <div style="margin-top: 20px">
                        <asp:Repeater ID="Report" runat="server">

                            <HeaderTemplate>
                                <table class="datatable" cellspacing="0" cellpadding="3" rules="cols" border="1" id="GridView1" style="border-color: #999999; border-width: 1px; border-style: solid; width: 1000px; border-collapse: collapse; margin: auto">
                                    <tr>
                                        <th>Staff ID</th>
                                        <th>Staff Name </th>
                                        <th>Class</th>
                                        <th>Course</th>
                                        <th>Course Ref</th>
                                        <th>Training Date</th>
                                        <%-- <th>Delete</th>--%>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><a href="Training_Records_Print.aspx?staffno=<%#Eval("StaffID")%>"><%#Eval("StaffID")%></a></td>
                                    <%--  <td><font><%#Eval("StaffID")%></font></td>--%>
                                    <td><font><%#Eval("StaffName")%></font></td>
                                    <td><font><%#Eval("Class_Name")%></font></td>
                                    <td><font><%#Eval("Course")%></font></td>
                                    <td><font><%#Eval("Course_Ref")%></font></td>
                                    <td><font><%#Convert.ToDateTime(Eval("Training_Date")).ToString("yyyy-MM-dd")%></font></td>
                                </tr>

                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="pagebreak" style="width: 800px; margin: auto">

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
            <div id="copyright">
                Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
            </div>
        </div>
    </form>
</body>
</html>
