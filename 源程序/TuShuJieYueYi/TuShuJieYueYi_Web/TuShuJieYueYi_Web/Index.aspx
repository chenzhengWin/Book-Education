<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TuShuJieYueYi_Web.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <title>首页</title>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/page.css" rel="stylesheet" />

    <script src="Admin/js/jquery.min.js"></script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="http://cdn.bootcss.com/html5shiv/3.7.2/html5shiv.min.js"></script>
  <script src="http://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script
        a
<![endif]-->


    <script>
        $(function () {
            // LoadNav();
            LoadBook();
         


        })

        function LoadNav() {

            $.getJSON("Loading.ashx", { action: 1 }, function (data) {

               
                $.each(data, function (index, item) {

                    $("#nav").append("<li class='active'><a href='#'>" + item.Name + "</a></li>");
                })
               // LoadEnter();
              

            })
        }
        function LoadEnter() {

            $.getJSON("Loading.ashx", { action: 2 }, function (data) {
                


                $.each(data, function (index,item) {
                  
                    if(index==2)
                    {
                        $("#row").append("<div class='col-md-4'><div class='modal-content clearfix'><span class='icon icon0" + (index + 1) + "'></span><h3><a href='Enter_Exam.aspx'>" + item.Cname + "</a><small>" + item.Ename + "</small></h3> <p>" + item.News + "</p> </div></div>");
                        return;

                    }
                    $("#row").append("<div class='col-md-4'><div class='modal-content clearfix'><span class='icon icon0" + (index + 1) + "'></span><h3><a href='Labrary_introduce.aspx'>" + item.Cname + "</a><small>" + item.Ename + "</small></h3> <p>" + item.News + "</p> </div></div>");
                })
                //LoadEnter2();


            })
        }

        function LoadEnter2() {

            $.getJSON("Loading.ashx", { action: 3 }, function (data) {
                var i = 8;
                $.each(data, function (index, item) {
                    var j ="0"+i.toString();
                    if (i == 10)
                    {
                        j = i.toString();
                    }
                   
                    $("#enter2").append("<div class='col-xs-12 col-md-4 clearfix'> <a href='#' class='img-circle text-center'><img src='img/icon"+j+".png' width='37' height='62'></a><h3><a href='#'>" + item.Cname + "<small>" + item.Ename + "</small></a>  </h3><p>" + item.News + "</p> <a href='#' class='btn btn-more'>MORE</a></div>");
                    i++;
                })
                //LoadBook();
            })
        }
        function LoadBook() {

            $.getJSON("Loading.ashx", { action: 4}, function (data) {
                $.each(data, function (index, item) {
                    if (index == 0)
                    {
                        $("#book").append("<div class='row book-info'><div class='col-xs-5 col-md-3 text-left'> <a href='#'><img src='img/tmp/img02.jpg'></a></div><div class='col-xs-7 col-md-9 text-left'><h3> <a href='Book_Introduce.aspx?id=" + item.Id + "'>" + item.Bookname + "</a></h3><ul class='list-unstyled'> <li>作者：" + item.Author + " </li><li>出版社：" + item.Publishing_hose + "</li><li>出版年：" + item.YearString + " </li> <li>定价:" + item.Price + "</li>  <li>装帧：" + item.Decorate + "</li>  <li>ISBN：" + item.Number + "</li> </ul> <p>" + item.Book_introduce + "</p> </div> </div>");
                    }
                    else if(index==1)
                    {
                        $("#book").append("<div class='row book-info'><div class='col-xs-5 col-md-3 text-left'> <a href='#'><img src='img/tmp/img01.jpg'></a></div><div class='col-xs-7 col-md-9 text-left'><h3> <a href='Book_Introduce.aspx?id=" + item.Id + "'>" + item.Bookname + "</a></h3><ul class='list-unstyled'> <li>作者：" + item.Author + " </li><li>出版社：" + item.Publishing_hose + "</li><li>出版年：" + item.YearString + " </li> <li>定价:" + item.Price + "</li>  <li>装帧：" + item.Decorate + "</li>  <li>ISBN：" + item.Number + "</li> </ul> <p>" + item.Book_introduce + "</p> </div> </div>");

                    }
                  
                })
               // LoadNotice();
               
            })
        }
    

        function LoadNotice() {

            $.getJSON("Loading.ashx", { action: 5 }, function (data) {
                $.each(data, function (index, item) {
                    $("#notice").append("<li><a href='Inform.aspx'>" + item.Title + "</a></li>");

                })

            })
        }



    </script>

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
    <div class="bg">
        <div class="container">
           <div class="row" id="enter1" runat="server">
                <%--<div class="col-md-4">
                    <div class="modal-content clearfix" onclick="javascript: window.location.href = 'Labrary_introduce.aspx'">
                        <span class="icon icon01"></span>
                        <h3>
                            图书馆简介<small>Library Industion</small></h3>
                        <p>
                            二十世纪80年代中期，我馆成为世界银行指定收藏馆；90年代中期，图书馆与会计学院合作成立会计资料研究中心；90年代</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="modal-content clearfix">
                        <span class="icon icon02"></span>
                        <h3>
                            入馆教育<small>Library Guide Education</small></h3>
                        <p>
                            大家都知道书的种类繁多，如文学、艺术、教育、科技、历史、地理，那么书到底有多少种呢？现在中国图书馆内所有的</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="modal-content clearfix" onclick="javascript: window.location.href = 'Enter_Exam.aspx'">
                        <span class="icon icon03"></span>
                        <h3>
                            入馆教育考试<small>Library Education Exam</small></h3>
                        <p>
                            大家都知道书的种类繁多，如文学、艺术、教育、科技、历史、地理，那么书到底有多少种呢？现在中国图书馆内所有的</p>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
    <div class="bg02">
        <div class="container">
            <div class="row new-book">
                <div class="col-xs-12 col-md-8">
                    <div class="book">
                        <h2>
                            <a href="#" class="btn btn-more pull-right">MORE</a><a href="Newbook_List.aspx">新书速递</a><small>/New Express</small></h2>
                        <div id="book">
                       <%-- <div class="row book-info">
                            <div class="col-xs-5 col-md-3 text-left">
                                <a href="#">
                                    <img src="img/tmp/img01.jpg"></a>
                            </div>
                            <div class="col-xs-7 col-md-9 text-left">
                                <h3>
                                    <a href="#">我讲个故事，你可别当真啊</a></h3>
                                <ul class="list-unstyled">
                                    <li>作者：囧叔 </li>
                                    <li>出版社：湖南文艺出版社</li>
                                    <li>出版年：2014-6 </li>
                                    <li>定价：32.80元</li>
                                    <li>装帧：平装</li>
                                    <li>ISBN：9787540467081</li>
                                </ul>
                                <p>
                                    也许你只是一只产品狗、程序猿、攻城狮，或者是实习生、 失婚妇女、 城乡结合部汽车修理工，但这并不妨碍你做一个侠客。也许你只有一技之长——买彩票、养狗、</p>
                            </div>
                        </div>
                        <div class="row book-info">
                            <div class="col-xs-5 col-md-3 text-left">
                                <a href="#">
                                    <img src="img/tmp/img02.jpg"></a>
                            </div>
                            <div class="col-xs-7 col-md-9 text-left">
                                <h3>
                                    <a href="#">时蔬小话</a></h3>
                                <ul class="list-unstyled">
                                    <li>作者：囧叔 </li>
                                    <li>出版社：湖南文艺出版社</li>
                                    <li>出版年：2014-6 </li>
                                    <li>定价：32.80元</li>
                                    <li>装帧：平装</li>
                                    <li>ISBN：9787540467081</li>
                                </ul>
                                <p>
                                    也许你只是一只产品狗、程序猿、攻城狮，或者是实习生、 失婚妇女、 城乡结合部汽车修理工，但这并不妨碍你做一个侠客。也许你只有一技之长——买彩票、养狗、</p>
                            </div>
                        </div>--%>

                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-4">
                    <div class="book">
                         <h2>
                            <a href="Inform.aspx" class="btn btn-more pull-right">MORE</a>通知公告<small>/Notice</small></h2>
                        <ul id="inform" runat="server" class="list-unstyled list-28">
                           <%-- <li><a href="#">欢迎向世界图书出版公司荐购影印版权</a></li>
                            <li><a href="#">2005年寒假学生借书规则调整通知 </a></li>
                            <li><a href="#">图书馆新主页试用</a></li>
                            <li><a href="#">第二届余志明《文渊阁四库全书电子版》学术成果奖征集参选论著和论文的通知</a></li>
                            <li><a href="#">本馆加入北京市北三环－学院路地区高校图书馆联合体</a></li>
                            <li><a href="#">读者满意度调查结果发布</a></li>
                            <li><a href="#">人文分馆面向全校开放服务</a></li>
                            <li><a href="#">图书馆启用“密码”（PIN）的说明 </a></li>
                            <li><a href="#">关于填报教学参考书的通知</a></li>
                            <li><a href="#">登记E-mail地址，接收流通通知 (研究生请特别注意)</a></li>--%>
                        </ul>
                    </div>
                </div>
            </div>
             <div class="row bg03 question text-center" id="enter2" runat="server">
                <%--<div class="col-xs-12 col-md-4 clearfix">
                    <a href="#" class="img-circle text-center">
                        <img src="img/icon08.png" width="37" height="62"></a>
                    <h3>
                        <a href="#">问题反馈<small>Question Feedback</small></a></h3>
                    <p>
                        欢迎大家来到问题反馈版区、使用过程中遇到的任何问题都可以在这里反馈！<br>
                        我们会悉心聆听、沟通交流，解决问题，一起敦促其不断优化，从而更好的服务网民！</p>
                    <a href="#" class="btn btn-more">MORE</a>
                </div>
                <div class="col-xs-12 col-md-4 clearfix">
                    <a href="#" class="img-circle text-center">
                        <img src="img/icon09.png" width="56" height="62"></a>
                    <h3>
                        <a href="#">图书漂流<small>Bookcrossing</small></a></h3>
                    <p>
                        欢迎大家来到问题反馈版区、使用过程中遇到的任何问题都可以在这里反馈！<br>
                        我们会悉心聆听、沟通交流，解决问题，一起敦促其不断优化，从而更好的服务网民！</p>
                    <a href="#" class="btn btn-more">MORE</a>
                </div>
                <div class="col-xs-12 col-md-4 clearfix" style="border-bottom: 0;">
                    <a href="#" class="img-circle text-center">
                        <img src="img/icon10.png" width="48" height="51"></a>
                    <h3>
                        <a href="#">图书评论<small>Book Notes</small></a></h3>
                    <p>
                        欢迎大家来到问题反馈版区、使用过程中遇到的任何问题都可以在这里反馈！<br>
                        我们会悉心聆听、沟通交流，解决问题，一起敦促其不断优化，从而更好的服务网民！</p>
                    <a href="#" class="btn btn-more">MORE</a>
                </div>--%>
                <div class="clearfix">
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
