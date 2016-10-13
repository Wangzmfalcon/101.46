<%@ Page Language="C#" AutoEventWireup="true" CodeFile="crew.aspx.cs" Inherits="crew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head id="Head1" runat="server">
    <title>Crew Information</title>
    <style type="text/css">
        .style1
        {
            height: 37px;
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
    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/airmacau.png" onclick="ImageButton1_Click" title ="Home page"  />
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
<td style="background-color:#ffff99;width:100px;text-align:top;">
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
<div style=" height:60px">
</div>
<div style="width:605px;" class="style2">

StaffNo:<asp:TextBox ID="StaffNo" runat="server" Width ="100px"></asp:TextBox>
&nbsp;StaffName:<asp:TextBox ID="StaffName" runat="server" Width ="100px"></asp:TextBox>
&nbsp;Title:<asp:DropDownList ID="Title" runat="server">
    </asp:DropDownList>
    
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="query" />
    
    &nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
        Text="insert" />
    
</div>
<div style="width:605px; text-align: center">
<asp:GridView ID="GridView1" runat="server"  Width="400px" AllowPaging="True" OnRowEditing="GridView1_RowEditing"
  OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"
  OnRowCancelingEdit="GridView1_RowCancelingEdit" 
 OnRowUpdating="GridView1_RowUpdating" 
        AutoGenerateColumns="False" style="color: #0000FF">
            
            <Columns>
                <asp:TemplateField HeaderText="StaffNo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Width="60px" Text='<%# Bind("StaffNo") %>' ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("StaffNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="StaffName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Width="100px"  Text='<%# Bind("StaffName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("StaffName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server"  Width="100px"  DataValueField='<%# Bind("Title") %>'></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" HeaderText="Edit"/>
                <asp:TemplateField>
                <HeaderTemplate>      
                <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server" /> </HeaderTemplate> 
                <ItemStyle Width="10px"></ItemStyle> <ItemTemplate>      
                <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );" runat="server" /> </ItemTemplate> 

                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    <asp:Button ID="Button3" runat="server" Text="Delete"  
        OnClientClick="return confirmMsg(form1)" onclick="Button3_Click" Visible="false"/>

    </div>

</td>
</tr>
        
<tr>
<td colspan="2" style="background-color:#99bbbb;text-align:center;">
Copyright www.airmacau.com.mo</tr>
        
</table>


    </div>
    </form>
</body>
