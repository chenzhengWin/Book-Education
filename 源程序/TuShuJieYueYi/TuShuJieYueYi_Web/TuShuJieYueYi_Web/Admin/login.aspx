<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/login.css">
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script src="js/kindeditor/kindeditor-min.js"></script>
    <script src="js/kindeditor/lang/zh_CN.js"></script>
    <script src="js/kindeditor/plugins/code/prettify.js"></script>


	<title>后台登陆</title>
</head>
<body>
	<div id="login_top">
		<div id="welcome">
			欢迎使用图书管理系统
		</div>
		<div id="back">
			<a href="#">返回首页</a>&nbsp;&nbsp; | &nbsp;&nbsp;
			<a href="#">帮助</a>
		</div>
	</div>
	<div id="login_center">
		<div id="login_area">
			<div id="login_form">
                <form id="form1" runat="server">
					<div id="login_tip">
						用户登录&nbsp;&nbsp;UserLogin
					</div>
					<div><input type="text" class="username" id="UserName" runat="server" /></div>
					<div><input type="password" class="pwd" id="Pwd" runat="server"  /></div>
					<div id="btn_area">
						<input type="button"  id="sub_btn" value="登&nbsp;&nbsp;录" runat="server" onserverclick="sub_btn_ServerClick" />&nbsp;&nbsp;
						<%--<input type="text" class="verify" />--%>
						<%--<img src="images/login/verify.png" alt="" width="80" height="40" />--%>
					</div>
				</form>
			</div>
		</div>
	</div>
	<div id="login_bottom">
		版权所有
	</div>
</body>
</html>