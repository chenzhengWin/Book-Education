<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="bookAdd.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Books.bookAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加图书信息</title>
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/main.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/colResizable-1.3.min.js"></script>
    <script type="text/javascript" src="../js/common.js"></script>
    <%--引入上传图片所需的js--%>
    <script src="../js/jquery.form.js"></script>
    <%--文本编辑器--%>
    <script src="../js/kindeditor/kindeditor-min.js"></script>
    <script src="../js/kindeditor/lang/zh_CN.js"></script>
    <script src="../js/kindeditor/plugins/code/prettify.js"></script>
   <%-- <script>
        //光标离开时，验证书号是否重复
        function isBookNumber() {
            var BookNumber = $("#txtISBN").val();
            if (BookNumber != null) {
                //将名称通过post请求
                //1.url:请求的地址
                //2.para{}:进行传递的参数
                //3.function(data):获取返回得到的结果，判断是否重复
                var url = "";
                var para = {};
                para.action = "isbookNumber";//传递action用来去一般处理程序中进行验证
                para.BookNumber = name;//传递信息去一般处理程序中进行xx是否重复的验证
                $.post(url, para, function (data) {
                    //返回结果进行判断
                    //data:是从handlder中获取的数据对象
                    if (data.Success) {
                        alert(data.Message);
                    }
                    else {
                        alert(data.Message);
                    }
                }, "json")
            }
            else {
                alert("请输入用户名");
            }
        }
    </script>--%>
    <script>
        function imgUpload() {
            var img = $("#file_Image").val();//获取file控件的值
            //判断选择的图片是否为空
            if ($.trim(img) == "") {
                alert("请你选择图片");
                return;
            }
            $("#form1").ajaxSubmit({
                type: "post",//提交方式
                dataType: "json",//返回结果的格式是json字符串格式
                url: "../Hander/imgUploadHandler.ashx",//提交地址
                data: { "action": "UploadImage" },//请求的参数,参数名
                success: function (data) {//请求成功进行信息查询
                    if (data.Success) {
                        $("#img1").attr("src", data.ImgUrl);
                        $("#imgsrc").val(data.ImgUrl);
                    }
                }
            })
        }
    </script>
    <%--文本编辑器--%>
    <script type="text/javascript">
        var editor1 = null;
        KindEditor.ready(function (K) {
            editor1 = K.create('#txtCatalog', {
                cssPath: '../js/kindeditor/plugins/code/prettify.css',
                uploadJson: '../js/kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '../js/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    this.sync();
                },
                afterBlur: function () {
                    this.sync();
                }
            });
            prettyPrint();
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $(".list_table").colResizable({
                liveDrag: true,
                gripInnerHtml: "<div class='grip'></div>",
                draggingClass: "dragging",
                minWidth: 30
            });
        });
    </script>
    <script type="text/javascript">

        //获取URL传递的参数信息 
        $.getUrlParam = function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            if (r != null) return unescape(r[2]); return null; //返回参数值
        }

        $(function () {
            $(".require").each(function () {
                $(this).append("<strong class='high'>*</strong>");
            })
           
            $("form :input").blur(function () {
                $(this).parent().find(".mm").remove();
                //验证书名
                if ($(this).is("#txtBookName")) {
                    var value = $.trim(this.value);
                    if (value == "") {
                        var errorMsg = "书名不能为空.";
                        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                    }
                }
                else {
                    $.getJSON("../Hander/Vaildate.ashx", { action: 1, name: $("#txtBookName").val() }, function (data) {
                        if (data.Success) {//根据一般处理过程返回的值判断是否成功
                            $("#txtBookName").parent().append("<span class='mm onError'>" + data.OkMsg + "</span>");
                        } else {
                            
                            $(this).parent().append("<span class='mm onSuccess'>" + data.OkMsg + "</span>");
                        }
                        
                    })

                }
                //验证作者
                if ($(this).is("#txtAuthor")) {
                    var value = $.trim(this.value);
                    if (value == "") {
                        var errorMsg = "作者名不能为空.";
                        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                    }
                }

                //验证出版社
                if ($(this).is("#txtPublish")) {
                    var value = $.trim(this.value);
                    if (value == "") {
                        var errorMsg = "出版社不能为空.";
                        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                    }
                }
                //验证单价
                if ($(this).is("#txtPrice")) {
                    var value = $.trim(this.value);
                    if (value == "") {
                        var errorMsg = "价格不能为空,请输入单价.";
                        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                    }
                }
               

                ////验证图书编号
                //if ($(this).is("#txtISBN")) {
                //    var value = $.trim(this.value);
                //    if (value == "") {
                //        var errorMsg = "图书编号不能为空";
                //        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                //    }
                //}
                //else
                //{
                //    $.getJSON("../Hander/Vaildate.ashx", { action: 2, num: $("#txtISBN").val() }, function (data) {
                //        if (data.Success) {//根据一般处理过程返回的值判断是否成功
                //            $("#txtISBN").parent().append("<span class='mm onError'>" + data.OkMsg + "</span>");
                //        } else {

                //            $(this).parent().append("<span class='mm onSuccess'>" + data.OkMsg + "</span>");
                //        }

                //    })
                    
                //}

            }).keyup(function () {
                $(this).triggerHandler("blur");


            }).focus(function () {
                $(this).triggerHandler("blur");
            });
        });
    </script>

  <%--  <script>

        $(function () {

            $("#txtISBN").blur(function () {

                //验证图书编号
                if ($(this).is("#txtISBN")) {
                    var value = $.trim(this.value);
                    if (value == "") {
                        var errorMsg = "图书编号不能为空";
                        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                    }
                }
                else
                {
                    $.getJSON("../Hander/Vaildate.ashx", { action: 2, num: $("#txtISBN").val() }, function (data) {
                        if (data.Success) {//根据一般处理过程返回的值判断是否成功
                            $("#txtISBN").parent().append("<span class='mm onError'>" + data.OkMsg + "</span>");
                        } else {

                            $(this).parent().append("<span class='mm onSuccess'>" + data.OkMsg + "</span>");
                        }

                    })

                }
            
            
            })
        })








    </script>--%>


    <style type="text/css">
        .onError {
            color:red;
            background: url(../img/reg3.gif) no-repeat 0 -2px;
            padding-left: 22px;
        }

        .onSuccess {
            background: url(../img/reg4.gif) no-repeat 0 -2px;
            padding-left: 22px;
        }

        .high {
            color: #F00;
        }
        /*#txtContent {
            float:left;
            display:block;
        }*/
        /*select {
            border: 1px solid #808080;
        }*/
    </style>
</head>
<body>
    <div id="forms" class="mt10" style="height:800px; overflow:auto;">
        <div class="box" >
            <div class="box_border">
                <div class="box_top">
                    <b class="pl15">添加图书信息</b>
                </div>
                <div class="box_center">
                    <form id="form1" runat="server" method="post">
                        <div runat="server" style="overflow: scroll; width: 100%; height: 1541px;">
                            <table class="form_table pt15 pb15" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">
                                <tr>
                                    <td class="td_right require">书名：</td>
                                    <td class="">
                                        <input type="text" maxlength="10" name="bookName" id="txtBookName" runat="server" class="input-text lh30 require1" size="40" onserverchange="txtBookName_ServerChange" />
                                        <%--<span style="color:red"><%=BookNameMsg %></span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right require" style="text-align: right">作者：</td>
                                    <td class="">
                                        <input type="text" maxlength="10" name="author" id="txtAuthor" runat="server" class="input-text lh30 require1" size="40" />
                                       <%-- <span style="color:red"><%=AutherMsg %></span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right require">出版社：</td>
                                    <td class="">
                                        <input type="text" maxlength="12" name="publish" id="txtPublish" value="" runat="server" class="input-text lh30 require1" size="40" />
                                        <%--<span style="color:red"><%=Pub_HouseMsg %></span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right require">出版年：</td>
                                    <td class="">
                                        <input type="date" name="year" id="txtYear" value="" runat="server" class="lh30 require1" />
                                       <%-- <span style="color:red"><%=Pub_YearMsg %></span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right require">定价:</td>
                                    <td class="">
                                        <input type="text" maxlength="6" name="price" id="txtPrice" value="" runat="server" class="input-text lh30 require1" size="10" />元
                                         <%--<span style="color:red"><%=PriceMsg %></span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">装帧:</td>
                                    <td>
                                        <input type="text" maxlength="10" name="decorate" id="txtDecorate" value="" runat="server" class="input-text lh30 require1" size="10" />
                                         <%--<span style="color:red"><%=DecorateMsg %></span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right require">ISBN:</td>
                                    <td>
                                        <input type="text" maxlength="20" name="isbn" id="txtISBN" value="" runat="server" class="input-text lh30 require1" size="20" />
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">作者简介:</td>
                                    <td>
                                        <textarea cols="80" rows="6" name="author_introduce" id="txtAuthor_introduce" runat="server"></textarea>
                                         <%--<span style="color:red"><%=Auther_introMsg %></span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">内容简介:</td>
                                    <td>
                                        <textarea cols="80" rows="6" name="book_introduce" id="txtBook_introduce" runat="server"></textarea>
                                         <%--<span style="color:red"><%=Book_introMsg %></span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">图书封面:</td>
                                    <td>
                                        <input type="file" name="file_Image" id="file_Image" value=" " />
                                         <%--<span style="color:red"><%=ImgMsg %></span>--%>
                                        <div style="width: 200px; height: 200px">
                                            <img src="#" style="width: 100px; height: 150px" id="img1" alt="Alternate Text" />
                                            <%--用来保存图片路径，后台赋值给实体属性--%>
                                            <br />
                                            <input type="hidden" id="imgurl" runat="server" />
                                        </div>
                                        <input type="button" id="btnImgUpload" value="上传图片" onclick="imgUpload()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">目录:</td>
                                    <td>
                                        <input style="width: 500px; height: 400px;" type="text" name="cotalog" runat="server" id="txtCatalog" value="" />
                                         <%--<span style="color:red"><%=CataMsg %></span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">图书类别:</td>
                                    <td>
                                        <select name="kind" class="input-text lh30" id="txtKind" runat="server">
                                            <option value="1">文学类</option>
                                            <option value="2">科技类</option>
                                            <option value="3">技术类</option>
                                            <option value="4">教科书</option>
                                            <option value="5">动漫</option>
                                            <option value="6">小说</option>
                                            <option value="7">最近新书</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">&nbsp;</td>
                                    <td class="">
                                        <input type="submit" name="btnOk" runat="server" id="btnOk" class="btn btn82 btn_save2" value="保存" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="reset" name="btnClear" runat="server" class="btn btn82 btn_res" value="重置" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

