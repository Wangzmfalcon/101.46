<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Station_Crew_Pair.aspx.cs" Inherits="Station_Crew_Pair" %>
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

 



    <title>Station Check</title>
    

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

<div style=" height:60px; font-size:14px; font-style:normal;">

    Station Code:<asp:TextBox ID="TextBox8" runat="server" Width=100px></asp:TextBox>
    Flight Type:<asp:DropDownList ID="DropDownList1" runat="server" Width=100px>
    </asp:DropDownList>
    StaffName/No:
    
    <%--<asp:DropDownList ID="DropDownList2" runat="server" Width=100px>
    </asp:DropDownList>--%>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    Date:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" style="width:70px;height:22px" name="cc_date" id="formdate">
    <asp:Button ID="Button1" runat="server" Text="Search" onclick="Button1_Click" />

    <br />
    <asp:Label ID="Label8" runat="server" Text=""></asp:Label>

</div>
  <div id="gridview" style="  text-align:center">
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
       AllowPaging="True" CellPadding="4" 
          ForeColor="#333333" GridLines="None" Width="810px" PageSize="15" 
        EnableModelValidation="True" 
       OnPageIndexChanging="GridView1_PageIndexChanging" 
        OnRowEditing="GridView1_RowEditing" 
         OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowUpdating="GridView1_RowUpdating"
          OnRowDataBound="GridView1_RowDataBound"
        >
          <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Station_Code">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"  Text ='<%#  Bind("Station_Code") %>'  Width="80px" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text ='<%#  Bind("Station_Code") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Station_Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text ='<%#  Bind("Station_Name") %>'  Width="80px" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text ='<%#  Bind("Station_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Flight_Type">
                <EditItemTemplate>
                       <asp:DropDownList ID="Flight_Type" runat="server"    DataValueField='<%#  Bind("Flight_Type") %>'   Width="80px" ></asp:DropDownList>
                    
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text ='<%#  Bind("Flight_Type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Allow_Staff_Name">
                <EditItemTemplate>
                   <asp:DropDownList ID="Allow_Staff_No" runat="server"    DataValueField='<%#  Bind("Allow_Staff_No") %>'   Width="80px" ></asp:DropDownList>
                 
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server"  Text ='<%#  Bind("Allow_Staff_No") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
         <%--   <asp:TemplateField HeaderText="Allow_Staff_Name">
                <EditItemTemplate>
                     <asp:DropDownList ID="Allow_Staff_Name" runat="server"    DataValueField='<%#  Bind("Allow_Staff_Name") %>'   Width="80px" ></asp:DropDownList>
                 
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server"  Text ='<%#  Bind("Allow_Staff_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="No_From">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server"  Text='<%# Bind("No_From") %>' onClick="WdatePicker()" Width="80px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("No_From") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No_To">
                <EditItemTemplate>
                   <asp:TextBox ID="No_To" runat="server"  Text='<%# Bind("No_To") %>' onClick="WdatePicker()" Width="80px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server"  Text='<%# Bind("No_To") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                  <EditItemTemplate>
                      <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                          CommandName="Update" Text="Update"></asp:LinkButton>
                      &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                          CommandName="Cancel" Text="Cancel" ></asp:LinkButton>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                          CommandName="Edit" Text="Edit" ></asp:LinkButton>
                  </ItemTemplate>
                  
              </asp:TemplateField>
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
    <div style=" margin: 0 0px auto auto; text-align:right">
      <asp:Button ID="Delete" runat="server" Text="Delete" 
          OnClientClick="return confirmMsg(form1)" Visible="false" 
          onclick="Delete_Click"/>
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
