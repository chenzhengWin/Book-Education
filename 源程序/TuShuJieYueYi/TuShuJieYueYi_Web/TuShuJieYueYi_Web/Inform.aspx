<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inform.aspx.cs" Inherits="TuShuJieYueYi_Web.Inform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
<title>通知公告</title>
<link href="css/bootstrap.min.css" type="text/css" rel="stylesheet">
<link href="css/page.css" type="text/css" rel="stylesheet">
<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
  <script src="http://cdn.bootcss.com/html5shiv/3.7.2/html5shiv.min.js"></script>
  <script src="http://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
    <style>
        .btn{
            background-image:url()
        }
    </style>
</head>

<body>
<header>
	<div class="container index-header">
    	<div class="row">
        	<div class="col-xs-12 col-md-9">
            <div class="logo">
                <img src="img/logo01.png" width="73" height="73" class="pull-left">
                <div>
                    <h1>洛阳师范学院<small>图书馆入馆教育互动平台</small></h1>
                    <p>Luoyang Normal University Library Entry Education Interactive Platform</p>
                </div>
                <div class="clearfix"></div>
            </div>
            </div>
            <div class="col-xs-0 col-md-3">
            <p class="index-badge">
                <a href="#"><span class="badge"><img src="img/icon01.png" width="12" height="16"></span>修改密码</a>
            </p>
            </div>
        </div>
    	
    </div>
    <div class="index-navbar">
        <nav class="navbar navbar-inverse" role="navigation">
          <ul class="nav navbar-nav" id="nav1" runat="server">
           <%--<li class="active"><a href="Index.aspx">首页</a></li>
            <li><a href="Inform.aspx">资讯中心</a></li>
            <li><a href="Enter_Exam.aspx">入馆教育</a></li>
            <li><a href="Labrary_introduce.aspx">图书馆简介</a></li>--%>
          </ul>
        </nav>
     </div>   
    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
      <!-- Indicators -->
      <ol class="carousel-indicators">
        <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
        <li data-target="#carousel-example-generic" data-slide-to="1"></li>
        <li data-target="#carousel-example-generic" data-slide-to="2"></li>
      </ol>    
      <!-- Wrapper for slides -->
      <div class="carousel-inner" role="listbox">
        <div class="item active">
          <img src="img/banner01.jpg">          
        </div>
        <div class="item">
         <img src="img/banner01.jpg">
        </div>
        <div class="item">
         <img src="img/banner01.jpg">
        </div>
      </div>    
      <!-- Controls -->
      <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left"></span>
        <span class="sr-only"></span>
      </a>
      <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right"></span>
        <span class="sr-only"></span>
      </a>
    </div>
</header>
<div class="bg02">
	<div class="container">
    	<div class="row new-book">
        	<div class="col-xs-12">
            	<div class="book">
                    <form runat="server">
                	<h2>
                    <div class="input-group search-btn">
                      <input type="text" name="tt"  class="form-control" placeholder="搜索"/>
                      <span class="input-group-btn">
                        <button class="btn btn-default" type="sumbit"><img src="img/icon14.png" ></button></span>
                        
                    </div> 
                    
                    通知公告<small>/Notice</small></h2></form>
                    <ul id="inform" runat="server" class="list-unstyled list-43">
                    	<%--<li><span class="time">2014-05-16</span><a href="#">欢迎向世界图书出版公司荐购影印版权</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">2005年寒假学生借书规则调整通知 </a></li>
                        <li><span class="time">2014-05-16</span><a href="#">图书馆新主页试用</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">第二届余志明《文渊阁四库全书电子版》学术成果奖征集参选论著和论文的通知</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">本馆加入北京市北三环－学院路地区高校图书馆联合体</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">读者满意度调查结果发布</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">人文分馆面向全校开放服务</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">图书馆启用“密码”（PIN）的说明 </a></li>
                        <li><span class="time">2014-05-16</span><a href="#">关于填报教学参考书的通知</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">登记E-mail地址，接收流通通知 (研究生请特别注意)</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">图书馆启用“密码”（PIN）的说明 </a></li>
                        <li><span class="time">2014-05-16</span><a href="#">关于填报教学参考书的通知</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">登记E-mail地址，接收流通通知 (研究生请特别注意)</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">关于填报教学参考书的通知</a></li>
                        <li><span class="time">2014-05-16</span><a href="#">登记E-mail地址，接收流通通知 (研究生请特别注意)</a></li>--%>
                    </ul>
                   <%-- <div class="text-center"> 
                       <div class="pagingbar">
                            <cite class="bora"><a>首 页</a><span>上一页</span><a class="selected">1</a><a>2</a><a>3</a><a>4</a><span>下一页</span><a>尾
                                页</a></cite>                            
                        </div>
                    </div>--%>

                      
                    
                </div>
            </div>
        </div>
    </div>
</div>
<footer>
	<div class="footer">
    	<div class="container">
    	<ul class="nav pull-left" id="nav2" runat="server">         
        	<%--<li><a href="Index.aspx">首页</a>|</li>
            <li><a href="Inform.aspx">资讯中心</a>|</li>
            <li><a href="Enter_Exam.aspx">入馆教育</a>|</li>
            <li><a href="Labrary_introduce.aspx">图书馆简介</a></li>--%>
        </ul> 
        <div class="pull-right footer-link">
        	<a href="#"><img src="img/icon11.png" width="34" height="34"></a>
            <a href="#"><img src="img/icon12.png" width="34" height="34"></a>
            <a href="#"><img src="img/icon13.png" width="34" height="34"></a>
        </div>
        </div>
    </div>
</footer>
<script src="js/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</body>
</html>
