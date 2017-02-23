<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Position_setting.aspx.cs" Inherits="Position" %>

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


    <script type="text/javascript">
        function cli(Obj) {
            var collid = document.getElementById("select_all")
            var coll = document.getElementsByName(Obj)
            if (collid.checked) {
                for (var i = 0; i < coll.length; i++)
                    coll[i].checked = true;
            } else {
                for (var i = 0; i < coll.length; i++)
                    coll[i].checked = false;
            }
        }


        function checkstatus() {

            var checkedbox = "";
            //check box
            var coll = document.getElementsByName("items")
            for (var i = 0; i < coll.length; i++)
                if (coll[i].checked) {
                    checkedbox += coll[i].id;
                    checkedbox += "|";
                }
            var savetxt = document.getElementById("savetxt")
            savetxt.value = checkedbox;
            console.log(checkedbox);

            document.getElementById("savedate").click();
        }

    </script>
    <title>Position</title>


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
                        <h1>Position Setting</h1>
                        Staff No.<a><%=userstring%></a>
                      
                    </div>
                    <div>

                         <a   style="margin-left:100px;margin-top:10px; width: 150px; height: 15px; background-color: #fff; display: inline-block; padding: 5px; text-align: center; border-radius: 5px; border: 1px solid #C0C0C0; vertical-align: central; padding-top: 7px; cursor: pointer" href="Position_Gap.aspx?userid=<%=userstring%>">Position Gap Analysis</a>

                    </div>
                    <div style="margin-top: 30px; margin-left: 100px; margin-right: auto">

                     <div style="float:left">   <asp:CheckBox ID="select_all" runat="server" onclick="cli('items');"/>Select All </div>     <div style="margin-top: 30px;">
                            <a onclick="checkstatus()" style="width: 30px; height: 15px; background-color: #fff; display: inline-block; padding: 5px; text-align: center; border-radius: 5px; border: 1px solid #C0C0C0; vertical-align: central; padding-top: 7px; cursor: pointer">Save</a>
                            <input id="savetxt" runat="server" text="Label" style="display: none"></input>
                            <asp:Button ID="savedate" runat="server" Text="Button" hidden="true" OnClick="savedateClick" />
                        </div>
                             </br> </br>
                        <div style="position: absolute; height: 400px">
                            <asp:Repeater ID="titlelist" runat="server">
                                <ItemTemplate>
                                    <%# trstyle((Container.ItemIndex+1))%>
                                </ItemTemplate>
                            </asp:Repeater>
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
