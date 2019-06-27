<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Infrom_introduce.aspx.cs" Inherits="TuShuJieYueYi_Web.Infrom_introduce" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>通知详情</title>
<link href="css/bootstrap.min.css" type="text/css" rel="stylesheet">
<link href="css/page.css" type="text/css" rel="stylesheet">
<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
  <script src="http://cdn.bootcss.com/html5shiv/3.7.2/html5shiv.min.js"></script>
  <script src="http://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
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
    <div class="container index-navbar">
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
          <img src="img/banner01.jpg"/>          
        </div>
        <div class="item">
         <img src="img/banner01.jpg"/>
        </div>
        <div class="item">
         <img src="img/banner01.jpg"/>
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
    	<div class="page-header">
        	<%--<img src="img/icon15.png"/>--%>
            <h2><%=Title %></h2>
        </div>
        <div class="library-post">
        	<%--<div class="text-center">
        	<img src="img/tmp/img05.jpg"/>
            </div>--%>
            <p id="tt" runat="server"></p>
			<%--<h5>历史沿革</h5>
            <p>西安邮电大学图书馆始建于1955年，1996年雁塔校区图书馆建成使用，2004年长安校区图书馆正式启用。
                目前，我校共有长安校区和雁塔校区两个图书馆，全馆各类工作人员共计60人。长安校区图书馆面积23441㎡，
                雁塔校区图书馆面积4986㎡。目前馆藏纸质图书160万余册，中外文电子图书数量为35万余册，中外文期刊千余种，
                中外文文献资源数据库30余种，并建有现代化的多媒体电子阅览室，拥有完善的网络环境，可为广大师生教学科研和学习提供良好的文献保障和优质的服务。</p>
            <h5>文献建设</h5>
            <p>在文献建设上，我馆坚持以学校学科建设为龙头，以服务教学科研为目的，以信息科学技术为特色。
                经过多年建设，我馆现已形成了具有鲜明信息科学技术特色的馆藏体系，目前馆藏纸质图书146万余册，涵盖了通信、信息、计算机、经济、
                管理、社会科学、文学、艺术、政治等相关学科，较好地满足了教学科研的需要。在搞好纸质文献建设的同时，我馆注重加强数字资源建设，
                现有馆藏中外文电子图书19万余册。通过联采、自购、自建等方式，建立了30余种中外文文献资源数据库，如中国期刊全文数据库、
                中国优秀博硕士学位论文全文数据库、清华同方中国重要会议论文全文数据库、清华同方中国重要报纸全文数据库、超星数字图书馆、
                北大方正Apabi数字图书系统、万方数据资源系统、道琼斯全球资讯教育平台、智联起点考试网、北京国道标准专题库、
                IEEE/IET Electronic Library(IEL)数据库、北京国道外文专题数据库、德国施普林格（SpringerLink）数据库、中宏经济数据库、国研网数据库、库客数字音乐图书馆、
                ACM（Association for Computing Machinery）数据库以及西安邮电大学本科毕业生优秀论文数据库、西安邮电大学教工论文数据库、西安邮电大学研究生毕业论文数据库等自建数据库。所有数据库全年24小时不停机开放，任何使用我院IP地址的终端用户都可以上网免费检索、使用全部数据库，极大地满足了广大师生教学和科研的需要，使馆藏文献资源建设跃上一个新的台阶。</p>
            <h5>自动化建设</h5>
            <p>在文献建设上，我馆坚持以学校学科建设为龙头，以服务教学科研为目的，以信息科学技术为特色。经过多年建设，我馆现已形成了具有鲜明信息科学技术特色的馆藏体系，目前馆藏纸质图书146万余册，涵盖了通信、信息、计算机、经济、管理、社会科学、文学、艺术、政治等相关学科，较好地满足了教学科研的需要。在搞好纸质文献建设的同时，我馆注重加强数字资源建设，现有馆藏中外文电子图书19万余册。通过联采、自购、自建等方式，建立了30余种中外文文献资源数据库，如中国期刊全文数据库、中国优秀博硕士学位论文全文数据库、清华同方中国重要会议论文全文数据库、清华同方中国重要报纸全文数据库、超星数字图书馆、北大方正Apabi数字图书系统、万方数据资源系统、道琼斯全球资讯教育平台、智联起点考试网、北京国道标准专题库、IEEE/IET Electronic Library(IEL)数据库、北京国道外文专题数据库、德国施普林格（SpringerLink）数据库、中宏经济数据库、国研网数据库、库客数字音乐图书馆、ACM（Association for Computing Machinery）数据库以及西安邮电大学本科毕业生优秀论文数据库、西安邮电大学教工论文数据库、西安邮电大学研究生毕业论文数据库等自建数据库。所有数据库全年24小时不停机开放，任何使用我院IP地址的终端用户都可以上网免费检索、使用全部数据库，极大地满足了广大师生教学和科研的需要，使馆藏文献资源建设跃上一个新的台阶。</p>--%>
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
        	<a href="#"><img src="img/icon11.png" width="34" height="34"/></a>
            <a href="#"><img src="img/icon12.png" width="34" height="34"/></a>
            <a href="#"><img src="img/icon13.png" width="34" height="34"/></a>
        </div>
        </div>
    </div>
</footer>
<script src="js/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</body>
</html>

