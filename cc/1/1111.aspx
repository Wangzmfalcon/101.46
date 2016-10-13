<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1111.aspx.cs" Inherits="crew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crew information</title>
    <style type="text/css">
        .style1
        {
            color: #0000FF;
        }
        .style2
        {
            text-align: left;
        }
        .style3
        {
            text-align: left;
        }
        .style4
        {
            color: #FF0000;
        }
    </style>
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


        <asp:Panel ID="Panel1" runat="server" Visible="true"  Width="605px" Height="400px" >
     <div style=" height:50px; text-align: left;">

</div>
<div style="width:605px; text-align: left">
<asp:GridView ID="GridView1" runat="server"  Width="400px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowDeleting="GridView1_RowDelete" 
          OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
        AutoGenerateColumns="False" style="color: #0000FF">
            
            <Columns>
            <asp:BoundField DataField="StaffNo" HeaderText="StaffNo"/>
            <asp:BoundField DataField="StaffName" HeaderText="StaffName"/>
            <asp:BoundField DataField="Title" HeaderText="Title"/>
                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete"/>
                <asp:CommandField ShowEditButton="True" HeaderText="Edit"/>
            </Columns>

        </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="false"  Width="605px" Height="400px">
      <div style=" height:50px" class="style3">

          <br />
          <span class="style4">Do you want to delete the follow information?</span></div>
<div style="width:605px; text-align: center ;height:40px">
    <span class="style1">Staff_No:</span><asp:Label ID="Label2" runat="server" 
        CssClass="style1"></asp:Label>
    <span class="style1">&nbsp; Staff_Name</span>:<asp:Label ID="Label3" runat="server" 
        CssClass="style1"></asp:Label>
    <span class="style1">&nbsp; Staff_Title:</span><asp:Label ID="Label4" runat="server" 
        CssClass="style1"></asp:Label>
    <br />
    <asp:Button ID="DeleteCrewInfo" runat="server" onclick="DeleteCrewInfo_Click" 
        Text="Yes" />
    &nbsp;&nbsp;
    <asp:Button ID="Cancel" runat="server" onclick="CancelCrewInfo_Click" 
        Text="Cancel" />

   </div>
    </asp:Panel>
    
     

    <asp:Panel ID="Panel3" runat="server" Visible="false"  Width="605px" Height="400px" >
      <div style=" height:50px; text-align: left;">

          <br />
          Insert Information:</div>
<div style="width:605px; text-align: left;">

    StaffNo:<asp:TextBox ID="TextBox1" runat="server" Width ="100px"></asp:TextBox>
    &nbsp; StaffName:<asp:TextBox ID="TextBox2" runat="server" Width ="100px"></asp:TextBox>
    &nbsp; Title:<asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    
    <asp:Button ID="Button3" runat="server" onclick="insert_Click" Text="Insert" />
    
&nbsp;<asp:Button ID="Button4" runat="server" onclick="CancelCrewInfo_Click" 
        Text="Cancel" Width="52px" />
        </asp:Panel>
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
