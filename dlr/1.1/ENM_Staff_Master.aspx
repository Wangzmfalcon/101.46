<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ENM_Staff_Master.aspx.cs" Inherits="Home" %>
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
 



    <title>ENM_Staff_Master</title>
    

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
<div id="biaoti" style=" font-size:20px; text-align:center; color:Red">ENM Staff Master<br />
    <br />
    </div>

<div style="width:800px; height=150px;font-size:14px; float:left;">
<p>Upload data, click Browse to select the data you want to upload, click the Upload 
    button to upload the data.</p>
    <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" Text="upload" onclick="Button1_Click" 
        style="height: 26px" />
</div>

<div style="width:800px; height=150px;font-size:14px; float:left;">
<p>Enter the query information</p>
StaffNO<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    Name<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>Licence_No<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
<asp:Button ID="Button2" runat="server" Text="query" onclick="Button2_Click" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
</div>
<div id="gridview" style="  text-align:center">
<asp:GridView ID="GridView1" runat="server"  Width="810px" AllowPaging="True"  GridLines="None" 
 OnRowCommand="GridView1_RowCommand"    OnPageIndexChanging="GridView1_PageIndexChanging"
  OnRowEditing="GridView1_RowEditing" 
        AutoGenerateColumns="False" style="color: #0000FF; margin-top: 0px;" 
         CellPadding="4" ForeColor="#333333" >
            
            <AlternatingRowStyle BackColor="White" />   
            
     
            
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
      <PagerTemplate>
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:LinkButton ID="lbFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                    CommandName="Page"><font title="首页">|<<</font></asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="lbPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                    CommandName="Page"><font title="上一页"><<</font></asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="lbNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                    CommandName="Page"><font title="下一页">>></font></asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="lbLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                    CommandName="Page"><font title="尾页">>>|</font></asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label
                                    ID="Label2" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageIndex + 1 %>"></asp:Label>&nbsp;
                                &nbsp;/&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount %>"></asp:Label>&nbsp;
                                &nbsp;&nbsp;
                            </PagerTemplate>

        </asp:GridView>
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
