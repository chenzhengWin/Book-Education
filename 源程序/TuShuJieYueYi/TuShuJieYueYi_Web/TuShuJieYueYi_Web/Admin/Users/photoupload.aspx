<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photoupload.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Users.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.form.js"></script>
    <%-- 图片上传--%>
    <script type="text/javascript">

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
                url: "../Hander/imgUploadHandler.ashx",
                data: { "action": "UploadImage" },
                success: function (data) {
                    if (data.Success) {
                        $("#img1").attr("src", data.ImgUrl);
                    }
                }
            });
            //$("#form1").ajaxSubmit({
            //    type: "post",//提交方式
            //    dataType: "json",//返回结果的格式是json
            //    url:"../Hander/imageUploadHandler.ashx",//提交地址
            //    data: { "action": "UploadImage" },
            //    success:function (data)//请求成功后的回调函数
            //    {
            //        if(data.Sucess)
            //        {
            //            $("#img1").attr("src", data.ImgUrl);
            //        }

            //    }

            //})
        }

        //当光标离开，进行用户名是否重复验证
        function isUserName()
        {
            var name = $("#txtUserName").val();//获取当前页面中id名称为txtUserName的值
            if (name != null)
            {
                //将名称通过post请求
                //参数：1.url(请求的地址) 2.para{}(进行传递的参数) 3.function(data):获取返回得到的结果，判断是否重复
            }
            var url = "../Hander/ajaxTest.ashx";
            var para = {};
            para.action = "isUserName";//传递action用来去一般处理程序中进行验证，例如【验证是添加还是修改或者是查询】
            para.userName = name;//传递信息去一般处理程序中进行用户名是否重复的验证
            $.post(url, para, function (data) {
                //返回结果进行判断
                if (data.Success)
                {
                    alert(data.Message);
                }
                else
                {
                    alert(data.Message);
                }
            }, "json");
        }



    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>用户名：</td> <td><input type="text" name="txtUserName" id="txtUserName" onblur="isUserName()" /></td>
                </tr>
                 <tr>
                    <td>密码：</td> <td><input type=="text" name="txtPwd" id="txtPwd" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="button" name="btn_Ok" value="登录" /></td>
                </tr>


                <tr>
                    <td>
                        <a href="../Hander/imgUploadHandler.ashx">图片</a>
                        <input type="file" id="file_Img" name="file_Img" />
                        <div style="width: 200px; height: 200px">
                            <img style="width: 100px; height: 150px" id="img1" />
                        </div>
                        <input type="button" id="btnUpload" value="上传图片" onclick="btnImgUpload();" />
                    </td>

                </tr>
               
            </table>
        </div>
    </form>


</body>
</html>
