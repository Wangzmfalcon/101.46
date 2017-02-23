<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Authorization.aspx.cs" Inherits="Authorization" %>

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
    <title>Datainput</title>
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
								<td style="height: 26px" width="25%">Staff NO:</td>
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
								<td style="height: 26px" width="25%">Project</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:Dropdownlist  id="Depart" runat="server" DataValueField='<%# Bind("Project") %>'></asp:Dropdownlist>
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
								<td style="height: 26px" width="25%">Range</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:Dropdownlist  id="Divis" runat="server" DataValueField='<%# Bind("Range") %>'></asp:Dropdownlist>
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
								<td style="height: 26px" width="25%">Level</td>
								<td class="auto-style4" style="height: 26px">
								&nbsp;
                                    <asp:Dropdownlist  id="Titl" runat="server" DataValueField='<%# Bind("Level") %>'></asp:Dropdownlist>
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
								<td style="height: 26px" width="25%">ExpireDate</td>
								       <td width="25%" class="auto-style4"><asp:TextBox ID="datejo" runat="server"  
                                        MaxLength="100" Rows="3" Height="20px" 
                                        Width="127px" onClick="WdatePicker()" 
                                        style="margin-left: 10px" ></asp:TextBox>  
        <img onclick="WdatePicker({el:$dp.$('datejo')})" src="My97DatePicker/skin/datePicker.gif" mce_src="My97DatePicker/skin/datePicker.gif"  align="absmiddle"></td>
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
								<td style="height: 26px" width="25%">Remarks</td>
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
<div class="menu">

<ul>
<li><a id="staffs" class="hide" href="Main.aspx" runat="server">Staff Settings</a>

    <ul>
    <li><a href="Department.aspx" title="Department">Department Setting</a></li>
    <li><a href="Position.aspx" title="Wrapping text around images">Division Setting</a></li>
    <li><a href="Title.aspx" title="Wrapping text around images">Title Setting</a></li>
    <li><a href="Staffin.aspx" title="Image Map for detailed information">Employee Setting</a></li>

    </ul>

</li>
<li><a style="width:150px" class="hide" href="Main.aspx">Authorization Settings</a>

    <ul>
    <li><a href="Project.aspx" title="Styling forms">Project Setting</a></li>  
    <li><a href="Range.aspx" title="Multi-position drop shadow">Range Setting</a></li>
    <li><a href="Level.aspx" title="Removing active/focus borders">Level Setting</a></li>

    </ul>

</li>
<li><a class="hide" href="Authorization.aspx">Authorization</a>

</li>
<li><a class="hide" href="AuthorizationSelect.aspx">AuthorizationSearch</a>

</li>
<li><a class="hide" href="../mozilla/index.html">Test</a>

</li>
</ul>
<!-- clear the floats if required -->
<div class="clear"> </div>
</div>

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
    &nbsp;Authorization</div>
</br>
</br>
<div  style="height:30px; text-align:center; color:black; font-size:large"  >
   
    Staff No：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
     <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="Search" />
     &nbsp;

    <asp:Button ID="btnAdd" runat="server" Height="25px" onclick="btnAdd_Click" 
            Text="Add" Width="65px" />
     

</div>
     <div style="height:30px;text-align:right; color:black;">
        </div>
   <div style="text-align:center; color:black;">
                <table cellspacing="3" cellpadding="1"  align="center"  border="0"
                    style="width: 800px" >
                    <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PagerSettings-Visible="False" PageSize="15" 
            onrowdeleting="GridView1_RowDeleting" Width="800px" 
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
                <asp:TemplateField HeaderText="Staff NO">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" MaxLength="20" Width="80" runat="server" Text='<%# Bind("StaffID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("StaffID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project">
                    <EditItemTemplate>
                        <asp:DropDownList ID="Project" MaxLength="20" Width="80" runat="server" DataValueField='<%# Bind("Project") %>'></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Project") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Range">
                    <EditItemTemplate>
                        <asp:DropDownList ID="Range" MaxLength="20" Width="80" runat="server" DataValueField='<%# Bind("Range") %>'></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Range") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level">
                    <EditItemTemplate>
                        <asp:Dropdownlist ID="Level" MaxLength="20" Width="80" runat="server" DataValueField='<%# Bind("Level") %>'></asp:Dropdownlist>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Level") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ExpireDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="ExpireDate" runat="server" Text='<%# Bind("ExpireDate") %>'  
                                        MaxLength="80" Rows="3" Height="20px" 
                                        Width="127px" onClick="WdatePicker()" 
                                        style="margin-left: 10px" ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("ExpireDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                             
                  <asp:TemplateField HeaderText="Remarks">
                    <EditItemTemplate>
                     <asp:TextBox ID="Remarks" MaxLength="20" Width="80" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Vaild">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox12" runat="server" Checked='<%#Eval("Vaild")%>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox11" runat="server"  Checked='<%#Eval("Vaild") %>' 
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
         </form>  
</body>
</html>