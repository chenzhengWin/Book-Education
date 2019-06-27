<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="userAdd.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Users.userAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/main.css" />
    <script src="../js/jquery-1.8.3.js"></script>
    <script src="../js/jquery.form.js"></script>
  <%--  <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/colResizable-1.3.min.js"></script>
    <script type="text/javascript" src="../js/common.js"></script>--%>
    <%-- <script type="text/javascript" src="../js/kindeditor/kindeditor.js"></script>
    <script type="text/javascript" src="../js/kindeditor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/kindeditor/plugins/code/prettify.js"></script>--%>

    <%-- 图片上传--%>
  <%--  <script type="text/javascript">

        function btnImgUpload() {
            var img = $("#file_Img").val();//获取file控件是否有内容
            //判断选择的图片是否为空
            if ($.trim(img) == "") {
                alert("请你选择图片！！！");
                return;
            }
            $("#form1").ajaxSubmit({
                type: "post",
                dataType: "json",
                url: "../Hander/imageUploadHandler.ashx",
                data: { "action": "UploadImage" },
                success: function (data) {
                    if (data.Success) {
                        $("#img1").attr("src", data.ImgUrl);
                    }
                }
            });
         
        }



    </script>--%>


    <%--  文本编辑器--%>
    <%--  <script type="text/javascript">
        var editor1 = null;
        KindEditor.ready(function (K) {
            editor1 = K.create('#txtContent', {
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
    </script>--%>
    <script type="text/javascript">
        $(function () {
            $(".list_table").colResizable({
                liveDrag: true,
                gripInnerHtml: "<div class='grip'></div>",
                draggingClass: "dragging",
                minWidth: 30
            });
            //$("#fupImage").change(function (e) {
            //    var file, img;
            //    if ((file = this.files[0])) {
            //        img = new Image();
            //        img.onload = function () {
            //            alert(this.width + " " + this.height);
            //        };
            //        img.src = _URL.createObjectURL(file);
            //    }

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
            $(".require").each(function() {
                $(this).append("<strong class='high'>*</strong>");
            })
            var name = "";
            $("form :input").blur(function () {
                $(this).parent().find(".mm").remove();

                //验证用户名是否正确
                if ($(this).is("#txtUserName")) {
                    var value = $.trim(this.value);
                    if (value == "") {
                        var errorMsg = "登录名不能为空.";
                        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                    }
                    else {
                        //ajax提交登录名，验证是否存在
                        var url = "../Handler/UserHandler.ashx";//一般处理程序地址
                        var para = {};//传递所需参数
                        para.action = "validateUser";//用来判断进入一般处理过程的哪个方法
                        para.name = value;//所需传递的参数
                        $.post(url, para, function (data) {
                            if (data.Sucess) {//根据一般处理过程返回的值判断是否成功
                                $("#txtUserName").parent().append("<span class='mm onError'>" + '登录名已存在，请重新输入' + "</span>");
                            } else {
                                var OkMsg = "输入正确!";
                                $(this).parent().append("<span class='mm onSuccess'>" + OkMsg + "</span>");
                            }
                        }, "json");

                    }
                }
                //验证密码是否正确
                if ($(this).is("#txtPassword")) {
                    var value = $.trim(this.value);
                    if (this.value == "" || this.value.length < 6) {
                        var errorMsg = "请输入正确密码,不能小于6位";
                        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                    }
                    else {
                        var okMsg = "输入正确！";
                        $(this).parent().append("<span class='mm onSuccess'>" + okMsg + "</span>");
                    }
                }

                //if ($(this).is("#txtContent")) {
                //    var value = $.trim(this.value);
                //    if (value=="") {
                //        var errorMsg = "内容不能为空。";
                //        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                //    }
                //    else {
                //        var okMsg = "输入正确！";
                //        $(this).parent().append("<span class='mm onSuccess'>" + okMsg + "</span>");
                //    }
                //}             
            }).keyup(function () {
                $(this).triggerHandler("blur");
                //if ($(this).is("#txtPwd") || $(this).is("#txtConfirmPwd")){
                //if ($("#txtPwd").value != "" && $("#txtPwd").value.length>=6) {
                //if ($("#txtConfirmPwd").value == $("#txtPwd").value) {
                //    var okMsg = "两次密码一致！！";
                //    $("#txtConfirmPwd").parent().append("<span class='mm onSuccess'>" + okMsg + "</span>");
                //}
                //else {
                //    var errorMsg = "两次密码不一致！";
                //    $("#txtConfirmPwd").parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                //}
                //}

            }).focus(function () {
                $(this).triggerHandler("blur");
            });
            $("#btnOk").click(function () {

                $("form .require1").trigger("blur");
                var len = $("form .onError").length;
                if (len) return false;
            })
        });
    </script>
    <style type="text/css">
        .onError {
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
    </style>
</head>

<body>
    <div id="forms" class="mt10">
        <div class="box">
            <div class="box_border">
                <div class="box_top">
                    <b class="pl15">添加用户信息</b>
                </div>
                <div class="box_center">
                    <form id="form1" runat="server">
                      
                   
                    <div runat="server" style="overflow: scroll; width: 100%; height: 700px;">
                        <table class="form_table pt15 pb15" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">

                            <tr>
                                <td class="td_right require" style="text-align: right">用户名：</td>
                                <td class="">
                                    <input type="text" maxlength="10" name="UserName" id="txtUserName" runat="server" class="input-text lh30 require1" size="40" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_right require">密码：</td>
                                <td class="">
                                    <input type="password" maxlength="20" name="Password" id="txtPassword" value="" runat="server" class="input-text lh30 require1" size="40" />
                                </td>
                            </tr>


                            <tr>
                                <td class="td_right">&nbsp;</td>
                                <td class="">

                                    <input type="button" id="sub_btn" value="添&nbsp;&nbsp;加" runat="server" onserverclick="sub_btn_ServerClick" />&nbsp;&nbsp;
                                   
                                   
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

