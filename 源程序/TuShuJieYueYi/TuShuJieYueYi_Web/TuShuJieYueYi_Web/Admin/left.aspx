<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>信息管理系统界面</title>
    <link rel="stylesheet" href="css/common.css"/>
    <link rel="stylesheet" href="css/style.css"/>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.SuperSlide.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".sideMenu").slide({
                titCell: "h3",
                targetCell: "ul",
                defaultIndex: 0,
                effect: 'slideDown',
                delayTime: '500',
                trigger: 'click',
                triggerTime: '150',
                defaultPlay: true,
                returnDefault: false,
                easing: 'easeInQuint',
                endFun: function () {
                    scrollWW();
                }
            });
            $(window).resize(function () {
                scrollWW();
            });
        });
        function scrollWW() {
            if ($(".side").height() < $(".sideMenu").height()) {
                $(".scroll").show();
                var pos = $(".sideMenu ul:visible").position().top - 38;
                $('.sideMenu').animate({ top: -pos });
            } else {
                $(".scroll").hide();
                $('.sideMenu').animate({ top: 0 });
                n = 1;
            }
        }

        var n = 1;
        function menuScroll(num) {
            var Scroll = $('.sideMenu');
            var ScrollP = $('.sideMenu').position();
            /*alert(n);
            alert(ScrollP.top);*/
            if (num == 1) {
                Scroll.animate({ top: ScrollP.top - 38 });
                n = n + 1;
            } else {
                if (ScrollP.top > -38 && ScrollP.top != 0) { ScrollP.top = -38; }
                if (ScrollP.top < 0) {
                    Scroll.animate({ top: 38 + ScrollP.top });
                } else {
                    n = 1;
                }
                if (n > 1) {
                    n = n - 1;
                }
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("ul li").click(function () {
                $(this).addClass("on").siblings().removeClass("on");
            })
        })

    </script>
    <style>
        .sideMenu ul li a {
            color: black;
        }

            .sideMenu ul li a:hover {
                color: black;
                font-weight: 700;
            }
    </style>
</head>

<body>
    <div class="side">
        <div class="sideMenu" style="margin: 0 auto">
            <h3>导航栏管理</h3>
            <ul>
                <li class="on"><a href="Nav/NavList.aspx" target="rightFrame">导航列表</a></li>
                <li><a href="Nav/NavAdd.aspx" target="rightFrame">导航添加</a></li>
                <%--<li><a href="Nav/NavEdit.aspx" target="rightFrame">导航修改</a></li>--%>
                <%--<li class="on"></li>--%>
            </ul>
            <h3>图标菜单管理</h3>
            <ul>
                <li class=""><a href="Enter/EnterList.aspx" target="rightFrame">图标列表</a></li>
                <li><a href="Enter/EnterAdd.aspx" target="rightFrame">图标添加</a></li>
               <%-- <li><a href="Enter/EnterEdit.aspx" target="rightFrame">图标修改</a></li>--%>
                <%--<li class="on"></li>--%>
            </ul>

            <h3>图书管理</h3>
            <ul>
                <li class=""><a href="Books/bookList.aspx" target="rightFrame">图书列表</a></li>
                <li><a href="Books/bookAdd.aspx" target="rightFrame">图书添加</a></li>
                <%--<li class="on"></li>--%>
            </ul>

            <h3>通知管理</h3>
            <ul>
                <li class=""><a href="Inform/InformList.aspx" target="rightFrame">通知列表</a></li>
                <li><a href="Inform/InformAdd.aspx" target="rightFrame">通知添加</a></li>
              <%--  <li><a href="Inform/InformEdit.aspx" target="rightFrame">通知修改</a></li>--%>
                <%--<li class="on"></li>--%>
            </ul>

            <h3>管理员信息管理</h3>
            <ul>
                <li class=""><a href="Users/userList.aspx" target="rightFrame">管理员信息列表</a></li>
                <li><a href="Users/userAdd.aspx" target="rightFrame">管理员信息添加</a></li>
                
                <%--<li class="on"></li>--%>
            </ul>
        </div>
    </div>
</body>
</html>

