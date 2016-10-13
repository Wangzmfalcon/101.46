<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkinsert.aspx.cs" Inherits="crewcheck" %>

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
<div  style="width:605px; height:60px ;">
</div>
<div style="width:605px; height:60px ;">
    Staff_No:<asp:TextBox ID="TextBox1" runat="server" Width="60px"></asp:TextBox>
    No_Type:<asp:DropDownList ID="DropDownList1" runat="server" Height="22px"  
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList>

    No_Object:<asp:DropDownList ID="DropDownList2" runat="server" Height="22px">
</asp:DropDownList>
     <br />
    <br />
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    Date:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" style="width:100px;height:22px" name="cc_date">  Except_For:<asp:DropDownList ID="DropDownList3" runat="server">
    </asp:DropDownList>
&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Query" onclick="Button1_Click" />
&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Insert" onclick="Button2_Click" />
  <div style="width:605px; text-align: center">

  <asp:Panel ID="Panel1" runat="server" Visible="true"  Width="605px" Height="400px" 
          style="text-align: left" >
       <div style=" height:50px; text-align: left;"></div>
       <div style="width:605px; text-align: left">

         
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"  style="color: #0000FF" 
           OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDelete" 
            OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" Width="605px">
             
            <Columns>
            <asp:BoundField DataField="StaffNo" HeaderText="StaffNo"/>
            <asp:BoundField DataField="No_Type" HeaderText="Type"/>
            <asp:BoundField DataField="No_Object" HeaderText="Object"/>
            <asp:BoundField DataField="No_From" HeaderText="From"/>
            <asp:BoundField DataField="No_To" HeaderText="To"/>
            <asp:BoundField DataField="Except_For" HeaderText="Except For"/>
            <asp:BoundField DataField="Remark" HeaderText="Remark"/>
                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete"/>
                <asp:CommandField ShowEditButton="True" HeaderText="Edit"/>
            </Columns>

             

               <EditRowStyle Width="20px" />
               <EmptyDataRowStyle Width="20px" />

             

           </asp:GridView>

       
       </div>
  </asp:Panel>
  
  <asp:Panel ID="Panel2" runat="server" Visible="false"  Width="605px" Height="400px" >
       <div style=" height:50px; text-align: left; color: #FF0000;">
           <br />
           Do you want to delete the follow information?</div>
       <div style="color: #0000FF">
       Staff_No:
           <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
           &nbsp;No_Type:<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
           &nbsp;No_Object:<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
           <br />
           From:<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
           &nbsp;To:<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
           &nbsp;Except_For:
           <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
           <br />
           <span class="style1">Remark:</span><asp:Label ID="Label8" runat="server" 
               CssClass="style1" Text="Label"></asp:Label>
           <br class="style1" />
           <asp:Button ID="Button3" runat="server" Text="Yes" onclick="Button3_Click" />
           &nbsp;
           <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Cancel" />
       </div>
  </asp:Panel>
  
  <asp:Panel ID="Panel3" runat="server" Visible="false"  Width="605px" Height="400px" 
          style="text-align: left" >
       <div style=" height:50px">
           <br />
           Insert Information:</div>
          Staff_No:<asp:TextBox ID="TextBox2" runat="server" Width="60px"></asp:TextBox>
    No_Type:<asp:DropDownList ID="DropDownList4" runat="server" Height="22px"  
        OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="True" >
</asp:DropDownList>

    No_Object:<asp:DropDownList ID="DropDownList5" runat="server" Height="22px">
</asp:DropDownList>
     <br />
    <br />
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
       From:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" style="width:100px;height:22px" name="cc_from">  
       To:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" style="width:100px;height:22px" name="cc_to">
       Except_For:<asp:DropDownList ID="DropDownList6" runat="server">
    </asp:DropDownList>
&nbsp;
       <br />
       <br />
       Remark:<asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
       <br />
       <br />
       <asp:Button ID="Button5" runat="server" onclick="insert_Click" Text="Yes" />
&nbsp;
    <asp:Button ID="Button6" runat="server" Text="Cancel" OnClick="Button4_Click"/>
      </asp:Panel>
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
