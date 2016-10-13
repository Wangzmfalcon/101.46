<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Datainput.aspx.cs" Inherits="Home" %>
<%@ Register src="Airmacau.ascx" tagname="Airmacau1" tagprefix="uc1" %>

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


 <!--js-->

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
    
  <script type="text/javascript">

      function textdown(e) {
          textevent = e;
          if (textevent.keyCode == 8) {
              return;
          }
          if (document.getElementById('Q23').value.length >= 300) {
              alert("No more than 300 letters")
              if (!document.all) {
                  textevent.preventDefault();
              }
              else {
                  textevent.returnValue = false;
              }
          }
      }
      function textup() {
          var s = document.getElementById('Q23').value;
          //判断ID为text的文本区域字数是否超过1000个   
          if (s.length > 300) {
              document.getElementById('Q23').value = s.substring(0, 300);
          }
      }


      function getdata() {

          var i;
          var flag=true;
          document.getElementById('datainput').value = "";
          for (i = 1; i < 25; i++) {
              var s = i.toString();
              var id = "Q" + s;
              var str = document.getElementById(id).value;
              if (!str) {
                  //alert("Question " + i + " is required");
                  //flag=false
                  //break;
                  var v_get = s + ":0|";
                  document.getElementById('datainput').value += v_get;
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

<body>

    <form id="form1" runat="server">

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
<div  style="height:60px; text-align:center; color:red; font-size:large"  >Date input
</div>
    <div  style="height:60px; text-align:center; color:red; font-size:large"  >
</div>
<div id="Datainput" style="width: 950px;table-layout:fixed;margin-left:50px">

    <table   style="width: 800px;height:40px " border="0">
        <tr style="height:30px ">
            </tr>
        <td width=300px>StaffNo.&nbsp;&nbsp;<input type="text" id="Q24" style="width:100px;height:20px"  /></td>
       <td width=300px> </td>
        <td width=300px> </td>
        <tr style="height:30px ">
            <td width=300px>1: &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Q1" runat="server" style="width:100px;height:20px"  >
        </asp:DropDownList></td>
            <td width=300px>2: &nbsp;&nbsp;&nbsp;<input class="Wdate" type="text" style="width:100px;height:20px"   onClick="WdatePicker()  " name="deptdate" id= "Q2" /></td>
      <td width=300px>3: &nbsp;&nbsp;&nbsp;<input type="text" id="Q3" style="width:100px;height:20px"  />&nbsp;&nbsp;
            </td>
        </tr>
        <tr style="height:30px ">
            
            <td width=300px>4: &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Q4" runat="server" style="width:100px;height:20px" >
        </asp:DropDownList></td>
        <td width=300px>5: &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Q5" runat="server" style="width:100px;height:20px" >
        </asp:DropDownList></td>
            <td width=300px>6: &nbsp;&nbsp;&nbsp;<input type="text" id="Q6" style="width:100px;height:20px"  /></td>
        </tr>
          <tr style="height:30px ">
            <td width=300px>7: &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Q7" runat="server" style="width:100px;height:20px" >
         </asp:DropDownList></td>
            <td width=300px>8: &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Q8" runat="server" style="width:100px;height:20px" >
         </asp:DropDownList></td>
             <td width=300px>9: &nbsp;&nbsp;&nbsp;<input type="text" id="Q9" style="width:100px;height:20px"  /></td>
         </tr>   
     
              </tr>
          <tr style="height:30px ">
             <td width=300px>10:&nbsp;&nbsp;<input type="text" id="Q10" style="width:100px;height:20px"  /></td>
              <td width=300px>11:&nbsp;&nbsp;<input type="text" id="Q11" style="width:100px;height:20px"  /></td>
               <td width=300px>12:&nbsp;&nbsp;<input type="text" id="Q12" style="width:100px;height:20px"  /></td>
         </tr>    
        <tr style="height:30px ">
             <td width=300px>13:&nbsp;&nbsp;<input type="text" id="Q13" style="width:100px;height:20px"  /></td>
              <td width=300px>14:&nbsp;&nbsp;<input type="text" id="Q14" style="width:100px;height:20px"  /></td>
               <td width=300px>15:&nbsp;&nbsp;<input type="text" id="Q15" style="width:100px;height:20px"  /></td>
         </tr>    
          <tr style="height:30px ">
             <td width=300px>16:&nbsp;&nbsp;<input type="text" id="Q16" style="width:100px;height:20px"  /></td>
              <td width=300px>17:&nbsp;&nbsp;<input type="text" id="Q17" style="width:100px;height:20px"  /></td>
               <td width=300px>18:&nbsp;&nbsp;<input type="text" id="Q18" style="width:100px;height:20px"  /></td>
         </tr>    
          <tr style="height:30px ">
             <td width=300px>19:&nbsp;&nbsp;<input type="text" id="Q19" style="width:100px;height:20px"  /></td>
              <td width=300px>20:&nbsp;&nbsp;<input type="text" id="Q20" style="width:100px;height:20px"  /></td>
               <td width=300px>21:&nbsp;&nbsp;<input type="text" id="Q21" style="width:100px;height:20px"  /></td>
         </tr>    
          <tr style="height:30px ">
             <td width=300px>22:&nbsp;&nbsp;<input type="text" id="Q22" style="width:100px;height:20px"  /></td>
              <td width=300px></td>
               <td width=300px></td>
         </tr>
       
         
        
    </table>
    <div>&nbsp;23:</div>
    <div style="height:100px ;width:700px">
            <textarea id="Q23" cols="20" name="S1" rows="2" style="height:90px ;width:600px"  onKeyDown="textdown(event)" onKeyUp="textup()"></textarea>    
            </div>
</div>
<div>

    <table>

        <tr>
           <td> <input id="datainput" style="display:none"  runat="server" onClick="save" /><div style="width:700px">
               
               </div></td>

             <td> <input id ="input" type="button" value="save" onClick="getdata()"> 
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" style="display:none"/></td>
        </tr>
  </table>

</div>
</div>
<div id="copyright">
Copyright © 2013 - All Rights Reserved Air Macau Company IT Division
</div>
</div>

    </form>
</body>
</html>
