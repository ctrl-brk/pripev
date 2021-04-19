<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="YandexMusic.aspx.cs" Inherits="Pripev.Web.UI.News.YandexMusic" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
   <meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
<style>
body {margin:0; padding:0; background-color:white; font:normal 11px Tahoma,Verdana,Helvetica,sans-serif; scrollbar-base-color:#FDF6D1;}
table {font:normal 11px Tahoma,Verdana,Helvetica,sans-serif;}
a {color:black;}
</style>
</head>

<script src='http://news.yandex.ru/common.js'></script>
<script>m_index = false;</script>
<script src='http://news.yandex.ru/music3.js' charset='windows-1251'></script>

<body>

<table border='0' cellspacing='0' cellpadding='2' width='100%'>

<script language="JavaScript">

var str = "";

if ( ( aObj = eval( 'm_music' ) ) && ( aObj.length > 0 ) )
   { 
   aObj.sort( compareTime );
   for ( j=0; j<aObj.length; j++ )
      { 
      str += '<tr><td colspan="2"><b><a href=' + aObj[j].url + '>' + aObj[j].title + '</a></b></td></tr>' +
             '<tr><td colspan="2"><div style="margin-bottom:3px">' + aObj[j].descr + '</div></td></tr>';
      }
   } 
str += '<tr><td><i><a href="http://news.yandex.ru" target="_blank">Все новости на '+ update_time + ' мск &gt;&gt;</a></i></td><td align="right"><a href="http://news.yandex.ru" target="_blank">Яндекс.Новости</b></td></tr>';
document.write( str );

</script>

</table>

</body>
</html>
