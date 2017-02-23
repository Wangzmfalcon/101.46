<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Training_Records_Print.aspx.cs" Inherits="Training_Records_Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible' />
    <meta http-equiv="Page-Enter" content="progid:DXImageTransform.Microsoft.RandomDissolve(Duration=2)">
    <title></title>
    <link href="css/Training_Print.css" rel="stylesheet" />

    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <style type="text/css">
        div.tolong:hover {
            text-overflow: inherit;
            overflow: visible;
        }


        div.tolongorg {
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
            width: 160px;
        }

        div.tolongclass {
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
            width: 460px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="print">
            <a href="#" id="print_btn" class="fa fa-print fa-2x" name="but1" onclick="winprint()" runat="server"></a>

        </div>

        <%for (int i = 1; i <= count; i++)
          {
              if (i == count)
              { 
        %>
        <div class="printform1">
            <%
              }
              else
              {
            %>
            <div class="printform">
                <%
              }
              
                %>

                <div class="printarea">
                    <div class="printtitle">
                        <div class=" col-md-2">
                            <img src="images/logo1.gif" style="margin-left: 6px; margin-top: 6px; float: left;" />
                        </div>
                        <div class=" col-md-10" style="position: relative; top: 5px">
                            <div style="width: 100%; text-align: center; height: 35px; line-height: 35px; font-family: Microsoft YaHei,SimHei,Cambria, Helvetica, sans-serif; font-size: 20px">Engineering and Maintenance Staff Training Record</div>
                            <%--<div style="width: 100%; text-align: center; height: 15px; line-height: 15px; font-family: Microsoft YaHei,SimHei,Cambria, Helvetica, sans-serif; font-size: 10px">Quality Monitoring System and Staff Record</div>--%>
                        </div>

                        <hr style="clear: both; position: absolute; width: 100%; bottom: 5px" />

                    </div>

                    <div class="printbody">
                        <div style="width: 100%; height: 90px">
                            <table style="width: 100%; border-collapse: collapse" id="basicinfo">
                                <tr>
                                    <td class="col-md-2">Staff Name:</td>
                                    <td class="col-md-4"><%=staffname%> </td>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2" style="text-align: right">Staff Number:</td>
                                    <td class="col-md-2" style="text-align: right"><%=staffid%> </td>
                                </tr>

                                <tr>
                                    <td class="col-md-2">Job Title:</td>
                                    <td class="col-md-4"><%=title%> </td>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2" style="text-align: right">Date Joined:</td>
                                    <td class="col-md-2" style="text-align: right"><%=datejoin%></td>
                                </tr>
                                <tr>
                                    <td class="col-md-2">Divsion:</td>
                                    <td class="col-md-4"><%=div%></td>
                                    <td class="col-md-2"></td>
                                    <td class="col-md-2" style="text-align: right">Date of Birth:</td>
                                    <td class="col-md-2" style="text-align: right"><%=birthdate%></td>
                                </tr>
                                <%--    <tr style="border-top: 1px solid #000000;">
                                <td class="col-md-2">License Number:</td>
                                <td class="col-md-2"><%=license%></td>
                                <td class="col-md-4"></td>
                                <td class="col-md-2" style="text-align: right">License Expiry Date:</td>
                                <td class="col-md-2" style="text-align: right"><%=licenseexpiry%></td>
                            </tr>--%>
                            </table>
                        </div>
                        <hr />

                        <table style="width: 100%; border-collapse: collapse; text-align: left" id="trainingdata">
                            <tr style="border-bottom: 1px solid #000000; height: 30px">
                                <td>Class Name</td>
                                <td>Course Ref</td>
                                <td>Training Date</td>
                                <td>Training Method</td>
                                <td>Duation</td>
                                <td>Location</td>
                                <td>Training Organization</td>
                            </tr>

                            <%for (int j = 1; j <= pagesize; j++)
                              {
                                  if (i == count && j > remainder && remainder != 0)
                                  {
                            %>
                            <tr>

                                <td colspan="7" style="text-align: center; border-top: 1px solid #000000;">None Follows</td>
                            </tr>
                            <%
                                  break;
                              }
                              ;%>
                            <tr>
                                <td>
                                    <div class="tolong tolongclass"><%=dt.Rows[(i-1)*pagesize+j-1]["Class Name"] %></div>
                                    </td>
                                <td><%=dt.Rows[(i-1)*pagesize+j-1]["Course Ref"] %></td>
                                <td><%=dt.Rows[(i-1)*pagesize+j-1]["Training Date"] %></td>
                                <td><%=dt.Rows[(i-1)*pagesize+j-1]["Training Method"] %></td>
                                <td><%=dt.Rows[(i-1)*pagesize+j-1]["Duation"] %></td>
                                <td><%=dt.Rows[(i-1)*pagesize+j-1]["Location"] %></td>
                                <td>
                                    <div class=" tolong tolongorg">
                                        <%=dt.Rows[(i-1)*pagesize+j-1]["Training Organization"] %>
                                    </div>
                                </td>


                            </tr>

                            <%}%>
                        </table>

                    </div>
                    <hr />

                    <div class="printfoot">
                        <div class="col-md-2">Print Date:<%=today %></div>
                        <div class="col-md-1" style="float: right">Page <%=i%> of <%=count%></div>

                    </div>
                </div>

            </div>
            <div class="pagebreak"></div>
            <%}%>
    </form>

    <script>

        function winprint() {
            $(".pagebreak").hide();
            document.all("but1").style.display = "none";
            window.print();
            window.close();
        }




    </script>
</body>
</html>
