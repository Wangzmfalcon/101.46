<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertCC.aspx.cs" Inherits="crewcheck" %>
<%@ Register src="Airmacau.ascx" tagname="Airmacau1" tagprefix="uc1" %>
<%@ Register src="leftmenu.ascx" tagname="leftmenu1" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="zh-CN" /> 
<meta name="author" content="Airmacau/ITD" /> 
<meta name="Copyright" content="Airmacau" /> 
<meta name="description" content="Airmacau" />
<meta name="keywords" content="Airmacau"  />
 <!--css-->
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/leftmenu.css" rel="stylesheet" type="text/css" />
 <link href="MyStyles.css" type="text/css" rel="stylesheet" />
 <!--js-->
 <script src="js/leftmenu.js" type="text/javascript"></script>
 <script type="text/javascript">
     var timoutID;
     function ShowMList() {
         var divRef = document.getElementById("divCheckBoxList");
         divRef.style.display = "block";
         var divRefC = document.getElementById("divCheckBoxListClose");
         divRefC.style.display = "block";
     }

     function HideMList() {
         document.getElementById("divCheckBoxList").style.display = "none";
         document.getElementById("divCheckBoxListClose").style.display = "none";
     }

     function FindSelectedItems(sender, textBoxID) {
         var cblstTable = document.getElementById(sender.id);
         var checkBoxPrefix = sender.id + "_";
         var noOfOptions = cblstTable.rows.length;
         var selectedText = "";
         for (i = 0; i < noOfOptions; ++i) {
             if (document.getElementById(checkBoxPrefix + i).checked) {
                 if (selectedText == "")
                     selectedText = document.getElementById(checkBoxPrefix + i).parentNode.innerText;
                 else
                     selectedText = selectedText + "," + document.getElementById(checkBoxPrefix + i).parentNode.innerText;
             }
         }
         document.getElementById(textBoxID.id).value = selectedText;
     }
    </script>
 



    <title>Add Crew Checck</title>
    

</head>

<body>

    <form id="form1" runat="server">

<div id="backpanel">
<uc1:Airmacau1 ID="Airmacau1" runat="server"/>

<div id="pagebody">
<div id ="leftmenu">
<uc1:leftmenu1 ID="leftmenu1" runat="server"/>

</div>

<div id="Contentpanel">
<div id="linkweb" style=" float:left; width:400px; height:25px;font-size:14px;">
</div>
<script>    setInterval("linkweb.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());", 1000);
</script>
<div id="welcome" style="width:400px; height:25px;text-align:right; font-size:14px; float:left;">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</div>
<div style=" width:810px; height:100px; font-size:20px; font-weight:bold">
    <br />
    Please fill in the information:</div>

<div style="width:810px;">
    <div style=" float:left">
    Staff_No:<asp:DropDownList ID="DropDownList4" runat="server"  Height="22px" Width="100px">
    </asp:DropDownList>
    No_Type:<asp:DropDownList ID="DropDownList1" runat="server" Height="22px"  Width="100px"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList>
</div>
<%--    No_Object:<asp:DropDownList ID="DropDownList2" runat="server" Height="22px"  Width="100px">
</asp:DropDownList>--%>
<div id="divCustomCheckBoxList" runat="server" onmouseover="clearTimeout(timoutID);" onmouseout="timoutID = setTimeout('HideMList()', 750);"  style=" float:left; border:none">
                    <table> 
                        <tr>
                            <td align="right" class="DropDownLook">
                                No_Object:<input id="txtSelectedMLValues" type="text" readonly="readonly" onclick="ShowMList()" style="width:40px;" runat="server" />
                            </td>
                            <td align="left" class="DropDownLook">
                                <img id="imgShowHide" runat="server" src="drop.gif" onclick="ShowMList()" align="left" />                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="DropDownLook">
                                <div>
            	                    <div runat="server" id="divCheckBoxListClose" class="DivClose">			                        
		                                <label runat="server" onclick="HideMList();" class="LabelClose" id="lblClose">X</label>
		                            </div>
                                    <div runat="server" id="divCheckBoxList" class="DivCheckBoxList">
		                                <asp:CheckBoxList ID="lstMultipleValues" runat="server" Width="250px" CssClass="CheckBoxList"></asp:CheckBoxList>						        			           			        
		                            </div>
		                        </div>
                            </td>
                        </tr>
                    </table>
                </div>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    From:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" style="width:100px;height:22px" name="cc_from" id= "from1">&nbsp;
     To:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" 
        style="width:100px;height:22px" name="cc_to" id="to11" value=" ">
    <br />
    <br />
     <br />
     Except_For:<asp:DropDownList ID="DropDownList3" runat="server"  Width="100px" Height="22px">
    </asp:DropDownList>
&nbsp;Remark:<asp:TextBox ID="TextBox1" runat="server" Width="300px" Height="22px"></asp:TextBox>
     &nbsp;
     <asp:Button ID="insert" runat="server" Text="Insert" onclick="Button2_Click" />

</div>
</div>
<div id="copyright">
Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
</div>
</div>

    </form>
</body>
</html>
