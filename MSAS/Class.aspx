<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Class.aspx.cs" Inherits="Class" %>

<%@ Register Src="Airmacau.ascx" TagName="Airmacau1" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <meta name="author" content="Airmacau/ITD" />
    <meta name="Copyright" content="Airmacau" />
    <meta name="description" content="Airmacau" />
    <meta name="keywords" content="Airmacau" />
    <!--css-->
    <link href="css/style.css" rel="stylesheet" type="text/css" />
     <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="My97Datepicker/WdatePicker.js"></script>
    <title>Class Input</title>

    <script type="text/javascript">

        function cli(Obj) {
            var collid = document.getElementById("select_all")
            var coll = document.getElementsByName(Obj)
            if (collid.checked) {
                for (var i = 0; i < coll.length; i++)
                    coll[i].checked = true;
            } else {
                for (var i = 0; i < coll.length; i++)
                    coll[i].checked = false;
            }
        }
        function classchange()
        { }
        function checkstatus() {

            var checkedbox = "";
            //check box
            var coll = document.getElementsByName("items")
            for (var i = 0; i < coll.length; i++)
                if (coll[i].checked) {
                    checkedbox += coll[i].id;
                    checkedbox += "|";
                }
            var savetxt = document.getElementById("savetxt")
            savetxt.value = checkedbox;
            console.log(checkedbox);
            document.getElementById("savedate").click();
        }
    </script>
</head>

<body>

    <form id="form1" runat="server">

        <div id="backpanel">
            <uc1:Airmacau1 ID="Airmacau1" runat="server" />

            <div id="pagebody">


                <div id="Contentpanel">
                    <div id="linkweb" style="float: left; width: 500px; height: 25px; font-size: 14px;">
                    </div>
                    <script>    setInterval("linkweb.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());", 1000);
                    </script>
                    <div id="welcome" style="width: 500px; height: 25px; text-align: right; font-size: 14px; float: left;">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>

                    <div style="height: 30px; text-align: center; color: black; font-size: large">
                        Class input
                    </div>
                    <br />
                    <br />
                    <div style="width: 1000px; margin-left: auto; margin-right: auto;">
                        <table style="margin-left: auto; margin-right: auto;">
                            <tr>
                                <td>Class Name:
                                    <asp:TextBox ID="Class_Name" MaxLength="80" runat="server" onblur="if(this.value.replace(/^ +| +$/g,'')=='')alert('Class Name is required')"></asp:TextBox>
                                </td>
                                <td>Course Ref
                                    <asp:DropDownList ID="Course_Ref" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Course_Ref_SelectedIndexChanged"></asp:DropDownList>
                                (调整该字段会导致下面的资料丢失)</td>

                                <td>Batch:
                                    <asp:TextBox ID="Batch" runat="server" ></asp:TextBox>
                                </td>
                                <td>
                                    <a onclick="checkstatus()" style="width: 30px; height: 15px; background-color: #fff; display: inline-block; padding: 5px; text-align: center; border-radius: 5px; border: 1px solid #C0C0C0; vertical-align: central; padding-top: 7px; cursor: pointer">Save</a>
                                    <input id="savetxt" runat="server" text="Label" style="display: none"></input>
                                    <asp:Button ID="savedate" runat="server" Text="Button" hidden="true" OnClick="savedateClick" />
                                </td>

                            </tr>
                            <tr>
                                <td>Instructor:
                                    <asp:TextBox ID="Instructor" runat="server"></asp:TextBox>
                                </td>
                                <td>Training Date:
                                    <asp:TextBox ID="Training_Date" runat="server"
                                        MaxLength="100" Rows="3" Height="20px"
                                        Width="127px" onClick="WdatePicker()"
                                        Style="margin-left: 10px"></asp:TextBox>
                                    <img onclick="WdatePicker({el:$dp.$('datejo')})" src="My97DatePicker/skin/datePicker.gif" mce_src="My97DatePicker/skin/datePicker.gif" align="absmiddle">
                                </td>
                                <td>Training Time<asp:TextBox ID="Training_Time" runat="server"></asp:TextBox>Hours</td>
                            </tr>
                            <tr>
                                <td>Training Type:
                                    <asp:DropDownList ID="Training_Type" runat="server"></asp:DropDownList>
                                </td>
                                <td>Location:
                                   <asp:TextBox ID="Location" runat="server"></asp:TextBox>
                                </td>
                                 <td>Training Organization<asp:TextBox ID="Training_Organization" MaxLength="25" runat="server"></asp:TextBox></td>
                            
                        
                            </tr>
                        </table>
                    </div>
                    <div id="rang" style="width: 800px; margin-left: auto; margin-right: auto">

                        <div>
                            Select attend:
                        <asp:CheckBox ID="select_all" runat="server" onclick="cli('items');" />Select All
                       
                        </div>
                        <br />
                        <div style="position: absolute; height: 400px; overflow: auto">
                            <asp:Repeater ID="titlelist" runat="server">
                                <ItemTemplate>
                                    <%# trstyle((Container.ItemIndex+1))%>
                                </ItemTemplate>
                            </asp:Repeater>
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
