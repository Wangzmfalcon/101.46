<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy of crewcheck.aspx.cs" Inherits="crewcheck" %>
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
 <link href="MyStyles.css" type="text/css" rel="stylesheet" />
 <!--js-->
 <script src="js/leftmenu.js" type="text/javascript"></script>
 <script src="js/check.js" type="text/javascript"></script>
 
 <script type="text/javascript">
     var timoutID;
     function ShowMList() {
         var divRef = document.getElementById("divCheckBoxList");
         divRef.style.display = "block";
         var divRefC = document.getElementById("divCheckBoxListClose");
         divRefC.style.display = "block";
     }

     function HideMList() {
         document.getElementById("divCheckBoxList").style.display = "none";
         document.getElementById("divCheckBoxListClose").style.display = "none";
     }

     function FindSelectedItems(sender, textBoxID) {
         var cblstTable = document.getElementById(sender.id);
         var checkBoxPrefix = sender.id + "_";
         var noOfOptions = cblstTable.rows.length;
         var selectedText = "";
         for (i = 0; i < noOfOptions; ++i) {
             if (document.getElementById(checkBoxPrefix + i).checked) {
                 if (selectedText == "")
                     selectedText = document.getElementById(checkBoxPrefix + i).parentNode.innerText;
                 else
                     selectedText = selectedText + "," + document.getElementById(checkBoxPrefix + i).parentNode.innerText;
             }
         }
         document.getElementById(textBoxID.id).value = selectedText;
     }
    </script>


    <title>Crew Check search</title>
    

    <style type="text/css">
        #divCustomCheckBoxList
        {
            width: 153px;
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
<div style=" height:60px; font-size:14px; font-style:normal;">
<div style="width: 316px; display:inline; float:left;"  >    Staff_No/Name:<%--<asp:DropDownList ID="DropDownList4" runat="server" Width="80px" Visible=false>
    </asp:DropDownList>--%>
    <asp:TextBox ID="TextBox1" runat="server" Width="70px"></asp:TextBox>
    No_Type:<asp:DropDownList ID="DropDownList1" runat="server" Height="22px"  Width="70px"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList>
   </div>
   <div id="divCustomCheckBoxList" runat="server" onmouseover="clearTimeout(timoutID);" onmouseout="timoutID = setTimeout('HideMList()', 750);"  style=" float:left; border:none">
                    <table> 
                        <tr>
                            <td align="right" class="DropDownLook">
                                No_Object:<input id="txtSelectedMLValues" type="text" readonly="readonly" onclick="ShowMList()" style="width:40px;" runat="server" />
                            </td>
                            <td align="left" class="DropDownLook">
                                <img id="imgShowHide" runat="server" src="drop.gif" onclick="ShowMList()" align="left" />                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="DropDownLook">
                                <div>
            	                    <div runat="server" id="divCheckBoxListClose" class="DivClose">			                        
		                                <label runat="server" onclick="HideMList();" class="LabelClose" id="lblClose">X</label>
		                            </div>
                                    <div runat="server" id="divCheckBoxList" class="DivCheckBoxList">
		                                <asp:CheckBoxList ID="lstMultipleValues" runat="server" Width="250px" CssClass="CheckBoxList"></asp:CheckBoxList>						        			           			        
		                            </div>
		                        </div>
                            </td>
                        </tr>
                    </table>
                </div>
   <div style=" float:left;"> 
   Date:&nbsp;<input class="Wdate" type="text" onClick="WdatePicker()" style="width:70px;height:22px" name="cc_date" id="formdate">
     Except_For:<asp:DropDownList ID="DropDownList3" runat="server"  Width="70px">
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="search" onclick="Button1_Click"  
        Width="70px" style="text-align: center"/>
    </div>


    <br />
    <div style="clear:both"></div>
    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
    </div>
  <div id="gridview" style="  text-align:center">

      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
      OnRowEditing="GridView1_RowEditing" 
          OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowUpdating="GridView1_RowUpdating"
      OnPageIndexChanging="GridView1_PageIndexChanging" 
          OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" CellPadding="4" 
          ForeColor="#333333" GridLines="None" Width="810px" PageSize="10" >
          <AlternatingRowStyle BackColor="White" />
          <Columns>
              <asp:BoundField DataField="Processed_At" HeaderText="Processed_At" 
                  ReadOnly="True" Visible="false"
                        SortExpression="Processed_At" >
             
              </asp:BoundField>
              <asp:TemplateField HeaderText="StaffNo">
                  <EditItemTemplate>
                     
                       <asp:DropDownList ID="staffNo" runat="server"  Width="80px"  DataValueField='<%#  Bind("StaffNo") %>' ></asp:DropDownList>

                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("StaffNo") %>'></asp:Label>
                  </ItemTemplate>
                  <ControlStyle Width="80px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Type" >
                  <EditItemTemplate>
                          <asp:DropDownList ID="DropDownList1" runat="server"  Width="80px"  DataValueField='<%#  Bind("No_Type") %>' ></asp:DropDownList>

                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("No_Type") %>'></asp:Label>
                  </ItemTemplate>
                  <ControlStyle Width="80px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Object">
                  <EditItemTemplate>
                    
                        <asp:DropDownList ID="DropDownList2" runat="server"  Width="80px"  DataValueField='<%#  Bind("No_Object") %>'></asp:DropDownList>

                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("No_Object") %>'></asp:Label>
                  </ItemTemplate>
                  <ControlStyle Width="80px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="From">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox4" runat="server"  Text='<%# Bind("No_From") %>' onClick="WdatePicker()" Width="80px"></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label4" runat="server" Text='<%# Bind("No_From") %>' ></asp:Label>
                  </ItemTemplate>
                  <ControlStyle Width="80px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="To">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("No_To") %>'  onClick="WdatePicker()" Width="80px"></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label5" runat="server" Text='<%# Bind("No_To") %>'></asp:Label>
                  </ItemTemplate>
                  <ControlStyle Width="80px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Except For">
                  <EditItemTemplate>
                      
                       <asp:DropDownList ID="DropDownList3" runat="server"  Width="80px"  DataValueField='<%#  Bind("Except_For") %>'></asp:DropDownList>

                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label6" runat="server" Text='<%# Bind("Except_For") %>'></asp:Label>
                  </ItemTemplate>
                  <ControlStyle Width="80px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Remark">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Remark") %>'  Width="70px" ></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label7" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                  </ItemTemplate>
                  <ControlStyle Width="100px" />
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
</div>
<div id="copyright">
Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
</div>
</div>

    </form>
</body>
</html>
