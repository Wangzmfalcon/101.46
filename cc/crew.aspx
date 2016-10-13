<%@ Page Language="C#" AutoEventWireup="true" CodeFile="crew.aspx.cs" Inherits="crew" %>
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

 <!--js-->
 <script src="js/leftmenu.js" type="text/javascript"></script>
  <script src="js/check.js" type="text/javascript"></script>
 



    <title>Crew Information search</title>
    

    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
    

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
<div style=" width:800px; height:100px;  font-size:20px; font-weight:bold">
    <br />
    Please enter your conditions:</div>
<div style=" height:60px; font-size:14px; font-style:normal; " class="style1">

StaffNo:<asp:TextBox ID="StaffNo" runat="server" Width ="100px"></asp:TextBox>
&nbsp;&nbsp; StaffName:<asp:TextBox ID="StaffName" runat="server" Width ="100px"></asp:TextBox>
&nbsp;&nbsp;Title:<asp:DropDownList ID="Title" runat="server">
    </asp:DropDownList>
    
    &nbsp;
    
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="search" />
    
    &nbsp;<br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    </div>


 <div id="gridview" style="  text-align:center">
<asp:GridView ID="GridView1" runat="server"  Width="810px" AllowPaging="True" OnRowEditing="GridView1_RowEditing"
  OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"
  OnRowCancelingEdit="GridView1_RowCancelingEdit" 
 OnRowUpdating="GridView1_RowUpdating"  GridLines="None" PageSize="15"
        AutoGenerateColumns="False" style="color: #0000FF; margin-top: 0px;" 
         CellPadding="4" ForeColor="#333333" >
            
            <AlternatingRowStyle BackColor="White" />
            
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

            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
      

        </asp:GridView>
        </div>
          <div style=" margin: 0 0px auto auto; text-align:right">
    <asp:Button ID="Button3" runat="server" Text="Delete"  
        OnClientClick="return confirmMsg(form1)" onclick="Button3_Click" Visible="false"/>
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
