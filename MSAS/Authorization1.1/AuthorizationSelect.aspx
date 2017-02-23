<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthorizationSelect.aspx.cs" Inherits="AuthorizationSelect" %>

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
    <title>AuthorizationS</title>
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

    
</div>
     <div style="height:30px;text-align:right; color:black;">
        </div>
   <div style="text-align:center; color:black;">
                <table cellspacing="3" cellpadding="1"  align="center"  border="0"
                    style="width: 800px" >
                    <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PagerSettings-Visible="False" PageSize="15" 
             Width="800px" 
            onrowdatabound="GridView1_RowDataBound" 
            onrowediting="GridView1_RowEditing" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
             BackColor="White" BorderColor="#999999" 
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
                        <asp:LinkButton ID="Label2" CommandName="Edit" CausesValidation="False" runat="server" Text='<%# Bind("StaffID") %>'></asp:LinkButton>
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