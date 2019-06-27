<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterList.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Enter.EnterList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>图标列表</title>
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/main.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/colResizable-1.3.min.js"></script>
    <script type="text/javascript" src="../js/common.js"></script>
    <script type="text/javascript" src="../js/laydate/laydate.js"></script>
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
</head>
<body>
    <form id="form1" runat="server">
        <div id="button" class="mt10">
            <%--<input type="button" name="button" class="btn btn82 btn_add" value="修改" runat="server" onclick="javascript: window.location.href = 'NavEdit.aspx'" />--%>
            <%--<input type="button" name="button" class="btn btn82 btn_config" value="修改" runat="server" onclick="javascript: window.location.href = 'IndexEdit.aspx'" />--%>
            <%-- <input type="button" name="button" class="btn btn82 btn_search" value="查询">    --%>
        </div>
        <div id="table" class="mt10">
            <div class="box span10 oh">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="list_table" style="text-align: center">
                   <tr>
                        <th width="10%">ID
                        </th>
                        <th width="20%">中文名称
                        </th>
                        <th width="15%">英文名称
                        </th>
                        <th width="30%">内容简介
                        </th>
                        <th width="10%">类别
                        </th>
                        <th width="15%">操作
                        </th>
                    </tr>
                     <asp:Repeater ID="repList" runat="server" OnItemCommand="repList_ItemCommand">
                        <%-- OnItemCommand="repListItemCommand"--%>
                        <ItemTemplate>
                            <tr class="tr">
                                <td class="td_center">

                                    <%#Eval("Id") %>
                                </td>
                                <td>

                                    <%#Eval("Cname") %>
                                </td>
                                <td>
                                    <%#Eval("Ename")%> 
                                </td>
                                <td>
                                    <%#Eval("News") %> 
                                </td>
                                 <td>
                                    <%#Eval("Type") %> 
                                </td>
                                <td class="td_center">
                                    <asp:LinkButton runat="server" CommandName="Edit" CommandArgument='<%#Eval("Id") %>'
                                        Text="修改"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
               <div class="page mt10">
                    <div class="pagination">
                        <%--<ul>
                            <li class="first-child"><a href="#">首页</a></li>
                            <li class="disabled"><span>上一页</span></li>
                            <li class="active"><span>1</span></li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">下一页</a></li>
                            <li class="last-child"><a href="#">末页</a></li>
                        </ul>--%>
                       <%--分页空间，需要进行外部dll文件引用才能够使用
                            <webdiyer:AspNetPager ID="pager" runat="server" OnPageChanged="pager_PageChanged"
                            NumericButtonCount="2" PageSize="2" AlwaysShow="True" ShowBoxThreshold="2" FirstPageText="首页"
                            LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" NumericButtonTextFormatString="{0}"
                            CustomInfoHTML="当前页:%CurrentPageIndex%&nbsp;总页数:%PageCount%&nbsp;总记录数:%RecordCount%&nbsp;&nbsp;&nbsp;&nbsp;"
                            CustomInfoTextAlign="Right" ShowCustomInfoSection="Left">
                        </webdiyer:AspNetPager>--%>
                      
                    </div>  
                     
                </div>
            </div>
        </div>
    </form>
</body>
</html>
