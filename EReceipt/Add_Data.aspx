<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_Data.aspx.cs" Inherits="Add_Data" %>

<%@ Register Src="~/NAV.ascx" TagName="NAV" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible' />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" href="images/airmacau.ico" />
    <title>Add Data</title>


    <%-- css --%>

    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/Style.css" rel="stylesheet" />
    <style type="text/css">
        .has-error {
            /*border-color: #a94442;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);*/
            background-color: #ff0000;
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
                <div style="padding-top: 10px">
                    <%--        <table border="1" style="margin-left: auto; margin-right: auto;">--%>
                    <table class="grid grid-striped" style="margin-top: 0; padding-top: 20px">
                        <tr>
                            <th colspan="2">
                                <asp:Label ID="pagetitle" runat="server"><%=strpagetitle%></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <td>Station:
                            </td>
                            <td>
                                <asp:DropDownList ID="Station" CssClass="datainput" runat="server" OnSelectedIndexChanged="Station_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Num:
                            </td>
                            <td>
                                <asp:TextBox ID="Num" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Issue Date:
                            </td>
                            <td>
                                <asp:TextBox ID="Issue" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Deposit Type:
                            </td>
                            <td>
                                <asp:DropDownList ID="Deposit" CssClass="datainput" runat="server"></asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>Sales Type:
                            </td>
                            <td>
                                <asp:DropDownList ID="Sales" CssClass="datainput" runat="server"></asp:DropDownList>

                            </td>
                        </tr>

                        <tr>
                            <td>Received From:
                            </td>
                            <td>
                                <asp:TextBox ID="Received" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>RTNG:
                            </td>
                            <td>
                                <asp:TextBox ID="RTNG" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>PNR:
                            </td>
                            <td>
                                <asp:TextBox ID="PNR" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>TTL PAXS:
                            </td>
                            <td>
                                <asp:TextBox ID="TTL" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Currency:
                            </td>
                            <td>
                                <asp:DropDownList ID="Currency" CssClass="datainput" runat="server"></asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>Total Amount:
                            </td>
                            <td>
                                <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>By Cash:
                            </td>
                            <td>
                                <asp:TextBox ID="cash" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>By Cheque No.:
                            </td>
                            <td>
                                <asp:TextBox ID="Cheque" runat="server"></asp:TextBox>

                                Drawn on :<asp:TextBox ID="Drawn" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>By Credit Card:
                            </td>
                            <td>
                                <asp:TextBox ID="card" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>By Bank Transfer:
                            </td>
                            <td>
                                <asp:TextBox ID="bank" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Remark:
                            </td>
                            <td>
                                <asp:TextBox ID="Remark" runat="server" TextMode="MultiLine" Width="100%" onKeyPress="return ( this.value.length < 200 );"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>OR No.:
                            </td>
                            <td>
                                <asp:TextBox ID="OR1" CssClass="OR" runat="server"></asp:TextBox>
                                <asp:Label ID="cur1" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="amt1" CssClass="OR_amt" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>OR No.:
                            </td>
                            <td>
                                <asp:TextBox ID="OR2" CssClass="OR" runat="server"></asp:TextBox>
                                <asp:Label ID="cur2" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="amt2" CssClass="OR_amt" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>OR No.:
                            </td>
                            <td>
                                <asp:TextBox ID="OR3" CssClass="OR" runat="server"></asp:TextBox>
                                <asp:Label ID="cur3" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="amt3" CssClass="OR_amt" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>OR No.:
                            </td>
                            <td>
                                <asp:TextBox ID="OR4" CssClass="OR" runat="server"></asp:TextBox>
                                <asp:Label ID="cur4" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="amt4" CssClass="OR_amt" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>OR No.:
                            </td>
                            <td>
                                <asp:TextBox ID="OR5" CssClass="OR" runat="server"></asp:TextBox>
                                <asp:Label ID="cur5" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="amt5" CssClass="OR_amt" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Balance
                            </td>
                            <td>
                                <asp:TextBox ID="Balance" runat="server"  ></asp:TextBox>
                                <%--   <asp:Label ID="Balance1" runat="server"></asp:Label>--%>
                                <a id="Balance1"><%=balance_Text%></a>
                            </td>
                        </tr>
                    </table>

                </div>
                <div class="col-md-4" style="margin: auto; float: none; margin-top: 10px">

                    <asp:LinkButton class="gridbutton" ID="Save" runat="server" Text="Save" OnClick="Save_Click" TabIndex="1" />

                    <asp:LinkButton class="gridbutton" ID="Reset" runat="server" Text="Reset" />

                    <asp:LinkButton class="gridbutton" ID="Print" runat="server" Text="Print" OnClick="Print_Click" />
                </div>
            </div>
        </div>

    </form>

    <script>


        $(document).ready(function () {


            //
            $(".mainbody").each(function () {
                var h1 = $(this).height();
                var h2 = $(this).children(".bodydiv").height();

                if (h2 > h1) {
                    $(this).css("height", h2 + 10);
                }


            });
            $("#Balance").hide();
            
            for (var j = 1; j <= 5; j++) {
                //alert(bal);
                //console.log($("#OR" + j).val());
                if ($("#OR" + j).val() == '') {

                    $("#cur" + j).hide();
                    $("#amt" + j).hide();
                }


            }

        });


        $("#Reset").click(
        function () {
            $("form").trigger('reset');
        });

        //$("#Received").datepicker({

        //});

        function savecheck() {
            //console.log($("#Station").val());
            $("#Amount").focusout();
            var err = 0;
            if (!$("#Station").val()) {

                alert("Please select Station");
                err++;
            }

            //else if (!$("#Deposit").val()) {

            //    alert("Please select Deposit");
            //    err++;
            //}

            else if (!$("#Sales").val()) {

                alert("Please select Sales");
                err++;
            }
            else if (!$("#Received").val() || $("#Received").val() == "") {

                alert("Please input Received");
                err++;
            }


            if (err > 0) {
                return false;
            }
            else
                return true;



        }



        $(".OR_amt").focusout(function () {
            getbalance();

        });

        $("#Amount").focusout(function () {
            getbalance();
            //bal = $("#Amount").val()

            //for (var j = 1; j <= 5; j++) {
            //    //alert(bal);
            //    $("#amt" + j).html()
            //    if ($("#amt" + j).val() == "") {
            //    }
            //    else
            //        bal = bal - $("#amt" + j).val();
            //}
            //$("#Balance").val(bal);
            //$("#Balance1").html(bal);

        });


        function getbalance() {
            bal = $("#Amount").val()

            for (var j = 1; j <= 5; j++) {
                //alert(bal);
                $("#amt" + j).html()
                if ($("#amt" + j).val() == "") {
                }
                else
                    bal = bal - $("#amt" + j).val();
            }
            $("#Balance").val(bal);
            $("#Balance1").html(bal);


        }

        $(".OR").focusout(function () {

            ornum = $(this).val();
            num = $("#Num").val();

            if (ornum == num) {
                alert("Can not use itself")

            }

            else {
                id = $(this).attr("id");


                i = id.replace("OR", "")
                // alert(i)
                $.post('OR_check.aspx', {
                    OR: $(this).val(),
                    Station: $("#Station").val(),
                }, function (result) {
                    var words = result.split('|');
                    var returntype = words[0];
                    var currency = words[1];
                    var or_amount = words[2];

                    switch (returntype) {
                        case '0':
                            $("#amt" + i).show();
                            $("#amt" + i).val(or_amount);
                            $("#cur" + i).html(currency + ":");
                            getbalance();
                            break;
                        case '1':
                            $("#amt" + i).val("");
                            $("#cur" + i).html("");                          
                            getbalance();
                            $("#amt" + i).hide();
                            $("#cur" + j).hide();
                            alert("OR can not found")
                            break;
                        case '2':
                            $("#amt" + i).show();
                            $("#amt" + i).val(or_amount);
                            $("#cur" + i).html(currency + ":");
                            getbalance();
                            alert("OR have been used")
                            break;
                        default:
                            getbalance();
                            break;
                    }




                });
            }

        });


        $('#Amount').focusout(function () {
            $('#Amount').removeClass("has-error")
            var fix_amount = $('#Amount').val();
            var fix_amountTest = /^(([1-9]\d*)|\d)(\.\d{1,2})?$/;
            if (fix_amountTest.test(fix_amount) == false) {
                $('#Amount').attr('title', 'Number only');
                $('#Amount').addClass("has-error");
                $('#Amount').focus();
            }
        });


        $('#TTL').focusout(function () {
            $('#TTL').removeClass("has-error")
            var fix_amount = $('#TTL').val();
            var fix_amountTest = /^(([1-9]\d*)|\d)?$/;

            if (fix_amountTest.test(fix_amount) == false) {
                $('#TTL').attr('title', 'Integer only');
                $('#TTL').addClass("has-error");
                $('#TTL').focus();
            }
        });



        window.onload = function () {
            document.body.onkeydown = function (event) {
                if (event.keyCode == 13) {
                    return false;
                }
            }
        }

    </script>
</body>
</html>
