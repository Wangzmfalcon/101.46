<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ereceipt_print.aspx.cs" Inherits="Ereceipt_print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible' />
    <title></title>
    <link href="css/Style.css" rel="stylesheet" />
    <link href="css/print.css" rel="stylesheet" />

    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <script>
   


    </script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <style>
        .printline {
            height: 5%;
            margin-top: 1%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="print">
            <a href="#"  id="print_btn" class="fa fa-print fa-2x" name="but1" onclick="winprint()" runat="server"></a>
            <a id="Printid" style="display:none"><%=Print_id%></a>
        </div>
        <div class="printform">
            <div class="printpageinf">
                <div style="padding-top: 28px">1st copy - For customer</div>
            </div>
            <div  class="printpage" <%=background_text%> >
                <div class="printhead ">
                    <div class=" col-md-4">
                        <img src="images/logo.gif" style="margin-left: 5px; margin-top: 5px; float: left" />
                    </div>
                    <div class="printtitle col-md-4">
                        <b>Official Receipt</b>
                    </div>
                    <div class="col-md-1" style="display: block; height: 20px">
                    </div>
                    <div class=" col-md-3" style="height: 100%">
                        <div style="float: left; width: 100%; height: 50%; margin-top: 5px">
                            <span class="printNo">No.<%=Station%></span>
                            <span class="printNonumber"><%=Num%></span>
                        </div>
                        <div style="width: 100%; height: 50%">
                            <span class="printDate">Date:</span>
                            <u><%=Issue_Date%></u>
                        </div>

                    </div>
                </div>
                <div class="printmean">
                    <div class="printline">
                        <div class="printlinetitle">Received from &nbsp </div>

                        <div class="printunderline"><%=Received%></div>
                    </div>
                    <div class="printline">
                        <div class="printlinetitle">The sum of&nbsp </div>
                        <div class="printunderline"><%=English_tatal%></div>
                    </div>
                    <div class="printline" id="test">
                        <div class="printlinetitle">In payment of &nbsp </div>
                        <div class="printunderline"><%=Deposit%> received of <%=Received%> for <%=TTL%> pax travel on <%=RTNG%>  <%=PNR%> (<%=Sales%>)</div>
                    </div>
                    <div class="printline" style="height: 10%; margin-top: 1%">
                        <div class="printlinetitle">Remarks &nbsp </div>

                        <div class="printunderline" id="remark_box"><%=Remark%></div>
                    </div>
                    <div class="printline">
                        <div class="printlinetitle" style="font-family: 'Times New Roman', Times, serif; font-size: 18px"><b><i><%=currency%></i></b> &nbsp </div>

                        <div style="font-size: 18px;"><u><%=Total_amt%></u></div>
                    </div>
                    <div class="printline">
                        <div class="printlinetitle">Breakdown: &nbsp </div>

                        <div>
                            <hr />
                        </div>
                    </div>
                    <%--      <%#Cash_html() %>--%>
                    <%=cash_html_text%>
                    <%=or_html_text%>
                    <%--        <div class="printline">
                        <div class="col-md-4">By cash &nbsp<u>MOP 3000</u></div>
                        <div class="col-md-4">By Credit card&nbsp<u>VI</u></div>
                        <div class="col-md-4">By Bank Transfer &nbsp<u>MOP 3000</u></div>
                    </div>--%>
                    <%--    <div class="printline">
                        <div class="col-md-5">By cheque No.  &nbsp<u>32365</u></div>
                        <div class="col-md-5">Drawn on&nbsp<u>BOC</u></div>
                    </div>--%>

               <%--     <div class="printline" style="height: 10%">
                        <div class="OR">
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                        </div>
                    </div>
                    <div class="printline">
                        <div>Balance:MOP <u><b>25000</b></u></div>
                    </div>--%>

                    <div class="printline" style="text-align: right">(this receipt is not valid unless the cheque is honoured)</div>
                    <div style="position: absolute; bottom: 10%; right: 25%; width: 9%; font-family: Arial, Helvetica, sans-serif; font-size: 14px;">Signature:</div>
                    <div style="position: absolute; bottom: 10%; right: 5%; width: 18%; border-bottom: 1px solid #000000;"></div>
                    <div style="position: absolute; bottom: 5%; right: 5%; width: 18%; border-bottom: 1px solid #000000; font-family: Arial, Helvetica, sans-serif; font-size: 14px;"><%=username%></div>
                </div>

            </div>
            <%--  page2      --%>
            <div class="printpageinf">
                <div style="padding-top: 28px">2nd copy - For Finance</div>
            </div>

             <div class="printpage" <%=background_text%>  >
                <div class="printhead ">
                    <div class=" col-md-4">
                        <img src="images/logo.gif" style="margin-left: 5px; margin-top: 5px; float: left" />
                    </div>
                    <div class="printtitle col-md-4">
                        <b>Official Receipt</b>
                    </div>
                    <div class="col-md-1" style="display: block; height: 20px">
                    </div>
                    <div class=" col-md-3" style="height: 100%">
                        <div style="float: left; width: 100%; height: 50%; margin-top: 5px">
                            <span class="printNo">No.<%=Station%></span>
                            <span class="printNonumber"><%=Num%></span>
                        </div>
                        <div style="width: 100%; height: 50%">
                            <span class="printDate">Date:</span>
                            <u><%=Issue_Date%></u>
                        </div>

                    </div>
                </div>
                <div class="printmean">
                    <div class="printline">
                        <div class="printlinetitle">Received from &nbsp </div>

                        <div class="printunderline"><%=Received%></div>
                    </div>
                    <div class="printline">
                        <div class="printlinetitle">The sum of&nbsp </div>
                        <div class="printunderline"><%=English_tatal%></div>
                    </div>
                    <div class="printline" id="test">
                        <div class="printlinetitle">In payment of &nbsp </div>
                        <div class="printunderline"><%=Deposit%> received of <%=Received%> for <%=TTL%> pax travel on <%=RTNG%>  <%=PNR%> (<%=Sales%>)</div>
                    </div>
                    <div class="printline" style="height: 10%; margin-top: 1%">
                        <div class="printlinetitle">Remarks &nbsp </div>

                        <div class="printunderline" id="remark_box"><%=Remark%></div>
                    </div>
                    <div class="printline">
                        <div class="printlinetitle" style="font-family: 'Times New Roman', Times, serif; font-size: 18px"><b><i>MOP</i></b> &nbsp </div>

                        <div style="font-size: 18px;"><u><%=Total_amt%></u></div>
                    </div>
                    <div class="printline">
                        <div class="printlinetitle">Breakdown: &nbsp </div>

                        <div>
                            <hr />
                        </div>
                    </div>
                    <%--      <%#Cash_html() %>--%>
                    <%=cash_html_text%>
                    <%=or_html_text%>
                    <%--        <div class="printline">
                        <div class="col-md-4">By cash &nbsp<u>MOP 3000</u></div>
                        <div class="col-md-4">By Credit card&nbsp<u>VI</u></div>
                        <div class="col-md-4">By Bank Transfer &nbsp<u>MOP 3000</u></div>
                    </div>--%>
                    <%--    <div class="printline">
                        <div class="col-md-5">By cheque No.  &nbsp<u>32365</u></div>
                        <div class="col-md-5">Drawn on&nbsp<u>BOC</u></div>
                    </div>--%>

               <%--     <div class="printline" style="height: 10%">
                        <div class="OR">
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                            <div class="col-md-4">OR No.<u>4330</u>:&nbsp MOP<u>9000</u></div>
                        </div>
                    </div>
                    <div class="printline">
                        <div>Balance:MOP <u><b>25000</b></u></div>
                    </div>--%>

                    <div class="printline" style="text-align: right">(this receipt is not valid unless the cheque is honoured)</div>
                    <div style="position: absolute; bottom: 10%; right: 25%; width: 9%; font-family: Arial, Helvetica, sans-serif; font-size: 14px;">Signature:</div>
                    <div style="position: absolute; bottom: 10%; right: 5%; width: 18%; border-bottom: 1px solid #000000;"></div>
                    <div style="position: absolute; bottom: 5%; right: 5%; width: 18%; border-bottom: 1px solid #000000; font-family: Arial, Helvetica, sans-serif; font-size: 14px;"><%=username%></div>
                </div>

            </div>




            <script>

                function winprint() {

                    //console.log(GetQueryString("Print_id"));
                    $.post('finalized.aspx', {
                        id: GetQueryString("Print_id")
                    }, function (result) {

                        console.log(result);



                    });

                    document.all("but1").style.display = "none";
                    window.print();
                    window.close();
                }



                function GetQueryString(name) {

                    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");

                    var r = window.location.search.substr(1).match(reg);

                    if (r != null) return unescape(r[2]); return null;

                }



                function format_money(input) {
                    var n = parseFloat(input).toFixed(2);
                    var re = /(\d{1,3})(?=(\d{3})+(?:\.))/g;
                    return n.replace(re, "$1,");
                }


                $(document).ready(function () {


                    //
                    $(".printline").each(function () {
                        var h1 = $(this).height();
                        var h2 = $(this).children(".printunderline").height();

                        if (h2 > h1) {
                            $(this).css("height", h2);
                        }


                        if (h2 == 0) {
                            $(this).children(".printunderline").css("height", "16px");

                        }

                    });




                });



            </script>
    </form>
</body>
</html>
