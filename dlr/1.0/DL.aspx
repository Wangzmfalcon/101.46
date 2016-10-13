<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DL.aspx.cs" Inherits="Home" %>
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
 



    <title>Deadline List Search</title>
    

    <style type="text/css">
        .style1
        {
            color: #FF0000;
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
<script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
<div style="width:800px; height=150px;font-size:14px; float:left;">
<p>输入信息，点击确定添加新的数据，*为必填</p>
StaffNO<span class="style1">*</span><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
截止日期<span class="style1">*</span><input id="to11" class="Wdate" name="dlday" 
        onclick="WdatePicker()" style="width:100px;height:22px" type="text" value=" " />提前天数</span><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" 
        style="height: 26px" />
</div>

<div style="width:800px; height=150px;font-size:14px; float:left;">
<p>输入对应的查询信息</p>
StaffNO<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
截止日期<input id="Text1" class="Wdate" name="dlday2" 
        onclick="WdatePicker()" style="width:100px;height:22px" type="text" value=" " />提前天数</span><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
<asp:Button ID="Button2" runat="server" Text="查询" onclick="Button2_Click" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
</div>
<div id="gridview" style="  text-align:center">
<asp:GridView ID="GridView1" runat="server"  Width="810px" AllowPaging="True"  GridLines="None" PageSize="10" OnRowCommand="GridView1_RowCommand"
  OnRowEditing="GridView1_RowEditing"  OnRowCancelingEdit="GridView1_RowCancelingEdit" 
 OnRowUpdating="GridView1_RowUpdating"    OnPageIndexChanging="GridView1_PageIndexChanging"
 OnRowDeleting="GridView1_Deleting" OnRowDataBound="GridView1_RowDataBound"
   
        AutoGenerateColumns="False" style="color: #0000FF; margin-top: 0px;" 
         CellPadding="4" ForeColor="#333333" >
            
            <AlternatingRowStyle BackColor="White" />   
             <Columns>



              <asp:TemplateField HeaderText="Staff_No">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Width="60px" Text='<%# Bind("Staff_No") %>' ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Staff_No") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Time">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Width="60px" Text='<%# Bind("Time") %>' ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="ProTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Width="60px" Text='<%# Bind("ProTime") %>' ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Status">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Width="60px"  Visible=false  Text='<%# Bind("Status") %>' ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:CommandField ShowEditButton="True" HeaderText="Edit"/>

              <asp:TemplateField>

          

     </asp:TemplateField>

                 <asp:TemplateField HeaderText="Confirm">
                     <ItemTemplate>
                         <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" 
                             CommandName="Delete" Text="Confirm"></asp:Button>
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
