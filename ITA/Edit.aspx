<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="_Default" %>

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
    <form id="form1" runat="server"   >

        
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
       
        </div>
 
        <div class="container">
            <div class="col-xs-6 col-md-2" >
                <input id="counter" value="1" type="number" style="display:none" />
             </div>
             <div class="col-xs-6 col-md-2">
                  <input id="hid" value="del1" type="text" style="display:none" />
              </div>
            <div class="col-xs-6 col-md-2">
                  <input id="red" value="row1" type="text" style="display:none" />
              </div>
              <div class="col-xs-6 col-md-2">
                 <asp:Button ID="savedata" runat="server" OnClick="savedata_Click" Text="Button" style="display:none"/>
              </div>
                 <div class="col-xs-6 col-md-3">
                 <input id="savetxt" value="" type="text" runat="server" style="display:none" />
              </div> 
               <div class="col-xs-6 col-md-1">
                  <a id="Save"  onclick="datacheck()" >Save</a>
              </div> 
               <div class="col-xs-6 col-md-12" style="height:20px">
                 
              </div> 
               <table class="table table-hover" id="insert">
                      <tr class="success" >
                           
                            <th style="width:190px">Ag ID</th>
                            <th style="width:475px">Description</th>
                            <th style="width:285px">Ag Expire Date</th>
                            <th style="width:95px">Add</th>
                            <th style="width:95px">Delete</th>
                        </tr>
                   <tr id="row1">
                     
                       <td>
                                 <input id="ag_id1"  />
                       </td>
                        <td >
                                 <input id="descr1" style="width:450px" />
                       </td>
                         <td>
                                 <input id="exp1"  />
                       </td>

                         <td>
                                 <a id="add1" onclick="add()">+</a>
                       </td>
                            <td>
                                 <a id="del1" onclick="del(1)" style=" display: none;" >-</a>
                       </td>
                   </tr>
               </table>
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
    <script>
        function add() {
            //获得计数器用来自动生成
            var i = $("#counter").val();
            //清空所有标红提示
            var trcount = $("#insert").find("tbody").children("tr").length
            //最多一次插入20行
            if (trcount == 21)
            {
                alert("Most add 20 records one time")
                return false;
            }
            //新增一行
            var j =parseInt(i) + 1;
            var txt1 = "<tr id=\"row"+j+"\">"
            var txt1 = txt1 + "<td><input  id=\"ag_id" + j + "\"  /></td>"
            var txt1 = txt1 + "<td><input  id=\"descr" + j + "\"  style=\"width:450px\" /></td>"
            var txt1 = txt1 + "<td><input  id=\"exp" + j + "\" /></td>"       
            var txt1 = txt1 + "<td><a id=\"add" + j + "\" onclick=\"add()\">+</a></td>"
            var txt1 = txt1 + "<td><a id=\"del" + j + "\" onclick=\"del("+j+")\" >-</a></td>"
            var txt1 = txt1 + "</tr>";            
            $("#insert").append(txt1);

            //计数器更新
            $("#counter").val(j);
            //
            $("#exp" + j + "").datepicker();
            $("#add"+j+"").button();
            $("#del" + j + "").button();
            //显示原来隐藏了的减号
            $("#" + $("#hid").val() + "").show();
    
        }

        function delcontrol()
        {
            //获得一个有几行
            var i=$("#insert").find("tbody").children("tr").length
            //如果只有一行数据的话  隐藏减号并标记
            if (i == 2)
            {
              
                var trid = $("#insert").find("tbody").children("tr").eq(1);
                var delb = trid.children("td").eq(4).children("a").eq(0);
                var hidid = delb.attr("id");
                delb.hide();
                $("#hid").val(delb.attr("id"));


            }
        }

        //数据检查  为空则标红
        function datacheck()
        {
           
            $("#" + $("#red").val() + "").children("td").eq(0).removeClass("warning");
            $("#" + $("#red").val() + "").children("td").eq(1).removeClass("warning");
            $("#" + $("#red").val() + "").children("td").eq(2).removeClass("warning");
            var txt = "";
            $("#savetxt").val(txt)
            var table = $("#insert").find("tbody").children("tr")
          

            //先将数据存在一个隐藏控件，然后调用一个隐藏按钮的onclick来处理数据
            for (var i = 1, l = table.length; i < l; i++) {
               
                for (var j = 0, m = 3; j < m; j++)
                {
                    var trd = table.eq(i);
                    var tdd = trd.children("td").eq(j);
                    var tddval = tdd.children("input").eq(0).val();
                  
                    
                    if (tdd.children("input").eq(0).val().length==0)
                    {
                        tdd.addClass("warning");                      
                        $("#red").val(trd.attr("id"));
                        return false;
                    }
                    txt = txt + tdd.children("input").eq(0).val();

                    if (j == 2)
                    {
                        txt = txt + "|";
                    }
                    else
                    {
                        txt = txt + "~";
                    }
                   
                }

              
            }
            $("#savetxt").val(txt)
            $("#savedata").click();
        }

        //删除一行 
        function del(i) {
            $("#row" + i + "").remove();
            delcontrol();
         
        }
        
        $("#Save").button();
        $("#exp1").datepicker();
        $("#add1").button();
        $("#del1").button();
     </script>
   

</body>
</html>
