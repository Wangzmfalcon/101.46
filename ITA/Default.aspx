<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>IT Agreement Control</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="./css/bootstrap.min.css" rel="stylesheet" />
    <link href="./css/bootstrap.css" rel="stylesheet" />
    <link href="./css/navbar-fixed-top.css" rel="stylesheet" />
    <link href="./css/sticky-footer.css" rel="stylesheet" />
    <link href="./datepicker/jquery-ui.css" rel="stylesheet" />
 
   
</head>
<body>
    <form id="form1" runat="server" DefaultButton="search">

        <!--加一个半透明层-->
        <div id="doing" style="filter: alpha(opacity=30); -moz-opacity: 0.3; opacity: 0.3; background-color: #000; z-index: 1000; position: absolute; left: 0; top: 0; display: none; overflow: hidden;">
        </div>
        <!--加一个登录层-->
        <div id="edittable" class="container" style="border: solid 10px #898989; background: #fff; padding: 10px; z-index: 1001; position: fixed ;  display: none; top: 300px; margin: 0 0 0 46.5px;">
            <div style="padding: 3px 10px 3px 10px; text-align: left; vertical-align: middle;">
                <div class="col-xs-6 col-md-2">
                    <div style="display: none;">
                    <asp:TextBox ID="EC" runat="server" > </asp:TextBox>
                    <asp:TextBox ID="ES" runat="server"> </asp:TextBox>
                     </div>
                 
                  <asp:TextBox ID="EID" runat="server" Width="155px" > </asp:TextBox>
                </div>
                <div class="col-xs-6 col-md-5">
                   
                  <asp:TextBox ID="ED" runat="server" Width="432" >  </asp:TextBox>
                </div>
                <div class="col-xs-6 col-md-3">
                 
                  <asp:TextBox ID="EED" runat="server"> </asp:TextBox>
                </div>



                <div class="col-xs-6 col-md-1">
                    <asp:Button ID="Bttcmd" runat="server" Text=" Confirm " OnClick="cmd" />
                </div>
                <div class="col-xs-6 col-md-1">
                    <input id="BttCancel" type="button" value=" Cancel "  onclick="ShowNo()" />
                </div>
            </div>
        </div>
        <!-- Fixed navbar -->

        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">ITA</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="Default.aspx">Home</a></li>
                        <li><a href="#about">About</a></li>
                        <li><a href="#contact">Contact</a></li>
                        <%--  <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
              <ul class="dropdown-menu">
                <li><a href="#">Action</a></li>
                <li><a href="#">Another action</a></li>
                <li><a href="#">Something else here</a></li>
                <li role="separator" class="divider"></li>
                <li class="dropdown-header">Nav header</li>
                <li><a href="#">Separated link</a></li>
                <li><a href="#">One more separated link</a></li>
              </ul>
            </li>--%>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <%--   <li><a href="../navbar/">Default</a></li>
            <li><a href="../navbar-static-top/">Static top</a></li>--%>
                        <li class="active"><a href="http://intranet.airmacau.com.mo">Airmacau <span class="sr-only">(current)</span></a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>
        <div class="container" style="margin-bottom: 40px">
            <div class="page-header">
                <h1>IT Agreement Control</h1>
            </div>
            <div class="row">
                <div class="col-xs-6 col-md-1">
                    <label>AgreementID</label>
                </div>

                <div class="col-xs-6 col-md-2">
                    <input id="Ag_id" runat="server" type="text" />
                </div>

                <div class="col-xs-6 col-md-1">
                    <label>Description</label>
                </div>

                <div class="col-xs-6 col-md-2">
                    <input id="Desr" runat="server" type="text" />
                </div>

                <div class="col-xs-6 col-md-2">
                    <label>Agreement Expire Date</label>
                </div>

                <div class="col-xs-6 col-md-2">
                    <input type="text" id="datepicker1" runat="server" />
                </div>
                <div class="col-xs-6 col-md-1">
                    <asp:Button ID="search" runat="server" Text="Search" OnClick="Search" />

                </div>
                  <div class="col-xs-6 col-md-1">
                    <a id="add" href="Edit.aspx" >Add</a>

                </div>
            </div>

        </div>
        <div class="container">
            <asp:Repeater ID="Ag_table" runat="server">
                <HeaderTemplate>
                    <table class="table table-hover">
                        <tr class="success">
                            <td style="display:none">Seq</td>
                            <td>Ag ID</td>
                            <td>Description</td>
                            <td>Ag Expire Date</td>
                            <td>Edit</td>
                            <td>Delete</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>

                    <%# trstyle((Container.ItemIndex+1))%>
                    <td>
                        <a class="butt" onclick="showFloat('<%#Container.ItemIndex + 1 %>','edit')" >Edit</a>

                    </td>
                    <td>
                        <a class="butt"  onclick="showFloat('<%#Container.ItemIndex + 1 %>','del')" >Delete</a>

                    </td>
                    </tr>  
                </ItemTemplate>
                <FooterTemplate>
                    </table>  
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <footer class="footer">
            <div class="container">
                <p class="text-muted">Copyright ©  2015 - All Rights Reserved Air Macau Company IT Division .</p>
            </div>
        </footer>


    </form>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <script type="text/javascript" src="./js/jquery-2.1.4.js" charset="UTF-8"></script> 
    <script src="./js/bootstrap.min.js"></script>
     
 <script src="./datepicker/external/jquery/jquery.js"></script>
 <script src="./datepicker/jquery-ui.js"></script>
      <script >


          $(function () {
              $("#datepicker1").datepicker();
          });
          $(function () {
              $("#EED").datepicker();
          });
          
          $("#search").button();
          $("#add").button();
          $(".butt").button();
          function showFloat(i, cmd) {
              var range = getRange();
              $("#doing").css("width", range.width + "px")
              $("#doing").css("height", range.height + "px")
              $("#doing").css("display", "block")


              document.getElementById("edittable").style.display = "";

              var seq = document.getElementById("agseq" + i).innerHTML;
              var id = document.getElementById("agid" + i).innerHTML;
              var desc = document.getElementById("agdesc" + i).innerHTML;
              var edate = document.getElementById("aged" + i).innerHTML;
              $("#EC").val(cmd);
              $("#ES").val(seq);
              $("#EID").val(id);
              $("#ED").val(desc);
              $("#EED").val(edate);
          
              return true;
          }

          function ShowNo() {
              document.getElementById("doing").style.display = "none";
              document.getElementById("edittable").style.display = "none";
          }

          function getRange() {
              var top = document.body.scrollTop;
              var left = document.body.scrollLeft;
              var height = document.body.clientHeight;
              var width = document.body.clientWidth;

              if (top == 0 && left == 0 && height == 0 && width == 0) {
                  top = document.documentElement.scrollTop;
                  left = document.documentElement.scrollLeft;
                  height = document.documentElement.clientHeight;
                  width = document.documentElement.clientWidth;
              }
              return { top: top, left: left, height: height, width: width };
          }


       
        
         </script>
     


</body>
</html>
