<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userList.aspx.cs" Inherits="TuShuJieYueYi_Web.Admin.Users.userList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>管理员信息列表</title>
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
 <%-- <a href="userEdit.aspx"></a>--%>
        <div id="button" class="mt10">
            <input type="button" name="button" class="btn btn82 btn_add" value="新增" runat="server" onclick="javascript: window.location = 'userAdd.aspx'" />
          
        </div>
        <div id="table" class="mt10">
            <div class="box span10 oh">
                
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="list_table" style="text-align: center">
                  
                    <asp:Repeater ID="repList" runat="server" OnItemCommand="repList_ItemCommand"><%-- OnItemCommand="repListItemCommand"--%>
                        
                        <HeaderTemplate>

                             <tr class="tr">
                                <th class="td_center">
                                   序号
                                </th>
                                <th>
                                    管理员角色
                                     
                                   
                                </th>
                                <th>
                                    密码
                                    
                                </th>
                                <th>
                                    状态 
                                </th>
                                <th class="td_center">
                                 操作
                                </th>
                            </tr>


                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr class="tr">
                                <td class="td_center">
                              
                                     <%#Eval("Id") %>
                                </td>
                                <td>
                                
                                     <%#Eval("username") %>
                                   
                                </td>
                                <td>
                                      
                                     <%#Eval("password") %>
                                </td>
                                <td>
                                  
                                    <%#Eval("state") %>
                                  
                                </td>
                                <td class="td_center">
                                    <asp:LinkButton runat="server" CommandName="Edit" CommandArgument='<%#Eval("Id") %>'
                                        Text="修改"></asp:LinkButton>
                                    <asp:LinkButton runat="server" CommandName="Del" CommandArgument='<%#Eval("Id") %>'
                                        Text="删除" OnClientClick="return confirm('确认删除吗?')"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div class="page mt10">
                    <div class="pagination">
                        
                     <%--  分页空间，需要进行外部dll文件引用才能够使用--%>
                            <webdiyer:AspNetPager ID="pager" runat="server" OnPageChanged="pager_PageChanged"
                            NumericButtonCount="2" PageSize="2" AlwaysShow="True" ShowBoxThreshold="2" FirstPageText="首页"
                            LastPageText="末页" PrevPageText="上一页" NextPageText="下一页" NumericButtonTextFormatString="{0}"
                            CustomInfoHTML="当前页:%CurrentPageIndex%&nbsp;    总页数:%PageCount%&nbsp; &nbsp;&nbsp;   总记录数:%RecordCount%&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                            CustomInfoTextAlign="Right" ShowCustomInfoSection="Left" BackColor="#C0E8EF" BorderColor="#94DCE4" BorderWidth="1px">
                           </webdiyer:AspNetPager>
                      
                    </div>  
                     
                </div>
            </div>
        </div>
    </form>
</body>
</html>
