﻿<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Staffin.aspx.cs" Inherits="Staffin" %>

<%@ Register src="Airmacau.ascx" tagname="Airmacau1" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
		<meta content="Microsoft Visual Studio 9.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
				<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="zh-CN" /> 
<meta name="author" content="Airmacau/ITD" /> 
<meta name="Copyright" content="Airmacau" /> 
<meta name="description" content="Airmacau" />
<meta name="keywords" content="Airmacau"  />
 <!--css-->
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="My97Datepicker/WdatePicker.js"></script>
<script type="text/javascript" language="javascript">
    function ShowNo() {
        document.getElementById("doing").style.display = "none";
        document.getElementById("divLogin").style.display = "none";
    }
    function $(id) {
        return (document.getElementById) ? document.getElementById(id) : document.all[id];
    }
    function showFloat() {
        var range = getRange();
      //  $('doing').style.width = range.width + "px";
      //  $('doing').style.height = range.height + "px";
      // $('doing').style.display = "block";
        document.getElementById("divLogin").style.display = "";
        return true;
    }
    function getRange() {
        var top = document.body.scrollTop;
        var left = document.body.scrollLeft;
        var height = document.body.clientHeight;
        var width = document.body.clientWidth;

        if (top == 0 && left == 0 && height == 0 && width == 0) {
            top = document.documentElement.scrollTop;
            left = document.documentElement.scrollLeft;
            height = document.documentElement.clientHeight;
            width = document.documentElement.clientWidth;
        }
        return { top: top, left: left, height: height, width: width };
    } 
    </script>
   <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <title>Employee</title>
    <style type="text/css">
        #TextArea1 {
            width: 674px;
            height: 76px;
        }

        #datainput {
            width: 303px;
        }
    </style>
        <style type="text/css">
        body{margin:0px;}
    </style>
    <style type="text/css">
        .style1
        {
            width: 129px;
        }
                </style>
  <script type="text/javascript">

      function getdata() {

          var i;
          var flag = true;
          document.getElementById('datainput').value = "";
          for (i = 1; i < 25; i++) {
              var s = i.toString();
              var id = "Q" + s;
              var str = document.getElementById(id).value;
              if (!str) {
                  alert("Question " + i + " is required");
                  flag = false
                  break;
              }
              else {
                  var v_get = s + ":" + document.getElementById(id).value + "|";
                  document.getElementById('datainput').value += v_get;
              }


          }

          if (flag) {
              document.getElementById("Button1").click();

              for (i = 1; i < 10; i++) {
                  var s = i.toString();
                  var id = "Q" + s;
                  document.getElementById(id).value = "";
              }
          }
      }

</script>

</head>
<script language="javascript" type="text/javascript" src="My97Datepicker/WdatePicker.js"></script>
<body>

    <form id="layout" runat="server">
<!--加一个半透明层-->   
    <div id="doing"  style="background-color:#000;width:100%;height:100%;z-index:1000;position: absolute;left:0;top:0;display:none;overflow: hidden;">
    </div>    
    <!--加一个登录层-->   
    <div id="divLogin" style="border:solid 10px #898989;background:#fff;padding:10px;width:780px;z-index:1001; position: absolute; display:none;top:50%; left:50%;margin:-200px 0 0 -400px;">
            <div style="padding:3px 10px 3px 10px;text-align:left;vertical-align:middle;" >
                <div>
                    
                                  <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Staff No.:</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:TextBox id="stano" runat="server"></asp:TextBox>
								</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>
				                <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Name</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:TextBox id="nam" runat="server"></asp:TextBox>
								</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>
				                <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Department</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:Dropdownlist  id="Depart" runat="server" DataValueField='<%# Bind("Department") %>'></asp:Dropdownlist>
								</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>
				<tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Station</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:Dropdownlist  id="Dropdownlist1" runat="server" DataValueField='<%# Bind("Station") %>'></asp:Dropdownlist>
								</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>
				
				
				                <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Division</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:Dropdownlist  id="Divis" runat="server" DataValueField='<%# Bind("Division") %>'></asp:Dropdownlist>
								</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>
				                <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Title</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:Dropdownlist  id="Titl" runat="server" DataValueField='<%# Bind("Title") %>'></asp:Dropdownlist>
								</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>
				                <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Date of Join</td>
								       <td width="25%" class="auto-style4"><asp:TextBox ID="datejo" runat="server"  
                                        MaxLength="100" Rows="3" Height="20px" 
                                        Width="127px" onClick="WdatePicker({maxDate:'%y-%M-%d'})" 
                                        style="margin-left: 10px" ></asp:TextBox>  
        <img onclick="WdatePicker({maxDate:'%y-%M-%d',el:$dp.$('datejo')})" src="My97DatePicker/skin/datePicker.gif" mce_src="My97DatePicker/skin/datePicker.gif"  align="absmiddle"></td>
                                    <td style="style7">
                                    &nbsp;</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>
				                <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Lisence</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:TextBox id="Lisen" runat="server"></asp:TextBox>
								</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>

                    <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Category</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                            <asp:Dropdownlist  id="Categoryin" runat="server" DataValueField='<%# Bind("Category") %>'></asp:Dropdownlist>
								</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>



                     <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">Non JMM</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                             <asp:CheckBox ID="checknotjmm" runat="server" Checked='<%#Eval("notJMM")%>' />
								</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>


								                <tr style="color:#FD795B">
					<td style="color:#000000; height: 32px;">
						<table cellspacing="1" cellpadding="1" width="100%" border="0">
							<tr>
								<td class="style19" width="15%" style="height: 26px">&nbsp;
									<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ForeColor="#FD795B" Font-Size="9pt"  ErrorMessage="Wrong Message！" ControlToValidate="Dep"></asp:requiredfieldvalidator>--%></td>
								<td class="auto-style1" style="height: 26px" width="5%">

								</td>
								<td style="height: 26px" width="25%">LisenceExpired</td>
								       <td width="25%" class="auto-style4"><asp:TextBox ID="LisenceEx1" runat="server"  
                                        MaxLength="100" Rows="3" Height="20px" 
                                        Width="127px" onClick="WdatePicker()" 
                                        style="margin-left: 10px" ></asp:TextBox>  
        <img onclick="WdatePicker({maxDate:'%y-%M-%d',el:$dp.$('LisenceEx1')})" src="My97DatePicker/skin/datePicker.gif" mce_src="My97DatePicker/skin/datePicker.gif"  align="absmiddle"></td>
                                    <td style="style7">
                                    &nbsp;</td>
								<td class="style13" style="height: 26px"></td>
								<td class="pt9" style="height: 26px">
									&nbsp;&nbsp;</td>
                                    </tr>  
						</table>
					</td>
				</tr>
                </div>
                <br/>
                <div align="center">     
                    <asp:Button  ID="BttLogin" runat="server" Text=" Confirm " OnClick="finish"/> 
                    <input id="BttCancel" type="button" value=" Cancel " onclick="ShowNo()" />
                </div>
            </div>
      </div> 
<div id="backpanel">
<uc1:Airmacau1 ID="Airmacau1" runat="server"/>


<div id="pagebody">


<div id="Contentpanel">
<div id="linkweb" style=" float:left; width:500px; height:25px;font-size:14px;">
</div>
<script>    setInterval("linkweb.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());", 1000);
</script>
<div id="welcome" style="width:500px; height:25px;text-align:right; font-size:14px; float:left;">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</div>
<div  style="height:30px; text-align:center; color:black; font-size:large"  >
    &nbsp;Employee</div>
</br>
</br>
<div  style="height:120px; text-align:center; color:black; font-size:large"  >
<table>
<tr style="height:30px">
   <td width="120">
    Staff No.：
    </td>
    <td width="130">
    <asp:TextBox ID="txtName" Width="120" runat="server"></asp:TextBox>
    </td>
    <td width="120">
     Name：
     </td>
     <td width="130">
     <asp:TextBox ID="tname" Width="120" runat="server"></asp:TextBox>
     </td>
     <td width="120">
     License：
     </td>
     <td width="130">
     <asp:TextBox ID="tlicen" Width="120" runat="server"></asp:TextBox>
     </td>
     </tr>
<tr style="height:30px">
<td width="120">
Department：
</td>
<td width="130">
<asp:DropDownList ID="tdepart" MaxLength="20" Width="120"  runat="server" DataValueField='<%# Bind("Department") %>'></asp:DropDownList></td>

<td width="120">Division：</td>
<td width="130"><asp:DropDownList ID="tdivi" MaxLength="20" Width="120"  runat="server" DataValueField='<%# Bind("Division") %>'></asp:DropDownList></td>
<td width="120">Title：</td><td width="130"><asp:DropDownList ID="ttitle" MaxLength="20" Width="120"  runat="server" DataValueField='<%# Bind("Title") %>'></asp:DropDownList></td>
</tr>
<tr style="height:30px">
<td width="120">
Category：
</td><td width="130"><asp:Dropdownlist ID="tcate" MaxLength="20" Width="120" runat="server" DataValueField='<%# Bind("category") %>'></asp:Dropdownlist></td>
<td width="120">Non JMM：</td><td width="130"><asp:DropDownList ID="tjmm" MaxLength="20" Width="120"  runat="server" DataValueField='<%# Bind("notJMM") %>'></asp:DropDownList></td>
<td width="120">Left：</td><td width="130"><asp:DropDownList ID="tleft" MaxLength="20" Width="120"  runat="server" DataValueField='<%# Bind("Left") %>'></asp:DropDownList></td>
<td>
<asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="Search" />

     </td>
</tr>
<tr style="height:30px">
<td width="120">
Station：
</td>
<td width="130">
<asp:DropDownList ID="station" MaxLength="20" Width="120"  runat="server" DataValueField='<%# Bind("Station") %>'></asp:DropDownList></td>
</tr>
     </table>
</div>



<div  style="height:30px; text-align:right; color:black; font-size:large"  >
<asp:Button ID="btnAdd" runat="server" Height="25px" onclick="btnAdd_Click" 
            Text="Add" Width="65px" />
</div>
 
   <div style="text-align:center; color:black;">
                <table cellspacing="3" cellpadding="1"  align="center"  border="0"
                    style="width: 800px" >
                    <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PagerSettings-Visible="False" PageSize="10" 
            onrowdeleting="GridView1_RowDeleting" Width="990px" 
            onrowdatabound="GridView1_RowDataBound" 
            onrowediting="GridView1_RowEditing" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowupdating="GridView1_RowUpdating" BackColor="White" BorderColor="#999999" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            
            <Columns>
                            <asp:TemplateField HeaderText="ID" Visible="false">
<%--                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" MaxLength="20" Width="80" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Seq") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Staff No.">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" MaxLength="20" Width="40"  runat="server" Text='<%# Bind("StaffID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2"  Width="40" runat="server" Text='<%# Bind("StaffID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" MaxLength="20" Width="70" runat="server" Text='<%# Bind("StaffName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" Width="70" runat="server" Text='<%# Bind("StaffName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Station">
                    <EditItemTemplate>
                        <asp:DropDownList ID="Station" MaxLength="20" Width="40"  runat="server" DataValueField='<%# Bind("Station") %>'></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label41" Width="40"  runat="server" Text='<%# Bind("Station") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dept.">
                    <EditItemTemplate>
                        <asp:DropDownList ID="Department" MaxLength="20" Width="40"  runat="server" DataValueField='<%# Bind("Department") %>'></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" Width="40"  runat="server" Text='<%# Bind("Department") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Div.">
                    <EditItemTemplate>
                        <asp:Dropdownlist ID="Division" MaxLength="20" Width="40"  runat="server" DataValueField='<%# Bind("Division") %>'></asp:Dropdownlist>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" Width="40"  runat="server" Text='<%# Bind("Division") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Title">
                    <EditItemTemplate>
                        <asp:Dropdownlist ID="Title" MaxLength="20" Width="100"  runat="server" DataValueField='<%# Bind("Title") %>'></asp:Dropdownlist>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" Width="100"  runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date of Join">
                    <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("DateOfJoin") %>'  
                                        MaxLength="80" Rows="3" Height="20px" 
                                        Width="80px" onClick="WdatePicker({maxDate:'%y-%M-%d'})" 
                                        style="margin-left: 10px" ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" Width="80" runat="server" Text='<%# Bind("DateOfJoin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                                                <asp:TemplateField HeaderText="License">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" MaxLength="20" Width="100" runat="server" Text='<%# Bind("License") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" Width="100"  runat="server" Text='<%# Bind("License") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                
                                                <asp:TemplateField HeaderText="Category">
                    <EditItemTemplate>
                        <asp:Dropdownlist ID="TextBoxcategory" MaxLength="20" Width="40" runat="server" DataValueField='<%# Bind("category") %>'></asp:Dropdownlist>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Labelategory" Width="40"  runat="server" Text='<%# Bind("category") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Non JMM">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBoxnotJMM" runat="server" Checked='<%#Eval("notJMM")%>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxnotJMM" runat="server"  Checked='<%#Eval("notJMM") %>' 
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Lic.Exp.">
                    <EditItemTemplate>
                                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("LicenseExpired") %>'  
                                        MaxLength="80" Rows="3" Height="20px" 
                                        Width="80px" onClick="WdatePicker()" 
                                        style="margin-left: 10px" ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" Width="80" runat="server" Text='<%# Bind("LicenseExpired") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date of Left">
                    <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxDateOfLeft" runat="server" Text='<%# Bind("DateOfLeft") %>'  
                                        MaxLength="80" Rows="3" Height="20px" 
                                        Width="80px" onClick="WdatePicker()" 
                                        style="margin-left: 10px" ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelDateOfLeft" Width="80"  runat="server" Text='<%# Bind("DateOfLeft") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Left">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox12" runat="server"   Checked='<%#Eval("HRstatus")%>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox11" runat="server"  Checked='<%#Eval("HRstatus") %>' 
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Cancel" Text="cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Edit" Text="edit"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:GridView>
                        <asp:Label ID="Lab_PageCount" runat="server"  Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>   
           <asp:Label  ID="Lab_CurrentPage" runat="server"  Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>  
                        &nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="First Page" />
                        &nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="〈" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="〉" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Last Page" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Turn To Page" />
        <asp:TextBox ID="TextBox1" runat="server" Width="51px"></asp:TextBox>
                    <%-- <tr>
    <td colspan="2" style="padding:0 20px;text-align:center;"><a href="changepwd.aspx" target="mainFrame">Change Password</a></td>
    </tr>--%>
    </td>
                </table>
</div>
           <div id="download" style="float:right" >
            <asp:LinkButton ID="LinkButton3" runat="server"  OnClick="downloadlink">Download</asp:LinkButton></div>
         </form>  
 
</body>
</html>