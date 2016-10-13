<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dropdownlistduoxuan .aspx.cs" Inherits="dropdownlistduoxuan_" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    <script language="javascript" type="text/javascript">
        var timoutID;

        //大队
        var panduan1 = 1;
        function ShowMList() {
            var divRef = document.getElementById("divssddList");
            divRef.style.display = "block";

        }
        function HideMList() {
            document.getElementById("divssddList").style.display = "none";
            if (panduan1 == 2) {
                document.getElementById("btnssdd").click();
            }
            panduan1 = 1;
        }
        function FindSelectedItems(sender) {
            var cblstTable = document.getElementById(sender.id);
            var checkBoxPrefix = sender.id + "_";
            var noOfOptions = cblstTable.rows.length;
            var selectedText = "";
            for (i = 0; i < noOfOptions; ++i) {
                if (document.getElementById(checkBoxPrefix + i).checked) {
                    if (selectedText == "") {
                        selectedText = document.getElementById(checkBoxPrefix + i).parentNode.innerText;
                    }

                    else {
                        selectedText = selectedText + "," + document.getElementById(checkBoxPrefix + i).parentNode.innerText;

                    }
                }
            }
            document.getElementById("texssdd").value = selectedText;
            panduan1 = 2;
        }

        //小队
        var panduan2 = 1;
        function ShowMssxd() {
            var divRef = document.getElementById("divssxdList");
            divRef.style.display = "block";

        }
        function HideMssxd() {
            document.getElementById("divssxdList").style.display = "none";
            if (panduan2 == 2) {
                document.getElementById("btnssxd").click();
            }
            panduan2 = 1;
        }
        function FindSelectedssxd(sender) {
            var cblstTable = document.getElementById(sender.id);
            var checkBoxPrefix = sender.id + "_";
            var noOfOptions = cblstTable.rows.length;
            var selectedText = "";
            for (i = 0; i < noOfOptions; ++i) {
                if (document.getElementById(checkBoxPrefix + i).checked) {
                    if (selectedText == "") {
                        selectedText = document.getElementById(checkBoxPrefix + i).parentNode.innerText;
                    }

                    else {
                        selectedText = selectedText + "," + document.getElementById(checkBoxPrefix + i).parentNode.innerText;

                    }
                }
            }
            document.getElementById("texssxd").value = selectedText;
            panduan2 = 2;
        }

        //分类盘点
        var panduan3 = 1;
        function ShowPdlx() {
            var divRef = document.getElementById("divPdlxList");
            divRef.style.display = "block";

        }
        function HidePdlx() {
            document.getElementById("divPdlxList").style.display = "none";
            if (panduan3 == 2) {
                document.getElementById("btnPdlx").click();
            }
            panduan3 = 1;
        }
        function FindPdlxItems(sender) {
            var cblstTable = document.getElementById(sender.id);
            var checkBoxPrefix = sender.id + "_";
            var noOfOptions = cblstTable.rows.length;
            var selectedText = "";
            for (i = 0; i < noOfOptions; ++i) {
                if (document.getElementById(checkBoxPrefix + i).checked) {
                    if (selectedText == "") {
                        selectedText = document.getElementById(checkBoxPrefix + i).parentNode.innerText;
                    }

                    else {
                        selectedText = selectedText + "," + document.getElementById(checkBoxPrefix + i).parentNode.innerText;

                    }
                }
            }
            document.getElementById("texPdlx").value = selectedText;
            panduan3 = 2;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                                   <asp:Button ID="btnssdd" runat="server" 
    Text="btnssdd" CssClass="yincang"  
                                 onclick="btnssdd_Click" />
                        
                                   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        
        <table class="style1">
             <tr>
             <td width="15%" height="25" align="left" valign="middle">
                        <asp:Label ID="lbssdd" runat="server" Text=""></asp:Label>
                        <asp:Panel ID="pnlssdd" runat="server" >
                            <div id="divssdd" runat="server" onmouseover="clearTimeout(timoutID);" onmouseout="timoutID = setTimeout('HideMList()', 75);">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="right">
                                            <asp:TextBox ID="texssdd" runat="server" onclick="ShowMList()" Width="150px"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <img id="Img1" alt="" runat="server" src="drop.gif" onclick="ShowMList()" align="left" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div runat="server" id="divssddList" class="DivCheckBoxList">
                                                <asp:CheckBoxList ID="lstssdd" runat="server" Width="165px" Font-Size="12px" CssClass="CheckBoxList"
                                                    onclick="FindSelectedItems(this);">
                                                   
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                     
                    </td>
             </tr>
        </table>
    
    </div>
    <div>


    <script type="text/javascript">
        var txt = "";
        function resetsrc(id) {
            if (id > 0) {
                var obj = document.getElementById("DropDownList1");
                for (i = 0; i < obj.length; i++) {
                    if (obj[i].value == id) {
                        var newtxt = obj[i].text;
                        if (txt.indexOf(newtxt) >= 0) {
                            alert("“" + newtxt + "” 已经选择过了！");
                        }
                        else {
                            txt += newtxt + ",";
                        }
                    }
                }
                document.getElementById("span").innerHTML = "你的选择：" + txt;
            }
        }
   </script>
<select name="DropDownList1" id="DropDownList1" onchange="resetsrc(this.value)">
 <option selected="selected" value="0">--选择期数--</option>
 <option value="1">2010年第一期</option>
 <option value="2">2010年第二期</option>
 <option value="3">2009年第三期</option>
 <option value="4">2009年第一期</option>
 <option value="5">2009年第二期</option>
 <option value="7">2009年第四期</option>
 <option value="8">2010年第三期</option>
</select>
<span id="span">你的选择：没有选择记录</span>

    </div>
    </form>
</body>
</html>