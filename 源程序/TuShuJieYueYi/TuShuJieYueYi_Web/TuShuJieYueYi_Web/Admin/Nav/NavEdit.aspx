﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NavEdit.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Nav.NavEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>导航信息修改</title>
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/main.css" />

    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/colResizable-1.3.min.js"></script>
    <script type="text/javascript" src="../js/common.js"></script>
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
                    <b class="pl15">导航菜单信息修改</b>
                </div>
                <div class="box_center">
                    <form id="form1" runat="server" method="post">
                        <div runat="server" style="overflow: scroll; width: 100%; height: 700px;">
                            <table class="form_table pt15 pb15" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">
                                
                                <tr>
                                    <td class="td_right require" style="text-align: right">原名称：</td>
                                    <td class="">
                                        <input type="text" maxlength="10" name="oldname" id="oldname" runat="server" class="input-text lh30 require1" size="40" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right require">新名称：</td>
                                    <td class="">
                                        <input type="text" maxlength="6" name="newname" id="newname" value="" runat="server" class="input-text lh30 require1" size="40" />
                                    </td>
                                </tr>
                                  <tr>
                                    <td class="td_right require">新URL：</td>
                                    <td class="">
                                        <input type="text" maxlength="20" name="newUrl" id="newUrl" value="" runat="server" class="input-text lh30 require1" size="40" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td_right">&nbsp;</td>
                                    <td class="">
                                        <input type="submit" name="btnOk" runat="server"   id="btnOk" class="btn btn82 btn_save2" value="保存" onserverclick="btnOk_ServerClick">    
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

