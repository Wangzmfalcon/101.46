﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertCC.aspx.cs" Inherits="crewcheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crew_check</title>
    <style type="text/css">
        .style1
        {
            color: #0000FF;
        }
    </style>
    <script language=javascript>
        function check_uncheck(Val) {
            var ValChecked = Val.checked;
            var ValId = Val.id;
            var frm = document.forms[0];
            // Loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for Header Template's Checkbox
                //As we have not other control other than checkbox we just check following statement
                if (this != null) {
                    if (ValId.indexOf('CheckAll') != -1) {
                        // Check if main checkbox is checked,
                        // then select or deselect datagrid checkboxes
                        if (ValChecked)
                            frm.elements[i].checked = true;
                        else
                            frm.elements[i].checked = false;
                    }
                    else if (ValId.indexOf('deleteRec') != -1) {
                        // Check if any of the checkboxes are not checked, and then uncheck top select all checkbox
                        if (frm.elements[i].checked == false)
                            frm.elements[1].checked = false;
                    }
                } // if
            } // for
        } // function
        function confirmMsg(frm) {
            var ValChecked = false;
            // loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("deleteRec") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked)
                        ValChecked = true;
                }
            }
            if (ValChecked) {
                return confirm('你确定要删除选中的记录吗？ 删除后将不能恢复！');
            }
            else {
                window.alert('请先钩选想要删除的记录！');
                return false;
            }
        }
</script> 
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/airmacau.png" 
            onclick="ImageButton1_Click" title ="Home page" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Log out</asp:HyperLink>
    
    </div>
    <div>
    <table width="705" border="0" align="center">
<tr>
<td colspan="2" style="background-color:#99bbbb;" class="style1">
<h1 style="text-align: center">Crew_Check System</h1>
</td>
</tr>

<tr valign="top">
<td style="background-color:#ffff99;width:100px;text-align:left;">
<b>Menu</b>
<br /><br />
<a href="changepassword.aspx">Change your password</a><br /><br />
<a href="crew.aspx">Crew information</a><br /><br />
<a href="crewcheck.aspx">Crew_Check information</a>
</td>
<td style="background-color:#EEEEEE;height:600px;width:400px;text-align:left;">
<div style="width:605px; text-align: right;">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</div>
<div  style="width:605px; height:60px; font-weight: 700;">
    <br />
    Please fill in the information:</div>
<div style="width:605px; height:60px ;">
    Staff_No:<asp:DropDownList ID="DropDownList4" runat="server" Width="100px">
    </asp:DropDownList>
    No_Type:<asp:DropDownList ID="DropDownList1" runat="server" Height="22px"  Width="100px"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList>

    No_Object:<asp:DropDownList ID="DropDownList2" runat="server" Height="22px"  Width="100px">
</asp:DropDownList>
     <br />
    <br />
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    From:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" style="width:100px;height:22px" name="cc_from">&nbsp;
     To:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" style="width:100px;height:22px" name="cc_to">
    <br />
    <br />
     Except_For:<asp:DropDownList ID="DropDownList3" runat="server"  Width="100px">
    </asp:DropDownList>
&nbsp;Remark:<asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
     &nbsp;
     <asp:Button ID="insert" runat="server" Text="Insert" onclick="Button2_Click" />
  <div style="width:605px; text-align: center">

  </div>
    </div>



</td>
</tr>

<tr>
<td colspan="2" style="background-color:#99bbbb;text-align:center;">
Copyright www.airmacau.com.mo>
</tr>
</table>


    </div>
    </form>
</body>
</html>