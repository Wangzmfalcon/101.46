﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="WebUserControl" %>
<style type="text/css"> 
.titleStyle{ 
background-color:#008800;color:#ffffff;border-top:1px solid #FFFFFF;font-size:9pt;cursor:hand; 
} 
.contentStyle{ 
background-color:#eeffee;color:blue;font-size:9pt; 
} 

a{ 
color:blue; 
} 

</style> 
<div>
<script language="JavaScript"> 
<!--
    var layerTop = 20; //菜单顶边距 
    var layerLeft = 30; //菜单左边距 
    var layerWidth = 140; //菜单总宽 
    var titleHeight = 20; //标题栏高度 
    var contentHeight = 200; //内容区高度 
    var stepNo = 10; //移动步数，数值越大移动越慢 

    var itemNo = 0; runtimes = 0;
    document.write('<span id=itemsLayer style="position:absolute;overflow:hidden;border:1px solid #008800;left:' + layerLeft + ';top:' + layerTop + ';width:' + layerWidth + ';">');

    function addItem(itemTitle, itemContent) {
        itemHTML = '<div id=item' + itemNo + ' itemIndex=' + itemNo + ' style="position:relative;left:0;top:' + (-contentHeight * itemNo) + ';width:' + layerWidth + ';"><table width=100% cellspacing="0" cellpadding="0">' +
'<tr><td height=' + titleHeight + ' onclick=changeItem(' + itemNo + ') class="titleStyle" align=center>' + itemTitle + '</td></tr>' +
'<tr><td height=' + contentHeight + ' class="contentStyle">' + itemContent + '</td></tr></table></div>';
        document.write(itemHTML);
        itemNo++;
    }
    //添加菜单标题和内容，可任意多项，注意格式： 
    addItem('欢迎', '<BR>　　欢迎光临设计在线！');
    addItem('网页陶吧', '<center><a href="#">网页工具</a> <BR><BR><a href="#">技术平台</a> <BR><BR><a href="#">设计理念</a> <BR><BR><a href="#">更多</a></center>');
    addItem('美工教室', '<center><a href="#">平面设计 </a> <BR><BR><a href="#">三维空间</a> <BR><BR><a href="#">设计基础</a> <BR><BR><a href="#">更多..</a></center>');
    addItem('Flash', '<center><a href="#">基础教程</a> <BR><BR><a href="#">技巧运用</a> <BR><BR><a href="#">实例剖析</a> <BR><BR><a href="#">更多..</a></center>');
    addItem('多媒体', '<center><a href="#">DIRECTOR</a> <BR><BR><a href="#">Authorware</a> <BR><BR><a href="#">更多..</a></center>');
    addItem('精品赏析', '<center><a href="#">设计精品</a></center>');

    document.write('</span>')
    document.all.itemsLayer.style.height = itemNo * titleHeight + contentHeight;

    toItemIndex = itemNo - 1; onItemIndex = itemNo - 1;

    function changeItem(clickItemIndex) {
        toItemIndex = clickItemIndex;
        if (toItemIndex - onItemIndex > 0) moveUp(); else moveDown();
        runtimes++;
        if (runtimes >= stepNo) {
            onItemIndex = toItemIndex;
            runtimes = 0;
        }
        else
            setTimeout("changeItem(toItemIndex)", 10);
    }

    function moveUp() {
        for (i = onItemIndex + 1; i <= toItemIndex; i++)
            eval('document.all.item' + i + '.style.top=parseInt(document.all.item' + i + '.style.top)-contentHeight/stepNo;');
    }

    function moveDown() {
        for (i = onItemIndex; i > toItemIndex; i--)
            eval('document.all.item' + i + '.style.top=parseInt(document.all.item' + i + '.style.top)+contentHeight/stepNo;');
    }
    changeItem(0); 
//--> 
</script> 
</div>