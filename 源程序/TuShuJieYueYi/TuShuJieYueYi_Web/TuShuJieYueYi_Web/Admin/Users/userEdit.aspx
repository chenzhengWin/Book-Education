<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userEdit.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Users.userEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title></title>
    <link rel="stylesheet" href="../css/style.css"/>
    <link rel="stylesheet" href="../css/common.css"/>
    <link rel="stylesheet" href="../css/main.css"/>
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/colResizable-1.3.min.js"></script>
    <script type="text/javascript" src="../js/common.js"></script>

    <script type="text/javascript">
        $(function () {
            $(".require").each(function () {
                $(this).parent().append("<strong class='high'>*</strong>");
            })
            $("form :input").blur(function () {
                $(this).parent().find(".mm").remove();
                //验证用户名是否正确

                if ($(this).is("#txtPassword")) {
                    if (this.value == "" || this.value.length < 6) {
                        var errorMsg = "请输入正确密码,不能小于6位";
                        $(this).parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                    }
                    else {
                        var okMsg = "输入正确！";
                        $(this).parent().append("<span class='mm onSuccess'>" + okMsg + "</span>");
                    }
                }

            }).keyup(function () {
                $(this).triggerHandler("blur");
                if ($(this).is("#txtPwd") || $(this).is("#txtConfirmPwd")){
                if ($("#txtPwd").value != "" && $("#txtPwd").value.length>=6) {
                if ($("#txtConfirmPwd").value == $("#txtPwd").value) {
                    var okMsg = "两次密码一致！！";
                    $("#txtConfirmPwd").parent().append("<span class='mm onSuccess'>" + okMsg + "</span>");
                }
                else {
                    var errorMsg = "两次密码不一致！";
                    $("#txtConfirmPwd").parent().append("<span class='mm onError'>" + errorMsg + "</span>");
                }
                }

            }).focus(function () {
                $(this).triggerHandler("blur");
            });
            $("#btnOk").click(function () {
                $("form .require").trigger("blur");
                var len = $("form .onError").length;
                if (len) return false;
            })
        })
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
    </style>
</head>
<body>
    <div id="forms" class="mt10">
        <div class="box">
            <div class="box_border">
                <div class="box_top">
                    <b class="pl15">修改用户</b>
                </div>
                <div class="box_center">
                    <form id="form1" runat="server">
                        <input type="hidden" id="view" runat="server" name="view" value="-1" />
                        <div runat="server">
                            <table class="form_table pt15 pb15" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">
                               
                                <tr>
                                    <td class="td_right" style="text-align: right">用户名：</td>
                                    <td class="">
                                        <input type="text" name="UserName" id="txtUserName" runat="server" class="input-text lh30" size="40"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">密码：</td>
                                    <td class="">
                                        <input type="text" name="UserNo" id="txtPassword" runat="server" class="input-text lh30 require" size="40"/>
                                    </td>
                                </tr> 
                                <tr>
                                    <td class="td_right">确认密码：</td>
                                    <td class="">
                                        <input type="password" name="txtConfirmPwd" id="txtConfirmPwd" runat="server" class="input-text lh30 require" size="40"/><%--<%=Msg1 %>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">用户状态:</td>
                                    <td>
                                         <input runat="server" type="radio" name="rdoState" id="rdoState1" checked="" value="0" />可用&nbsp;&nbsp;
                                         <input runat="server" type="radio" name="rdoState" id="rdoState2" value="1" />不可用
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">&nbsp;</td>
                                    <td class="">
                                        <input type="button" name="btnOk" runat="server"   id="btnOk" class="btn btn82 btn_save2" value="保存" onserverclick="btnOk_ServerClick"/>
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

