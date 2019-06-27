<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <title>信息管理系统界面</title>
</head>
<frameset rows="125,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset cols="206,*" frameborder="no" border="0" framespacing="0">
    <frame src="left.aspx" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame" title="leftFrame" />
    <frame src="Nav/NavList.aspx" name="rightFrame"  id="rightFrame" title="rightFrame" />
  </frameset>
</frameset>

<noframes>
    <body>
    </body>
</noframes>
   
</html>
   
 
